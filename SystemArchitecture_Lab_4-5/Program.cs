using System;
using PL;

namespace SystemArchitecture_Lab_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Menu mainMenu = new Menu();
            mainMenu.StartMenu();
        }
    }
}
