﻿using FigureMath.Exceptions;
using FigureMath.Figures;
using Xunit;

namespace FigureMath.Tests
{
    public class RectangleTests
    {
        #region snippet_Constructor_Passes_InputIsCorrect

        [Fact]
        public void Constructor_Passes_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};

            // Act
            var result = Record.Exception(() => new Rectangle(aVertex, bVertex, cVertex, dVertex));

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region snippet_Constructor_ThrowsFigureMathException_InputIsInCorrect

        [Fact]
        public void Constructor_ThrowsFigureMathException_InputIsInCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0, 1};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};

            // Act
            void result()
            {
                new Rectangle(aVertex, bVertex, cVertex, dVertex);
            }

            // Assert
            Assert.Throws<FigureMathException>(result);
        }

        #endregion

        #region snippet_Constructor_ThrowsFigureMathException_InputIsInCorrect

        [Fact]
        public void Constructor_ThrowsFigureMathException_InputIsnull()
        {
            // Arrange
            double[] aVertex = null;
            double[] bVertex = null;
            double[] cVertex = null;
            double[] dVertex = null;

            // Act
            void result()
            {
                new Rectangle(aVertex, bVertex, cVertex, dVertex);
            }

            // Assert
            Assert.Throws<FigureMathException>(result);
        }

        #endregion

        #region snippet_GetArea_ReturnsDouble_InputIsCorrect

        [Fact]
        public void GetArea_ReturnsDouble_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);

            // Act
            var result = quadrangle.GetArea();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetCircumscribedCircleRadius_ReturnsDouble_InputIsCorrect

        [Fact]
        public void GetCircumscribedCircleRadius_ReturnsDouble_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);

            // Act
            var result = quadrangle.GetCircumscribedCircleRadius();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetDiagonals_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetDiagonals_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);

            // Act
            var result = quadrangle.GetDiagonals();

            // Assert
            Assert.IsType<double[]>(result);
        }

        #endregion

        #region snippet_GetInscribedCircleRadius_ReturnsDouble_InputIsCorrectButInscribeImpossible

        [Fact]
        public void GetInscribedCircleRadius_ReturnsDouble_InputIsCorrectButInscribeImpossible()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);

            // Act
            void result()
            {
                quadrangle.GetInscribedCircleRadius();
            }

            // Assert
            Assert.Throws<FigureMathException>(result);
        }

        #endregion

        #region snippet_GetPerimeter_ReturnsDouble_InputIsCorrect

        [Fact]
        public void GetPerimeter_ReturnsDouble_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);

            // Act
            var result = quadrangle.GetPerimeter();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetSides_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetSides_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);

            // Act
            var result = quadrangle.GetSides();

            // Assert
            Assert.IsType<double[]>(result);
        }

        #endregion

        #region snippet_GetAngles_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetAngles_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);

            // Act
            var result = quadrangle.GetAngles();

            // Assert
            Assert.IsType<double[]>(result);
        }

        #endregion

        #region snippet_CompareTo_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void CompareTo_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);
            var circle = new Circle(1);

            // Act
            var result = quadrangle.CompareTo(circle);

            // Asserts
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_CompareTo_ThrowsFigureMathException_InputIsInCorrect

        [Fact]
        public void CompareTo_ThrowsFigureMathException_InputIsInCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 0};
            var cVertex = new double[] {1, 1};
            var dVertex = new double[] {0, 1};
            var quadrangle = new Rectangle(aVertex, bVertex, cVertex, dVertex);
            Circle circle = null;

            // Act
            void result()
            {
                quadrangle.CompareTo(circle);
            }

            // Assert
            Assert.Throws<FigureMathException>(result);
        }

        #endregion
    }
}