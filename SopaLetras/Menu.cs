using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SopaLetras
{
    class Menu
    {
        // Menu Principal do jogo
        public void getMenu()
        {
            // Logotipo do jogo SOPAZIO
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(7, 3);
            Console.WriteLine(" .----------------. .----------------. .----------------. .----------------. .----------------. .----------------. .----------------. ");
            Console.SetCursorPosition(7, 4);
            Console.WriteLine("| .--------------. | .--------------. | .--------------. | .--------------. | .--------------. | .--------------. | .--------------. |");
            Console.SetCursorPosition(7, 5);
            Console.WriteLine("| |    _______   | | |     ____     | | |   ______     | | |      __  /   | | |   ________   | | |     _____    | | |     ____     | |");
            Console.SetCursorPosition(7, 6);
            Console.WriteLine("| |   /  ___  |  | | |   .'    `.   | | |  |_   __ \\   | | |     /  \\     | | |  |  __   _|  | | |    |_   _|   | | |   .'    `.   | |");
            Console.SetCursorPosition(7, 7);
            Console.WriteLine("| |  |  (__ \\_|  | | |  /  .--.  \\  | | |    | |__) |  | | |    / /\\ \\    | | |  |_/  / /    | | |      | |     | | |  /  .--.  \\  | |");
            Console.SetCursorPosition(7, 8);
            Console.WriteLine("| |   '.___`-.   | | |  | |    | |  | | |    |  ___/   | | |   / ____ \\   | | |     .'.' _   | | |      | |     | | |  | |    | |  | |");
            Console.SetCursorPosition(7, 9);
            Console.WriteLine("| |  |`\\____) |  | | |  \\  `--'  /  | | |   _| |_      | | | _/ /    \\ \\_ | | |   _/ /__/ |  | | |     _| |_    | | |  \\  `--'  /  | |");
            Console.SetCursorPosition(7, 10);
            Console.WriteLine("| |  |_______.'  | | |   `.____.'   | | |  |_____|     | | ||____|  |____|| | |  |________|  | | |    |_____|   | | |   `.____.'   | |");
            Console.SetCursorPosition(7, 11);
            Console.WriteLine("| |              | | |              | | |              | | |              | | |              | | |              | | |              | |");
            Console.SetCursorPosition(7, 12);
            Console.WriteLine("| '--------------' | '--------------' | '--------------' | '--------------' | '--------------' | '--------------' | '--------------' |");
            Console.SetCursorPosition(7, 13);
            Console.WriteLine(" '----------------' '----------------' '----------------' '----------------' '----------------' '----------------' '----------------'");
            Console.Title = "SOPÁZIO";

            // letras MENU
            Console.SetCursorPosition(60, 17);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("__  __ ______ _   _ _    _ ");
            Console.SetCursorPosition(60, 18);
            Console.WriteLine("|  \\/  |  ____| \\ | | |  | |");
            Console.SetCursorPosition(60, 19);
            Console.WriteLine("| \\  / | |__  |  \\| | |  | |");
            Console.SetCursorPosition(60, 20);
            Console.WriteLine("| |\\/| |  __| | . ` | |  | |");
            Console.SetCursorPosition(60, 21);
            Console.WriteLine("| |  | | |____| |\\  | |__| |");
            Console.SetCursorPosition(60, 22);
            Console.WriteLine("|_|  |_|______|_| \\_|\\____/ ");
                             
                             
            // caixa do menu
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(46, 25);
            Console.Write("╔═══════════════════════════════════════════════════════╖");
            Console.SetCursorPosition(46, 26);
            Console.Write("║                                                       ║");
            Console.SetCursorPosition(46, 27);
            Console.Write("║                                                       ║");
            Console.SetCursorPosition(46, 28);
            Console.Write("║                                                       ║");
            Console.SetCursorPosition(46, 29);
            Console.Write("║                                                       ║");
            Console.SetCursorPosition(46, 30);
            Console.Write("║                                                       ║");
            Console.SetCursorPosition(46, 31);
            Console.Write("║                                                       ║");
            Console.SetCursorPosition(46, 32);
            Console.Write("║                                                       ║");
            Console.SetCursorPosition(46, 33);
            Console.Write("╘═══════════════════════════════════════════════════════╝");

            // interior da caixa - opções
            Console.SetCursorPosition(64, 27);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" » F1 - REGRAS");
            Console.SetCursorPosition(64, 29);
            Console.WriteLine(" » F2 - NOVO JOGO");
            Console.SetCursorPosition(64, 31);
            Console.WriteLine(" » ESC - QUIT");

            //Tratamento das teclas permitidas no menu
            ConsoleKeyInfo myKey;
            Regras myRegras = new Regras();
            Program mygame = new Program();
            Console.ForegroundColor = ConsoleColor.Green;

            //funcionamento exclusivo das teclas F1,F2 ou ESC no menu
            while (true)
            {
                myKey = Console.ReadKey(true);
                switch (myKey.Key)
                {
                    case ConsoleKey.F1:
                        for (int i = 0; i < 10; i++)
                        {


                            Console.Beep((i + 10) * 100, 100);
                        }
                        Console.Clear();
                        myRegras.getRegras();
                        return;

                    case ConsoleKey.F2:

                        for (int i = 0; i < 10; i++)
                        {


                            Console.Beep((i + 10) * 100, 100);
                        }
                        Console.Clear();
                        mygame.jogo();
                        return;

                    case ConsoleKey.Escape:

                        Console.Clear();
                        return;
                }
            }
        }
    }
}