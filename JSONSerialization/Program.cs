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
        /// <summary>
        /// Метод получает из консоли длину массива
        /// </summary>
        /// <returns>Целое число</returns>
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
            //File.Delete("log.txt"); // Удаление старых логов (если мешает)
            File.AppendAllText("log.txt", "Начало работы.\r\n\r\n\r\n");
            do
            {
                Console.Clear();
                // Перенаправляем стандартный поток вывода

                Console.OutputEncoding = System.Text.Encoding.Unicode;
                
                // Показываем меню
                ShowMenu();

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 35);

                //Повтор решения
                Console.WriteLine("Для повтора программы нажмите Enter, для выхода - любую другую клавишу");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            
            Console.Clear();
            Console.WriteLine("Хорошего дня!");
            File.AppendAllText("log.txt", "Завершение работы.\r\n\r\n\r\n");
        }
        /// <summary>
        /// Метод выводит в консоль меню, в котором управление происходит стрелками
        /// </summary>
        public static void ShowMenu()
        {   
            // Варианты выбора меню
            int ind = 0;
            string[] fields = { "Использовать структуру", "Использовать класс", "FoRtNiTe DaNcE" };

            do
            {
                Console.Clear();
                // Отображаем меню
                Console.WriteLine("Меню:");
                for (int i = 0; i < fields.Length; i++)
                {
                    if (ind == i)
                    {
                        Console.WriteLine($"[X]  {fields[i]}");
                    }
                    else if (i == fields.Length - 1)
                    {
                        // Секретная вкладка
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

            // Обрабатываем выбор пользователя
            switch (ind)
            {
                case 0:
                    UseSctruct();
                    Logger.LogWC("Пользователь начинает работу со структурой.");
                    break;
                case 1:
                    UseClass();
                    Logger.LogWC("Пользователь начинает работу с классом.");
                    break;
                case 2:
                    Fortnite();
                    Logger.LogWC("Пользователь играет в Fortnite и ему пора в дурку.");
                    break;
            }
        }
        /// <summary>
        /// Метод использует структуру ConsoleSimbolStruct для хранения символов
        /// </summary>
        public static void UseSctruct()
        {
            // Получаем длину массивы из консоли
            int ArrayLength = GetLengthInput();
            Logger.LogWC("Количество элементов в массиве: " + ArrayLength);

            // Основная работа программы
            DateTime dt = DateTime.Now;
            
            Logger.Log("Начало наблюдения.");
            Logger.Log(dt + "; " + dt.Millisecond + " Milliseconds");
            
            ConsoleSimbolStruct[] chars = new ConsoleSimbolStruct[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                chars[i] = new ConsoleSimbolStruct('*',
                                                  rand.Next(30), rand.Next(30));
            }
            
            Logger.Log("Конец наблюдения.");
            DateTime dt_new = DateTime.Now;
            Logger.Log(dt_new + "; " + dt_new.Millisecond + " Milliseconds");
            Logger.Log("Время наблюдения: " + (dt_new.Millisecond - dt.Millisecond) + " Milliseconds");

            RGB[] arr = new RGB[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                ConsoleColor color = getRandomColor();

                arr[i] = new RGB(color.ToString());

                Console.ForegroundColor = color;
                Console.SetCursorPosition(chars[i].X, chars[i].Y + 5);
                Console.Write(chars[i].Simb);
                Thread.Sleep(50); // using System.Threading;
            }

            // Сериализуем массив цветов
            Serialize(arr);
        }
        
        /// <summary>
        /// Метод использует класс ConsoleSimbolClass для хранения символов
        /// </summary>
        public static void UseClass()
        {
            // Получаем длину массивы из консоли
            int ArrayLength = GetLengthInput();
            Logger.LogWC("Количество элементов в массиве: " + ArrayLength);

            // Основная работа программы
            DateTime dt = DateTime.Now;
            Logger.Log("Начало наблюдения.");
            Logger.Log(dt + "; " + dt.Millisecond + " Milliseconds");
            
            ConsoleSimbolClass[] chars = new ConsoleSimbolClass[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                chars[i] = new ConsoleSimbolClass('*',
                                                  rand.Next(30), rand.Next(30));
            }
            
            Logger.Log("Конец наблюдения.");
            DateTime dt_new = DateTime.Now;
            Logger.Log(dt_new + "; " + dt_new.Millisecond + " Milliseconds");
            Logger.Log("Время наблюдения: " + (dt_new.Millisecond - dt.Millisecond) + " Milliseconds");

            RGB[] arr = new RGB[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                ConsoleColor color = getRandomColor();

                arr[i] = new RGB(color.ToString());

                Console.ForegroundColor = color;
                Console.SetCursorPosition(chars[i].X, chars[i].Y + 5);
                Console.Write(chars[i].Simb);
                Thread.Sleep(50); // using System.Threading;
            }

            // Сериализуем массив цветов
            Serialize(arr);
        }
        /// <summary>
        /// Метод выводит на экран Fortnite Dance со звуковыми эффектами
        /// </summary>
        public static void Fortnite()
        {
            // Воспроизводим музыку
            player = new MediaPlayer();
            player.Open(new Uri(@"../../Fortnite.mp3", UriKind.Relative));
            player.Volume = 0.1;
            player.Play();
            int frame = 0;
            // Количество кадров FortniteDance
            while (frame < 35)
            {
                Console.Clear();
                Console.WriteLine(FortniteDance.rawInput[(frame++) % FortniteDance.rawInput.Length]);
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// Метод сериализует массив использованных цветов для вывода в консоль
        /// </summary>
        /// <param name="objs">Массив цветов</param>
        public static void Serialize(RGB[] objs)
        {
            // Создаем json сериалайзер
            var ser = new DataContractJsonSerializer(typeof(RGB[]));
            try
            {
                // Открываем поток с доступом к записи в файл
                using (FileStream stream = new FileStream("serialize.json", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    // Очищаем файл от предыдущего использования
                    stream.SetLength(0);

                    // Сериализуем в файл
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
