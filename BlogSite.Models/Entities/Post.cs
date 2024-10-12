using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Entities;

public sealed class Post : Entity<Guid>
{
    

    public string Title { get; set; }

    public string Content { get; set; }


}
