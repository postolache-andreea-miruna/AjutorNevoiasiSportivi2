using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IDonariManager
    {
        List<DonariNevoiasModel> GetDonareByNevoias(int id);
        List<DonariDonatorModel> GetDonareByDonator(int id);
        List<DonariDataDonatie> GetDonareByDataDonatie(DateTime id);
    }
}
