using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Questionnaire
    {
        [Key]
        public int QuestionnaireId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        List<Question> Questions { get; set; }
    }
}
