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



namespace WPFUI
{
    public class UI:MainWindow
    {
        static public Rectangle[,] RectArray = new Rectangle[20, 10];
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
      

        static public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                NewGame.Down();
            }
        }

        static public void MoveLeft(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                NewGame.Left();
                
            }
        }
        static public void CreateNew(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                NewGame.DropFigure();

            }
        }
        static public void MoveRight(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
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
