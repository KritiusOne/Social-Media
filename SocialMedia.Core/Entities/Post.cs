namespace SocialMedia.Core.Entities
{
    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}
