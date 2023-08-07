using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMemoryCache _memoryCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [ResponseCache(Duration =5)]//�ͻ��˻���
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }

        [HttpGet]
        public async Task<ActionResult<WeatherForecast?>> GetByDateFromCache(string dateTime)
        {
            _logger.LogInformation("��ʼִ��GetByDateFromCache����");
            WeatherForecast? res = await _memoryCache.GetOrCreateAsync(dateTime, async (a) => 
            {
                _logger.LogInformation("�����ݿ��л�ȡ����");
                //a.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);//���Թ���ʱ��
                //a.SlidingExpiration = TimeSpan.FromSeconds(1);//��������ʱ��
                a.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Random.Shared.Next(5,10));//������Թ���ʱ��
                return await Task.Run(() =>
                {
                    return new WeatherForecast
                    {
                        Date = Convert.ToDateTime(dateTime),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    };
                });
            });
            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return res;
            }         
        }
    }
}