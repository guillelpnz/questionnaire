using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Question;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionnaireController : Controller
    {
        private IQuestionnaireService _questionnaireService;
        private IMapper _mapper;

        public QuestionnaireController(
            IQuestionnaireService questionnaireService,
            IMapper mapper)
        {
            _questionnaireService = questionnaireService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var questionnaire = _questionnaireService.GetById(id);
            return Ok(questionnaire);
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateQuestionnaireRequest model)
        {
            _questionnaireService.Update(model);
            return Ok(new { message = "User updated" });
        }
    }
}
