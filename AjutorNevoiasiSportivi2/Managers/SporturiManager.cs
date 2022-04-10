using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class SporturiManager: ISporturiManager
    {
        private readonly ISporturiRepository sporturiRepository;

        public SporturiManager(ISporturiRepository sporturiRepository)
        {
            this.sporturiRepository = sporturiRepository;
        }

        public List <SportModel> GetSporturi()
        {
            var sporturi = sporturiRepository.GetSporturiIQueryable()
                .Select(s => new SportModel
                {
                    Id = s.Id,
                    NumeSport = s.NumeSport
                })
                .OrderBy(s=>s.Id)
                .ToList();
            return sporturi;

        }

        public void Delete(int id)
        {
            var sport = sporturiRepository.GetSporturiIQueryable()
                .FirstOrDefault(x => x.Id == id);
            sporturiRepository.Delete(sport);
        }
        public void Create(CreareSportModel creareSportModel)
        {
            var newSport = new Sport
            {
                NumeSport = creareSportModel.NumeSport
            };
            sporturiRepository.Create(newSport);
        }

        public void Update(SportModel sportModel)
        {
            var sport = sporturiRepository.GetSporturiIQueryable()
                .FirstOrDefault(x => x.Id == sportModel.Id);
            sport.NumeSport = sportModel.NumeSport;
            sporturiRepository.Update(sport);
        }
    }
}
