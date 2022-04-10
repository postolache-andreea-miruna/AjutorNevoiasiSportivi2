namespace AjutorNevoiasiSportivi2.Models
{
    public class IstoricIstModel
    {
        public string NumeProba { get; set; }
        public string NumeCompetitie { get; set; }
        public int LocClasament { get; set; }
        public int TimpObtinut { get; set; }//in secunde
        public bool Medaliat { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
