using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class IstoricParticipariManager: IIstoricParticipariManager
    {
        private readonly IIstoricParticipariRepository istoricParticipariRepository;
        public IstoricParticipariManager(IIstoricParticipariRepository istoricParticipariRepository)
        {
            this.istoricParticipariRepository = istoricParticipariRepository;
        }
        public List<IstoricModel> GetIstoriceSpCompProba()
        {
            var istorice = istoricParticipariRepository
                .GetIstoriceIQueryable()
                .Select(x => new IstoricModel
                {
                    TalentatNevoiasId = x.TalentatNevoiasId,
                    TalentatNevoiasName = x.TalentatNevoias.NumeNevoias,
                    TalentatNevoiasPrenume = x.TalentatNevoias.PrenumeNevoias,
                    NumeCompetitie = x.Competitie.NumeCompetitie,
                    NumeProba = x.Proba.NumeProba,
                    LocClasament = x.LocClasament,


                })
                .OrderBy(x => x.NumeCompetitie)
                .ToList();
            return istorice;
        }

        public List<IstoricIstModel> GetIstoricByIdSp(int id)
        {
            var istoric = istoricParticipariRepository
                .GetIstoricPrComp()
                .Where(x => x.TalentatNevoiasId == id)
                .Select(x => new IstoricIstModel
                {
                    NumeProba = x.Proba.NumeProba,
                    NumeCompetitie = x.Competitie.NumeCompetitie,
                    DataStart = x.Competitie.DataStart,
                    DataFinal = x.Competitie.DataFinal,
                    LocClasament = x.LocClasament,
                    TimpObtinut = x.TimpObtinut,
                    Medaliat = x.Medaliat
                    
                })
                .OrderBy(x=>x.NumeCompetitie)
                .ToList();
            return istoric;
        }

        public List<IstoricBestOfModel> GetBestOfcByIdSp(int id)
        {
            var istorice = istoricParticipariRepository
                .GetIstoricPrComp()
                .Where(i => i.TalentatNevoiasId == id)
                .GroupBy(i => i.Proba.NumeProba)
                .Select(i => new IstoricBestOfModel
                {
                    NumeProba = i.Key,
                    TimpObtinut = i.Min(t => t.TimpObtinut)
                })
                .ToList();
            return istorice;
        }

    }
}
