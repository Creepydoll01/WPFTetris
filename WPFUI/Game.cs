using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricksClass;
using static WPFUI.TetrisGrid;
using System.Windows.Input;
using System.Windows;
using FiguresClasses;
using static WPFUI.MoveFigures;
using static WPFUI.CollisionManager;

using System.Threading;
using System.Windows.Threading;

namespace WPFUI
{
    
   

    public class Game
    {
        List<Brick> TetrisGrid;
        Figures Figure;
        GameInfo Info;
        bool NoCollision = false;
        DispatcherTimer RefreshTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(0.5)
        };

        public void DropFigure()
        {
            Figure = FigureFactory.Create();
        }
        public void GameOver()
        {

        }
        public void Down()
        {   
                NoCollision = CheckCollision(MoveDown, ref Figure, ref TetrisGrid, Info);
                DrawGrid(TetrisGrid);
            
        }

        public void Left()
        {
            NoCollision = CheckCollision(MoveLeft, ref Figure, ref TetrisGrid, Info);
            DrawGrid(TetrisGrid);
        }
        public void Right ()
        {
            NoCollision = CheckCollision(MoveRight, ref Figure, ref TetrisGrid, Info);
            DrawGrid(TetrisGrid);
        }
        public void Rotate()
        {
            NoCollision = CheckCollision(MoveRotate, ref Figure, ref TetrisGrid, Info);
            DrawGrid(TetrisGrid);
        }
        public void CreateNew()
        {
            DropFigure();
        }

        public Game()
        {
            Info = new GameInfo();
            TetrisGrid = CreateEngineGrid();

        }
        
        public void Play()

        {
            RefreshTimer.Tick += (o, e) =>
            {
                if(!NoCollision)
                {
                    DropFigure();
                    }
            };
            RefreshTimer.IsEnabled = true;

            
            
                
            
                
        }

        static public void DrawGrid(List<Brick> TetrisGrid)
        {
            foreach (Brick item in TetrisGrid)
            {
                if (item.IsPresent == true)
                {
                    UI.RectArray[item.PosY, item.PosX].Fill =UI.BrushPresent;
                }
                else
                    UI.RectArray[item.PosY, item.PosX].Fill = UI.BrushDefault;
            }
        }
        
    }
}
