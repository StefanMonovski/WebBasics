using _01.Chronometer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Chronometer
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch stopwatch;

        private string time { get; set; }

        private List<string> laps { get; set; }

        public Chronometer()
        {
            stopwatch = new Stopwatch();
            laps = new List<string>();
        }

        public void Start()
        {
            if (!stopwatch.IsRunning)
            {
                Task task = new Task(() => stopwatch.Start());
                task.Start();
            }
        }

        public void Stop()
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }            
        }

        public string Lap()
        {
            string lap = stopwatch.Elapsed.ToString();
            laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            stopwatch.Stop();
            stopwatch.Reset();
            laps.Clear();
        }

        public string GetTime()
        {
            time = stopwatch.Elapsed.ToString();
            return time;
        }

        public string GetLaps()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Laps:");
            if (laps.Count == 0)
            {               
                sb.AppendLine("no laps");
            }
            else
            {
                for (int i = 1; i <= laps.Count; i++)
                {
                    sb.AppendLine($"{i}. {laps[i - 1]}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
