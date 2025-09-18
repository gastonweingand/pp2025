using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Proto
{
    internal interface IShape : ICloneable
    {
        void Draw();
    }
}
