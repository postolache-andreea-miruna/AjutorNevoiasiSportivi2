namespace AjutorNevoiasiSportivi2.Entities
{
    public class IstoricParticipare
    {
        public int TalentatNevoiasId { get; set; }
        public int CompetitieId { get; set; }
        public int ProbaId { get; set; }
        public int LocClasament { get; set; }
        public int TimpObtinut { get; set; }//secunde

        public bool Medaliat { get; set; }

        public TalentatNevoias TalentatNevoias { get; set; }
        public Competitie Competitie { get; set; }
        public Proba Proba { get; set; }

    }
}
