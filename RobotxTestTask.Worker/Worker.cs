using RobotxTestTask.Core.Services;

namespace RobotxTestTask.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ExcelDataImportService dataImportService;
        public Worker(ExcelDataImportService dataImportService)
        {
            this.dataImportService = dataImportService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await InitDataSearch();
            await WatcherDataSearch();
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000, stoppingToken);
            }
            await Task.CompletedTask;
        }

        private async Task InitDataSearch()
        {
            var existedFiles = Directory.GetFiles("data");
            foreach (var file in existedFiles)
            {
                await dataImportService.ImportData(file);
            }
        }

        private async Task WatcherDataSearch()
        {
            using var watcher = new FileSystemWatcher("data");
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;
        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            await dataImportService.ImportData(e.FullPath);
        }
    }
}
