using Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JSONSerialization
{
    class Program
    {
        private static Random rand = new Random();
        private static ConsoleColor getRandomColor()
        {
            return (ConsoleColor)(rand.Next(Enum.GetNames(typeof(ConsoleColor)).Length));
        }

        private static int GetLengthInput()
        {
            int res;
            Console.WriteLine("Введите длину массива");
            while (!int.TryParse(Console.ReadLine(), out res) || res < 0)
            {
                Console.WriteLine("Было введено не число или же оно меньше 0, повторите ввод");
            }
            Console.Clear();
            return res;
        }

        static MediaPlayer player;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                // Перенаправляем стандартный поток вывода

                Console.OutputEncoding = System.Text.Encoding.Unicode;
                ShowMenu();


                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 35);
                //Повтор решения
                Console.WriteLine("Для повтора программы нажмите Enter, для выхода - любую другую клавишу");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
        }

        public static void ShowMenu()
        {
            int ind = 0;
            string[] fields = { "Использовать структуру", "Использовать класс", "FoRtNiTe DaNcE" };

            do
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                for (int i = 0; i < fields.Length; i++)
                {
                    if (ind == i)
                    {
                        Console.WriteLine($"[X]  {fields[i]}");
                    }
                    else if (i == fields.Length - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("[ ] FoRtNiTe DaNcE");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"[ ]  {fields[i]}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Для перемещения используйте стрелки вверх/вниз");
                Console.WriteLine("Для выбора - Enter");
                //Обработка нажатий клавиш
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    ind = ind - 1 < 0 ? 0 : ind - 1;
                }
                if (key == ConsoleKey.DownArrow)
                {
                    ind = ind + 1 >= fields.Length ? fields.Length - 1 : ind + 1;
                }
                if (key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);

            switch (ind)
            {
                case 0:
                    UseSctruct();
                    break;
                case 1:
                    UseClass();
                    break;
                case 2:
                    Fortnite();
                    break;
            }
        }

        public static void UseSctruct()
        {
            int ArrayLength = GetLengthInput();

            DateTime dt = DateTime.Now;
            Console.WriteLine("Начало наблюдения.");
            Console.WriteLine(dt + "; " + dt.Millisecond + " Milliseconds");
            ConsoleSimbolStruct[] chars = new ConsoleSimbolStruct[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                chars[i] = new ConsoleSimbolStruct('*',
                                                  rand.Next(30), rand.Next(30));
            }
            Console.WriteLine("Конец наблюдения.");
            dt = DateTime.Now;
            Console.WriteLine(dt + "; " + dt.Millisecond + " Milliseconds");

            RGB[] arr = new RGB[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                ConsoleColor color = getRandomColor();

                arr[i] = new RGB(color.ToString());

                Console.ForegroundColor = color;
                Console.SetCursorPosition(chars[i].X, chars[i].Y + 4);
                Console.Write(chars[i].Simb);
                Thread.Sleep(50); // using System.Threading;
            }

            Serialize(arr);
        }

        public static void UseClass()
        {
            int ArrayLength = GetLengthInput();

            DateTime dt = DateTime.Now;
            Console.WriteLine("Начало наблюдения.");
            Console.WriteLine(dt + "; " + dt.Millisecond + " Milliseconds");
            ConsoleSimbolClass[] chars = new ConsoleSimbolClass[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                chars[i] = new ConsoleSimbolClass('*',
                                                  rand.Next(30), rand.Next(30));
            }
            Console.WriteLine("Конец наблюдения.");
            dt = DateTime.Now;
            Console.WriteLine(dt + "; " + dt.Millisecond + " Milliseconds");

            RGB[] arr = new RGB[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                ConsoleColor color = getRandomColor();

                arr[i] = new RGB(color.ToString());

                Console.ForegroundColor = color;
                Console.SetCursorPosition(chars[i].X, chars[i].Y + 4);
                Console.Write(chars[i].Simb);
                Thread.Sleep(50); // using System.Threading;
            }

            Serialize(arr);
        }

        public static void Fortnite()
        {
            player = new MediaPlayer();
            player.Open(new Uri(@"../../Fortnite.mp3", UriKind.Relative));
            player.Volume = 0.1;
            player.Play();
            int frame = 0;
            while (frame < 35)
            {
                Console.Clear();
                Console.WriteLine(FortniteDance.rawInput[(frame++) % FortniteDance.rawInput.Length]);
                Thread.Sleep(100);
            }
        }
        public static void Serialize(RGB[] objs)
        {
            var ser = new DataContractJsonSerializer(typeof(RGB[]));
            try
            {
                using (FileStream stream = new FileStream("serialize.json", FileMode.OpenOrCreate,FileAccess.Write))
                {
                    ser.WriteObject(stream, objs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сериализации:\n " + ex.Message);
            }
        }
    }
}

/*⠀⠀⠀⠀⠀⠀⣤⣶⣶
⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣀⣀
⠀⠀⠀⠀⠀⣀⣶⣿⣿⣿⣿⣿⣿
⣤⣶⣀⠿⠶⣿⣿⣿⠿⣿⣿⣿⣿
⠉⠿⣿⣿⠿⠛⠉⠀⣿⣿⣿⣿⣿
⠀⠀⠉⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣤⣤
⠀⠀⠀⠀⠀⠀⠀⣤⣶⣿⣿⣿⣿⣿⣿
⠀⠀⠀⠀⠀⣀⣿⣿⣿⣿⣿⠿⣿⣿⣿⣿
⠀⠀⠀⠀⣀⣿⣿⣿⠿⠉⠀⠀⣿⣿⣿⣿
⠀⠀⠀⠀⣿⣿⠿⠉⠀⠀⠀⠀⠿⣿⣿⠛
⠀⠀⠀⠀⠛⣿⣿⣀⠀⠀⠀⠀⠀⣿⣿⣀
⠀⠀⠀⠀⠀⣿⣿⣿⠀⠀⠀⠀⠀⠿⣿⣿
⠀⠀⠀⠀⠀⠉⣿⣿⠀⠀⠀⠀⠀⠀⠉⣿
⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⣀⣿
⠀⠀⠀⠀⠀⠀⣀⣿⣿
⠀⠀⠀⠀⠤⣿⠿⠿⠿ ⠀⠀⠀⠀⣀
⠀⠀⣶⣿⠿⠀⠀⠀⣀⠀⣤⣤
⠀⣶⣿⠀⠀⠀⠀⣿⣿⣿⠛⠛⠿⣤⣀
⣶⣿⣤⣤⣤⣤⣤⣿⣿⣿⣀⣤⣶⣭⣿⣶⣀
⠉⠉⠉⠛⠛⠿⣿⣿⣿⣿⣿⣿⣿⠛⠛⠿⠿
⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠿
⠀⠀⠀⠀⠀⠀⠀⠿⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⠀⣭⣿⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⣤⣿⣿⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⠿
⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠿
⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⠉⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⠀⠉⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⣿⠛⠿⣿⣤
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣿⠀⠀⠀⣿⣿⣤
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⣶⣿⠛⠉
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿
⠀⠀⣶⠀⠀⣀⣤⣶⣤⣉⣿⣿⣤⣀
⠤⣤⣿⣤⣿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣀
⠀⠛⠿⠀⠀⠀⠀⠉⣿⣿⣿⣿⣿⠉⠛⠿⣿⣤
⠀⠀⠀⠀⠀⠀⠀⠀⠿⣿⣿⣿⠛⠀⠀⠀⣶⠿
⠀⠀⠀⠀⠀⠀⠀⠀⣀⣿⣿⣿⣿⣤⠀⣿⠿
⠀⠀⠀⠀⠀⠀⠀⣶⣿⣿⣿⣿⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⠿⣿⣿⣿⣿⣿⠿⠉⠉
⠀⠀⠀⠀⠀⠀⠀⠉⣿⣿⣿⣿⠿
⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⠉
⠀⠀⠀⠀⠀⠀⠀⠀⣛⣿⣭⣶⣀
⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠉⠛⣿
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠀⣿⣿
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣉⠀⣶⠿
⠀⠀⠀⠀⠀⠀⠀⠀⣶⣿⠿
⠀⠀⠀⠀⠀⠀⠀⠛⠿⠛
*/
