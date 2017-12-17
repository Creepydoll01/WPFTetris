using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricksClass;
using static TetrisLogic.TetrisGrid;
using System.Windows.Input;
using System.Windows;
using FiguresClasses;
using static TetrisLogic.MoveFigures;
using static TetrisLogic.CollisionManager;
using TetrisLogic;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFUI
{



    public class Game
    {
        public List<Brick> TetrisGrid;
        public Figures Figure;
        public Figures NextFigure;
        Random rng = new Random();
        private List<Color> ListOfColors = new List<Color>() { Colors.Yellow, Colors.Green, Colors.LightBlue, Colors.Black, Colors.Red, Colors.Orange};
        GameInfo Info;
        static private double RefreshInterval;
        bool NoCollision;
        DispatcherTimer RefreshTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(RefreshInterval)
        };
        public Game()
        {
            Info = new GameInfo();
            TetrisGrid = CreateEngineGrid();
            Figure = new Figures();
            NextFigure = new Figures();
            NoCollision = false;
            RefreshInterval = 0.5;


        }
        private void Makemove(object sender, EventArgs e)
        {
           
            if (!NoCollision)
            {
                DropFigure();
                    }
            foreach (Brick item in TetrisGrid)
            {
                if (TetrisGrid.Find(x => x.PosY == 0 && x.IsSolid == true) != null)
                {
                    RefreshTimer.IsEnabled = false;
                    MessageBox.Show("Game over");
                    return;
                }
            }
            Down();
            

        }
        
        

        public void DropFigure()
        {

                Figure = NextFigure;
                
                UI.BrushPresent = new SolidColorBrush
                {
                    Color = ListOfColors[rng.Next(0,5)]
                };
                

                if (RefreshInterval > 0.1)
                {
                    RefreshInterval -= 0.01;
                    RefreshTimer.Interval = TimeSpan.FromSeconds(RefreshInterval);
                }

            NextFigure = FigureFactory.Create();
            UI.DrawNextFigure(NextFigure);
            
            
        }
        
        public void Down()
        {   
            NoCollision = CheckCollision(MoveDown, ref Figure, ref TetrisGrid, Info);
            
            UI.DrawGrid(TetrisGrid);
            


        }

        public void Left()
        {
            NoCollision = CheckCollision(MoveLeft, ref Figure, ref TetrisGrid, Info);
            UI.DrawGrid(TetrisGrid);

        }
        public void Right ()
        {
            NoCollision = CheckCollision(MoveRight, ref Figure, ref TetrisGrid, Info);
            UI.DrawGrid(TetrisGrid);

        }
        public void Rotate()
        {
            NoCollision = CheckCollision(MoveRotate, ref Figure, ref TetrisGrid, Info);
            UI.DrawGrid(TetrisGrid);

        }
       

        
        
        
        
        public void Play(Label ScoreLabel)

        {
            Figure = FigureFactory.Create();
            NextFigure = FigureFactory.Create();
            RefreshTimer.Tick += Makemove;
            RefreshTimer.Tick += (o, e) =>
            {
                ScoreLabel.Content = Info.LinesCleared;

                
            };
            RefreshTimer.IsEnabled = true;
            

            
            
                
            
                
        }

        
        
    }
}
