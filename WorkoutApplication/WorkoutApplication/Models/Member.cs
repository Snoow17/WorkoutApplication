using MongoDB.Bson;

namespace WorkoutApplication.Models
{
    public class Member
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}
