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
        private double _amplitude;

        private bool _startingPosition;

        private double _cyclicFrequency;

        private double _initialPhase;

        /// <summary>
        /// Амплитуда отклонения объекта от положения равновесия [метр]
        /// </summary>
        public double Amplitude
        {
            get
            {
                return _amplitude;
            }
            set
            {
                if (value > 0)
                {
                    _amplitude = value;
                }
                else
                {
                    throw new Exception("Введено некорректное значение.");
                }
            }
        }

        /// <summary>
        /// Начальное положение объекта: 0 - положение равновесия, 1 - положение 
        /// максимального отклонения
        /// </summary>
        public bool StartingPosition
        {
            get
            {
                return _startingPosition;
            }
            set
            {
                switch (Convert.ToBoolean(value))
                {
                    case false:
                        _startingPosition = value;
                        break;
                    case true:
                        _startingPosition = value;
                        break;
                    default:
                        throw new Exception("Введено некорректное значение.");
                }
            }
        }

        /// <summary>
        /// Циклическая частота колебаний [рад/сек]
        /// </summary>
        public double CyclicFrequency
        {
            get
            {
                return _cyclicFrequency;
            }
            set
            {
                if (value > 0)
                {
                    _cyclicFrequency = value;
                }
            }
        }

        /// <summary>
        /// Начальная фаза колебаний [град]
        /// </summary>
        public double InitialPhase
        {
            get
            {
                return _initialPhase;
            }
            set
            {
                if (Math.Abs(value) < 180)
                {
                    _initialPhase = value / Math.PI;
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
        /// <returns>Значение типа double</returns>
        public double ConvertToRadian(double phaseInDegrees)
        {
            double phaseInRadian = phaseInDegrees / (2 * Math.PI);

            return phaseInRadian;
        }

        /// <summary>
        /// Метод для расчета циклической частоты колебаний
        /// </summary>
        /// <param name="period">Период колебаний [c]</param>
        /// <returns></returns>
        public double CalculateFrequency (double period)
        {
            if (period > 0)
            {
                double frequency = (2 * Math.PI / period);

                return frequency;
            }
            else
            {
                throw new Exception("\nВведено некорректное значение.\n");
            }
            
        }

        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа float</returns>
        public override double CalculateCoordinate()
        {
            switch (Convert.ToInt16(StartingPosition))
            {
                case 0:
                    Coordinate = Amplitude * Math.Sin(CyclicFrequency * Time + InitialPhase);
                    break;
                case 1:
                    Coordinate = Amplitude * Math.Cos(CyclicFrequency * Time + InitialPhase);
                    break;
            }

            return Coordinate;
        }
    }
}
