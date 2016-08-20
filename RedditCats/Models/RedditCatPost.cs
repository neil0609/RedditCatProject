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

            /*JsonConvert.DeserializeObject(responseFromServer);*/

            //RedditPost[] neil = new RedditPost[(redditData.Length)];

            //for (int i = 0; i < redditData.Length; i++)
            //{
            //    //neil[i] = redditData.Decode<T>(redditData);
            //}

            //List<RedditPost> list = JsonConvert.DeserializeObject<List<RedditPost>>(responseFromServer);
            //RedditPost[] list = JsonConvert.DeserializeObject<RedditPost[]>(responseFromServer);            

            //var deserializedItemsFromItems = JsonConvert.DeserializeObject<List<object>>(responseFromServer);

            //RedditPost myDeserializedObj = (RedditPost)JavaScriptConvert.DeserializeObject(Request["jsonString"], typeof(RedditPost));
            //List<RedditPost> myDeserializedObjList = (List<RedditPost>)JsonConvert.DeserializeObject(Request[redditData], typeof(List<RedditPost>));


            //var post = new RedditPost();
            //List<RedditPost> redditPost = new List<RedditPost>();

            //for (var i = 0; i < redditData.Length; i++)
            //{

            //    post.Author = redditData[i].data.author;
            //    post.Id = redditData[i].data.id;
            //    post.Title = redditData[i].data.title;
            //    post.Url = redditData[i].data.preview.images[0].source.url;

            //    redditPost.Add(post);
            //}



            //dynamic dynJson = JsonConvert.DeserializeObject(responseFromServer);
            //foreach (var item in dynJson)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}\n", item.id, item.displayName,
            //        item.slug, item.imageUrl);
            //}
            //var post1 = new RedditPost();
            //var post2 = new RedditPost();

            //List<RedditPost> post = new List<RedditPost>();
            //post.Add(post1);
            //post.Add(post2);

        }
    }
}