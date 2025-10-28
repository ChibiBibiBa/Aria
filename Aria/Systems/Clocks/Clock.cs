using Raylib_cs;

namespace Aria.Systems.Clocks
{
    public class Clock
    {
        private float currentValue = 0f;
        private float duration;
        private bool finished = false;
        private bool ongoing = false;
        public bool Finished { get { return finished; } }
        public bool Ongoing { get { return ongoing; } }
        public Clock(float duration)
        {
            this.duration = duration;
        }

        public void Reset()
        {
            currentValue = 0f;
            finished = false;
            ongoing = false;
        }

        public void Update()
        {
            if (ongoing && !finished)
            {
                currentValue += Raylib.GetFrameTime();
            }

            if (currentValue >= duration)
            {
                ongoing = false;
                finished = true;
            }
        }

        public delegate void Updater();
        public Updater Start()
        {
            Reset();
            this.ongoing = true;
            return this.Update;
        }


    }
}