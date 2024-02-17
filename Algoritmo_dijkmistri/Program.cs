using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_dijkmistri
{
    internal class Program
    {
        // funzione che inserisce le lettere nell'array
        public static void Inserisci_lettere(int n, ref char[] Lettere)
        {
            int ascii = 65;

            for (int i = 0; i < n; i++) 
            {
                Lettere[i] = (char)ascii;
                ascii += 1 ;
            }
        }

        // funzione che inserisce i valori nella matrice

        public static void ScegliCollegamenti(ref int[,] matrice, int nodi)
        {
            int caso = 9;

            for (int i = 0;i < nodi;i++)
            {
                for (int j = 0; j < nodi; j++)
                {
                    if (i == j)
                    {
                        matrice[i, j] = -1;
                    }
                    else
                    {
                        if (i == 0) // prima riga
                        {
                            caso = Randomizzare_casuale();

                            if(caso == 0) // nessun collegamento
                            {
                                matrice[i, j] = -1;
                            }
                            else
                            {
                                matrice[i, j] = 1;
                            }
                        }
                        else
                        {
                            if (matrice[j, i] == -1)
                            {
                                matrice[i, j] = -1;
                            }
                            else
                            {
                                caso = Randomizzare_casuale();

                                if (caso == 0) // nessun collegamento
                                {
                                    matrice[i, j] = -1;
                                }
                                else
                                {
                                    matrice[i, j] = 1;
                                }
                            }
                        }
                    }
                }
            }
        }

        // funzione che rende un numero casuale

        public static int Randomizzare()
        {
            Random rnd = new Random();
            return rnd.Next(1,11);
        }

        // casualità 50 / 50

        public static int Randomizzare_casuale()
        {
            Random rnd = new Random();
            int n = rnd.Next(0, 2);
            return n;
        }

        // funzione che mostra la matrice

        public static void MostraMatrice(int[,] matrice, int nodi, char[] lettere)
        {
            for (int i = 0; i < nodi; i++)
            {
                for (int j = 0; j < nodi; j++)
                {
                    // prima riga mostro lettere
                    if (i == 0 && j == 0)
                    {
                        for (int a = 0; a < nodi; a++)
                        {
                           if(a== 0)
                           {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"  {lettere[a]} ");
                                Console.ForegroundColor = ConsoleColor.White;
                           }
                           else
                           {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"{lettere[a]} ");
                                Console.ForegroundColor = ConsoleColor.White;
                           }

                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\n\n{lettere[i]} ");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (matrice[i, j] == -1) // nessun collegamento
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("X");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write($"{matrice[i, j]}");
                        }
                            
                        

                    }
                    else // mostro numeri
                    {
                       
                        if ( j==0) // a capo
                        {
                            if (matrice[i, j] == -1) // nessun collegamento
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"\n{lettere[i]}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(" X");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"\n{lettere[i]}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($" {matrice[i, j]}");
                            }
                        }
                        else
                        {
                            if (matrice[i, j] == -1) // nessun collegamento
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(" X");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write($" {matrice[i, j]}");
                            }
                        }
                        
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero di nodi");
            int nodi = Convert.ToInt32(Console.ReadLine());

            char[] Lettere = new char[nodi]; // creo l'array che contiene le lettere

            // riempio l'array con le lettere

            Inserisci_lettere(nodi, ref Lettere);

            int[,] matrice = new int[nodi,nodi]; // creo la matrice

            // mostro matrice
            Console.Clear();

            ScegliCollegamenti(ref matrice, nodi);
            MostraMatrice(matrice, nodi, Lettere);


        }
    }
}
