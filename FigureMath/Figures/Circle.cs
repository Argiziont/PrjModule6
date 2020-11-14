using FigureMath.Interfaces;
using System;
using FigureMath.Exceptions;


namespace FigureMath.Figures
{
    [Serializable]
    public class Circle : IFigure, IComparer
    {
        public double Radius { get; }

        /// <summary>
        /// Creates instance of radius
        /// </summary>
        /// <param name="radius">Your radius</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Area of a figure</returns>
        public double GetArea()
        {
            return Radius * Math.Pow(Math.PI,2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Perimeter of circle</returns>
        public double GetPerimeter()
        {
            return Radius * Math.PI* 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Array of lengths of side of circle</returns>
        public double[] GetSides()
        {
            return new[]
            {
                Radius * Math.PI * 2
            };
        }

        /// <summary>
        /// Compares current figure with given
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
    }
}
