using MongoDB.Bson;
using MongoDB.Driver;
using WorkoutApplication.Models;

namespace WorkoutApplication
{
    public class Database
    {
        MongoClient dbClient = new MongoClient();

        private IMongoDatabase GetDb()
        {
            return dbClient.GetDatabase("WorkoutDB");
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            return await GetDb().GetCollection<Member>("Members")
                .Find(b => true)
                .ToListAsync();
        }

        public async Task SaveMember(Member member)
        {
            await GetDb().GetCollection<Member>("Members")
                .InsertOneAsync(member);
        }

        public async Task<Member> GetMember(string id)
        {
            ObjectId _id = new ObjectId(id);

            var member = await GetDb().GetCollection<Member>("Members")
                .Find(b => b.Id == _id)
                .SingleOrDefaultAsync();

            return member;
        }

        public async Task DeleteMember(string id)
        {
            ObjectId _id = new ObjectId(id);

            await GetDb().GetCollection<Member>("Members")
                .DeleteOneAsync(b => b.Id == _id);
        }

        public async Task ShowMember(string id)
        {
            ObjectId _id = new ObjectId(id);

            await GetDb().GetCollection<Member>("Members")
                .Find(b => b.Id == _id)
                .SingleOrDefaultAsync();
        }

        public async Task EditMember(string id, Member member)
        {
            ObjectId _id = new ObjectId(id);
            
            await GetDb().GetCollection<Member>("Members")
                .ReplaceOneAsync(b => b.Id == _id, member);
        }
    }
}
