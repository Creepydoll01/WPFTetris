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

        

        public static List<Brick> Update(Figures Figure, ref List<Brick> TetrisGridEngine)
        {

            foreach (Brick item in Figure.PreviousState)
                if (item.PosY >= 0)
                {
                    TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsPresent = false;
                    TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsMain = false;
                }

            foreach (Brick item in Figure.FigureType)
            {
                if (item.IsSolid == true)
                {
                    return TetrisGridEngine;
                }
                if (item.PosY >= 0)
                {
                    TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsPresent = true;
                    if (item.IsMain == true)

                        TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsMain = true;
                }

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
        static private int LinesCleared = 0;

        public static int ClearLine(ref Figures Figure, ref List<Brick> TetrisGridEngine)

        {
            LinesCleared = 0;
            foreach (Brick Item in Figure.FigureType)
            {
                Item.IsPresent = false;
                Item.IsSolid = false;
            }
            foreach (Brick item in Figure.PreviousState)
            {
                item.IsPresent = false;
                item.IsSolid = false;
            }
            
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

                    LinesCleared++;


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
            

            return LinesCleared;
        }

        

    }
}
