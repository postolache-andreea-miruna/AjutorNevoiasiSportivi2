namespace AjutorNevoiasiSportivi2.Entities
{
    public class Adresa
    {
        public int Id { get; set; }
        public string NumeStrada { get; set; }
        public int NumarBloc { get; set; }
        public int NumarAp { get; set; }
        public string CodPostal { get; set; }

        public int TalentatNevoiasId { get; set; } //FK
        public TalentatNevoias TalentatNevoias { get; set; }//PT JOIN
    }
}
