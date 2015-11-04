using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerEvent
{
    public class Timer
    {
        public event EventHandler<TimerArgs> Ring = delegate { };
        
        public bool Completed { get; private set; }

        private int originalTime;
        private Thread timer;
        private object synObject = new Guid();

        public Timer(int miliseconds)
        {
            originalTime = miliseconds;
            Completed = false;
        }

        public void Start()
        {
            timer = new Thread(() => {
                lock (synObject)
                {
                    Thread.Sleep(originalTime);
                }
                Completed = true;
                OnRing();
            });
            timer.Start();
        }

        public void WaitRing()
        {
            lock (synObject)
            {

            }
        }

        private void OnRing()
        {
            EventHandler<TimerArgs> handler = Ring;
            handler(this, new TimerArgs(originalTime));
        }
    }

    public class Oven
    {
        public Oven()
        {

        }

        public void RegisterTimer(Timer timer)
        {
            timer.Ring += Check;
        }

        public void UnregisterTimer(Timer timer)
        {
            timer.Ring -= Check;
        }

        private void Check(object sender, TimerArgs e)
        {
            Console.WriteLine($"Oven should be checked, timers time {e.OriginalTime} miliseconds");
        }
    }

    public class Microwave
    {
        public Microwave(Timer timer)
        {
            timer.Ring += Check;
        }

        private void Check(object sender, TimerArgs e)
        {
            Console.WriteLine($"Microwave should be checked, timers time {e.OriginalTime} miliseconds");
        }
    }
}
