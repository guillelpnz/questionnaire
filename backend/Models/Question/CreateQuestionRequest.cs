namespace WebApi.Models.Question;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateQuestionRequest
{
    [Required]
    public string Label { get; set; }

    [Required]
    public AnswerType AnswerType { get; set; }

    [Required]
    public String AnswerContent { get; set; }

    [Required]
    public String Choices { get; set; }
}