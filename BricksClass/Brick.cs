using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BricksClass
{
    public class Brick
    {
        static public Brick Copy(Brick Brick)
        {
            return new Brick(Brick.PosY, Brick.PosX, Brick.IsMain, Brick.IsPresent);
        }
        public bool IsSolid;
        public int PosX;
        public int PosY;
        public bool IsMain;
        public bool IsPresent;
        public Brick(int posy, int posx, bool ismain, bool ispresent)
        {
            PosX = posx;
            PosY = posy;
            IsMain = ismain;
            IsPresent = ispresent;
        }

    }
}
