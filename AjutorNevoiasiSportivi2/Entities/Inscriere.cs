namespace AjutorNevoiasiSportivi2.Entities
{
    public class Inscriere
    {
        public int TalentatNevoiasId { get; set; }
        public int AntrenorId { get; set; }
        public DateTime DataStart { get; set; }

        public TalentatNevoias TalentatNevoias { get; set; }
        public Antrenor Antrenor { get; set; }
    }
}
