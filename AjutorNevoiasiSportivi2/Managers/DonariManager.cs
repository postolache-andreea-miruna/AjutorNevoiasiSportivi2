using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class DonariManager: IDonariManager
    {
        private readonly IDonariRepository donariRepository;
        public DonariManager(IDonariRepository donariRepository)
        {
            this.donariRepository = donariRepository;
        }
        public List<DonariNevoiasModel> GetDonareByNevoias(int id)
        {
            var donari = donariRepository
                .GetDonariDonator()
                .Where(x => x.TalentatNevoiasId == id)
                .Select(x => new DonariNevoiasModel
                {
                    Pseudonim = x.Donator.Pseudonim,
                    DataDonatie = x.DataDonatie,
                    ElementDonat = x.ElementDonat,
                    ConfirmarePrimire = x.ConfirmarePrimire
                })
                .OrderByDescending(x=>x.DataDonatie)
                .ToList();
            return donari;
        }
        public List<DonariDonatorModel> GetDonareByDonator(int id)
        {
            var donari = donariRepository
                .GetDonariNevoias()
                .Where(x => x.DonatorId == id)
                .Select(x => new DonariDonatorModel
                {
                    NumeNevoias = x.TalentatNevoias.NumeNevoias,
                    PrenumeNevoias = x.TalentatNevoias.PrenumeNevoias,
                    DataDonatie = x.DataDonatie,
                    ElementDonat = x.ElementDonat,
                    ConfirmarePrimire = x.ConfirmarePrimire
                })
                .OrderByDescending(x => x.DataDonatie)
                .ToList();
            return donari;

        }

        public List<DonariDataDonatie> GetDonareByDataDonatie(DateTime id)
        {
            var donari = donariRepository
                .GetDonariNevoiasDonator()
                .Where(x => x.DataDonatie == id)
                .Select(x => new DonariDataDonatie
                {
                    NumeNevoias = x.TalentatNevoias.NumeNevoias,
                    PrenumeNevoias = x.TalentatNevoias.PrenumeNevoias,
                    Pseudonim = x.Donator.Pseudonim,
                    ElementDonat = x.ElementDonat
                })
                .OrderBy(x => x.ElementDonat)
                .ToList();
            return donari;
        }

    }
}
