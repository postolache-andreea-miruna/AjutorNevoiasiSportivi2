using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class CluburiManager: ICluburiManager
    {
        private readonly ICluburiRepository cluburiRepository;
        public CluburiManager(ICluburiRepository cluburiRepository)
        {
            this.cluburiRepository = cluburiRepository;
        }

        public List<CluburiModel> GetCluburi()
        {
            var cluburi = cluburiRepository.GetCluburiIQueryable()
                .Select(x => new CluburiModel
                {
                    Id = x.Id,
                    NumeClub = x.NumeClub
                })
                .OrderBy(x=>x.Id)
                .ToList();
            return cluburi;
        }

        public List<GetCluburiModel> GetClubuiInfo(int id)
        {
            var club = cluburiRepository.GetCluburiIQueryable()
                .Where(x => x.Id == id)
                .Select(x=> new GetCluburiModel
                {
                    NumeClub = x.NumeClub,
                    Email = x.Email
                }).ToList();
            return club;
        }

        public void Delete(int id)
        {
            var club = cluburiRepository.GetCluburiIQueryable()
                .FirstOrDefault(x => x.Id == id);
            cluburiRepository.Delete(club);
        }
        public void Create(GetCluburiModel getCluburiModel)
        {
            var newClub = new Club
            {
                NumeClub = getCluburiModel.NumeClub,
                Email = getCluburiModel.Email
            };
            cluburiRepository.Create(newClub);
        }
        public void Update(ClubUpdateModel clubUpdateModel)
        {
            var club = cluburiRepository.GetCluburiIQueryable()
                .First(x => x.Id == clubUpdateModel.Id);
            club.Email = clubUpdateModel.Email;
            cluburiRepository.Update(club);
        }
    }

}
