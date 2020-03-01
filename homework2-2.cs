using System;

namespace homework6
{
    class Program
    {
        static public void Max(int[] n)
        {
            int Max = n[0];
            foreach(int i in n)
            {
                if (Max < i) Max = i;
            }
            Console.WriteLine($"数组最大值为{Max}");
        }
        static public void Min(int[] n)
        {
            int Min = n[0];
            foreach (int i in n)
            {
                if (Min > i) Min = i;
            }
            Console.WriteLine($"数组最大值为{Min}");
        }
        static public void average
            (int[] n)
        {
            int sum = 0;
            int average = 0;
            foreach (int i in n)
            {
                sum += i;
            }
            average = sum / n.Length;
            Console.WriteLine($"数组和为{sum}");
            Console.WriteLine($"平均值为{average}");
        }
        
        static void Main(string[] args)
        {
            int n = 0;//数组初始长度为n
            int[] array;
            Console.WriteLine("请输入数组长度");
            n = int.Parse(Console.ReadLine());
            array = new int[n];
            Console.WriteLine($"请输入数组的{n}个数字");
            for(int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Max(array);
            Min(array);
            average(array);
        }
    }
}
