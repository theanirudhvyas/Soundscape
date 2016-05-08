using System.Collections.Generic;

namespace App2
{

    public class Book
    {
        public object ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string isbn { get; set; }
    }

    /* public class RootObject
     {
         public string Error { get; set; }
         public double Time { get; set; }
         public string Total { get; set; }
         public int Page { get; set; }
         public List<Book> Books { get; set; }
     }
     */

    public class Status
    {
        public string version { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }

    public class Song
    {
        public string artist_id { get; set; }
        public string id { get; set; }
        public string artist_name { get; set; }
        public string title { get; set; }
    }

    public class Response
    {
        public Status status { get; set; }
        public List<Song> songs { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }
}