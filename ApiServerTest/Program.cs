using System.IO;
using System.Collections.Generic;
WebApplication app = WebApplication.Create();
app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

// List<Artifact> relics = new List<Artifact>();
Dictionary<string, Artifact> relics = new Dictionary<string, Artifact>();
relics.Add("Ancient_Crow", new() {Name = "Ancient Crow", Value = 255, DateFound = "1749-05-17"});


app.MapGet("/", Answer);
app.MapGet("/relics",() => {return relics;});
app.MapGet("/relics/{name}",(string name) => 
{
    return relics.ContainsKey(name) ?  Results.Ok(relics[name]) : Results.NotFound();
});
    

app.MapGet("/russianroulette/", () => 
{
    Random gen = new Random();
    string[] names = new string[5];
    names[0] = "alive";
    names[1] = "alive";
    names[2] = "alive";
    names[3] = "alive";
    names[4] = null;
    return names[gen.Next(5)];
});
app.Run();

static string Answer()
{    
    return "trollos";
    
    // return String.Join("",File.ReadAllLines("./testsite/index.html"));
}