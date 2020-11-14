using System;
using FigureMath.Interfaces;

namespace FigureMath.Abstractions
{
    [Serializable]
    public abstract class Triangle : IFigure
    {
        public abstract double[] AVertex { get; }
        public abstract double[] BVertex { get;}
        public abstract double[] CVertex { get;}
        protected abstract double AbDirect { get;}
        protected abstract double BcDirect { get;}
        protected abstract double CaDirect { get;}
        protected abstract double HalfPerimeter { get; }
        public abstract double GetArea();

        public abstract double GetPerimeter();

        public abstract double[] GetSides();

        public abstract double[] GetHeight();

        public abstract double[] GetMedian();

        public abstract double[] GetBisector();

        public abstract double[] GetAngles();

        public abstract double GetCircumscribedCircleRadius();

        public abstract double GetInscribedCircleRadius();
    }
}
