using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<User>().HasData(
                   new User() { UserId = 1, Email = "a@a.es", Password = "123456", FirstName = "Pepe", LastName = "Papa", Role = Role.User }
            );
            var fileName = "./Helpers/Questions.json";
            var questionList = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<List<Question>>(questionList);
            var i = 1;
            foreach (var item in data)
            {
                var question = item as Question;
                modelBuilder.Entity<Question>().HasData(
                    new Question() { QuestionId = i, Label = question.Label, AnswerContent = question.AnswerContent, AnswerType = question.AnswerType, Choices = question.Choices }
                );
                i++;
            }
        }
    }
}
