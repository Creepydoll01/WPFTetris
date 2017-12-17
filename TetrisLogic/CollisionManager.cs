using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricksClass;
using FiguresClasses;
using static TetrisLogic.MoveFigures;
using static TetrisLogic.TetrisGrid;


namespace TetrisLogic
{
    public delegate void Moving(ref Figures Figure);
    public class CollisionManager
    {
        
        public static void MakeSolid( ref Figures Figure, ref List<Brick> TetrisGridEngine)
        {
            foreach (Brick item in Figure.FigureType)
            {
                if (item.PosY >= 0)
                {
                    item.IsSolid = true;
                    TetrisGridEngine.Find(x => x.PosY >= 0 && x.PosY == item.PosY && x.PosX == item.PosX).IsSolid = true;
                }
                else return;
            }

        }
        public static bool CheckCollision(Moving Move, ref Figures Figure, ref List<Brick> TetrisGridEngine, GameInfo Info)
        {
            
            List<Brick> TempState = Figure.PreviousState.Select(o => Brick.Copy(o)).ToList();
            foreach(Brick item in Figure.FigureType)
            {
                if (item.IsSolid == true)
                {
                    return false;
                }
            }
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
                        MakeSolid(ref Figure, ref TetrisGridEngine);
                        Info.LinesCleared += ClearLine(ref Figure, ref TetrisGridEngine);
                        
                        nonCollide = false;
                        
                        
                        return nonCollide;
                    }
                    else
                    {
                        nonCollide = true;
                        break;
                    }

                }
            }
            
            
            Update(Figure, ref TetrisGridEngine);
            
            return nonCollide;
        }
        public static bool IsSolidBelow(Figures Figure, List<Brick> TetrisGridEngine)
        {
            bool IsSolidBelow = false;
            foreach (Brick item in Figure.FigureType)
            {

                
                if (item.PosX >= 0 && item.PosX < 10 && item.PosY > 0 && item.PosY < 20 && TetrisGridEngine.Find(x => x.PosY == item.PosY && x.PosX == item.PosX).IsSolid == true)
                {
                    IsSolidBelow = true;
                    return IsSolidBelow;

                }
                else IsSolidBelow = false;
            }

            return IsSolidBelow;
        }
        
    }
}
