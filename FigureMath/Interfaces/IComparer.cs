using System;
using System.Collections.Generic;
using System.Text;

namespace FigureMath.Interfaces
{
    public interface IComparer
    {
        double CompareTo(IFigure figure);
    }
}
