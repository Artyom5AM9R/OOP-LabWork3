using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    /// <summary>
    /// Класс для описания равномерного движения объектов
    /// </summary>
    public class UniformMotion : Motion
    {
        public override float CoordinateCalculation()
        {
            Coordinate = Speed * Time;

            return Coordinate;
        }
    }
}
