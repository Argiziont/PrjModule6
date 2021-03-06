﻿using System;
using FigureMath.Abstractions;
using FigureMath.Exceptions;
using FigureMath.Helpers;
using FigureMath.Interfaces;

namespace FigureMath.Figures
{
    [Serializable]
    public sealed class Rhombus : Quadrangle, IComparer
    {
        private const double Tolerance = 0.01;

        /// <summary>
        ///     Creates instance of rhombus
        /// </summary>
        /// <param name="aCords">A vertex coordinates</param>
        /// <param name="bCords">B vertex coordinates</param>
        /// <param name="cCords">C vertex coordinates</param>
        /// <param name="dCords">D vertex coordinates</param>
        public Rhombus(double[] aCords, double[] bCords, double[] cCords, double[] dCords)
        {
            if (aCords == null) throw new FigureMathException(nameof(aCords));
            if (bCords == null) throw new FigureMathException(nameof(bCords));
            if (cCords == null) throw new FigureMathException(nameof(cCords));
            if (dCords == null) throw new FigureMathException(nameof(cCords));

            if (aCords.Length != 2)
                throw new FigureMathException("A coordinates must have exact 2 coords");
            if (bCords.Length != 2)
                throw new FigureMathException("A coordinates must have exact 2 coords");
            if (cCords.Length != 2)
                throw new FigureMathException("A coordinates must have exact 2 coords");
            if (dCords.Length != 2)
                throw new FigureMathException("D coordinates must have exact 2 coords");

            AVertex = aCords;
            BVertex = bCords;
            CVertex = cCords;
            DVertex = dCords;

            if (!(Math.Abs(AbDirect - BcDirect) < Tolerance && Math.Abs(AbDirect - CdDirect) < Tolerance &&
                  Math.Abs(AbDirect - DaDirect) < Tolerance))
                throw new FigureMathException("This is not rhombus");
        }

        public Rhombus()
        {
            
        }

        public override double[] AVertex { get; init; }
        public override double[] BVertex { get; init; }
        public override double[] CVertex { get; init; }
        public override double[] DVertex { get; init; }
        protected override double AbDirect => FigureMathHelper.GetDirectLength(AVertex, BVertex);

        protected override double BcDirect => FigureMathHelper.GetDirectLength(BVertex, CVertex);

        protected override double CdDirect => FigureMathHelper.GetDirectLength(CVertex, DVertex);

        protected override double DaDirect => FigureMathHelper.GetDirectLength(DVertex, AVertex);

        protected override double HalfPerimeter => (AbDirect + BcDirect + CdDirect + DaDirect) / 2;

        /// <summary>
        ///     Compares current figure with given
        /// </summary>
        /// <param name="figure">Your figure to compare</param>
        /// <returns>"0" if figures is equal "-1" if this figure area is less and "1" if this area is greater</returns>
        public double CompareTo(IFigure figure)
        {
            if (figure == null) throw new FigureMathException(nameof(figure));

            if (GetArea() < figure.GetArea())
                return -1;
            return GetArea() > figure.GetArea() ? 1 : 0;
        }

        /// <summary>
        /// </summary>
        /// <returns>Area of a figure</returns>
        public override double GetArea()
        {
            return Math.Sqrt((HalfPerimeter - AbDirect) * (HalfPerimeter - BcDirect) * (HalfPerimeter - CdDirect) *
                             (HalfPerimeter - DaDirect) -
                             AbDirect * BcDirect * CdDirect * DaDirect * Math.Pow(
                                 Math.Cos((FigureMathHelper.GetDegreesToRadians(GetAngles()[0]) +
                                           FigureMathHelper.GetDegreesToRadians(GetAngles()[2])) / 2), 2));
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of angles</returns>
        public override double[] GetAngles()
        {
            return new[]
            {
                FigureMathHelper.GetAngleBetweenVertex(BVertex, AVertex, DVertex),
                FigureMathHelper.GetAngleBetweenVertex(AVertex, BVertex, CVertex),
                FigureMathHelper.GetAngleBetweenVertex(BVertex, CVertex, DVertex),
                FigureMathHelper.GetAngleBetweenVertex(AVertex, DVertex, CVertex)
            };
        }

        /// <summary>
        /// </summary>
        /// <returns>Radius of a inscribed circle</returns>
        public override double GetCircumscribedCircleRadius()
        {
            throw new FigureMathException("Couldn't circumscribe circle");
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of diagonals</returns>
        public override double[] GetDiagonals()
        {
            return new[]
            {
                FigureMathHelper.GetDirectLength(AVertex, CVertex),
                FigureMathHelper.GetDirectLength(BVertex, DVertex)
            };
        }

        /// <summary>
        /// </summary>
        /// <returns>Radius of a circumscribed circle</returns>
        public override double GetInscribedCircleRadius()
        {
            return GetArea() / HalfPerimeter;
        }

        /// <summary>
        /// </summary>
        /// <returns>Perimeter of quadrangle</returns>
        public override double GetPerimeter()
        {
            return AbDirect + BcDirect + CdDirect + DaDirect;
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of lengths of sides of the quadrangle</returns>
        public override double[] GetSides()
        {
            return new[]
            {
                AbDirect,
                BcDirect,
                CdDirect,
                DaDirect
            };
        }
    }
}