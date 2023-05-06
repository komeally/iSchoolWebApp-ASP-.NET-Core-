namespace iSchoolWebApp.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CourseRootModel
    {
        public string courseID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
