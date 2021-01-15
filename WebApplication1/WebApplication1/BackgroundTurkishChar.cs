using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1
{

    internal class BackgroundTurkishCharState
    {
        public static char TurkishChar = 'M';
    }

    public class BackgroundTurkishChar : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        
        private char[] turkishCharList = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'İ', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };
        private Random rand;
        private int randomIndex = 0;
        private bool randomLowerUpper = true;
        

        public BackgroundTurkishChar(ILogger<BackgroundRandomNumber> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Arkaplan Servisi Başlatılıyor.");
            rand = new Random();
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));//her 2 saniye de 1 kere dowork çalıştır.

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            randomIndex = rand.Next(0, 29);
            randomLowerUpper = Convert.ToBoolean(rand.Next(0, 2));
            BackgroundTurkishCharState.TurkishChar = randomLowerUpper ? char.ToUpper(turkishCharList[randomIndex]) : char.ToLower(turkishCharList[randomIndex]);
            _logger.LogInformation("Arkaplan Servisi Çalışıyor.");
            _logger.LogInformation($"Rasgele Türkçe Karakter Üretildi. {BackgroundTurkishCharState.TurkishChar}");
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
