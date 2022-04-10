namespace AjutorNevoiasiSportivi2.Entities
{
    public class Competitie
    {
        public int Id { get; set; }
        public string NumeCompetitie { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataFinal { get; set; }
        public int Importanta { get; set; }

        public ICollection<IstoricParticipare> IstoricParticipari { get; set; }
    }
}
