using Foot.Tools;
using Foot.API;
using System.Text.Json;
using Foot.API.Models;
namespace Foot.MsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCall()
        {
            Call call = new Call();
            var url = "https://api.football-data.org/v2/competitions";
            var result = call.GetDataFromApi(url);
            Assert.IsNotNull(result);
            FootCompetitions competitions = JsonSerializer.Deserialize<FootCompetitions>(result);
            Assert.IsNotNull(competitions);
            Assert.IsNotNull(competitions.competitions);
        }
    }
}