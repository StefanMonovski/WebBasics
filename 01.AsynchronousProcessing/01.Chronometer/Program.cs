using System;
using System.Threading.Tasks;

namespace _01.Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();

            string command;
            while ((command = Console.ReadLine()) != "exit")
            {
                switch (command)
                {
                    case "start": chronometer.Start(); break;
                    case "stop": chronometer.Stop(); break;
                    case "lap": Console.WriteLine(chronometer.Lap()); break;
                    case "laps": Console.WriteLine(chronometer.GetLaps()); break;
                    case "time": Console.WriteLine(chronometer.GetTime()); break;
                    case "reset": chronometer.Reset(); break;
                }
            }
        }
    }
}
