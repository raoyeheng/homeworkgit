using System;

namespace tangle
{
    class Program
    {
        class rectangle
        {
            bool set;
            double length;
            double width;
            public void setrectangle(double width, double length)
            {
                if (length > 0 && width > 0)
                {
                    this.length = length;
                    this.width = width;

                }
                else
                {
                    Console.WriteLine("构造失败");
                    set = false;
                }
            }
            public double getarea()
            {
                if (set == true)
                {
                    return length * width;
                }
                else return 0;
            }
        }
            class square
            {
                bool set;
                double length;
                public void setsquare(double length)
                {
                if (length > 0)
                {
                    this.length = length;
                }
                else { Console.WriteLine("构造失败");set = false; }
                }
            public double getarea()
            {
                if (set == true)
                {
                    return length * length;
                }
                else return 0;
            }
         }
        class triangle
        {
            bool set=true;
            double first, second, third;
            public void settriangle(double first,double second,double third)
            {
           
                if (first > 0 && second > 0 && third > 0 && first + second > third && first + third > second && second + third > first)
                {  
                    this.first = first;
                    this.second = second;
                    this.third = third;
                    
                }
                else
                {
                    Console.WriteLine("构造失败");
                    set = false;
                }
            }
            public double getarea()
            {

                if (set == true)
                {
                    double p = (first + second + third) / 2;
                    double e = p * (p - first) * (p - second) * (p - third);
                    return System.Math.Sqrt(e);
                }
               else return 0;
                
            }
        }
            static void Main(string[] args)
        {
            triangle s2 = new triangle();
            s2.settriangle(3, 4, 9);
            Console.WriteLine($"三角形面积为{s2.getarea()}");
        }
    }
}
