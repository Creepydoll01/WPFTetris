using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresClasses;
using BricksClass;

namespace TetrisLogic
{
    public class MoveFigures:Figures
    {
        
       static  public  void MoveDown(ref Figures Figure)
        {
            Figure.PreviousState = Figure.FigureType.Select(o => Brick.Copy(o)).ToList();

            foreach (Brick item in Figure.FigureType)
                item.PosY++;

        }
       static public void  MoveLeft(ref Figures Figure)

        {
            Figure.PreviousState = Figure.FigureType.Select(o => Brick.Copy(o)).ToList();
            foreach (Brick item in Figure.FigureType)
            {

                item.PosX--;
            }

            

        }
        static public  void MoveRight(ref Figures Figure)

        {
            Figure.PreviousState = Figure.FigureType.Select(o => Brick.Copy(o)).ToList();
            foreach (Brick item in Figure.FigureType)
            {

                item.PosX++;
            }
           

        }
        static public  void MoveRotate(ref Figures Figure)
        {

            if (Figure is OFigure)
                return;
            Figure.PreviousState = Figure.FigureType.Select(o => Brick.Copy(o)).ToList();
            int RelativeX, RelativeY, CentX, CentY;
            CentX = Figure.FigureType.Find(x => x.IsMain == true).PosX;
            CentY = Figure.FigureType.Find(x => x.IsMain == true).PosY;
            foreach (Brick Item in Figure.FigureType)
            {
                if ((Item.IsMain == false))
                {
                    RelativeX = Item.PosX - CentX;
                    RelativeY = Item.PosY - CentY;
                    Item.PosY = (-RelativeX + CentY);
                    Item.PosX = (RelativeY + CentX);

                }
            }
            



        }

       
    }
    
  
}
