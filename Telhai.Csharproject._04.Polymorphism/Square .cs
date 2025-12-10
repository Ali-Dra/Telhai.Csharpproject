using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.Csharproject._04.Polymorphism
{
    public class Square : Drawing
    {
        public double Length { get; set; }

        public Square()
        {
            Length = 6;
        }

        public override double Area()
        {
            return Math.Pow(Length, 2);
        }

        public override string ToString()
        {
            return $"Square: {base.ToString()}, Length: {Length}, Area: {Area()}";
        }
    }
}
