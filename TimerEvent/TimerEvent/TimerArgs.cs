using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEvent
{

    public sealed class TimerArgs : EventArgs
    {
        private readonly int originalTime;

        public int OriginalTime { get { return originalTime;} }

        public TimerArgs(int originalTime)
        {
            this.originalTime = originalTime;
        }
    }
}
