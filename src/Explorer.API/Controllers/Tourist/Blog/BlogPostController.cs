﻿using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Blog
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/blog/blogpost")]
    public class BlogPostController : BaseApiController
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public ActionResult<PagedResult<BlogPostDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _blogPostService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<BlogPostDto> Create([FromBody] BlogPostDto blogPost)
        {
            var result = _blogPostService.Create(blogPost);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<BlogPostDto> Update([FromBody] BlogPostDto blogPost)
        {
            var result = _blogPostService.Update(blogPost);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _blogPostService.Delete(id);
            return CreateResponse(result);
        }

    }
}
