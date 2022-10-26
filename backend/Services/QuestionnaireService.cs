using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Question;

namespace WebApi.Services
{
    public interface IQuestionnaireService
    {
        Questionnaire GetById(int id);
        
        void Update(UpdateQuestionnaireRequest model);
    }
    public class QuestionnaireService : IQuestionnaireService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public QuestionnaireService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Questionnaire GetById(int id)
        {
            var questionnaire = _context.Questionnaire.Find(id);
            if (questionnaire == null) throw new KeyNotFoundException("Questionnaire not found");
            return questionnaire;
        }

        public void Update(UpdateQuestionnaireRequest model)
        {
            var questionnaireMapped = _mapper.Map<Questionnaire>(model);
            var foundQuestionnaire = GetById(questionnaireMapped.QuestionnaireId);

            _mapper.Map(model, foundQuestionnaire);
            _context.Questionnaire.Update(foundQuestionnaire);
            _context.SaveChanges();
        }
    }
    
}
