using Microsoft.AspNetCore.Html;
using System.ComponentModel;

namespace noelwiz.gay.Models
{
    public class BlogPostModel
    {
        public int Id { get;}

        [DisplayName("Title")]
        public string PostTitle { get; set; } = string.Empty;

        private string RawBody;

        [DisplayName("Content")]
        public HtmlString PostBody { get; set; } = HtmlString.Empty;    
        public DateTime PostDate { get; set; }

        public HtmlString FirstSentince
        {
            get 
            {
                return new HtmlString(RawBody.Substring(0, RawBody.IndexOf(".")));
            }
        }

        public BlogPostModel(int id, string title, string html)
        {
            this.Id = id;
            PostDate = DateTime.Now;
            PostTitle = title;

            RawBody = html;
            PostBody = new HtmlString(html);
        }
    }
}
