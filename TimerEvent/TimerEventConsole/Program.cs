using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimerEvent;
using Timer = TimerEvent.Timer;

namespace TimerEventConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before timer");
            int t = 10000;
            Console.WriteLine($"Timer - {t} miliseconds");
            Timer timer = new Timer(t);
            Microwave microwave = new Microwave(timer);
            timer.Start();
            Console.WriteLine("Started");
            Thread.Sleep(2000);
            Console.WriteLine("2000");
            Console.WriteLine("Adding oven");
            Oven oven = new Oven();
            oven.RegisterTimer(timer);
            Console.WriteLine("Awaiting timer");
            timer.WaitRing();
            Console.WriteLine("Ring");
            Console.ReadLine();
        }
    }
}
