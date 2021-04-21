using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    /// <summary>
    /// Класс для описания колебательного движения объектов
    /// </summary>
    public class OscillatoryMotion : Motion
    {
        /// <summary>
        /// Амплитуда отклонения объекта от положения равновесия [метр]
        /// </summary>
        public float Amplitude
        {
            get
            {
                return Amplitude;
            }
            set
            {
                if (value > 0)
                {
                    Amplitude = value;
                }
                else
                {
                    throw new Exception("\nВведено некорректное значение.\n");
                }
            }
        }

        /// <summary>
        /// Начальное положение объекта: 0 - положение равновесия, 1 - положение 
        /// максимального отклонения
        /// </summary>
        public byte StartingPosition
        {
            get
            {
                return StartingPosition;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        StartingPosition = value;
                        break;
                    case 1:
                        StartingPosition = value;
                        break;
                    default:
                        throw new Exception("\nВведено некорректное значение.\n");
                }
            }
        }

        /// <summary>
        /// Циклическая частота колебаний [рад/сек]
        /// </summary>
        public float CyclicFrequency
        {
            get
            {
                return CyclicFrequency;
            }
            set
            {
                if (value > 0)
                {
                    CyclicFrequency = value;
                }
            }
        }

        /// <summary>
        /// Начальная фаза колебаний [рад]
        /// </summary>
        public float InitialPhase
        {
            get
            {
                return InitialPhase;
            }
            set
            {
                if (Math.Abs(value) <= (360 / 2 * Math.PI))
                {
                    InitialPhase = value;
                }
                else
                {
                    throw new Exception("\nВведено некорректное значение.\n");
                }
            }
        }

        /// <summary>
        /// Метод для перевода начальной фазы колебаний из градусов в радианы
        /// </summary>
        /// <returns>Значение типа float</returns>
        public float ConvertToRadian(float phaseInDegrees)
        {
            float phaseInRadian = (float)(phaseInDegrees / (2 * Math.PI));

            return phaseInRadian;
        }

        /// <summary>
        /// Метод для расчета циклической частоты колебаний
        /// </summary>
        /// <param name="period">Период колебаний [c]</param>
        /// <returns></returns>
        public float CalculateFrequency (float period)
        {
            float frequency = (float)(2 * Math.PI / period);

            return frequency;
        }

        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа float</returns>
        public override float CalculateCoordinate()
        {
            switch (StartingPosition)
            {
                case 0:
                    Coordinate = Amplitude * (float)(Math.Sin(CyclicFrequency * Time + InitialPhase));
                    break;
            }

            return Coordinate;
        }
    }
}
