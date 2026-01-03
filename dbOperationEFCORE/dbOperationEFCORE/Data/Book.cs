namespace dbOperationEFCORE.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LanguageId{get; set;}
        public required Language Language { get; set; }

    }
}
