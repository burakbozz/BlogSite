using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Comment.Requesets;
using BlogSite.Models.Dtos.Comment.Responses;
using BlogSite.Models.Dtos.User.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concrets;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository,IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public ReturnModel<CommentResponseDto> Add(CreateCommentRequest create)
    {
        Comment createdComment = _mapper.Map<Comment>(create);


        _commentRepository.Add(createdComment);

        CommentResponseDto response = _mapper.Map<CommentResponseDto>(createdComment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Comment Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        List<Comment> comments = _commentRepository.GetAll();
                    
        List<CommentResponseDto> userResponses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = userResponses,
            Message = "Comment listelendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto?> GetById(Guid id)
    {
        Comment? comment = _commentRepository.GetById(id);
        CommentResponseDto responseDto = _mapper.Map<CommentResponseDto>(comment);
        if (comment is null)
        {
            return new ReturnModel<CommentResponseDto?>
            {
                Data = null,
                Message = "",
                StatusCode = 404,
                Success = false
            };

        }
        return new ReturnModel<CommentResponseDto?>
        {
            Data = responseDto,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }



    public ReturnModel<CommentResponseDto> Remove(Guid id)
    {
        Comment comment = _commentRepository.GetById(id);
        Comment deletedcomment = _commentRepository.Remove(comment);

        CommentResponseDto response = _mapper.Map<CommentResponseDto>(deletedcomment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Comment Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment)
    {
        Comment? comment = _commentRepository.GetById(updateComment.Id);
        comment.Text = updateComment.Text;
        
        comment.UpdatedDate = DateTime.Now;


        Comment updatedComment = _commentRepository.Update(comment);


        CommentResponseDto dto = _mapper.Map<CommentResponseDto>(updatedComment);
        return new ReturnModel<CommentResponseDto>
        {
            Data = dto,
            Message = "Comment güncellendi",
            StatusCode = 200,
            Success = true
        };
    }
    public ReturnModel<List<CommentResponseDto>> GetCommentsByAuthor(long authorId)
    {
        var comments = _commentRepository.GetCommentsByAuthor(authorId).ToList();
        var commentDtos = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = commentDtos,
            Message = "Yazara ait yorumlar listelendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetCommentsByPost(Guid postId)
    {
        var comments = _commentRepository.GetCommentsByPost(postId).ToList();
        var commentDtos = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = commentDtos,
            Message = "Posta ait yorumlar listelendi.",
            StatusCode = 200,
            Success = true
        };
    }

}
