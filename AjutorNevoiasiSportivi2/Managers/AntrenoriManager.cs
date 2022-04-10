using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class AntrenoriManager: IAntrenoriManager
    {
        private readonly IAntrenoriRepository antrenoriRepository;
        public AntrenoriManager(IAntrenoriRepository antrenoriRepository)
        {
            this.antrenoriRepository = antrenoriRepository;
        }

        public List<AntrenorModel> GetAntrenori()
        {
            var antrenori = antrenoriRepository.GetAntrenoriSport()
                .Select(x=> new AntrenorModel
                {
                    Id = x.Id,
                    NumeAntrenor = x.NumeAntrenor,
                    PrenumeAntrenor = x.PrenumeAntrenor,
                    NumeSport = x.Sport.NumeSport
                })
                .OrderBy(x => x.NumeSport)
                .ToList();
            return antrenori;
        }
        public List<GetAntrenorModel> GetAntrenorById(int id)
        {
            var antrenor = antrenoriRepository
                .GetAntrenoriSportClub()
                .Where(x=>x.Id == id)
                .Select(x => new GetAntrenorModel
                {
                    NumeAntrenor = x.NumeAntrenor,
                    PrenumeAntrenor = x.PrenumeAntrenor,
                    Gen = x.Gen,
                    AniExperienta = x.AniExperienta,
                    NumeSport = x.Sport.NumeSport,
                    NumeClub = x.Club.NumeClub
                }).ToList();
            return antrenor;
        }
        public List<ClubAntrenorModel> GetAntrenorByIdClub(int id)
        {
            var antrenori = antrenoriRepository
                .GetAntrenoriSport()
                .Where(x=>x.ClubId == id)
                .Select(x=> new ClubAntrenorModel
                {
                    Id = x.Id,
                    NumeAntrenor=x.NumeAntrenor,
                    PrenumeAntrenor = x.PrenumeAntrenor,
                    AniExperienta=x.AniExperienta,
                    NumeSport = x.Sport.NumeSport
                })
                .OrderBy(x => x.NumeSport)
                .ToList();
            return antrenori;
        }
        public List<SportAntrenorModel> GetAntrenorByIdSport(int id)
        {
            var antrenori = antrenoriRepository
                .GetAntrenoriClub()
                .Where(x => x.SportId == id)
                .Select(x => new SportAntrenorModel
                {
                    Id = x.Id,
                    NumeAntrenor = x.NumeAntrenor,
                    PrenumeAntrenor = x.PrenumeAntrenor,
                    AniExperienta = x.AniExperienta,
                    NumeClub = x.Club.NumeClub
                })
                .OrderBy(x => x.NumeClub)
                .ToList();
            return antrenori;
        }

        public void Delete(int id)
        {
            var antrenor = antrenoriRepository
                .GetAntrenoriIQueriable()
                .FirstOrDefault(x => x.Id == id);
            antrenoriRepository.Delete(antrenor);
        }

        public void Create(CreareAntrenorModel creareAntrenorModel)
        {
            var newAntrenor = new Antrenor
            {
                NumeAntrenor = creareAntrenorModel.NumeAntrenor,
                PrenumeAntrenor = creareAntrenorModel.PrenumeAntrenor,
                Gen = creareAntrenorModel.Gen,
                AniExperienta = creareAntrenorModel.AniExperienta,
                SportId = creareAntrenorModel.SportId,
                ClubId = creareAntrenorModel.ClubId
            };
            antrenoriRepository.Create(newAntrenor);
        }

        public void Update(AntrenorUpdateModel antrenorUpdateModel)
        {
            var antrenor = antrenoriRepository
                .GetAntrenoriIQueriable()
                .FirstOrDefault(x=>x.Id == antrenorUpdateModel.Id);
            if (antrenor == null)
                return;
            antrenor.NumeAntrenor = antrenorUpdateModel.NumeAntrenor;
            antrenor.AniExperienta = antrenorUpdateModel.AniExperienta;
            antrenoriRepository.Update(antrenor);
        }
    }
}
