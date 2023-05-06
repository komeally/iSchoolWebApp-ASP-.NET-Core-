namespace iSchoolWebApp.Models;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class OlderRootModel
{
    public List<Older> older { get; set; }
}
public class Older
{
    public string date { get; set; }
    public string title { get; set; }
    public string description { get; set; }
}

