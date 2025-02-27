﻿using BlogSite.Models.Dtos.Comment.Requesets;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController(ICommentService _commentService) : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _commentService.GetAll();
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateCommentRequest dto)
        {
            var result = _commentService.Add(dto);
            return Ok(result);
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _commentService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var result = _commentService.Remove(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateCommentRequest dto)
        {
            var result = _commentService.Update(dto);
            return Ok(result);
        }

        [HttpGet("GetCommentsByPost/{postId}")]
        public IActionResult GetCommentsByPost(Guid postId)
        {
            var result = _commentService.GetCommentsByPost(postId);
            return Ok(result);


        }


        [HttpGet("GetCommentsByAuthor/{authorId}")]
        public IActionResult GetCommentsByAuthor(string authorId)
        {
            var result = _commentService.GetCommentsByAuthor(authorId);
            return Ok(result);


        }
    }
}
