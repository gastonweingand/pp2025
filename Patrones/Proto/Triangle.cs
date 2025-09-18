using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Proto
{
    public class Triangle : IShape
    {
        public int BaseLength { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public Triangle(int baseLength, int height, string color)
        {
            BaseLength = baseLength;
            Height = height;
            Color = color;
        }
        public void Draw()
        {
            Console.WriteLine($"Dibujando un triángulo base {BaseLength}, altura {Height} y color {Color}");
        }
        public object Clone()
        {
            return new Triangle(BaseLength, Height, Color);
        }
    }
}
