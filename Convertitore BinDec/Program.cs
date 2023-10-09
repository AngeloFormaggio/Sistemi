using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Convertitore_BinDec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] binario = { true, true, false, false,false,false,false,false,/**/true, false, true, false,true,false,false,false,/**/false, false, false, false, false, false, false, true,/**/false, false, false, false, false, false, true,true};// 11000000, 10101000, 00000001, 00000011.
            bool[] bin = { true, false, true, false };
            int[] puntato = {10,10,10,10};
            int numDec = 10;
            
            Console.WriteLine(Convert_Binario_To_Decimale(bin));
            
            Console.WriteLine(Convert_Decimale_Puntato_To_Decimale(puntato));
            
            int[] dtp = Convert_Binario_To_Decimale_Puntato(binario);
            foreach(int num in dtp)
            {
                Console.Write($"{num}.");
            }
            Console.WriteLine();    

            bool[] b = Convert_Decimale_Puntato_To_Binario(puntato);
            foreach(bool bi in b)
            {
                if(bi)
                    Console.Write("1");
                else
                    Console.Write("0");
            }
            Console.WriteLine();

            int[] dp = Convert_Decimale_To_Decimale_Puntato(numDec);
            foreach (int num in dp)
            {
                Console.Write($"{num}.");
            }
            Console.WriteLine();


            bool[] bb = Convert_Decimale_To_Binario(numDec);
            foreach (bool bi in bb)
            {
                if (bi)
                    Console.Write("1");
                else
                    Console.Write("0");
            }



            Console.ReadLine();
        }

        static int Convert_Binario_To_Decimale(bool[] b)
        {
            int dec = 0;//variabile da ritornare
            Array.Reverse(b);//giro l'array b
            for (int i = 0; i < b.Length; i++)
                if (b[i])//se b è true quindi 1 sommo alla variabile dec la potenza
                    dec += (int)(Math.Pow(2, i));       
            return dec;
        }

        static int Convert_Decimale_Puntato_To_Decimale(int[] dp)
        {
            int dec = 0;
            Array.Reverse(dp);
            for(int i = 0; i < dp.Length;i++)
            {
                dec += dp[i] * (int)(Math.Pow(256, i));
            }
            return dec;
        }

        static int[] Convert_Binario_To_Decimale_Puntato(bool[] b)
        {
            int[] dp = new int[4];
            int supInt = 0;
            int cont = 0;
            Array.Reverse(b);

            for(int i  = 0; i < dp.Length; i++)
            {
                for(int x = 0; x < 8; x++)
                {
                    if (b[x+cont])
                        supInt += (int)Math.Pow(2, x);
                }
                dp[i] = supInt;
                supInt= 0;
                cont += 8;     
            }

            Array.Reverse(dp);
            return dp;
        }

        static bool[] Convert_Decimale_Puntato_To_Binario(int[] dp)
        {
            bool[] b = new bool[32];
            int cont = 0;
            Array.Reverse(dp);

            for(int i = 0; i <dp.Length; i++)
            {
                for(int x = 7; x > 0; x--)
                {
                    if (dp[i] % 2 == 0)
                        b[x + cont] = false;
                    else
                        b[x + cont] = true;
                    dp[i] /= 2;

                }
                
                cont += 8;
            }

            return b;
        }

        static int[] Convert_Decimale_To_Decimale_Puntato(int n)
        {
            int[] dp = new int[4];
            bool[] b = new bool[32];

            for (int i = 0; i < b.Length; i++)
            {
                if (n % 2 == 1)
                    b[i] = true;
                n /= 2;
            }

            int supInt = 0;
            int cont = 0;

            for (int i = 0; i < dp.Length; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (b[x + cont])
                        supInt += (int)Math.Pow(2, x);
                }
                dp[i] = supInt;
                supInt = 0;
                cont += 8;
            }

            Array.Reverse(dp);
            return dp;

        }

        static bool[] Convert_Decimale_To_Binario(int n)
        {
            bool[] b = new bool[32];
            
            for(int i = 0; i < b.Length; i++)
            {
                if (n % 2 == 1)
                    b[i] = true;
                n /= 2;
            }

            Array.Reverse(b);
            return b;
        }

    }
}

