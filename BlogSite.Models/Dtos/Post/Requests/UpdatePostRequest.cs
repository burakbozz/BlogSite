namespace BlogSite.Models.Dtos.Post.Requests;

public sealed record UpdatePostRequest(Guid Id,string Title, string Content);


