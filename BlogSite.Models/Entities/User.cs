using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Entities;

public class User : IdentityUser
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string City { get; set; }

    public DateTime BirthDate { get; set; }

    
    public List<Post> Posts { get; set; }

    public List<Comment> Comments { get; set; }
}
