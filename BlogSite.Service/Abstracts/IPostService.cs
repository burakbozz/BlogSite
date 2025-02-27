﻿using BlogSite.Models.Dtos.Post.Requests;
using BlogSite.Models.Dtos.Post.Responses;
using Core.Responses;


namespace BlogSite.Service.Abstracts;

public interface IPostService
{
    ReturnModel<List<PostResponseDto>> GetAll();

    ReturnModel<PostResponseDto?> GetById(Guid id);

    ReturnModel<PostResponseDto> Add(CreatePostRequest create, string userId);

    ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost);

    ReturnModel<PostResponseDto> Remove(Guid id);

    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id);

    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id);
}
