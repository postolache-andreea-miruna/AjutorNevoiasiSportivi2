using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class CompetitiiManager :ICompetitiiManager
    {
        private readonly ICompetitiiRepository competitiiRepository;
        public CompetitiiManager(ICompetitiiRepository competitiiRepository)
        {
            this.competitiiRepository = competitiiRepository;
        }
        public List<CompetitieModel> GetCompetitii()
        {
            var competitii = competitiiRepository.GetCompetitiiIQueryable()
                .Select(x => new CompetitieModel
                {
                    Id=x.Id,
                    NumeCompetitie = x.NumeCompetitie
                })
                .OrderBy(x => x.Id)
                .ToList();
            return competitii;
        }

        public List<GetCompetitieModel> GetCompetitiiInfo(int id)
        {
            var competitie = competitiiRepository.GetCompetitiiIQueryable()
                .Where(x => x.Id == id)
                .Select(x => new GetCompetitieModel
                {
                    NumeCompetitie = x.NumeCompetitie,
                    DataStart = x.DataStart,
                    DataFinal = x.DataFinal,
                    Importanta = x.Importanta
                }).ToList();
            return competitie;
        }
        public void Delete(int id)
        {
            var competitie = competitiiRepository.GetCompetitiiIQueryable()
                .FirstOrDefault(x => x.Id == id);
            if (competitie == null)
            {
                return;
            }
            competitiiRepository.Delete(competitie);
        }

        public void Create(CreareCompModel creareCompModel)
        {
            var newCompetitie = new Competitie
            {
                NumeCompetitie = creareCompModel.NumeCompetitie,
                DataStart = creareCompModel.DataStart,
                DataFinal = creareCompModel.DataFinal,
                Importanta = creareCompModel.Importanta
            };
            competitiiRepository.Create(newCompetitie);
        }

        public void Update(CompetitieUpdateModel competitieUpdateModel)
        {

            var competitie = competitiiRepository.GetCompetitiiIQueryable()
                .FirstOrDefault(x => x.Id == competitieUpdateModel.Id);
            if (competitie == null)
            { 
                return;
            }
            
            competitie.DataStart = competitieUpdateModel.DataStart;
            competitie.DataFinal = competitieUpdateModel.DataFinal;
            competitiiRepository.Update(competitie);
            
        }
    }
}
