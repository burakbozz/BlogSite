using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Post.Requests;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

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

    public ReturnModel<PostResponseDto> Add(CreatePostRequest create)
    {
        Post createdPost = _mapper.Map<Post>(create);
        createdPost.Id = Guid.NewGuid();

        _postRepository.Add(createdPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = _postRepository.GetAll();
        List<PostResponseDto> postResponses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = postResponses,
            Message = "Post listelendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto?> GetById(Guid id)
    {
        Post? post = _postRepository.GetById(id);
        PostResponseDto responseDto = _mapper.Map<PostResponseDto>(post);
        if (post is null)
        {
            return new ReturnModel<PostResponseDto?>
            {
                Data = null,
                Message = "",
                StatusCode = 404,
                Success = false
            };

        }
        return new ReturnModel<PostResponseDto?>
        {
            Data = responseDto,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }



    public ReturnModel<PostResponseDto> Remove(Guid id)
    {
        Post post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Remove(post);

        PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost)
    {
        
        Post post = _postRepository.GetById(updatePost.Id);

        
        post.Content = updatePost.Content;
        post.Title = updatePost.Title;
        post.UpdatedDate = DateTime.Now; 

        
        Post updatedPost = _postRepository.Update(post);

        
        PostResponseDto dto = _mapper.Map<PostResponseDto>(updatedPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = dto,
            Message = "Post güncellendi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(long id)
    {
        var posts = _postRepository.GetAll(x => x.AuthorId == id, false);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };

    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        var posts = _postRepository.GetAll(x => x.CategoryId == id, false);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

}
