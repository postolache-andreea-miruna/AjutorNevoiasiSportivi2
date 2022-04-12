namespace AjutorNevoiasiSportivi2.Models
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public IFormFile Attachment { get; set; }
        public string FromEmail { get; set; }
        public string FromPassword { get; set; }
    }
}
