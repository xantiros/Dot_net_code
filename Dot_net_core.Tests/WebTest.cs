using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dot_net_core.Tests
{
    [TestClass]
    class WebTest
    {
        public HttpClient httpClient;

        [TestInitialize]
        public void Setup()
        {
            httpClient = new HttpClient();
        }

        [TestMethod]
        public async Task http_testAsync()
        {
            //arrange
            //acct
            var response = await httpClient.GetAsync("http://httpstat.us/204");
            //assert
            
            //response.StatusCode();
        }
    }
}
