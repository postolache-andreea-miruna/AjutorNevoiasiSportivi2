namespace AjutorNevoiasiSportivi2.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string NumeClub { get; set; }
        public string Email { get; set; }

        public ICollection<Antrenor> Antrenori { get; set; }

    }
}
