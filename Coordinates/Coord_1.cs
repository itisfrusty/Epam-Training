using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Вводите аргументы построчно, завершая строку клавишей ENTER. ");
                Console.WriteLine("Для завершения ввода ещё раз нажмите клавишу ENTER.");
                var list = new List<string>();  // список для строк ввода
                var queue = new Queue<char>();  // очередь для вводиых символов
                while (true)
                {
                    var code = Console.Read(); // читаем с устройства ввода
                    try
                    {
                        if (code < 0) break;
                        var ch = Convert.ToChar(code); // в символы
                        if (ch == '\n')  // если была нажата Enter
                        {
                            // соединяем накопленные в очереди

                            var sb = new StringBuilder();
                            while (queue.Count > 0)
                                sb.Append(queue.Dequeue());
                            queue.Clear(); // очищаем очередь
                            var s = sb.ToString().Trim();
                            if (s.Length == 0) break;

                            // запоминаем строку в списке
                            list.Add(s);
                        }
                        queue.Enqueue(ch); // добавляем символ в очередь                    
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.WriteLine("Введены строки: ");
                foreach (var line in list)
                    Console.WriteLine(line);

                // делаем разбор строк:
                var result = new List<string>();
                foreach (var line in list)
                {
                    var items = line.Split(new[] { ',' });
                    if (items.Length == 2)
                    {
                        var x = items[0].Trim().Replace('.', ',');
                        var y = items[1].Trim().Replace('.', ',');
                        result.Add(string.Format("X:{0} Y:{1}", x, y));
                    }
                }
                Console.WriteLine("В отформатированном виде: ");
                foreach (var line in result)
                    Console.WriteLine(line);
            }
        }
    }

