using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_Processing
{
    public class Chronometer : IChronometer
    {
        private List<string> _laps;
        private Stopwatch _stopwatch;

        public Chronometer()
        {
            this._laps = new List<string>();
            this._stopwatch = new Stopwatch();
        }
        public string GetTime => _stopwatch.Elapsed.ToString("mm\\:ss\\.ff");

        public List<string> Laps => this._laps;

        public string Lap()
        {
            string currentLap = GetTime;
            this._laps.Add(currentLap);
            return currentLap;
        }

        public void Reset()
        {
            this._stopwatch.Stop();
            this._stopwatch.Reset();
            this._laps.Clear();
        }

        public void Start()
        {
            this._stopwatch.Start();

        }

        public string Time()
        {
            return GetTime;
        }

        public void Stop()
        {
            this._stopwatch.Stop();
        }
   
    }
}
