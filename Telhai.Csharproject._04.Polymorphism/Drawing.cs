using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.Csharproject._04.Polymorphism
{
    public class Drawing
    {
        private static int _nextId = 0;
        private int id;

        public Drawing()
        {
            id = _nextId++;

        }

        public virtual double Area()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Drawing - Id: {id}";
        }
    }
}
