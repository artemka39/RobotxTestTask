using ReobotxTestTask.Core.Services;
using System.Timers;

namespace RobotxTestTask.Worker
{
    public class Worker : BackgroundService
    {
        private readonly DataImportService dataImportService;
        public Worker(DataImportService dataImportService)
        {
            this.dataImportService = dataImportService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var watcher = new FileSystemWatcher("data");
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000, stoppingToken);
            }
            await Task.CompletedTask;
        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            await dataImportService.ImportData(e.FullPath);
        }
    }
}
