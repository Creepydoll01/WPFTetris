using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricksClass;
using FiguresClasses;
using static WPFUI.MoveFigures;
using static WPFUI.TetrisGrid;


namespace WPFUI
{
    public delegate void Moving(ref Figures Figure);
    public class CollisionManager
    {
        
        public static void MakeSolid(Figures Figure, ref List<Brick> TetrisGridEngine)
        {
            foreach (Brick item in Figure.FigureType)
                TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsSolid = true;

        }
        public static bool CheckCollision(Moving Move, ref Figures Figure, ref List<Brick> TetrisGridEngine, GameInfo Info)
        {

            List<Brick> TempState = Figure.PreviousState.Select(o => Brick.Copy(o)).ToList();
            Move(ref Figure);
            bool nonCollide = true;
            foreach (Brick item in Figure.FigureType)


            {


                if (item.PosX > 9 || item.PosX < 0)
                {
                    Figure.FigureType = Figure.PreviousState.Select(o => Brick.Copy(o)).ToList();
                    Figure.PreviousState = TempState.Select(o => Brick.Copy(o)).ToList();

                    break;

                }


                else if (IsSolidBelow(Figure, TetrisGridEngine) || item.PosY == 20)
                {
                    Figure.FigureType = Figure.PreviousState.Select(o => Brick.Copy(o)).ToList();
                    Figure.PreviousState = TempState.Select(o => Brick.Copy(o)).ToList();
                    if (Move == MoveDown)
                    {
                        MakeSolid(Figure, ref TetrisGridEngine);
                        Info.LinesCleared += ClearRow(ref TetrisGridEngine).LinesCleared;
                        Console.WriteLine("In collision ConsoleGridEngine is " + TetrisGridEngine.Find(x => x.PosY == 19 && x.PosX == 1).IsPresent);
                        nonCollide = false;
                        //break;
                        return nonCollide;
                    }
                    else
                    {
                        nonCollide = true;
                        break;
                    }

                }
            }

            Console.WriteLine("Before Update ConsoleGridEngine is " + TetrisGridEngine.Find(x => x.PosY == 19 && x.PosX == 1).IsPresent);
            Update(ref Figure, ref TetrisGridEngine);
            Console.WriteLine("After Update ConsoleGridEngine is " + TetrisGridEngine.Find(x => x.PosY == 19 && x.PosX == 1).IsPresent);
            return nonCollide;
        }
        public static bool IsSolidBelow(Figures Figure, List<Brick> TetrisGridEngine)
        {
            bool IsSolidBelow = false;
            foreach (Brick item in Figure.FigureType)
            {

                
                if (item.PosX >= 0 && item.PosX < 10 && item.PosY > 0 && item.PosY < 20 && TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsSolid == true)
                {
                    if(item.PosY==0)
                    {
                        
                    }
                    IsSolidBelow = true;
                    return IsSolidBelow;
                }
                else IsSolidBelow = false;
            }

            return IsSolidBelow;
        }
        
    }
}
