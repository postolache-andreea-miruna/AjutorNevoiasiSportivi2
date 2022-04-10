using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class AdreseManager: IAdreseManager
    {
        private readonly IAdreseRepository adreseRepository;
        public AdreseManager(IAdreseRepository adreseRepository)
        {
            this.adreseRepository = adreseRepository;
        }

        public List<AdreseModel> GetAdrese()
        {
            var adrese = adreseRepository.GetAdreseNevIQueryable()
                .Select(x=>new AdreseModel
                {
                    Id = x.Id,
                    NumeStrada = x.NumeStrada,
                    CodPostal = x.CodPostal,
                    TalentatNevoiasNume = x.TalentatNevoias.NumeNevoias,
                    TalentatNevoiasPrenume = x.TalentatNevoias.PrenumeNevoias
                })
                .OrderBy(x=>x.Id)
                .ToList();
            return adrese;
        }
        public List<GetAdresaModel> GetAdreseInfo(int id)
        {
            var adresa = adreseRepository.GetAdreseNevIQueryable()
                .Where(x => x.Id == id)
                .Select(x=> new GetAdresaModel
                {
                    NumeStrada = x.NumeStrada,
                    NumarBloc = x.NumarBloc,
                    NumarAp = x.NumarAp,
                    CodPostal = x.CodPostal,
                    TalentatNevoiasNume = x.TalentatNevoias.NumeNevoias,
                    TalentatNevoiasPrenume = x.TalentatNevoias.PrenumeNevoias
                })
                .ToList();
            return adresa;
        }
        public void Delete(int id)
        {
            var adresa = adreseRepository.GetAdreseIQueryable()
                 .FirstOrDefault(x => x.Id == id);
            if (adresa == null)
            { return; }
            adreseRepository.Delete(adresa);
        }
        public void Create(CreareAdresaModel creareAdresaModel)
        {
            var newAdresa = new Adresa
            {
                NumeStrada = creareAdresaModel.NumeStrada,
                NumarBloc = creareAdresaModel.NumarBloc,
                NumarAp = creareAdresaModel.NumarAp,
                CodPostal = creareAdresaModel.CodPostal,
                TalentatNevoiasId = creareAdresaModel.TalentatNevoiasId
            };
            adreseRepository.Create(newAdresa);
        }
        public void Update(AdresaUpdateModel adresaUpdateModel)
        {
            var adresa = adreseRepository.GetAdreseIQueryable()
                .FirstOrDefault(x=>x.Id == adresaUpdateModel.Id);
            if (adresa == null)
            {
                return;
            }
            adresa.NumeStrada= adresaUpdateModel.NumeStrada;
            adresa.NumarBloc= adresaUpdateModel.NumarBloc;
            adresa.NumarAp= adresaUpdateModel.NumarAp;
            adresa.CodPostal= adresaUpdateModel.CodPostal;
            adreseRepository.Update(adresa);
        }
    }
}
