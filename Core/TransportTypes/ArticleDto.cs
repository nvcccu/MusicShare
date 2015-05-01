using System;

namespace Core.TransportTypes {
    public class ArticleDto {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsModerated { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public int WatchNumber { get; set; }
    }
}
