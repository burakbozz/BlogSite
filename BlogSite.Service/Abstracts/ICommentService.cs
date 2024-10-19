
using BlogSite.Models.Dtos.Comment.Requesets;
using BlogSite.Models.Dtos.Comment.Responses;
using BlogSite.Models.Dtos.Post.Requests;
using BlogSite.Models.Dtos.Post.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAll();

    ReturnModel<CommentResponseDto?> GetById(Guid id);

    ReturnModel<CommentResponseDto> Add(CreateCommentRequest create);

    ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment);

    ReturnModel<CommentResponseDto> Remove(Guid id);
}
