using BlogSite.Models.Dtos.Post.Requests;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstracts;

public interface IPostService
{
    List<PostResponseDto> GetAll();
    PostResponseDto? GetById(Guid id);
    Post Add(CreatePostRequest create);
}
