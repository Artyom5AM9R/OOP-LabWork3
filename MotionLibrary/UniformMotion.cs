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
        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа float</returns>
        public override double CalculateCoordinate()
        {
            Coordinate = Speed * Time;

            return Coordinate;
        }
    }
}
