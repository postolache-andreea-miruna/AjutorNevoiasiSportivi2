namespace AjutorNevoiasiSportivi2.Entities
{
    public class Donare
    {
        public int DonatorId { get; set; }
        public int TalentatNevoiasId { get; set; }
        public DateTime DataDonatie { get; set; }
        public string ElementDonat { get; set; }
        public string? ConfirmarePrimire { get; set; } 

        public Donator Donator { get; set; }
        public TalentatNevoias TalentatNevoias { get; set; }
    }
}
