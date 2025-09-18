using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Proto
{
    public class Circle : IShape
    {
        public int Radius { get; set; }
        public string Color { get; set; }

        public Circle(int radius, string color)
        {
            Radius = radius;
            Color = color;
        }
        public void Draw()
        {
            Console.WriteLine($"Dibujando un círculo de radio {Radius} y color {Color}");
        }
        public object Clone()
        {
            // Clonación profunda si tuviera referencias complejas
            return new Circle(Radius, Color);
        }
    }
}
