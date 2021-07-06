using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace TeleprompterConsole
{
    /// <summary>
    /// Class for setting configuration for the teleprompter instance
    /// </summary>
    internal class TelePrompterConfig
    {
        public int DelayInMilliseconds { get; private set; } = 200;

        /// <summary>
        /// for changing the delay on teleprompter
        /// </summary>
        /// <param name="increment">increase delay by this increment (ms)</param>
        public void UpdateDelay(int increment)  // negative speeds it up!!
        {
            var newDelay = Min(DelayInMilliseconds + increment, 1000);  // will never be greater than 1000ms
            newDelay = Max(newDelay, 20);                               // will never be less than 20ms
            DelayInMilliseconds = newDelay;
        }

        public bool Done { get; private set; }

        /// <summary>
        /// Method to show that config is complete
        /// </summary>
        public void SetDone()
        {
            Done = true;
        }
    }
}
