namespace CommunityCenterGorublyane.Core.Models.News
{
    public class NewsCommentServiceModel
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
