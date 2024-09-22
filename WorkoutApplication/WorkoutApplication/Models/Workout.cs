using MongoDB.Bson;

namespace WorkoutApplication.Models
{
    public class Workout
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Date { get; set; }
    }
}
