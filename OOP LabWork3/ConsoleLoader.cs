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
        /// корректного значения. Автоматически выполняется перевод значения в тип double
        /// </summary>
        /// <param name="outputLine">Строка для вывода в консоль</param>
        /// <param name="onRead">Действие, которое необходимо сделать</param>
        public static void SafeReadFromConsole(string outputLine, Action<double> onRead)
        {
            while (true)
            {
                try
                {
                    Console.Write(outputLine);
                    onRead(Convert.ToDouble(Console.ReadLine().Replace(".", ",")));
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

                    MotionBase tmpMotion;
                    
                    switch (type)
                    {
                        case 1:
                            tmpMotion = new UniformMotion();
                            break;
                        case 2:
                            tmpMotion = new AcceleratedMotion();
                            break;
                        case 3:
                            tmpMotion = new OscillatoryMotion();
                            break;
                        default:
                            throw new Exception("Введено некорректное значение.");
                    }

                    switch (tmpMotion)
                    {
                        case UniformMotion motion:
                            SafeReadFromConsole("Скорость (м/с): ", input => motion.Speed = input);
                            SafeReadFromConsole("Время (с): ", input => motion.Time = input);
                            break;
                        case AcceleratedMotion motion:
                            SafeReadFromConsole("Начальная координата тела: ", input => 
                                motion.StartCoordinate = input);
                            SafeReadFromConsole("Начальная скорость (м/с): ", input =>
                                motion.Speed = input);
                            SafeReadFromConsole("Время (с): ", input => motion.Time = input);
                            SafeReadFromConsole("Ускорение (м/с^2): ", input =>
                                motion.Acceleration = input);
                            break;
                        case OscillatoryMotion motion:                            
                            SafeReadFromConsole("Амплитуда отклонения тела: ", input =>
                                motion.Amplitude = input);
                            SafeReadFromConsole("Начальное положение тела (0 - равновесие, 1 - " +
                                "максимальное отклонение): ", input => motion.StartingPosition = 
                               (StartingPositionType)input);
                            SafeReadFromConsole("Циклическая частота (рад/с): ", input =>
                                motion.CyclicFrequency = input);
                            SafeReadFromConsole("Время (с): ", input => motion.Time = input);
                            SafeReadFromConsole("Начальная фаза (град): ", input =>
                                motion.InitialPhase = input);
                            break;
                    }
//TODO: Показать полиморфизм +++
                    tmpMotion.CalculateCoordinate();

                    switch(type)
                    {
                        case 1:
                            ColorTextInConsole($"\nКоордината тела при равномерном движении: " +
                                $"{tmpMotion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
                        case 2:
                            ColorTextInConsole($"\nКоордината тела при равноускоренном движении: " +
                                $"{tmpMotion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
                        case 3:
                            ColorTextInConsole($"\nКоордината тела при колебательном движении: " +
                                $"{tmpMotion.Coordinate} м\n\n", ConsoleColor.Blue);
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
