using AutoMapper;
using BlogSite.Models.Dtos.Category.Requests;
using BlogSite.Models.Dtos.Category.Responses;
using BlogSite.Models.Dtos.Comment.Requesets;
using BlogSite.Models.Dtos.Comment.Responses;
using BlogSite.Models.Dtos.Post.Requests;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Dtos.User.Requests;
using BlogSite.Models.Dtos.User.Responses;
using BlogSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequest, Post>();
        CreateMap<Post, PostResponseDto>();
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<RegisterRequestDto, User>();
        CreateMap<User,UserResponseDto>();
        CreateMap<CreateCommentRequest, Comment>();
        CreateMap<Comment,CommentResponseDto>();
        CreateMap<Comment, CommentResponseDto>()
        .ForMember(x => x.UserUsername, opt => opt.MapFrom(x => x.User.UserName)) 
        .ForMember(x => x.PostTitle, opt => opt.MapFrom(x => x.Post.Title))       
        .ForMember(x => x.PostContent, opt => opt.MapFrom(x => x.Post.Content));

    }
}
