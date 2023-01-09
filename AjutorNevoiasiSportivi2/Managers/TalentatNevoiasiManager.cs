using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class TalentatNevoiasiManager: ITalentatNevoiasiManager
    {
        private readonly ITalentatNevoiasiRepository talentatNevoiasiRepository;
        public TalentatNevoiasiManager(ITalentatNevoiasiRepository talentatNevoiasiRepository )
        {
            this.talentatNevoiasiRepository = talentatNevoiasiRepository;
        }

        public List<TalentatNevoiasiModel> GetTalentatNevoiasi()
        {
            var nevoiasi = talentatNevoiasiRepository.GetNevoiasiIQueryable()
                .Select(x=> new TalentatNevoiasiModel
                {
                    Id = x.Id,
                    NumeNevoias = x.NumeNevoias,
                    PrenumeNevoias=x.PrenumeNevoias,
                    SportTalent = x.SportTalent,
                    DeAjutat = x.DeAjutat,
                    Email = x.Email,
                    Telefon = x.Telefon
                })
                .OrderBy(x => x.Id)
                .ToList();
            return nevoiasi;
        }

        public List<GetTalentNevoiasiModel> GetNevoiasiInfo(int id)
        {
            var nevoiasi = talentatNevoiasiRepository.GetNevoiasiIQueryable()
                .Where(x => x.Id == id)
                .Select(x => new GetTalentNevoiasiModel
                {
                    Gen = x.Gen,
                    NumeNevoias = x.NumeNevoias,
                    PrenumeNevoias = x.PrenumeNevoias,
                    DataNastere = x.DataNastere,
                    SportTalent = x.SportTalent,
                    Email = x.Email,
                    Telefon = x.Telefon
                })
                .ToList();
            return nevoiasi;
        }

        public void Delete(int id)
        {
            var nevoias = talentatNevoiasiRepository.GetNevoiasiIQueryable()
                .FirstOrDefault(x => x.Id == id);
            if (nevoias == null)
                return;
            talentatNevoiasiRepository.Delete(nevoias);
        }
        public void Create(CreareNevoiasModel creareNevoiasModel)
        {
            var newNevoias = new TalentatNevoias
            {
                Gen = creareNevoiasModel.Gen,
                NumeNevoias = creareNevoiasModel.NumeNevoias,
                PrenumeNevoias = creareNevoiasModel.PrenumeNevoias,
                DataNastere = creareNevoiasModel.DataNastere,
                SportTalent = creareNevoiasModel.SportTalent,
                DeAjutat = creareNevoiasModel.DeAjutat,
                Email = creareNevoiasModel.Email,
                Telefon = creareNevoiasModel.Telefon
            };
            talentatNevoiasiRepository.Create(newNevoias);
        }

        public void Update(NevoiasUpdateModel nevoiasUpdateModel)
        {
            var nevoias = talentatNevoiasiRepository.GetNevoiasiIQueryable()
                .FirstOrDefault(x=>x.Id == nevoiasUpdateModel.Id);
            if (nevoias == null)
                return;
            nevoias.NumeNevoias = nevoiasUpdateModel.NumeNevoias;
            nevoias.DeAjutat = nevoiasUpdateModel.DeAjutat;
            nevoias.Email = nevoiasUpdateModel.Email;
            nevoias.Telefon = nevoiasUpdateModel.Telefon;
            talentatNevoiasiRepository.Update(nevoias);
        }

    }

}
