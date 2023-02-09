using System;
using System.Collections.Generic;
using System.IO;

namespace tt
{
    class Program
    {

        private static int cost = 0;
        private static string name = " ";

        static void Main()
        {

            int position = 1;
            zakaz zakaz = new zakaz();
            zakaz.menu();
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Итого - " + cost);
            Console.WriteLine("Ваш выбор - " + name);
            Console.SetCursorPosition(0, 0);
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {


                if (key.Key == ConsoleKey.UpArrow) { position--; }
                else if (key.Key == ConsoleKey.DownArrow) { position++; }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    zakaz.vivodName = name;
                    zakaz.vivodCost = cost;
                    zakaz.fail();
                    cost = 0;
                    name = null;
                    Console.ReadKey();
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        Main();
                    }
                }
                Console.Clear();
                zakaz.menu();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine(cost);
                Console.WriteLine(name);
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");


                key = Console.ReadKey();
            }
            SrtelochkiPodMenu(position);
        }

        static void SrtelochkiPodMenu(int position)
        {
            zakaz zakaz = new zakaz();
            ConsoleKeyInfo key;
            List<tortiki> tort = zakaz.podmenu();
            zakaz.cheleee(tort[position]);
            int positionPodMenu = 1;
            key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow) { positionPodMenu--; }
                else if (key.Key == ConsoleKey.DownArrow) { positionPodMenu++; }
                else if (key.Key == ConsoleKey.Escape) { Main(); }

                Console.Clear();
                zakaz.cheleee(tort[position]);
                Console.SetCursorPosition(0, positionPodMenu);
                Console.WriteLine("->");
                key = Console.ReadKey();
            }
            Console.Clear();
            if (key.Key == ConsoleKey.Enter)
            {
                cost += tort[position].cost[positionPodMenu];
                name += tort[position].name[positionPodMenu];

            }
            Console.Clear();
            Main();
        }
    }
}