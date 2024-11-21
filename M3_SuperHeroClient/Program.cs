using M3_SuperHeroClient;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;


var jsonData = new HttpClient().GetStringAsync("http://localhost:5253/api").Result;
var superHeros = JsonConvert.DeserializeObject<IEnumerable<SuperHero>>(jsonData);
foreach (var item in superHeros)
{
    Console.WriteLine(item.Name + " " + item.Power + " " + item.HeroSide);
}

Console.ReadKey();