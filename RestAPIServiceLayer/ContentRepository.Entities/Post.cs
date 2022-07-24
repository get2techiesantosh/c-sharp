using System;
using System.Collections.Generic;

namespace ContentRepository.Entities
{
    public partial class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
