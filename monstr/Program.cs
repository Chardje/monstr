using System;

namespace monstr
{
    class Program
    {
        #region peremennie
        
        static byte [] monstr = new byte [5];
        static Random R = new Random();
        static int round = 1;
        static byte a = 1;
        static byte dver;
        static bool game = true;
        #endregion
        static void Main()
        {
            while (true)
            {
                game = true;
                round = 1;
                for (byte round = 0;round<45;round++)
                {
                    Door();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    resp_monstr();
                    read();
                    prov();
                    if (!game)
                    {
                        break;
                    }
                }
            }
        }
        static void Door()
        {
            a = 1;
            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 35; x++)
                {
                    if ((x % 7 == 0 || x % 7 == 1) || y == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }
                    else if (y == 3 && x % 7 == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($" {a}");
                        a++;
                    }
                    else if (y == 7 && x % 7 == 6)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"[]");

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }

                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
        static void resp_monstr()
        {
            for (int i = 0; i < monstr.Length; i++)
            {
                monstr[i] = 0;
            }
            for (int i= 0 ; i <monstr.Length ;i++)
            {
                for (int i0=0; i0 < monstr.Length;i0++)
                {                
                    
                    if (i==i0)
                    {
                        
                    }
                    else if (monstr[i]== monstr[i0]||monstr[i]==0)
                    {
                        monstr[i] = (byte)R.Next(1, 6);
                        i0 = -1;
                        
                    }
                    
                }
            }
        }
        static void read()
        {
            try
            {
                do
                {
                    Console.Write("\nВведiть номер дверi: ");
                    dver = Convert.ToByte(Console.ReadLine());
                }
                while (dver<0||dver>monstr.Length);                         

            }
            catch
            {
                read();
            }
            
        }
        static void prov()
        {
            for (int i=0;i<(round/15)+1;i++)
            {
                if (monstr[i]==dver)
                {
                    Console.WriteLine("Там був монстр");                    
                    game = false;
                }
            }
            Console.Write($"Монстр ");
            for (int i = 0; i < ((round / 15) + 1); i++)
            {
                Console.Write($"{monstr[i]}, ");
            }
            Console.WriteLine("\b");
            Console.WriteLine($"Раунд {round}");
            round++;
        }
    }
}
