namespace BlogSite.Models.Dtos.Comment.Responses;

public sealed record CommentResponseDto
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public string UserUsername { get; init; }
    public string PostTitle { get; init; }
    public string PostContent { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }

}
