namespace AjutorNevoiasiSportivi2.Entities
{
    public class Antrenor
    {
        public int Id { get; set; }
        public string NumeAntrenor { get; set; }
        public string PrenumeAntrenor { get; set; }
        public string Gen { get; set; }
        public int AniExperienta { get; set; }

        //un antrenor preda un sg sport
        public int SportId { get; set; }//fk
        public Sport Sport { get; set; }//pt join
        //un antr e la un sg club
        public int ClubId { get; set; }//fk
        public Club Club { get; set; }//pt join

        public ICollection<Inscriere> Inscrieri { get; set; }

    }
}
