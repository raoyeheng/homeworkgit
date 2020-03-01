using System;

namespace ConsoleApp5
{
    
    class Primefactor
    {
        bool Isprime(int n)
        {
            bool ret = true;
            if (n == 2) { return ret; };
            if (n % 2 != 0)
            {
                int bound = (int)System.Math.Sqrt(n) + 1;
                for (int i = 2; i < bound; i++)
                {
                    if (n % i == 0)
                    {
                        ret = false;
                        break;
                    }
                }
            }
            else { ret = false; }
            return ret;
        }
        private void display(int k)
        {
            Console.WriteLine("素数因子是：");
            for(int n = 2; n < k+1; n++)
            {
                if (k % n == 0 && Isprime(n)==true)
                {
                    Console.WriteLine(n);
                }
            }
        }
        public static void Main(string[] args)
        {
            Primefactor p1 = new Primefactor();
            p1.display(6);
        }
    }
     
}
