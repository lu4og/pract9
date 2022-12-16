using pract9;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;

namespace pract9
{
    class istok
    {
        public ConsoleKey key;
        public string sslka;
    }
    class google_v_pomoshy
    {
        protected static List<istok> us = new List<istok>();
        protected static List<ConsoleKey> vse_klavishi = new List<ConsoleKey>();
        protected static List<string> vse_sslki = new List<string>();
        protected static void vivod_vsego()
        {
            Console.Clear();
            Console.WriteLine("Список ваших горячих клавиш\nКлавиша\t\tСсылка");
            foreach (istok a in us)
            {
                Console.WriteLine($"  {a.key}\t\t{a.sslka}");
            }
            Console.WriteLine("\nИзменить пункт или удалить пункт - 'F2'\nСоздать новый пункт - 'F1'\nПерейти в меню выполнения - 'F10'");
            deserialization_and_serialization.ser(us);
        }

        protected static void dobavlenie_klavishi()
        {
            istok per = new istok();
            while (true)
            {
                Console.Clear();
                Console.Write("Введите клавишу: ");
                per.key = Console.ReadKey().Key;
                if (vse_klavishi.Contains(per.key))
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели клавишу, которая уже существует в вашем списке, попробуйте еще раз!");
                    Thread.Sleep(500);
                }
                else
                {
                    vse_klavishi.Add(per.key);
                    break;
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите ссылку: ");
                per.sslka = Console.ReadLine();
                if (vse_sslki.Contains(per.sslka))
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели ссылку, которая уже существует в вашем списке, попробуйте еще раз!");
                    Thread.Sleep(500);
                }
                else
                {
                    vse_sslki.Add(per.sslka);
                    break;
                }
            }
            us.Add(per);
        }
    }
    class klaviha : google_v_pomoshy
    {
        protected static int udalenie_or_izmenenie_clavishi()
        {
            if (us.Count != 0)
            {
                Console.Clear();
                int pos = 2;
                ConsoleKeyInfo klavisha;
                vivod_vsego();
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(">>");
                do
                {
                    vivod_vsego();
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine(">>");
                    klavisha = Console.ReadKey(true);
                    if (klavisha.Key == ConsoleKey.UpArrow)
                    {
                        pos--;
                        if (pos < 2)
                            pos = 2;
                    }
                    if (klavisha.Key == ConsoleKey.DownArrow)
                    {
                        pos++;
                        if (pos > us.Count + 1)
                            pos = us.Count + 1;
                    }
                } while (klavisha.Key != ConsoleKey.Enter);
                return pos - 2;
            }
            else
            {
                Console.WriteLine("В вашем списке нет элементов");
                Thread.Sleep(1000);
                Console.Clear();
                return -1;
            }
        }
    }
    class open : klaviha
    {
        protected static void apen()
        {
            Console.Write("Вы находитесь в режиме открытия: для открытия введите клавишу соотвествующую вашему списку: ");
            ConsoleKeyInfo n = Console.ReadKey(true);
            int u = 0;
            foreach (ConsoleKey g in vse_klavishi)
            {
                if (g == n.Key)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo { FileName = vse_sslki[u], UseShellExecute = true });
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Отказано в доступе");
                    }
                    break;
                }
                else
                {
                    u++;
                }
            }
        }
    }
    class deserialization_and_serialization : open
    {
        public static List<istok> deser()
        {
            return JsonConvert.DeserializeObject<List<istok>>(File.ReadAllText("C:\\Users\\lu4lu\\OneDrive\\Рабочий стол\\openka.json")) ?? new List<istok>();
        }
        public static void ser(List<istok> list)
        {
            File.WriteAllText("C:\\Users\\lu4lu\\OneDrive\\Рабочий стол\\openka.json", JsonConvert.SerializeObject(list));
        }
    }
}

internal class Program : deserialization_and_serialization
{
    static void Main()
    {   
        us = deser();
        foreach (istok l in us)
        {
            vse_klavishi.Add(l.key);
            vse_sslki.Add(l.sslka);
        }
        ConsoleKeyInfo key;
        while (true)
        {
            do
            {
                vivod_vsego();
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.F2 && key.Key != ConsoleKey.F10 && key.Key != ConsoleKey.F1);
            switch (key.Key)
            {
                case ConsoleKey.F1:
                    dobavlenie_klavishi();
                    break;
                case ConsoleKey.F2:
                    int del = udalenie_or_izmenenie_clavishi();
                    if (del == -1)
                    {
                        break;
                    }
                    if (del > 0)
                    {
                        int vibor;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите действие:\n1.Удалить клавишу\n2.Изменить клавишу");
                            vibor = Convert.ToInt32(Console.ReadLine());
                        } while (vibor != 1 && vibor != 2);
                        switch (vibor)
                        {
                            case 1:
                                vse_klavishi.RemoveAt(del);
                                vse_sslki.RemoveAt(del);
                                us.RemoveAt(del);
                                break;
                            case 2:
                                Console.Clear();
                                while (true)
                                {
                                    int y = 0;
                                    Console.Clear();
                                    Console.WriteLine("Введите новую клавишу: ");
                                    ConsoleKeyInfo neww = Console.ReadKey();
                                    if (vse_klavishi.Contains(neww.Key))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Такая клавиша уже есть в вашем списке");
                                    }
                                    else
                                    {
                                        foreach (istok a in us)
                                        {
                                            if (y == del)
                                                a.key = neww.Key;
                                            else
                                            {
                                                y++;
                                            }
                                        }
                                        vse_klavishi[del] = neww.Key;
                                        break;
                                    }
                                }
                                break;
                        }
                        break;
                    }
                    break;
                case ConsoleKey.F10:
                    apen();
                    break;

            }
        }
    }
}