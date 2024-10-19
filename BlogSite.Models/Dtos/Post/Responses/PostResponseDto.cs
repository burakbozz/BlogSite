using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Post.Responses
{
    public sealed record PostResponseDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UpdatedDate { get; init; }
        public string AuthorUserName { get; init; }
        public string CategoryName { get; init; }
    }


    
}
