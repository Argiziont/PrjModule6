using System;


namespace FigureMath.Exceptions
{
    public class FigureMathException: Exception
    {
        public FigureMathException():this(null) { }
        public FigureMathException(string message) : base(message) { }
    }
}
