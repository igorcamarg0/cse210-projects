using System;
using System.Collections.Generic;

namespace YouTubeVideoTracker
{
    // Comment class
    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    // Video class
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }

        public List<Comment> GetComments()
        {
            return Comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create videos
            Video video1 = new Video("How to Cook Pasta", "Chef Anna", 300);
            Video video2 = new Video("Tech Review: Smartwatch", "GadgetGuru", 600);
            Video video3 = new Video("Workout Tips for Beginners", "FitnessPro", 450);

            // Add comments to video1
            video1.AddComment(new Comment("John", "Great tips!"));
            video1.AddComment(new Comment("Emily", "Looks delicious."));
            video1.AddComment(new Comment("Mike", "I'll try this recipe tonight!"));

            // Add comments to video2
            video2.AddComment(new Comment("Sophia", "Helpful review, thanks!"));
            video2.AddComment(new Comment("Liam", "Waiting for the next gadget review."));
            video2.AddComment(new Comment("Olivia", "Very detailed and clear."));

            // Add comments to video3
            video3.AddComment(new Comment("Emma", "Exactly what I needed!"));
            video3.AddComment(new Comment("Noah", "Will start my workout tomorrow."));
            video3.AddComment(new Comment("Mason", "Thanks for the motivation."));

            // Store videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Display video details
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

                Console.WriteLine("Comments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.Name}: {comment.Text}");
                }

                Console.WriteLine();
            }
        }
    }
}