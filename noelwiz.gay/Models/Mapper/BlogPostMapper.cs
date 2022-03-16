using DataLayer.Models;

namespace noelwiz.gay.Models.Mapper
{
    public class BlogPostMapper
    {
        public static BlogPostModel MapToModel(Blogpost post)
        {
            var mapped = new BlogPostModel(post.Id, post.Title, post.Content);

            return mapped;
        }


        public static List<BlogPostModel> MapModels(List<Blogpost> posts)
        {
            var result = new List<BlogPostModel>();

            foreach (var post in posts)
            {
                result.Add(MapToModel(post));
            }
            return result;
        }


    }
}
