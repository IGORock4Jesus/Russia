using System;
using System.Threading;

namespace Russia.Common
{
	public class Job : IDisposable
    {
        private Thread thread;
        private bool enabled;

		public delegate void JobHandler(int elapsedTime);
		public event JobHandler Processing;

		public int PauseTime { get; set; } = 0;

        public void Start()
		{
			if (enabled)
			{
				return;
			}

            thread = new Thread(StartRendering);
            enabled = true;
            thread.Start();
        }

		public void Stop()
		{
			if (!enabled)
			{
				return;
			}

			enabled = false;
			if (thread.IsAlive)
			{
				thread.Join();
			}
		}

		private void StartRendering()
		{
			int oldTime = Environment.TickCount;
			while (enabled)
			{
				int newTime = Environment.TickCount;
				int elapsedTime = newTime - oldTime;
				oldTime = newTime;

				Processing?.Invoke(elapsedTime);

				Thread.Sleep(PauseTime);
			}
		}

		public void Dispose()
		{
			Stop();
		}
	}
}
