using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace RedditCats.Models
{
    public class RedditCatPost
    {
        public static IEnumerable<RedditPost> GetAll()
        {


            WebRequest request = WebRequest.Create("https://www.reddit.com/r/cats.json");

            // Get the response.

            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams and the response.
            reader.Close();
            response.Close();

            var obj = Json.Decode(responseFromServer); 
            var redditData = obj.data.children;

            List<RedditPost> redditPost = new List<RedditPost>();
            var post = new RedditPost();
            foreach (var reddit in redditData)
            {
                post = new RedditPost();
                post.Author = reddit.data.author;
                post.Id = reddit.data.id;
                post.Title = reddit.data.title;
                post.Url = reddit.data.preview.images[0].source.url;
                redditPost.Add(post);
            }
            return redditPost;
        }
    }
}