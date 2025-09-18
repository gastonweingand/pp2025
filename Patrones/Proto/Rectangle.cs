using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Proto
{
    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public Rectangle(int width, int height, string color)
        {
            Width = width;
            Height = height;
            Color = color;
        }
        public void Draw()
        {
            Console.WriteLine($"Dibujando un rectángulo {Width}x{Height} y color {Color}");
        }
        public object Clone()
        {
            return new Rectangle(Width, Height, Color);
        }
    }

}
