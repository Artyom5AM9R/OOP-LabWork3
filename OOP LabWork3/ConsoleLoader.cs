using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionLibrary;

namespace OOP_LabWork3
{
    /// <summary>
    /// Класс для реализации функционала библиотеки MotionLibrary
    /// </summary>
    public class ConsoleLoader
    {
        /// <summary>
        /// Метод для вывода на экран цветного текста
        /// </summary>
        /// <param name="text">Тескт для вывода на экран</param>
        /// <param name="color">Цвет текста</param>
        public static void ColorTextInConsole (string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод для повтора действий по считыванию значения из консоли до момента получения
        /// корректного значения
        /// </summary>
        /// <param name="outputLine">Строка для вывода в консоль</param>
        /// <param name="onRead">Действие, которое необходимо сделать</param>
        public static void SafeReadFromConsole(string outputLine, Action<string> onRead)
        {
            while (true)
            {
                try
                {
                    Console.Write(outputLine);
                    onRead(Console.ReadLine().Replace(".", ","));
                    return;
                }
                catch (Exception exception)
                {
                    ColorTextInConsole($"\n{exception.Message} Повторите ввод.\n\n",
                        ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        public static void Main()
        {
            while (true)
            {
                try
                {
                    ColorTextInConsole("Виды мехнического движения:\n" +
                                       "1 - равномерное;\n" +
                                       "2 - равноускоренное;\n" +
                                       "3 - колебательное.\n", ConsoleColor.Green);
                    ColorTextInConsole("\nВыберите тип движения для расчета координаты тела: ",
                        ConsoleColor.Green);
                    byte type = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine();

                    if (type <= 0 || type > 3)
                    {
                        throw new Exception("Введено некорректное значение.");
                    }

                    MotionBase tmpMotion;
                    
                    switch (type)
                    {
                        case 1:
                            tmpMotion = new UniformMotion();
                            break;
                        case 2:
                            tmpMotion = new AcceleratedMotion();
                            break;
                        default:
                            tmpMotion = new OscillatoryMotion();
                            break;
                    }

                    switch (tmpMotion)
                    {
                        case UniformMotion motion:
                            SafeReadFromConsole("Скорость (м/с): ", input => 
                            motion.Speed = Convert.ToDouble(input));
                            SafeReadFromConsole("Время (с): ", input => 
                            motion.Time = Convert.ToDouble(input));

                            motion.CalculateCoordinate();

                            ColorTextInConsole($"\nКоордината тела при равномерном движении: " +
                                $"{motion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
                        case AcceleratedMotion motion:
                            SafeReadFromConsole("Начальная координата тела: ", input =>
                            motion.StartCoordinate = Convert.ToDouble(input));
                            SafeReadFromConsole("Начальная скорость (м/с): ", input =>
                                    motion.Speed = Convert.ToDouble(input));
                            SafeReadFromConsole("Время (с): ", input =>
                                motion.Time = Convert.ToDouble(input));
                            SafeReadFromConsole("Ускорение (м/с^2): ", input =>
                                motion.Acceleration = Convert.ToDouble(input));

                            motion.CalculateCoordinate();

                            ColorTextInConsole($"\nКоордината тела при равноускоренном движении: " +
                                $"{motion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
                        case OscillatoryMotion motion:                            
                            SafeReadFromConsole("Амплитуда отклонения тела: ", input =>
                            motion.Amplitude = Convert.ToDouble(input));
                            SafeReadFromConsole("Начальное положение тела (0 - равновесия, 1 - " +
                                "максимальное отклонение): ", input => motion.StartingPosition = 
                                Convert.ToByte(input));
                            SafeReadFromConsole("Циклическая частота (рад/с): ", input =>
                                motion.CyclicFrequency = Convert.ToDouble(input));
                            SafeReadFromConsole("Время (с): ", input =>
                                motion.Time = Convert.ToDouble(input));
                            SafeReadFromConsole("Начальная фаза (град): ", input =>
                                motion.InitialPhase = Convert.ToDouble(input));

                            motion.CalculateCoordinate();

                            ColorTextInConsole($"\nКоордината тела при колебательном движении: " +
                                $"{motion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
                    }

                    ColorTextInConsole("\nДля выхода из программы нажмите клавишу Esc\n",
                        ConsoleColor.Green);
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                catch (Exception exception)
                {
                    ColorTextInConsole($"\n{exception.Message} Повторите ввод.\n\n", ConsoleColor.Red);
                }
            }
        }
    }
}
