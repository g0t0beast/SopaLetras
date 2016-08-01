using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SopaLetras
{
    class SopaDeLetras
    {
        //ATRIBUTOS
        public String[] matrizSopa;
        private int NumCols = 0;
        

        //CONSTRUCTOR
        public SopaDeLetras(string filepath)
        {
            try
            {
                FileStream input = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(input);
                String line;
                int NumLinhas = (File.ReadLines(filepath).Count());
                
                int i = 0;
                matrizSopa = new String[NumLinhas];
                //Ler as linhas do ficheiro e passar para um Array.
                while ((line = sr.ReadLine()) != null)
                {
                    matrizSopa[i] = line;
                    if (i == 0) 
                        NumCols = line.Length;
                    //Erro caso esteja mal construído o ficheiro da Sopa de Letras. Isto é, uma linha ou várias com mais ou menos caracteres
                    else if (line.Length != NumCols)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(5, 7);
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╖");
                        Console.SetCursorPosition(7, 9);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ERRO!! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" O Número de letras não é igual em todas as linhas - (Linha:" + (i + 1) + ")");
                        Console.SetCursorPosition(6, 11);
                        Console.WriteLine("______________________________________________________________________");
                        Console.SetCursorPosition(12, 13);
                        Console.WriteLine("Por favor alterar o ficheiro e voltar a tentar. Obrigado");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(5, 15);
                        Console.WriteLine("╘═══════════════════════════════════════════════════════════════════════╝");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    i++;
                }
                sr.Close();
            }
            catch (IOException e)
            {
                //erros
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


        //METODOS

        //obtem a letra da posição pretendida
        public char obtainLetter(int linha, int coluna)
        {
            return matrizSopa[linha][coluna];
        }

        //mostra a matriz sopa de letras
        public void showMatriz()
        {
            Console.SetCursorPosition(34, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(matrizSopa.Length / 2 + 40, 2);
            Console.WriteLine("SOPA DE LETRAS");
            Console.ResetColor();
            int i;
            for (i = 0; i < matrizSopa.Length; i++)
            {
               Console.ForegroundColor = ConsoleColor.White;
               Console.SetCursorPosition(36,7 + (i*2));
               Console.WriteLine(meteEspacos(matrizSopa[i])); 
            }
        }

        //mete espaços para mostrar a matriz
        private string meteEspacos(string p)
        {
            string temp = "";
            for(int i=0;i<p.Length;i++) 
            {
                temp += "  ";
                temp+=p[i];
            }
            return temp;

        }

        //coloca os números à volta da matriz
        public void showNumbers()
        {
            int i;
            //Números na vertical
            for (i = 0; i < matrizSopa.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(33, 7 + (i*2));
                Console.WriteLine((i + 1));
           
            }
            //Números na horizontal
            for (i = 0; i < NumCols; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(38 + (i*3), 5);
                Console.WriteLine((i + 1));
                Console.Write("  ");
            }
        }

        //identifica a última linha da matriz consoante o seu tamanho
        internal int getLastLine()
        {
            return 9+ matrizSopa.Length * 2;
        }
    }
}