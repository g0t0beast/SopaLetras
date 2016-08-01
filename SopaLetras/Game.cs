using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;

namespace SopaLetras
{
    //MODO DE JOGO SIMPLES
    class GameSimples
    {
        public GameSimples(SopaDeLetras matriz, Respostas awn)
        {
            Players nplayers = GameComplexo.getNumPlayers("simple");
            Console.ResetColor();
            int PalavrasPorAcertar = awn.matrizRespostas.Length;
            int NumJogadores = nplayers.matrizPlayers.Length;
            string[] ListaJogadores = nplayers.matrizPlayers;
            //CICLO DO JOGO
            while (PalavrasPorAcertar > 0)
            {
                for (int J = 0; J < NumJogadores; J++)
                {
                    Console.Clear();
                    matriz.showMatriz();
                    Console.Write("Player: ");
                    Console.ResetColor();
                    Console.WriteLine(ListaJogadores[J]);
                    Console.SetCursorPosition(2, 5);
                    Console.WriteLine("SCORE: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    nplayers.ShowPoints();
                    Console.ResetColor();
                    Console.SetCursorPosition(30, matriz.getLastLine());
                    Console.Write(ListaJogadores[J] + " introduza uma palavra para jogar: ");
                    string s = Console.ReadLine();
                    awn.ComparaPalavra(s);
                    Console.SetCursorPosition(30, matriz.getLastLine() + 2);
                    Console.WriteLine(awn.RESULTADO);
                    Console.ReadKey();
                    if (awn.RESULTADO == "Parabéns, Acertou!!")
                    {
                        PalavrasPorAcertar--;
                        nplayers.GivePoints(J, s.Length);
                    }
                    if (PalavrasPorAcertar == 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(30, 1);
                        Console.WriteLine("   _________    __  _________   ____ _    ____________ ");
                        Console.SetCursorPosition(30, 2);
                        Console.WriteLine("  / ____/   |  /  |/  / ____/  / __ \\ |  / / ____/ __ \\");
                        Console.SetCursorPosition(30, 3);
                        Console.WriteLine(" / / __/ /| | / /|_/ / __/    / / / / | / / __/ / /_/ /");
                        Console.SetCursorPosition(30, 4);
                        Console.WriteLine("/ /_/ / ___ |/ /  / / /___   / /_/ /| |/ / /___/ _, _/");
                        Console.SetCursorPosition(30, 5);
                        Console.WriteLine("\\____/_/  |_/_/  /_/_____/   \\___/ |___/_____/_/ |_|");
                        Console.ResetColor();
                        Console.SetCursorPosition(2, 5);
                        Console.Write("RESULTADOS: ");
                        nplayers.ShowPoints();
                       

                 
                        Console.WriteLine("");
                        Console.SetCursorPosition(40, 8);
                        Console.WriteLine("Carregue ENTER para voltar ao MENU");
                        ConsoleKeyInfo myKey;
                        Menu menu = new Menu();
                        myKey = Console.ReadKey(true);

                        if (myKey.Key == ConsoleKey.Enter)
                        {
                            for (int i = 0; i < 2; i++)
                            {


                                Console.Beep((i + 10) * 100, 100);
                            }
                            Console.Clear();
                            menu.getMenu();
                        }


                        if (J == (NumJogadores))
                            J = 0;
                    }

                }
            }
        }

    }
    //MODO de jogo COMPLEXO
    class GameComplexo
    {
        //int tempo;
        //Timer timerMoveSprite;
        int jogador = 0;

        public GameComplexo(SopaDeLetras matriz, Respostas awn)
        {
            Players nplayers = getNumPlayers("complex");
            int PalavrasPorAcertar = awn.matrizRespostas.Length;
            int NumJogadores = nplayers.matrizPlayers.Length;
            string[] ListaJogadores = nplayers.matrizPlayers;
            //TIMER
            /*timerMoveSprite = new Timer(); // Inicializa
            timerMoveSprite.Interval = 1000; // Define Intervalo em Milisegundos
            timerMoveSprite.Elapsed += new ElapsedEventHandler(MoveSprite); // Adiciona a função que criamos na lista de funções a serem chamadas quando o intervalo for atingido
            timerMoveSprite.Start(); // Ativa o Timer (faz o mesmo começar a contagem)*/
            //CICLO DO JOGO
            while (PalavrasPorAcertar > 0)
            {
                //tempo = 0;
                for (int J = jogador; J < NumJogadores; J++)
                {
                    Console.Clear();
                    matriz.showMatriz();
                    awn.showRespostas();
                    matriz.showNumbers();
                    Console.SetCursorPosition(2, 3);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Player: ");
                    Console.ResetColor();
                    Console.WriteLine(ListaJogadores[J]);
                    Console.SetCursorPosition(2, 5);
                    Console.WriteLine("SCORE: ");
                    nplayers.ShowPoints();

                    //PEDE A PRIMEIRA E ÚLTIMA LETRA POR COORDENADAS

                    //PRIMEIRA LETRA DA PALAVRA
                    Console.SetCursorPosition(30, matriz.getLastLine());
                    Console.WriteLine("Diga onde está a primeira letra da palavra");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Linha: ");
                    Console.ResetColor();
                    int LinhaI = TestLinhaI(matriz);

  /////////////                  //TESTE
                   // Console.WriteLine(LinhaI);


                    Console.SetCursorPosition(46, matriz.getLastLine() + 1);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Coluna: ");
                    Console.ResetColor();
                    int ColunaI = TestColunaI(matriz);

      ///////////              //TESTE
                    //Console.WriteLine(ColunaI);
                    
                    //ÚLTIMA LETRA DA PALAVRA
                    Console.SetCursorPosition(30, matriz.getLastLine() + 2);
                    Console.WriteLine("E a última letra?");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Linha: ");
                    Console.ResetColor();
                    int LinhaF = TestLinhaF(matriz);

    //////////////                //TESTE
                  //  Console.WriteLine(LinhaF);


                    Console.SetCursorPosition(46, matriz.getLastLine() + 3);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Coluna: ");
                    Console.ResetColor();
                    int ColunaF = TestColunaF(matriz);

    /////////////                //TESTE
                    //Console.WriteLine(ColunaF);

                    char[] word = new char[0];

                    //PALAVRA HORIZONTAL
                    //condição para ser horizontal
                    if (LinhaI == LinhaF)
                    {
                        int g = 0;
                        //esquerda para a direita
                        if (ColunaF >= ColunaI)
                        {
                            word = new char[(ColunaF - ColunaI) + 1];
                            for (int i = ColunaI; i <= ColunaF; i++)
                            {
                                word[g] = matriz.obtainLetter(LinhaI - 1, i - 1);
                                g++;
                            }
                        }
                        //direita para a esquerda
                        if (ColunaI > ColunaF)
                        {
                            word = new char[(ColunaI - ColunaF) + 1];
                            for (int i = ColunaI; i >= ColunaF; i--)
                            {
                                word[g] = matriz.obtainLetter(LinhaI - 1, i - 1);
                                g++;
                            }
                        }
                    }//fim palavra horizontal

                    //PALAVRA VERTICAL
                    //condição para ser vertical
                    if (ColunaI == ColunaF)
                    {
                        int g = 0;
                        //de cima para baixo
                        if (LinhaF > LinhaI)
                        {
                            word = new char[(LinhaF - LinhaI) + 1];
                            for (int i = LinhaI; i <= LinhaF; i++)
                            {
                                word[g] = matriz.obtainLetter(i - 1, ColunaI - 1);
                                g++;
                            }
                        }
                        //de baixo para cima
                        if (LinhaI > LinhaF)
                        {
                            word = new char[(LinhaI - LinhaF) + 1];
                            for (int i = LinhaI; i >= LinhaF; i--)
                            {
                                word[g] = matriz.obtainLetter(i - 1, ColunaI - 1);
                                g++;
                            }
                        }
                    } //fim palavra vertical

                    //PALAVRA DIAGONAL
                    //condição para ser diagonal
                    if (ColunaI != ColunaF && LinhaI != LinhaF)
                    {
                        int g = 0;
                        //ESQUERDA PARA A DIREITA
                        if (ColunaI < ColunaF)
                        {
                            word = new char[(ColunaF - ColunaI) + 1];
                            //Decrescente ( -> \ )
                            if (LinhaI < LinhaF)
                            {
                                for (int i = LinhaI; i <= LinhaF; i++)
                                {
                                    int value = ColunaI - 1;
                                    word[g] = matriz.obtainLetter(i - 1, value + g);
                                    g++;
                                }
                            }
                            //Crescente ( -> / )
                            if (LinhaI > LinhaF)
                            {
                                for (int i = LinhaI; i >= LinhaF; i--)
                                {
                                    int value = ColunaI - 1;
                                    word[g] = matriz.obtainLetter(i - 1, value + g);
                                    g++;
                                }
                            }
                        }
                        //DIREITA PARA A ESQUERDA
                        if (ColunaI > ColunaF)
                        {
                            word = new char[(ColunaI - ColunaF) + 1];
                            //Decrescente ( / <- )
                            if (LinhaI < LinhaF)
                            {
                                for (int i = LinhaI; i <= LinhaF; i++)
                                {
                                    int value = ColunaI - 1;
                                    word[g] = matriz.obtainLetter(i - 1, value - g);
                                    g++;
                                }
                            }
                            //Crescente ( \ <- )
                            if (LinhaI > LinhaF)
                            {
                                for (int i = LinhaI; i >= LinhaF; i--)
                                {
                                    int value = ColunaI - 1;
                                    word[g] = matriz.obtainLetter(i - 1, value - g);
                                    g++;
                                }
                            }
                        }

                    }//fim palavra diagonal

                    //Palavra escolhida através das coordenadas de Letra inicial e Final
                    string s = new string(word);
                    Console.SetCursorPosition(30, 38);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("A palavra que encontrou foi:  ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(s);
                    //Verificar se está correcta
                    awn.ComparaPalavra(s);
                    Console.SetCursorPosition(35, 39);
                   
                    
                   
                    //SE ACERTOU
                    if (awn.RESULTADO == "Parabéns, Acertou!!")
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(35, 39);
                        
                        Console.WriteLine(awn.RESULTADO);
                        /*tempo = 0;
                        timerMoveSprite.Start();*/
                        nplayers.GivePoints(J, s.Length);
                        PalavrasPorAcertar--;
                        Console.ReadKey();
                    }
                    //SE FALHOU
                    if (awn.RESULTADO == "Falhou ou a Palavra já foi Encontrada!")
                    {
                        /*tempo = 0;
                        timerMoveSprite.Start();*/
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(35, 39);

                        Console.WriteLine(awn.RESULTADO);
                        Console.ReadKey();
                        
                    }
                    //FINAL DO JOGO
                    if (PalavrasPorAcertar == 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(35, 2);

            Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(30, 1);
                        Console.WriteLine("   _________    __  _________   ____ _    ____________ ");
                        Console.SetCursorPosition(30, 2);
                        Console.WriteLine("  / ____/   |  /  |/  / ____/  / __ \\ |  / / ____/ __ \\");
                        Console.SetCursorPosition(30, 3);
                        Console.WriteLine(" / / __/ /| | / /|_/ / __/    / / / / | / / __/ / /_/ /");
                        Console.SetCursorPosition(30, 4);
                        Console.WriteLine("/ /_/ / ___ |/ /  / / /___   / /_/ /| |/ / /___/ _, _/");
                        Console.SetCursorPosition(30, 5);
                        Console.WriteLine("\\____/_/  |_/_/  /_/_____/   \\___/ |___/_____/_/ |_|");
                        Console.ResetColor();
                        Console.SetCursorPosition(2, 5);
                        Console.Write("RESULTADOS: ");
                        nplayers.ShowPoints();
                       

                 
                        Console.WriteLine("");
                        Console.SetCursorPosition(40, 8);
                        Console.WriteLine("Carregue ENTER para voltar ao MENU");
                        ConsoleKeyInfo myKey;
                        Menu menu = new Menu();
                        myKey = Console.ReadKey(true);
                        if (myKey.Key == ConsoleKey.Enter)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                Console.Beep((i + 10) * 100, 100);
                            }
                            Console.Clear();
                            menu.getMenu();
                        }
                    }
                }//fim do FOR
            }//fim do while(ciclo de jogo)
        }


        //MÉTODO PARA ERROS NO NUM DA COORDENADA DA LINHA INICIAL
        private int TestLinhaI(SopaDeLetras matriz)
        {
            Console.SetCursorPosition(38, matriz.getLastLine() + 1);
            Console.WriteLine("              ");
            Console.SetCursorPosition(38, matriz.getLastLine() + 1);
            int Linha = 0;
            try
            {
                Linha = int.Parse(Console.ReadLine());
                if (Linha < 1 || Linha > matriz.matrizSopa.Length)
                {
                    Console.SetCursorPosition(30, matriz.getLastLine() + 2);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                    Console.WriteLine("O número deve ser entre 1 e " + matriz.matrizSopa.Length + " .");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 4);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                    Console.WriteLine("Carregue na tecla ENTER");
                    Console.ReadLine();
                    Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                    Console.WriteLine("                                                           ");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                    Console.WriteLine("                                        ");
                    TestLinhaI(matriz);
                }

            }
            catch (Exception )
            {
                Console.SetCursorPosition(30, matriz.getLastLine() + 2);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                Console.WriteLine("Deve introduzir um número entre 1 e " + matriz.matrizSopa.Length + " .");
                Console.SetCursorPosition(30, matriz.getLastLine() + 4);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                Console.WriteLine("Carregue na tecla ENTER");
                Console.ReadLine();
                Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                Console.WriteLine("                                                           ");
                Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                Console.WriteLine("                                        ");
                TestLinhaI(matriz);
            }
            return Linha;
        }
        //MÉTODO PARA ERROS NO NUM DA COORDENADA DA LINHA FINAL
        private int TestLinhaF(SopaDeLetras matriz)
        {

            Console.SetCursorPosition(38, matriz.getLastLine() + 3);
            Console.WriteLine("              ");
            Console.SetCursorPosition(38, matriz.getLastLine() + 3);

            int Linha = 0;
            try
            {
                Linha = int.Parse(Console.ReadLine());
                if (Linha < 1 || Linha > matriz.matrizSopa.Length)
                {
                    Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                    Console.WriteLine("O número deve ser entre 1 e " + matriz.matrizSopa.Length + " .");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 7);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                    Console.WriteLine("Carregue na tecla ENTER");
                    Console.ReadLine();
                    Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                    Console.WriteLine("                                                           ");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                    Console.WriteLine("                                        ");
                    TestLinhaF(matriz);
                }
            }
            catch (Exception )
            {
                Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                Console.WriteLine("O número deve ser entre 1 e " + matriz.matrizSopa.Length + " .");
                Console.SetCursorPosition(30, matriz.getLastLine() + 7);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                Console.WriteLine("Carregue na tecla ENTER");
                Console.ReadLine();
                Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                Console.WriteLine("                                                           ");
                Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                Console.WriteLine("                                        ");
                TestLinhaF(matriz);
            }
            return Linha;
            
        }
        //MÉTODO PARA ERROS NO NUM DA COORDENADA DA COLUNA INICIAL
        private int TestColunaI(SopaDeLetras matriz)
        {
            Console.SetCursorPosition(55, matriz.getLastLine() + 1);
            Console.Write("                          ");
            Console.SetCursorPosition(55, matriz.getLastLine() + 1);
            int Coluna = 0;
            try
            {
                Coluna = int.Parse(Console.ReadLine());
                if (Coluna < 1 || Coluna > matriz.matrizSopa[1].Length)
                {
                    Console.SetCursorPosition(30, matriz.getLastLine() + 2);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                    Console.WriteLine("O número deve ser entre 1 e " + matriz.matrizSopa[1].Length + " .");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 4);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                    Console.WriteLine("Carregue na tecla ENTER");
                    Console.ReadLine();
                    Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                    Console.WriteLine("                                                           ");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                    Console.WriteLine("                              ");
                    TestColunaI(matriz);
                }
            }
            catch (Exception )
            {
                Console.SetCursorPosition(30, matriz.getLastLine() + 2);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                Console.WriteLine("O número deve ser entre 1 e " + matriz.matrizSopa[1].Length + " .");
                Console.SetCursorPosition(30, matriz.getLastLine() + 4);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                Console.WriteLine("Carregue na tecla ENTER");
                Console.ReadLine();
                Console.SetCursorPosition(30, matriz.getLastLine() + 3);
                Console.WriteLine("                                                           ");
                Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                Console.WriteLine("                                        ");
                TestColunaI(matriz);
            }
            return Coluna;
            
        }
        //MÉTODO PARA ERROS NO NUM DA COORDENADA DA COLUNA FINAL
        private int TestColunaF(SopaDeLetras matriz)
        {
            Console.SetCursorPosition(55, matriz.getLastLine() + 3);
            Console.WriteLine("              ");
            Console.SetCursorPosition(55, matriz.getLastLine() + 3);

            int Coluna = 0;
            try
            {
                Coluna = int.Parse(Console.ReadLine());
                if (Coluna < 1 || Coluna > matriz.matrizSopa[1].Length)
                {
                    Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                    Console.WriteLine("O número deve ser entre 1 e " + matriz.matrizSopa[1].Length + " .");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 7);
                    Console.WriteLine("");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                    Console.WriteLine("Carregue na tecla ENTER");
                    Console.ReadLine();
                    Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                    Console.WriteLine("                                                           ");
                    Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                    Console.WriteLine("                                        ");
                    TestColunaF(matriz);
                }
            }
            catch (Exception )
            {
                Console.SetCursorPosition(30, matriz.getLastLine() + 5);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                Console.WriteLine("O número deve ser entre 1 e " + matriz.matrizSopa[1].Length + " .");
                Console.SetCursorPosition(30, matriz.getLastLine() + 7);
                Console.WriteLine("");
                Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                Console.WriteLine("Carregue na tecla ENTER");
                Console.ReadLine();
                Console.SetCursorPosition(30, matriz.getLastLine() + 6);
                Console.WriteLine("                                                           ");
                Console.SetCursorPosition(30, matriz.getLastLine() + 8);
                Console.WriteLine("                                        ");
                TestColunaF(matriz);
            }
            return Coluna;
            
        }

       
        //fim GameComplexo


        /*public void MoveSprite(object source, ElapsedEventArgs e)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            tempo++;
            if (tempo == 20)
            {
                timerMoveSprite.Stop();
                //Console.SetCursorPosition(35, 23);
                //Console.WriteLine("O tempo acabou, é a vez do proximo jogador");
                //Console.ReadLine();
                //jogador++;
                //Console.SetCursorPosition(left, top);
                tempo = 0;
                //timerMoveSprite.Start();
                return;
            }
            timerMoveSprite.Interval = 1000;
            timerMoveSprite.Start();
            Console.SetCursorPosition(1, 2);
            Console.WriteLine(tempo);
            Console.SetCursorPosition(left, top);
        }*/

        //Pede o número de jogadores e os nomes
        public static Players getNumPlayers(string type)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(40, 2);
            if (type.Equals("complex"))
                Console.WriteLine("SOPA DE LETRAS - DADOS DOS JOGADORES - COMPLEX MODE");
            else
                Console.WriteLine("SOPA DE LETRAS - DADOS DOS JOGADORES - SIMPLE MODE");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(4, 6);
            Console.Write("# Escolha entre 1 a 4 Jogadores: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            int nplayers = 0;
            try
            {
                nplayers = int.Parse(Console.ReadLine());
                if (nplayers < 1 || nplayers > 4)
                {

                    Console.Clear();
                    Console.SetCursorPosition(5, 7);
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╖");
                    Console.SetCursorPosition(7, 9);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ERRO!! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("O número de jogadores deve ser entre 1 e 4.");
                    Console.SetCursorPosition(6, 11);
                    Console.WriteLine("______________________________________________________________________");
                    Console.SetCursorPosition(12, 13);
                    Console.WriteLine("Carregue na tecla ENTER");

                    Console.SetCursorPosition(5, 15);
                    Console.WriteLine("╘═══════════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey();
                    getNumPlayers(type);
                }
            }
            catch
            {
                Console.Clear();
                Console.SetCursorPosition(5, 7);
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╖");
                Console.SetCursorPosition(7, 9);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERRO!! ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("O número de jogadores deve ser um número inteiro entre 1 e 4.");
                Console.SetCursorPosition(6, 11);
                Console.WriteLine("______________________________________________________________________");
                Console.SetCursorPosition(12, 13);
                Console.WriteLine("Carregue na tecla ENTER");
                Console.SetCursorPosition(5, 15);
                Console.WriteLine("╘═══════════════════════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(5, 15);
                Console.ReadKey();
                getNumPlayers(type);
            }

            return new Players(nplayers);
        }
    }//fim GameComplexo
}
            



        
    

