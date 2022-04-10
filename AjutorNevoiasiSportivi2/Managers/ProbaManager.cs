using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class ProbaManager:IProbaManager
    {
        private readonly IProbaRepository probaRepository;
        
        public ProbaManager(IProbaRepository probaRepository)
        {
            this.probaRepository = probaRepository;
        }
        public List<ProbaModel> GetProbe()
        {
            var probe = probaRepository.GetProbeIQueryable()
                .Select(x => new ProbaModel
                {
                    Id = x.Id,
                    NumeProba = x.NumeProba
                })
                .OrderBy(x=>x.Id)
                .ToList();
            return probe;
        }

        public void Delete(int id)
        {
            var proba = probaRepository.GetProbeIQueryable()
                .FirstOrDefault(x => x.Id == id);
            if (proba == null)
            {
                return;
            }
            probaRepository.Delete(proba);
                
        }

        public void Create(CreareProbModel creareProbModel)
        {
            var newProba = new Proba
            {
                NumeProba = creareProbModel.NumeProba
            };
            probaRepository.Create(newProba);
        }

        public void Update(ProbaUpdateModel probaUpdateModel)
        {
            var probe = probaRepository.GetProbeIQueryable()
                .FirstOrDefault(x=>x.Id == probaUpdateModel.Id);
            if (probe == null)
            { return; }
            probe.NumeProba = probaUpdateModel.NumeProba;
            probaRepository.Update(probe);
        }
    }

}
