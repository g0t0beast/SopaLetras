using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SopaLetras
{
    class Regras


        // REGRAS
    {
        //menu regras
        public void getRegras()
        {
            ConsoleKeyInfo myKey;
            Console.SetCursorPosition(67, 8);
            Console.WriteLine("REGRAS DO SOPAZIO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 13);
            Console.WriteLine("É possível escolher até 4 jogadores.");
            Console.SetCursorPosition(50, 16);
            Console.WriteLine("Pontuação atribuida através do tamanho da palavra.");
            Console.SetCursorPosition(48, 19);
            Console.WriteLine("O jogadores vao alternando, até terminarem as palavras.");
            Console.SetCursorPosition(46, 22);
            Console.WriteLine("O jogo termina quando todas as palavras forem descobertas.");
            Console.SetCursorPosition(44, 25);
            Console.WriteLine("No Modo SIMPLES apenas necessita de escrever e acertar a palavra.");
            Console.SetCursorPosition(48, 28);
            Console.WriteLine("No Modo COMPLEXO tem de dar as coordenadas da palavra");
            Console.SetCursorPosition(54, 37);
            Console.WriteLine("Carregue ENTER para voltar ao menu anterior");
            Menu menu = new Menu();
            while (true)
            {
                myKey = Console.ReadKey(true);
                if (myKey.Key == ConsoleKey.Enter)
                    break;
            }

          
            for (int i = 0; i < 2; i++)
            {
                Console.Beep((i + 10) * 100, 100);
            }
            Console.Clear();
            menu.getMenu();
                 
         }
    }
}
