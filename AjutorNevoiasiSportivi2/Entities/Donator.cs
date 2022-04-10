namespace AjutorNevoiasiSportivi2.Entities
{
    public class Donator
    {
        public int Id { get; set; }
        public string NumeDonator { get; set; }
        public string PrenumeDonator { get; set; }
        public string Pseudonim { get; set; }
        public string Email { get; set; }

        public ICollection<Donare> Donari { get; set; }
    }
}
