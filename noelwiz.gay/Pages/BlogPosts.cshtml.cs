#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Context;
using DataLayer.Models;
using noelwiz.gay.Models;
using noelwiz.gay.Models.Mapper;

namespace noelwiz.gay.Pages
{
    public class BlogPostsModel : PageModel
    {
        private readonly DataLayer.Context.postgresContext _context;

        public BlogPostsModel(postgresContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<BlogPostModel> BlogPostList { get;set; }

        public async Task OnGetAsync()
        {
            var posts = await  _context.Blogposts.ToListAsync();

            BlogPostList = BlogPostMapper.MapModels(posts);
        }
    }
}
