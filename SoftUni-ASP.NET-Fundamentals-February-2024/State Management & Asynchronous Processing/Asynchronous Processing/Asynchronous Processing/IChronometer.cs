using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_Processing
{
    public interface IChronometer
    {
        public string GetTime { get; }

        public List<string> Laps { get; }

        public void Start();

        public void Stop();

        public string Lap();

        public void Reset();


    }
}
