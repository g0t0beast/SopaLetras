using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SopaLetras
{
    class Respostas
    {

        //ATRIBUTOS
        public string[] matrizRespostas;
        public string RESULTADO;
        public int CounterNumPalavras;
        

        //CONSTRUCTOR
        public Respostas(string filepath)
        {
            try
            {
                FileStream input = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(input);
                string line;
                int NumLinhas = (File.ReadLines(filepath).Count());
                CounterNumPalavras = NumLinhas;
                int i = 0;
                matrizRespostas = new string[NumLinhas];
                // ler e escrever na consola todas as linhas do ficheiro

                while ((line = sr.ReadLine()) != null)
                {
                    matrizRespostas[i] = line;
                    i++;
                }
                sr.Close();
            }
            catch (IOException e)
            {
                // erros
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


        }

        //METODOS

        //Mostra as respostas solução
        public void showRespostas()
        {
            int a;
            Console.SetCursorPosition(2,17);
            Console.WriteLine("Lista:");
            for (a = 0; a < matrizRespostas.Length; a++) 
            {
                Console.SetCursorPosition(2, 19 +a);
                Console.WriteLine(matrizRespostas[a]);
            }
        }

        //Compara uma qualquer palavra com as soluções
        public string ComparaPalavra(string palavra)
        {
            int g=0;
            RESULTADO = "Falhou ou a Palavra já foi Encontrada!";
       
            for( g=0; g < matrizRespostas.Length; g++)
            {
                if (palavra.ToUpper() == matrizRespostas[g])
                {
                    RESULTADO = "Parabéns, Acertou!!";
                    //Assim permite não haver o erro de acertar quando fica vazio o elemento do array
                    matrizRespostas[g] = "            ";
                }
                
            }
            return RESULTADO; 
        }

    }
}
