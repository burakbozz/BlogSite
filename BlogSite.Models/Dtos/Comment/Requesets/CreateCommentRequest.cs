
namespace BlogSite.Models.Dtos.Comment.Requesets;

public sealed record CreateCommentRequest(string Text,long UserId,Guid PostId);

