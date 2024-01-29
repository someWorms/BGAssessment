using ANPR.Infrastructure.Globals;
using ANPR.Services;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace ANPR
{
    public partial class ANRP_Service : ServiceBase
    {
        DirectoryWatcher watcher;
        public ANRP_Service()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json", optional: false)
                .Build();

            Config.DbConnection = configuration["DatabaseConnection"];
            Config.FolderPath = configuration["ANRPFolderPath"];

            watcher = new DirectoryWatcher();
            Thread watcherThread = new Thread(new ThreadStart(watcher.StartWatch));
            watcherThread.Start();
        }

        protected override void OnStop()
        {
            watcher.StopWatch();
        }

        [Conditional("DEBUG_SERVICE")]
        private static void DebugMode()
        {
            Debugger.Break();
        }
    }
}
