﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();


            var obj = Json.Decode(responseFromServer); /*JsonConvert.DeserializeObject(responseFromServer);*/
            var redditData = obj.data.children;
            var post = new RedditPost();
            List<RedditPost> redditPost = new List<RedditPost>();

            for (var i = 0; i < redditData.Length; i++)
            {

                post.Author = redditData[i].data.author;
                post.Id =  redditData[i].data.id;
                post.Title = redditData[i].data.title;
                post.Url = redditData[i].data.preview.images[0].source.url;

                redditPost.Add(post);
            }




            //var post1 = new RedditPost();
            //var post2 = new RedditPost();




            //List<RedditPost> post = new List<RedditPost>();
            //post.Add(post1);
            //post.Add(post2);

            return redditPost;

        }
    }
}