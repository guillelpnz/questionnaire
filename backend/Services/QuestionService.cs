namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Models.Question;

public interface IQuestionService
{
    IEnumerable<Question> GetAll();
    Question GetById(int id);
    void Create(CreateQuestionRequest model);
    void Update(int id, UpdateQuestionRequest model);
    void Delete(int id);
}

public class QuestionService : IQuestionService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public QuestionService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Question> GetAll()
    {
        return _context.Questions;
    }

    public Question GetById(int id)
    {
        return getQuestion(id);
    }

    public void Create(CreateQuestionRequest model)
    {

        // map model to new user object
        var question = _mapper.Map<Question>(model);

        // save user
        _context.Questions.Add(question);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateQuestionRequest model)
    {
        var user = getQuestion(id);

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Questions.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var question = getQuestion(id);
        _context.Questions.Remove(question);
        _context.SaveChanges();
    }

    // helper methods

    private Question getQuestion(int id)
    {
        var question = _context.Questions.Find(id);
        if (question == null) throw new KeyNotFoundException("Question not found");
        return question;
    }
}