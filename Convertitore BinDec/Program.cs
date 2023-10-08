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
            int[] puntato = {10,10,10,10};//134744072  //inserire il numero puntato
            //Console.WriteLine(Convert_Binario_To_Decimale(binario));
            //Console.WriteLine(Convert_Decimale_Puntato_To_Decimale(puntato));
            int[] dp = Convert_Binario_To_Decimale_Puntato(binario);
            foreach(int num in dp)
            {
                Console.Write($"{num}.");
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
    }
}
