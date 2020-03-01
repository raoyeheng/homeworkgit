using System;

namespace homework8
{
   
    class Program
    {
        
        static void Main(string[] args)
        { 
            void sieve(int n)
            {
                bool[] is_prime = new bool[0];
                int[] prime = new int[0];
                int t = 0;
                for (int i = 0; i <=n; i++)
                {
                    Array.Resize<bool>(ref is_prime, is_prime.Length + 1); //动态增加数组长度

                    is_prime[i] = true;
                }
                is_prime[0] = is_prime[1] = false;
                for (int i = 2; i <= n; i++)//依次遍历
                {
                    if (is_prime[i])//检验到目前为止其是不是素数        
                    {
                        
                        Array.Resize<int>(ref prime, prime.Length + 1);
                        prime[t++] = i;
                       
                        for (int j = 2 * i; j <= n; j += i)
                        {
                            is_prime[j] = false;//其整数倍不是素数，置为false
                        }
                    }
                }
                for(int i = 0; i < t; i++)
                {
                    Console.WriteLine($"{prime[i]}");
                }
            }
            sieve(100);
        }
    }
}
