namespace AjutorNevoiasiSportivi2.Entities
{
    public class Proba
    {
        public int Id { get; set; }
        public string NumeProba { get; set; }

        public ICollection<IstoricParticipare> IstoricParticipari { get; set; }

    }
}
