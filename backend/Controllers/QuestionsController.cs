using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;
using WebApi.Controllers;
using WebApi.Services;
using AutoMapper;
using WebApi.Models.Question;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    private IQuestionService _questionService;
    private IMapper _mapper;

    public QuestionsController(
        IQuestionService questionService,
        IMapper mapper)
    {
        _questionService = questionService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _questionService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _questionService.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(CreateQuestionRequest model)
    {
        _questionService.Create(model);
        return Ok(new { message = "User created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateQuestionRequest model)
    {
        _questionService.Update(id, model);
        return Ok(new { message = "User updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _questionService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}