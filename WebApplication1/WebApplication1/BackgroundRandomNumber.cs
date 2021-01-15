using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1
{

    internal class BackgroundRandomNumberState
    {
        public static sbyte RandomNumber = 0;
    }

    public class BackgroundRandomNumber : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private Random rand;

        public BackgroundRandomNumber(ILogger<BackgroundRandomNumber> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Arkaplan Servisi Başlatılıyor.");
            rand = new Random();
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));//her 1 saniye de 1 kere dowork çalıştır.

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            BackgroundRandomNumberState.RandomNumber = Convert.ToSByte(rand.Next(-127, 127));
            _logger.LogInformation("Arkaplan Servisi Çalışıyor.");
            _logger.LogInformation($"Rasgele Sayı Üretildi. {BackgroundRandomNumberState.RandomNumber}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Arkaplan Servisi Durduruldu.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

       
    }
}
