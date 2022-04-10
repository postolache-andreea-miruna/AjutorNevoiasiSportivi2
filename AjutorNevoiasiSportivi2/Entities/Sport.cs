namespace AjutorNevoiasiSportivi2.Entities
{
    public class Sport
    {
        public int Id { get; set; }
        public string NumeSport { get; set; }

        public ICollection<Antrenor> Antrenori { get; set; }   
    }
}
