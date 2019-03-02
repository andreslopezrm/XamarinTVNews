using System.Collections.Generic;
using System.Json;

namespace XamarinTVNews
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Body { get; set; }


        public static Post[] FromJSONArray(JsonArray array)
        {
            var list = new List<Post>();

            foreach(var obj in array) 
            {
                var post = new Post
                {
                    Id = int.Parse(obj["id"].ToString()),
                    Title = obj["title"],
                    Thumbnail = obj["thumbnail"],
                    Body = obj["body"]
                };

                post.Body = post.Body.Replace("<p>", "");
                post.Body = post.Body.Replace("</p>", "\n");

                list.Add(post);
            }
            return list.ToArray();
        }
    }

}
