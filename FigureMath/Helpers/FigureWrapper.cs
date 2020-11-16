using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMath.Helpers
{
    public sealed record FigureWrapper<T>
    {
        public string TypeOf => typeof(T).Name;
        public T WrapContent { get; init; }
    }
}
