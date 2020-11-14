using FigureMath.Exceptions;
using FigureMath.Figures;
using Xunit;

namespace FigureMath.Tests
{
    public class ArbitraryTriangleTests
    {
        #region snippet_Constructor_Passes_InputIsCorrect

        [Fact]
        public void Constructor_Passes_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};

            // Act
            var result = Record.Exception(() => new ArbitraryTriangle(aVertex, bVertex, cVertex));

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
            var bVertex = new double[] {1, 1, 2};
            var cVertex = new double[] {2, 1, 3};

            // Act
            void result()
            {
                new ArbitraryTriangle(aVertex, bVertex, cVertex);
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

            // Act
            void result()
            {
                new ArbitraryTriangle(aVertex, bVertex, cVertex);
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
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetArea();

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
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetCircumscribedCircleRadius();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetHeight_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetHeight_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetHeight();

            // Assert
            Assert.IsType<double[]>(result);
        }

        #endregion

        #region snippet_GetInscribedCircleRadius_ReturnsDouble_InputIsCorrect

        [Fact]
        public void GetInscribedCircleRadius_ReturnsDouble_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetInscribedCircleRadius();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetMedian_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetMedian_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetMedian();

            // Assert
            Assert.IsType<double[]>(result);
        }

        #endregion

        #region snippet_GetPerimeter_ReturnsDouble_InputIsCorrect

        [Fact]
        public void GetPerimeter_ReturnsDouble_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetPerimeter();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetBisector_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetBisector_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetBisector();

            // Assert
            Assert.IsType<double[]>(result);
        }

        #endregion

        #region snippet_GetSides_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetSides_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            var aVertex = new double[] {0, 0};
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetSides();

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
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);

            // Act
            var result = triangle.GetAngles();

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
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);
            var circle = new Circle(1);

            // Act
            var result = triangle.CompareTo(circle);

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
            var bVertex = new double[] {1, 1};
            var cVertex = new double[] {2, 1};
            var triangle = new ArbitraryTriangle(aVertex, bVertex, cVertex);
            Circle circle = null;

            // Act
            void result()
            {
                triangle.CompareTo(circle);
            }

            // Assert
            Assert.Throws<FigureMathException>(result);
        }

        #endregion
    }
}