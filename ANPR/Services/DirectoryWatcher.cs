using ANPR.Infrastructure.Globals;
using ANPR.Persistence.Database;
using ANPR.Services.Interfaces;
using System;
using System.Linq;

namespace ANPR.Services
{
    public class DirectoryWatcher
    {
        private readonly System.Timers.Timer _timer;
        private readonly IFileService _service;
        private DateTime _lastVisited;

        public DirectoryWatcher()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(Watch);

            _service = new FileService(new DatabaseContext());
        }

        private void Watch(object sender, System.Timers.ElapsedEventArgs e)
        {
            _lastVisited = DateTime.Now;

            //get all files in directory, as they can change.
            string[] files = System.IO.Directory.GetFiles(Config.FolderPath, "*.lpr", System.IO.SearchOption.AllDirectories);

            //go through each, verifying if there are new (compared with db)
            foreach (string file in files)
            {
                _service.SaveData(file);
            }

            TimeSpan ts = DateTime.Now.Subtract(_lastVisited);
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(1);

            if (maxWaitTime.Subtract(ts).CompareTo(TimeSpan.Zero) > -1)
                _timer.Interval = maxWaitTime.Subtract(ts).TotalMilliseconds;
            else
                _timer.Interval = 1;

            _timer.Start();
        }

        public void StartWatch()
        {
            _timer.Interval = 1;
            _timer.Start();
        }

        public void StopWatch()
        {
            _timer.Stop();
        }
    }
}
