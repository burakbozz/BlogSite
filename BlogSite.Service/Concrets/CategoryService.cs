﻿
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Category.Requests;
using BlogSite.Models.Dtos.Category.Responses;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;
using System.Reflection.Metadata.Ecma335;

namespace BlogSite.Service.Concrets;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;   
    }
    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create)
    {
        Category createdCategory = _mapper.Map<Category>(create);
        

        _categoryRepository.Add(createdCategory);

        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> categoryResponses = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = categoryResponses,
            Message = "Category listelendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto?> GetById(int id)
    {
        Category? category = _categoryRepository.GetById(id);
        CategoryResponseDto responseDto = _mapper.Map<CategoryResponseDto>(category);

        if (category is null)
        {
            return new ReturnModel<CategoryResponseDto?>
            {
                Data = null,
                Message = "",
                StatusCode = 404,
                Success = false
            };

        }
        return new ReturnModel<CategoryResponseDto?>
        {
            Data = responseDto,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        Category? category = _categoryRepository.GetById(id);
        Category? deletedCategory = _categoryRepository.Remove(category);

        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "category Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory)
    {
        Category? category = _categoryRepository.GetById(updateCategory.Id);
        category.Name = updateCategory.Name;
        category.UpdatedDate = DateTime.Now;
        
        Category updatedCategory = _categoryRepository.Update(category);


        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = dto,
            Message = "Category güncellendi",
            StatusCode = 200,
            Success = true
        };
    }
}
