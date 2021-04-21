using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionLibrary;

namespace OOP_LabWork3
{
    public class ConsoleLoader
    {
        public static void ColorTextInConsole (string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод для повтора действий по считыванию значения из консоли до момента получения
        /// корректного значения и последующего совершения действия с ним
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
                    onRead(Console.ReadLine());
                    return;
                }
                catch (Exception exception)
                {
                    ColorTextInConsole($"\n{exception.Message} Повторите ввод.\n",
                        ConsoleColor.Red);
                }
            }
        }

        public static void Main(string[] args)
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

                    if (type <= 0 || type > 3)
                    {
                        throw new Exception("Введено некорректное значение.");
                    }

                    Motion tmpMotion;
                    
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
                            SafeReadFromConsole("\nСкорость (м/с): ", input => 
                            motion.Speed = Convert.ToDouble(input));
                            SafeReadFromConsole("Время (с): ", input => 
                            motion.Time = Convert.ToDouble(input));

                            motion.CalculateCoordinate();

                            ColorTextInConsole($"\nКоордината тела при равномерном движении: " +
                                $"{motion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
                        case AcceleratedMotion motion:
                            /*while (true)
                            {
                                Console.Write("\nНужен ли расчет ускорения (Y/N)? ");
                                string choice = Console.ReadLine().ToLower();

                                bool marker = false;

                                switch (choice)
                                {
                                    case "y":
                                        SafeReadFromConsole("\nНачальная скорость (м/с): ", input =>
                                            motion.StartSpeed = Convert.ToDouble(input));
                                        SafeReadFromConsole("Конечная скорость (м/с): ", input =>
                                            motion.Speed = Convert.ToDouble(input));
                                        SafeReadFromConsole("Время (с): ", input =>
                                            motion.Time = Convert.ToDouble(input));

                                        motion.CalculateAcceleration();

                                        ColorTextInConsole($"\nРассчитанное ускорение (м/с^2): " +
                                            $"{motion.Acceleration}\n",
                                            ConsoleColor.Blue);
                                        marker = true;
                                        break;
                                    case "n":
                                        marker = true;
                                        break;
                                    default:
                                        ColorTextInConsole($"\nВведено некорректное значение. " +
                                            $"Повторите ввод.\n", ConsoleColor.Red);
                                        break;
                                }

                                if (marker)
                                {
                                    break;
                                }
                            }*/

                            SafeReadFromConsole("\nНачальная координата тела: ", input =>
                            motion.StartCoordinate = Convert.ToDouble(input));
                            SafeReadFromConsole("Начальная скорость (м/с): ", input =>
                                    motion.StartSpeed = Convert.ToDouble(input));
                            SafeReadFromConsole("Время (с): ", input =>
                                motion.Time = Convert.ToDouble(input));
                            SafeReadFromConsole("Ускорение (м/с^2): ", input =>
                                motion.Acceleration = Convert.ToDouble(input));

                            motion.CalculateCoordinate();

                            ColorTextInConsole($"\nКоордината тела при равноускоренном движении: " +
                                $"{motion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
                        case OscillatoryMotion motion:
                            /*while (true)
                            {
                                Console.Write("\nНужен ли расчет циклической частоты колебаний (Y/N)? ");
                                string choice = Console.ReadLine().ToLower();

                                bool marker = false;

                                switch (choice)
                                {
                                    case "y":
                                        double period = 0;

                                        SafeReadFromConsole("\nПериод колебаний (с): ", input =>
                                            period = Convert.ToDouble(input));

                                        ColorTextInConsole($"\nРассчитанная частота (рад/с): " +
                                            $"{motion.CalculateFrequency(period)}\n",
                                            ConsoleColor.Blue);
                                        marker = true;
                                        break;
                                    case "n":
                                        marker = true;
                                        break;
                                    default:
                                        ColorTextInConsole($"\nВведено некорректное значение. " +
                                            $"Повторите ввод.\n", ConsoleColor.Red);
                                        break;
                                }

                                if (marker)
                                {
                                    break;
                                }
                            }

                            while (true)
                            {
                                Console.Write("\nНужен ли перевод начально (Y/N)? ");
                                string choice = Console.ReadLine().ToLower();

                                bool marker = false;

                                switch (choice)
                                {
                                    case "y":
                                        double period = 0;

                                        SafeReadFromConsole("\nПериод колебаний (с): ", input =>
                                            period = Convert.ToDouble(input));

                                        ColorTextInConsole($"\nРассчитанная частота (рад/с): " +
                                            $"{motion.CalculateFrequency(period)}\n",
                                            ConsoleColor.Blue);
                                        marker = true;
                                        break;
                                    case "n":
                                        marker = true;
                                        break;
                                    default:
                                        ColorTextInConsole($"\nВведено некорректное значение. " +
                                            $"Повторите ввод.\n", ConsoleColor.Red);
                                        break;
                                }

                                if (marker)
                                {
                                    break;
                                }
                            }*/

                            SafeReadFromConsole("\nАмплитуда отклонения тела: ", input =>
                            motion.StartCoordinate = Convert.ToDouble(input));
                            SafeReadFromConsole("Начальная скорость (м/с): ", input =>
                                    motion.StartSpeed = Convert.ToDouble(input));
                            SafeReadFromConsole("Время (с): ", input =>
                                motion.Time = Convert.ToDouble(input));
                            SafeReadFromConsole("Ускорение (м/с^2): ", input =>
                                motion.Acceleration = Convert.ToDouble(input));

                            motion.CalculateCoordinate();

                            ColorTextInConsole($"\nКоордината тела при колебательном движении: " +
                                $"{motion.Coordinate} м\n\n", ConsoleColor.Blue);
                            break;
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
