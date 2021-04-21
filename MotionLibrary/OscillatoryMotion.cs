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
    public class OscillatoryMotion : MotionBase
    {
        /// <summary>
        /// Амплитуда колебаний
        /// </summary>
        private double _amplitude;

        /// <summary>
        /// Начальное положение тела
        /// </summary>
        private byte _startingPosition;

        /// <summary>
        /// Циклическая частота колебаний
        /// </summary>
        private double _cyclicFrequency;

        /// <summary>
        /// Начальная фаза колебаний
        /// </summary>
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
        public byte StartingPosition
        {
            get
            {
                return _startingPosition;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        _startingPosition = value;
                        break;
                    case 1:
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
                else
                {
                    throw new Exception("Введено некорректное значение.");
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
                    _initialPhase = value * Math.PI / 180;
                }
                else
                {
                    throw new Exception("Введено некорректное значение.");
                }
            }
        }

        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа double, округленное до 2 знаков после запятой</returns>
        public override double CalculateCoordinate()
        {
            switch (StartingPosition)
            {
                case 0:
                    Coordinate = (Amplitude * Math.Sin(CyclicFrequency * Time + InitialPhase));
                    break;
                case 1:
                    Coordinate = Amplitude * Math.Cos(CyclicFrequency * Time + InitialPhase);
                    break;
            }

            return Coordinate;
        }
    }
}
