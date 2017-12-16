using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricksClass;
using static TetrisLogic.TetrisGrid;

namespace TetrisLogic
{
    
   

    class Game
    {
        GameInfo _Info;
        bool NoCollision = true;
        public static  void GameOver()
        {

        }
        public void MakeMove()
        {

        }
        public Game()
        {
            _Info = new GameInfo();
        }

        public void StartGame()
        {
            
            List<Brick> EngineGrid = CreateEngineGrid();
        }
    }
}
