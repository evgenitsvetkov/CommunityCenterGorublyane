namespace CommunityCenterGorublyane.Core.Models.News
{
    public class NewsCommentServiceModel
    {
        public int Id { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
