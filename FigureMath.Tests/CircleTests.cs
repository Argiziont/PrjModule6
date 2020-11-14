using FigureMath.Exceptions;
using FigureMath.Figures;
using Xunit;

namespace FigureMath.Tests
{
    public class CircleTests
    {
        #region snippet_Constructor_Passes_InputIsCorrect

        [Fact]
        public void Constructor_Passes_InputIsCorrect()
        {
            // Arrange
            double radius = 10;

            // Act
            var result = Record.Exception(() => new Circle(radius));

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region snippet_GetArea_ReturnsDouble_InputIsCorrect

        [Fact]
        public void GetArea_ReturnsDouble_InputIsCorrect()
        {
            // Arrange
            double radius = 10;
            var circle = new Circle(radius);

            // Act
            var result = circle.GetArea();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetPerimeter_ReturnsDouble_InputIsCorrect

        [Fact]
        public void GetPerimeter_ReturnsDouble_InputIsCorrect()
        {
            // Arrange
            double radius = 10;
            var circle = new Circle(radius);

            // Act
            var result = circle.GetPerimeter();

            // Assert
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_GetSides_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void GetSides_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            double radius = 10;
            var circle = new Circle(radius);

            // Act
            var result = circle.GetSides();

            // Assert
            Assert.IsType<double[]>(result);
        }

        #endregion

        #region snippet_CompareTo_ReturnsDoubleArray_InputIsCorrect

        [Fact]
        public void CompareTo_ReturnsDoubleArray_InputIsCorrect()
        {
            // Arrange
            double radius = 10;
            var circleMain = new Circle(radius);
            var circle = new Circle(1);

            // Act
            var result = circleMain.CompareTo(circle);

            // Asserts
            Assert.IsType<double>(result);
        }

        #endregion

        #region snippet_CompareTo_ThrowsFigureMathException_InputIsInCorrect

        [Fact]
        public void CompareTo_ThrowsFigureMathException_InputIsInCorrect()
        {
            // Arrange
            double radius = 10;
            var circleMain = new Circle(radius);
            Circle circle = null;

            // Act
            void result()
            {
                circleMain.CompareTo(circle);
            }

            // Assert
            Assert.Throws<FigureMathException>(result);
        }

        #endregion
    }
}