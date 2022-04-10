using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class InscriereManager: IInscriereManager
    {
        private readonly IInscriereRepository inscriereRepository;
        public InscriereManager(IInscriereRepository inscriereRepository)
        {
            this.inscriereRepository = inscriereRepository;
        }

        public List<InscriereNevoiasModel> GetInscriereByIdNevoias(int id)
        {
            var inscrieri = inscriereRepository
                .GetInscriereNevAntrCl()
                .Where(x => x.TalentatNevoiasId == id)
                .Select(x => new InscriereNevoiasModel
                {
                   /*NumeNevoias = x.TalentatNevoias.NumeNevoias,
                   PrenumeNevoias = x.TalentatNevoias.PrenumeNevoias,*/
                   NumeAntrenor = x.Antrenor.NumeAntrenor,
                   PrenumeAntrenor = x.Antrenor.PrenumeAntrenor,
                   NumeClub = x.Antrenor.Club.NumeClub,
                   DataStart = x.DataStart
                })
                .OrderByDescending(x => x.DataStart)
                .ToList();
            return inscrieri;

        }
        public List <InscriereAntrenorModel> GetInscriereByIdAntrenor(int id)
        {
            var inscrieri = inscriereRepository
                .GetInscriereNev()
                .Where(x => x.AntrenorId == id)
                .Select(x => new InscriereAntrenorModel
                {
                    NumeNevoias = x.TalentatNevoias.NumeNevoias,
                    PrenumeNevoias = x.TalentatNevoias.PrenumeNevoias,
                    DataNastere = x.TalentatNevoias.DataNastere,
                    Email = x.TalentatNevoias.Email,
                    Telefon = x.TalentatNevoias.Telefon,
                    DataStart = x.DataStart
                })
                .OrderByDescending(x => x.DataStart)
                .ToList();
            return inscrieri;
                
        }
    }
}
