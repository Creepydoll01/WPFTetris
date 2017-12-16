using System;
using System.Threading;
using System.Collections.Generic;

using FiguresClasses;
using BricksClass;
using static WPFUI.MoveFigures;
using static WPFUI.TetrisGrid;
using static WPFUI.CollisionManager;
using WPFUI;


namespace tetrisconsole
{
    

 




    class Program
    {
        
        static string[,] TetrisGrid = new string[20, 10];
        static int LinesCleared = 0;
        static List<Brick> TetrisEngineGrid= new List<Brick>();
        static string[,] FillConsoleGrid(List<Brick> TetrisGridEngine)
        {
            foreach (Brick item in TetrisGridEngine)
            {
                
                if (item.IsPresent == false)
                {
                    TetrisGrid[item.PosY, item.PosX] = "*";
                }
                else 
                {
                    
                        TetrisGrid[item.PosY, item.PosX] = "■";
                }
                if (item.IsMain == true)
                {
                   // TetrisGrid[item.PosY, item.PosX] = "a";
                }
                if (item.IsSolid == true)
                {
                    //TetrisGrid[item.PosY, item.PosX] = "a";
                }

            }
            return TetrisGrid;
        }

        static void DrawGrid(string[,] TetrisGrid)
        {
            
            for (int i = 0; i<20;i++)
            {
                for (int j = 0; j<10;j++)
                {
                    Console.Write(TetrisGrid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
        
      
        static void Main(string[] args)
        {

            bool collide = true;
            TetrisEngineGrid = CreateEngineGrid();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            GameInfo info = new GameInfo();
         

            while (true)
            {
                collide = true;
                Figures Figure = FigureFactory.Create();
                while (collide)
                {
                    

                    
                    Console.WriteLine(LinesCleared);
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        collide = CheckCollision(MoveDown, ref Figure, ref TetrisEngineGrid, info);

                    }

                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        collide = CheckCollision(MoveLeft, ref Figure, ref TetrisEngineGrid, info);
                        
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        collide = CheckCollision(MoveRight, ref Figure, ref TetrisEngineGrid, info);
                    }
                    else if (key.Key == ConsoleKey.Spacebar)
                    {
                        collide = CheckCollision(MoveRotate, ref Figure, ref TetrisEngineGrid, info);
                    }
                    
                    if (key.Key == ConsoleKey.Escape)
                        collide = false;

                    Console.Clear();
                    Console.WriteLine(TetrisEngineGrid[191].IsPresent);
                    TetrisGrid = FillConsoleGrid(TetrisEngineGrid);
                    DrawGrid(TetrisGrid);
                    Figures newFigure = FigureFactory.Create();
                    
                    Thread.Sleep(50);
                    




                }
                
               
                
            }




            
            
           
        }
    }
}
