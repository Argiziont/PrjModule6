using System;
using FigureMath.Abstractions;
using FigureMath.Exceptions;
using FigureMath.Helpers;
using FigureMath.Interfaces;

namespace FigureMath.Figures
{
    [Serializable]
    public sealed class IsoscelesTriangle : Triangle, IComparer
    {
        private const double Tolerance = 0.01;

        /// <summary>
        ///     Creates instance of isosceles triangle
        /// </summary>
        /// <param name="aCords">A vertex coordinates</param>
        /// <param name="bCords">B vertex coordinates</param>
        /// <param name="cCords">C vertex coordinates</param>
        public IsoscelesTriangle(double[] aCords, double[] bCords, double[] cCords)
        {
            if (aCords == null) throw new FigureMathException(nameof(aCords));
            if (bCords == null) throw new FigureMathException(nameof(bCords));
            if (cCords == null) throw new FigureMathException(nameof(cCords));

            if (aCords.Length != 2)
                throw new FigureMathException("A coordinates must have exact 2 coords");
            if (bCords.Length != 2)
                throw new FigureMathException("A coordinates must have exact 2 coords");
            if (cCords.Length != 2)
                throw new FigureMathException("A coordinates must have exact 2 coords");

            AVertex = aCords;
            BVertex = bCords;
            CVertex = cCords;

            if (!(Math.Abs(AbDirect - BcDirect) < Tolerance || Math.Abs(BcDirect - CaDirect) < Tolerance ||
                  Math.Abs(CaDirect - BcDirect) < Tolerance))
                throw new FigureMathException("This is not isosceles triangle");
        }

        public IsoscelesTriangle()
        {
            
        }

        public override double[] AVertex { get; set; }

        public override double[] BVertex { get; set; }

        public override double[] CVertex { get; set; }

        protected override double AbDirect => FigureMathHelper.GetDirectLength(AVertex, BVertex);

        protected override double BcDirect => FigureMathHelper.GetDirectLength(BVertex, CVertex);

        protected override double CaDirect => FigureMathHelper.GetDirectLength(CVertex, AVertex);

        protected override double HalfPerimeter => (AbDirect + BcDirect + CaDirect) / 2;

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
            return Math.Sqrt(HalfPerimeter * (HalfPerimeter - AbDirect) * (HalfPerimeter - BcDirect) *
                             (HalfPerimeter - CaDirect));
        }

        /// <summary>
        /// </summary>
        /// <returns>Radius of a circumscribed circle</returns>
        public override double GetCircumscribedCircleRadius()
        {
            return AbDirect * BcDirect * CaDirect / 4 * GetArea();
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of heights</returns>
        public override double[] GetHeight()
        {
            return new[]
            {
                2 * GetArea() / AbDirect,
                2 * GetArea() / BcDirect,
                2 * GetArea() / CaDirect
            };
        }

        /// <summary>
        /// </summary>
        /// <returns>Radius of a inscribed circle</returns>
        public override double GetInscribedCircleRadius()
        {
            return GetArea() / HalfPerimeter;
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of medians in triangle</returns>
        public override double[] GetMedian()
        {
            return new[]
            {
                Math.Sqrt((2 * Math.Pow(BcDirect, 2) + 2 * Math.Pow(CaDirect, 2) - Math.Pow(AbDirect, 2)) / 2),
                Math.Sqrt((2 * Math.Pow(AbDirect, 2) + 2 * Math.Pow(CaDirect, 2) - Math.Pow(BcDirect, 2)) / 2),
                Math.Sqrt((2 * Math.Pow(AbDirect, 2) + 2 * Math.Pow(BcDirect, 2) - Math.Pow(CaDirect, 2)) / 2)
            };
        }

        /// <summary>
        /// </summary>
        /// <returns>Perimeter of triangle</returns>
        public override double GetPerimeter()
        {
            return AbDirect + BcDirect + CaDirect;
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of lengths of sides of the triangle</returns>
        public override double[] GetSides()
        {
            return new[]
            {
                AbDirect,
                BcDirect,
                CaDirect
            };
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of bisectors</returns>
        public override double[] GetBisector()
        {
            return new[]
            {
                Math.Sqrt(AbDirect * BcDirect * (AbDirect + BcDirect + CaDirect) * (AbDirect + BcDirect - CaDirect)) /
                (AbDirect + BcDirect),
                Math.Sqrt(AbDirect * CaDirect * (AbDirect + BcDirect + CaDirect) * (AbDirect + CaDirect - BcDirect)) /
                (AbDirect + CaDirect),
                Math.Sqrt(BcDirect * CaDirect * (AbDirect + BcDirect + CaDirect) * (BcDirect + CaDirect - AbDirect)) /
                (BcDirect + CaDirect)
            };
        }

        /// <summary>
        /// </summary>
        /// <returns>Array of angles</returns>
        public override double[] GetAngles()
        {
            return new[]
            {
                FigureMathHelper.GetAngleBetweenVertex(AVertex, BVertex, CVertex),
                FigureMathHelper.GetAngleBetweenVertex(BVertex, AVertex, CVertex),
                FigureMathHelper.GetAngleBetweenVertex(AVertex, CVertex, BVertex)
            };
        }
    }
}