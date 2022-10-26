using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WebApi.Entities;

public class Question
{
    [Key]
    public int QuestionId { get; set; }
	public string Label { get; set; }
	public AnswerType AnswerType { get; set; }
	public String AnswerContent { get; set; }
	public String Choices { get; set; }
	public int QuestionnaireId { get; set; }
    public Questionnaire Questionnaire { get; set; }
	public int UserId { get; set; }
}