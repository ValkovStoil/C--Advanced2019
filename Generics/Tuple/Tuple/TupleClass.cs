using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class TupleClass<T, T1>
    {
        public T Item1 { get; set; }

        public T1 Item2 { get; set; }

        public TupleClass(T item1, T1 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
