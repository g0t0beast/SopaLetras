using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace SopaLetras
{


    class Program
    {
        static GameSimples games;
        static GameComplexo gamec;

        //ecran para a escolha da dificuldade da sopa de letras e/ou do modo de jogo
        public void INITSCREEN(string what)
        {
            Console.Clear();
            Console.Title = "SOPÁZIO";
            Console.ForegroundColor = ConsoleColor.Green;
            if (what.Equals("dific")) //LOGO DIFICULDADE caso exista a possibilidade de escolha do grau de dificuldade
            {
                Console.SetCursorPosition(48, 11);
                Console.WriteLine("      _ _  __ _            _     _           _      ");
                Console.SetCursorPosition(48, 12);
                Console.WriteLine("     | (_)/ _(_)          | |   | |         | |     ");
                Console.SetCursorPosition(48, 13);
                Console.WriteLine("   __| |_| |_ _  ___ _   _| | __| | __ _  __| | ___ ");
                Console.SetCursorPosition(48, 14);
                Console.WriteLine("  / _` | |  _| |/ __| | | | |/ _` |/ _` |/ _` |/ _ \\");
                Console.SetCursorPosition(48, 15);
                Console.WriteLine(" | (_| | | | | | (__| |_| | | (_| | (_| | (_| |  __/");
                Console.SetCursorPosition(48, 16);
                Console.WriteLine("  \\__,_|_|_| |_|\\___|\\__,_|_|\\__,_|\\__,_|\\__,_|\\___|");
            }
            //escolha do modo de jogo
            if (what.Equals("modo")) //LOGO MODO 
            {
                Console.SetCursorPosition(59, 11);
                Console.WriteLine("                     _       ");
                Console.SetCursorPosition(59, 12);
                Console.WriteLine("                    | |      ");
                Console.SetCursorPosition(59, 13);
                Console.WriteLine(" _ __ ___   ___   __| | ___  ");
                Console.SetCursorPosition(59, 14);
                Console.WriteLine("| '_ ` _ \\ / _ \\ / _` |/ _ \\ ");
                Console.SetCursorPosition(59, 15);
                Console.WriteLine("| | | | | | (_) | (_| | (_) |");
                Console.SetCursorPosition(59, 16);
                Console.WriteLine("|_| |_| |_|\\___/ \\__,_|\\___/ ");
            }

            //caixa da página onde se escolhe a dificuldade e o modo de jogo
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



        }

        //tamanho da consola e correr o menu
        public static void Main(string[] args)
        {
            Console.SetWindowSize(150, 60);
            Menu zzz = new Menu();
            zzz.getMenu();
        }

        //vai identificar se se trata de um jogo com uma ou duas sopa de letras. Permite que o utilizador escolha as opções
        public void jogo()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Magenta;
            //vai verificar na paste Score o número de ficheiros presentes
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("Score\\");
            int count = dir.GetFiles().Length;
            //JOGO COM APENAS UMA SOPA DE LETRAS
            if (count == 2)
            {
                INITSCREEN("modo");
                int nivel;
                nivel = processTypeGame();
                Console.Clear();
                //JOGO SIMPLES
                if (nivel == 1)
                {
                    Respostas rep = new Respostas("Score\\respostaFacil.txt");
                    SopaDeLetras Matriz = new SopaDeLetras("Score\\ficheiroFacil.txt");
                    games = new GameSimples(Matriz, rep);
                }
                //JOGO COMPLEXO
                if (nivel == 2)
                {
                    Respostas rep = new Respostas("Score\\respostaFacil.txt");
                    SopaDeLetras Matriz = new SopaDeLetras("Score\\ficheiroFacil.txt");
                    gamec = new GameComplexo(Matriz, rep);
                }
            }
            //JOGO COM DUAS SOPAS DE LETRAS (FÁCIL E DIFÍCIL)
            if (count == 4)
            {
                INITSCREEN("dific");
                Console.SetCursorPosition(64, 27);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" » 1  -  FÁCIL");
                Console.SetCursorPosition(64, 29);
                Console.WriteLine(" » 2  -  DIFÍCIL");
                Console.SetCursorPosition(64, 31);
                Console.WriteLine(" » Opção: ");
                Console.SetCursorPosition(74, 31);
                int opcao = processTypeGame();
                //COMPLEXO SIMPLES
                INITSCREEN("modo");
                Console.SetCursorPosition(64, 27);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" » 1  -  SIMPLES");
                Console.SetCursorPosition(64, 29);
                Console.WriteLine(" » 2  -  COMPLEXO");
                Console.SetCursorPosition(64, 31);
                Console.WriteLine(" » Opção: ");
                Console.SetCursorPosition(74, 31);
                int nivel = processTypeGame();
                if (opcao == 1)
                {
                    if (nivel == 1)
                    {
                        Respostas rep = new Respostas("Score\\respostaFacil.txt");
                        SopaDeLetras Matriz = new SopaDeLetras("Score\\ficheiroFacil.txt");
                        games = new GameSimples(Matriz, rep);
                    }
                    if (nivel == 2)
                    {
                        Respostas rep = new Respostas("Score\\respostaFacil.txt");
                        SopaDeLetras Matriz = new SopaDeLetras("Score\\ficheiroFacil.txt");
                        gamec = new GameComplexo(Matriz, rep);
                    }
                }
                if (opcao == 2)
                {
                    if (nivel == 1)
                    {
                        Respostas rep = new Respostas("Score\\respostaDificil.txt");
                        SopaDeLetras Matriz = new SopaDeLetras("Score\\ficheiroDificil.txt");
                        games = new GameSimples(Matriz, rep);
                    }
                    if (nivel == 2)
                    {
                        Respostas rep = new Respostas("Score\\respostaDificil.txt");
                        SopaDeLetras Matriz = new SopaDeLetras("Score\\ficheiroDificil.txt");
                        gamec = new GameComplexo(Matriz, rep);
                    }
                }
            }
            Console.ReadKey();
        }

        //MÉTODO auxiliar que permite identificar a dificuldade da sopa de letras e/ou o modo de jogo
        private int processTypeGame()
        {
            ConsoleKeyInfo myKey;
            while (true)
            {
                myKey = Console.ReadKey(true);
                switch (myKey.Key)
                {
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.NumPad1:
                        return 1;
                    case ConsoleKey.NumPad2:
                        return 2;
                }
            }
        }

    }
}
    
       
                
     