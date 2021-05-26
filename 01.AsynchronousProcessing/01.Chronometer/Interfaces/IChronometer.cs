using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Chronometer.Interfaces
{
    public interface IChronometer
    {
        void Start();

        void Stop();

        string Lap();

        void Reset();

        string GetTime();

        string GetLaps();
    }
}
