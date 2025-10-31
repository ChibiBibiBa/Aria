using Raylib_cs;

namespace Aria.Systems.Clocks
{
    public class Clock
    {
        private float currentValue = 0f;
        private float duration = 0f;
        public bool Finished { get; private set; } = false;
        public bool Ongoing { get; private set; } = false;
        public bool Stopped { get; private set; } = false;
        public Clock(float duration)
        {
            this.duration = duration;
        }

        public void Reset()
        {
            currentValue = 0f;
            Finished = false;
            Ongoing = false;
            Stopped = false;
        }

        public void Update()
        {
            if (Stopped)
            {
                return;
            }
            if (Ongoing && !Finished)
            {
                currentValue += Raylib.GetFrameTime();
            }

            if (currentValue >= duration)
            {
                Ongoing = false;
                Finished = true;
            }
        }

        public delegate void Updater();
        public Updater Start()
        {
            Reset();
            this.Ongoing = true;
            return this.Update;
        }
        public void Stop()
        {
            Stopped = true;
        }
        public void Resume()
        {
            Stopped = false;
        }

    }
}