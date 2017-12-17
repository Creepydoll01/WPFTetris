using System.Collections.Generic;
using BricksClass;
using System;

namespace FiguresClasses
{
    public class Figures
    {
        
        private List<Brick> _PreviousState;

        public List<Brick> PreviousState
        {
            get { return _PreviousState; }
            set { _PreviousState = value; }
        }


        private List<Brick> _FigureType;
        public List<Brick> FigureType
        {
            get { return _FigureType; }
            set { _FigureType = value; }
        }
       


    }

     class LongFigure : Figures
    {
        public LongFigure()
        {
            FigureType = new List<Brick>() { new Brick(-1, 4, false, true), new Brick(-2, 4, true, true), new Brick(-3, 4, false, true), new Brick(-4, 4, false, true) };
        }

    }
    public class OFigure : Figures
    {
        public OFigure()
        {
            FigureType = new List<Brick>() { new Brick(-1, 3, true, true), new Brick(-1, 4, false, true), new Brick(-2, 3, false, true), new Brick(-2, 4, false, true) };
        }
    }
    class SFigure : Figures
    {
        public SFigure()
        {
            FigureType = new List<Brick>() { new Brick(-1, 3, true, true), new Brick(-1, 4, false, true), new Brick(-2, 4, false, true), new Brick(-2, 5, false, true) };
        }
    }
    class ZFigure : Figures
    {
        public ZFigure()
        {
            FigureType = new List<Brick>() { new Brick(-2, 3, false, true), new Brick(-2, 4, false, true), new Brick(-1, 4, true, true), new Brick(-1, 5, false, true) };
        }
    }
    class LFigure : Figures
    {
        public LFigure()
        {
            FigureType = new List<Brick>() { new Brick(-1, 4, true, true), new Brick(-1, 5, false, true), new Brick(-2, 4, false, true), new Brick(-3, 4, false, true) };
        }
    }
    class LrFigure : Figures
    {
        public LrFigure()
        {
            FigureType = new List<Brick>() { new Brick(-1, 4, true, true), new Brick(-1, 5, false, true), new Brick(-2, 5, false, true), new Brick(-3, 5, false, true) };
        }
    }
    class Tfigure : Figures
    {
        public Tfigure()
        {
            FigureType = new List<Brick>() { new Brick(-1, 4, false, true), new Brick(-1, 5, true, true), new Brick(-1, 6, false, true), new Brick(-2, 5, false, true) };
        }
    }


    public class FigureFactory:Figures
    {
        static List<Figures> FiguresList = new List<Figures>();
        static Random rng = new Random();
        public static void FillList()
        {
            FiguresList.Add(new LongFigure());
            FiguresList.Add(new OFigure());
            FiguresList.Add(new SFigure());
            FiguresList.Add(new ZFigure());
            FiguresList.Add(new LFigure());
            FiguresList.Add(new Tfigure());
        }
        static public Figures Create()
        {
            FillList();
            int i = rng.Next(1, FiguresList.Count - 1);
            
           
            FiguresList[i].PreviousState = FiguresList[i].FigureType;
            return FiguresList[i];
        }

    }
}
