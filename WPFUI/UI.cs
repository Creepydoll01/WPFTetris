using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BricksClass;
using FiguresClasses;



namespace WPFUI
{
    public class UI:MainWindow
    {
        
        static public Rectangle[,] RectArray = new Rectangle[20, 10];
        static public Rectangle[,] NewFigureArray = new Rectangle[5, 5];
        static public SolidColorBrush BrushDefault = new SolidColorBrush
        {
            Color = Colors.Gray
        };
        static public SolidColorBrush BrushPresent = new SolidColorBrush
        {
            Color = Colors.Red
        };
        static public void GenerateGrid(Grid WPFTetrisGrid)
        {
            
            for(int i=0;i<20;i++)
            {
                
                WPFTetrisGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int j = 0; j < 10; j++)
            {
                WPFTetrisGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                    Rectangle Brick = new Rectangle();
                    RectArray[i, j] = Brick;
                    WPFTetrisGrid.Children.Add(Brick);
                    Grid.SetRow(Brick, i);
                    Grid.SetColumn(Brick, j);
                    Brick.Fill = BrushDefault;

                }
            }


        }
        static public void GenerateNextFigureGrid (Grid FigureGrid)
        {
            for(int i = 0; i < 5; i++)
            {
                FigureGrid.RowDefinitions.Add(new RowDefinition());
                FigureGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i<5;i++)
            {
                for(int j = 0; j<5;j++)
                {
                    Rectangle Rect = new Rectangle();
                    NewFigureArray[i, j] = Rect;
                    FigureGrid.Children.Add(Rect);
                    Grid.SetRow(Rect, i);
                    Grid.SetColumn(Rect, j);
                    Rect.Fill = BrushDefault;
                }
            }
        }

        
        static public void DrawGrid(List<Brick> TetrisGrid)
        {
            foreach (Brick item in TetrisGrid)
            {
                if (item.IsPresent == true && !item.IsSolid)
                {
                    RectArray[item.PosY, item.PosX].Fill = BrushPresent;
                }
                else if (!item.IsSolid)
                    RectArray[item.PosY, item.PosX].Fill = BrushDefault;
            }
        }
        static public void DrawNextFigure(Figures Figure)
        {
            int x = 0, y = 0, shiftX = 0, shiftY = 0;
            foreach (Rectangle item in NewFigureArray)
                item.Fill = BrushDefault;

            x = Figure.FigureType.Find(a=> a.IsMain == true).PosX;
            y = Figure.FigureType.Find(a => a.IsMain == true).PosY;
            shiftX = 2 - x;
            shiftY = 2 - y;
            
            foreach (Brick item in Figure.FigureType)
            {
                NewFigureArray[item.PosY + shiftY, item.PosX + shiftX].Fill = BrushPresent;
            }

            
            
        }

        static public void MoveLeft(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                NewGame.Left();
                
            }
        }
       
        static public void MoveRight(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                NewGame.Right();
            }
        }
        static public void Rotate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                NewGame.Rotate();
            }
        }
    }
}
