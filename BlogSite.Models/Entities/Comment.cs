﻿

using Core.Entities;

namespace BlogSite.Models.Entities;

public class Comment : Entity<Guid>
{
    public string Text { get; set; }


    public long UserId { get; set; }
    public User User { get; set; }


    public Guid PostId { get; set; }
    public Post Post { get; set; }
}
