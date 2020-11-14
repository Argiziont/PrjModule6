using System;

namespace FigureMath.Helpers
{
    public static class FigureMathHelper
    {
        public static double GetDirectLength(double[] firstVertex, double[] secondVertex)
        {
            return Math.Sqrt(Math.Pow(secondVertex[0] - firstVertex[0], 2) +
                             Math.Pow(secondVertex[1] - firstVertex[1], 2));
        }

        public static double GetRadiansToDegrees(double radians)
        {
            return 180 / Math.PI * radians;
        }

        public static double GetDegreesToRadians(double degrees)
        {
            return degrees / (180 / Math.PI);
        }

        /// <summary>
        ///     Returns angle between vertexes
        /// </summary>
        /// <param name="firstVertex">First Vertex</param>
        /// <param name="secondVertex">Second Vertex</param>
        /// <param name="thirdVertex">Third Vertex</param>
        /// <returns>Return angle near second Vertex</returns>
        public static double GetAngleBetweenVertex(double[] firstVertex, double[] secondVertex, double[] thirdVertex)
        {
            var aLength = GetDirectLength(thirdVertex, secondVertex);

            var bLength = GetDirectLength(firstVertex, thirdVertex);

            var cLength = GetDirectLength(firstVertex, secondVertex);

            return GetRadiansToDegrees(Math.Acos(
                (Math.Pow(aLength, 2) + Math.Pow(cLength, 2) - Math.Pow(bLength, 2)) / (2 * aLength * cLength)));
        }

        public static bool GetParallelism(double[] firstVertexFirstLine, double[] secondVertexFirstLine,
            double[] firstVertexSecondLine, double[] secondVertexSecondLine)
        {
            const double tolerance = 0.01;
            var firstSlope = (firstVertexFirstLine[1] - secondVertexFirstLine[1]) /
                             (firstVertexFirstLine[0] - secondVertexFirstLine[0]);
            var secondSlope = (firstVertexSecondLine[1] - secondVertexSecondLine[1]) /
                              (firstVertexSecondLine[0] - secondVertexSecondLine[0]);
            return Math.Abs(firstSlope - secondSlope) < tolerance;
        }
    }
}