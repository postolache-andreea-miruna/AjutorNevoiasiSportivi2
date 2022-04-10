namespace AjutorNevoiasiSportivi2.Entities
{
    public class TalentatNevoias
    {
        public int Id { get; set; }
        public char Gen { get; set; }
        public string NumeNevoias { get; set; }
        public string PrenumeNevoias { get; set; }
        public DateTime DataNastere { get; set; }
        public string SportTalent { get; set; }
        public bool DeAjutat { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public Adresa Adresa { get; set; } //pt join
        public ICollection<IstoricParticipare> IstoricParticipari { get; set; }
        public ICollection<Donare> Donari { get; set; }
        public ICollection<Inscriere>Inscrieri { get;set; }

    }
}
