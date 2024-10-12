namespace BlogSite.Models.Dtos.Post.Requests;

public sealed record UpdatePostRequest(Guid id,string Title, string Content);


