using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi.Models.Question
{
    public class UpdateQuestionnaireRequest
    {
        int QuestionnaireId { get; set; }
        List<UpdateQuestionModel> _questions = new List<UpdateQuestionModel>();
    }

    public class UpdateQuestionModel
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
    }
}
