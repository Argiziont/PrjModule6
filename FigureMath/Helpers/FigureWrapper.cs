using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMath.Helpers
{
    public class FigureWrapper<T>
    {
        public string TypeOf => typeof(T).Name;
        public T WrapContent { get; set; }
    }
    public class DeFigureWrapper
    {
        public string TypeOf { get; set; }
        public object WrapContent { get; set; }
    }
}
