using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebMerchant.Merchant.Contracts;

namespace WebMerchant.Web.Controllers
{
    [Route("api/[controller]")]
    public class GoodsController : Controller
    {
        private readonly IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm",
            "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                                                          {
                                                              DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                                                              TemperatureC = rng.Next(-20, 55),
                                                              Summary = Summaries[rng.Next(Summaries.Length)]
                                                          });
        }

        [HttpPost("[action]")]
        public object WeatherForecasts2([FromBody] TableState tableState)
        {
            int count = 0;
            var data = _goodsService.GetGoods(tableState.page, tableState.pageLen,ref count);
            return new {data, count};

        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }

    public class TableState
    {
        public int pageLen { get; set; }
        public int count { get; set; }
        public int page { get; set; }
        public string url { get; set; }
    }
}