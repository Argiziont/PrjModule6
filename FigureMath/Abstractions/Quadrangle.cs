﻿using System;
using FigureMath.Interfaces;

namespace FigureMath.Abstractions
{
    [Serializable]
    public abstract class Quadrangle : IFigure
    {
        public abstract double[] AVertex { get; init; }
        public abstract double[] BVertex { get; init; }
        public abstract double[] CVertex { get; init; }
        public abstract double[] DVertex { get; init; }
        protected abstract double AbDirect { get; }
        protected abstract double BcDirect { get; }
        protected abstract double CdDirect { get; }
        protected abstract double DaDirect { get; }
        protected abstract double HalfPerimeter { get; }

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public abstract double[] GetSides();

        public abstract double[] GetDiagonals();

        public abstract double[] GetAngles();

        public abstract double GetCircumscribedCircleRadius();

        public abstract double GetInscribedCircleRadius();
    }
}