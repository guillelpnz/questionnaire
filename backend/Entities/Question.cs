using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class Question
{
    [Key]
    public int QuestionId { get; set; }
	public string Label { get; set; }
	public AnswerType AnswerType { get; set; }
	public String AnswerContent { get; set; }
	public String Choices { get; set; }
}