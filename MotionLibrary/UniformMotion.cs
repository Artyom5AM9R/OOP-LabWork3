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
    public class UniformMotion : MotionBase
    {
        /// <summary>
        /// Метод для определения координаты нахождения объекта с записью 
        /// полученного значения в поле _coordinate
        /// </summary>
        public override void CalculateCoordinate()
        {
            Coordinate = Speed * Time;
        }
    }
}
