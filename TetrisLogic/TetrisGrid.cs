using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricksClass;
using FiguresClasses;

namespace TetrisLogic
{
   
    public class TetrisGrid
    {

        public GameInfo Info = new GameInfo();

        public static List<Brick> Update(ref Figures Figure, ref List<Brick> TetrisGridEngine)
        {

            foreach (Brick item in Figure.PreviousState)
                if (item.PosY >= 0)
                {
                    TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsPresent = false;
                    TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsMain = false;
                }

            foreach (Brick item in Figure.FigureType)
                if (item.PosY >= 0)
                {
                    TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsPresent = true;
                    if (item.IsMain == true)

                        TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsMain = true;
                }


            return TetrisGridEngine;


        }
        static public List<Brick> CreateEngineGrid()
        {
            List<Brick> TetrisEngineGrid = new List<Brick>();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    TetrisEngineGrid.Add(new Brick(i, j, false, false));
                }

            }
            return TetrisEngineGrid;
        }

        public static GameInfo ClearRow(ref List<Brick> TetrisGridEngine)

        {
            GameInfo info = new GameInfo();
            List<Brick> NewGrid = new List<Brick>();


            bool[,] BrickArray = new bool[20, 10];
            bool[,] NewBrickArray = new bool[20, 10];

            foreach (Brick item in TetrisGridEngine)
            {
                BrickArray[item.PosY, item.PosX] = item.IsSolid;

            }

            for (int i = 0; i < 20; i++)
            {
                int j;
                for (j = 0; j < 10; j++)
                {
                    if (BrickArray[i, j] == false)
                        break;
                }
                if (j == 10)
                {
                    info.LinesCleared++;


                    for (j = 0; j < 10; j++)
                    {
                        BrickArray[i, j] = false;
                    }

                    for (int k = 1; k < i; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            NewBrickArray[k + 1, l] = BrickArray[k, l];
                        }
                    }
                    for (int k = 1; k < i; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            BrickArray[k, l] = false;
                        }
                    }
                    for (int k = 0; k < 20; k++)
                        for (int l = 0; l < 10; l++)
                            if (NewBrickArray[k, l] == true)
                                BrickArray[k, l] = true;


                }




            }


            foreach (Brick item in TetrisGridEngine)
            {
                item.IsSolid = BrickArray[item.PosY, item.PosX];
                item.IsPresent = BrickArray[item.PosY, item.PosX];
            }
            Console.WriteLine("Brick array is " + BrickArray[19, 1]);
            Console.WriteLine("ConsoleGridEngine is " + TetrisGridEngine.Find(x => x.PosY == 19 && x.PosX == 1).IsPresent);

            return info;
        }

        

    }
}
