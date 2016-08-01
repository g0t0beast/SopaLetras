using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SopaLetras
{
    class Players
    {
        //ATRIBUTO
        public string[] matrizPlayers;
        public int[] matrizScore;
        public int Numplayers;

        //CONSTRUTOR

        //recebe o número de jogadores e pede os seus nomes guardando num array matrizPlayers
        public Players(int nplayers)
        {
            matrizPlayers = new string[nplayers];
            matrizScore = new int[nplayers];
            Numplayers = nplayers;
            for (int i = 0; i < nplayers; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(6, 10 + (i*3));
                Console.Write(" » Introduza o nome do jogador " + (i + 1) + ": ");
                Console.ResetColor();
                matrizPlayers[i] = Console.ReadLine();
            }

        }

        //METODO

        //apresenta a Lista de jogadores
        public void ShowPlayerList()
        {
            int g;
            for (g = 0; g < matrizPlayers.Length; g++)
            {
                Console.WriteLine(matrizPlayers[g]);
            }
        }

        //atribui os pontos das palavras certas
        public void GivePoints(int Posit, int Points)
        {
            matrizScore[Posit] += Points;
        }

        //mostra os pontos dos jogadores. Junta a matrizPlayers com a matrizScore
        public void ShowPoints()
        {
            int p;
            for (p = 0; p < matrizScore.Length; p++)

            {
                Console.SetCursorPosition(2, 6+p);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(matrizPlayers[p]);
                Console.Write(" » " );
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(matrizScore[p]);
                Console.ResetColor();

            }
        }
    }
}
