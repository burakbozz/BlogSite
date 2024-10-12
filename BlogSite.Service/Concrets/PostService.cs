using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Post.Requests;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concrets;


public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public Post Add(CreatePostRequest create)
    {
        Post post = _mapper.Map<Post>(create);
        Post createdPost = _postRepository.Add(post);

        return createdPost;
    }

    public List<PostResponseDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public PostResponseDto? GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}
