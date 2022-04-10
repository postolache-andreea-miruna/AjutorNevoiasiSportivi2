using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using AjutorNevoiasiSportivi2.Repositories;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class DonatoriManager: IDonatoriManager
    {
        private readonly IDonatoriRepository donatoriRepository;

        public DonatoriManager(IDonatoriRepository donatoriRepository)
        {
            this.donatoriRepository = donatoriRepository;
        }

        public List<DonatorModel> GetDonatori()
        {
            var donatori = donatoriRepository.GetDonatoriIQueryable()
                .Select(x=> new DonatorModel
                {
                    Id = x.Id,
                    Pseudonim = x.Pseudonim
                })
                .OrderBy(x=>x.Id)
                .ToList();
            return donatori;
        }

        public List<GetDonatorModel> GetDonatorInfo(int id)
        {
            var donatori = donatoriRepository.GetDonatoriIQueryable()
                .Where(x=>x.Id == id)
                .Select(x => new GetDonatorModel
                {
                    NumeDonator = x.NumeDonator,
                    PrenumeDonator = x.PrenumeDonator,
                    Pseudonim = x.Pseudonim,
                    Email = x.Email
                }).ToList();
            return donatori;
        }

        public void Delete(int id)
        {
            var donator = donatoriRepository.GetDonatoriIQueryable()
                .FirstOrDefault(x => x.Id == id);
            donatoriRepository.Delete(donator);
        }

        public void Create(GetDonatorModel getDonatorModel)
        {
            var newDonator = new Donator
            {
                NumeDonator = getDonatorModel.NumeDonator,
                PrenumeDonator = getDonatorModel.PrenumeDonator,
                Pseudonim = getDonatorModel.Pseudonim,
                Email = getDonatorModel.Email
            };
            if (newDonator == null)
                return;
            donatoriRepository.Create(newDonator);
        }

        public void Update(DonatorUpdateModel donatorUpdateModel)
        {
            var donator = donatoriRepository.GetDonatoriIQueryable()
                .FirstOrDefault(x => x.Id == donatorUpdateModel.Id);
            if (donator == null)
                return;
            donator.NumeDonator = donatorUpdateModel.NumeDonator;
            donator.Email = donatorUpdateModel.Email;
            donatoriRepository.Update(donator);
        }
    }
}
