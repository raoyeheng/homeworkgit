using System;
using System.Threading;
namespace clock
{
    class Program
    {


        public delegate void ClockTick(object sender);
        public delegate void ClockAlarm(object sender);

        public class Clock
        {
            public ClockTime c1 = new ClockTime();
            public Clock()
            {
                c1.clockevent2 += alarm;
                c1.clockevent1 += tick;
            }
            void tick(object sender)
            {
                Console.WriteLine($"{c1.hour}:{c1.minute}:{c1.second}");
            }
            void alarm(object sender)
            {
                Console.WriteLine("到时！");
            }
        }
        public class ClockTime
        {
            public int hour { get; set; }
            public int minute { get; set; }
            public int second { get; set; }
            public event ClockTick clockevent1;
            public event ClockAlarm clockevent2;

            public void go(int a, int b, int c)
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    this.second = DateTime.Now.Second;
                    this.minute = DateTime.Now.Minute;
                    this.hour = DateTime.Now.Hour;
                    clockevent1(this);
                    DoAlarm(a, b, c);
                }
            }
            public void DoAlarm(int a, int b, int c)
            {
                if (a == this.hour && b == this.minute && c == this.second)
                {
                    clockevent2(this);
                }
            }
        }
        static void Main(string[] args)
        {
            Clock myclock = new Clock();
            myclock.c1.go(10, 36, 0);                      //定时
        }
    }
}
