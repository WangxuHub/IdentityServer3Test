using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiTest
{
    [Route("values")]
    public class ValuesController : ApiController
    {
        private static readonly Random _random = new Random();

        public IEnumerable<string> Get()
        {
            var random = new Random();

            return new[]
            {
            _random.Next(0, 10).ToString(),
            _random.Next(0, 10).ToString()
        };
        }
    }
}