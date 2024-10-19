﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Entities;

public sealed class Post : Entity<Guid>
{
    public Post()
    {
        
    }
    public string Title { get; set; }

    public string Content { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }


    public long AuthorId { get; set; }

    public User Author { get; set; }

    public List<Comment> Comments { get; set; }

}
