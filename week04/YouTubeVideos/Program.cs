using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "Introduction to C#",
            "Andrew B",
            420);

        video1.AddComment(new Comment(
            "John",
            "This was a very helpful introduction!"));

        video1.AddComment(new Comment(
            "Mary",
            "I finally understand the basics of C#."));

        video1.AddComment(new Comment(
            "David",
            "Great explanation and examples."));

        Video video2 = new Video(
            "Object-Oriented Programming",
            "Tech Academy",
            600);

        video2.AddComment(new Comment(
            "Sarah",
            "The explanation of classes was excellent."));

        video2.AddComment(new Comment(
            "Michael",
            "Very useful lesson for beginners."));

        video2.AddComment(new Comment(
            "Grace",
            "I enjoyed learning about objects."));

        Video video3 = new Video(
            "Learning Git and GitHub",
            "Code Masters",
            510);

        video3.AddComment(new Comment(
            "Daniel",
            "GitHub makes collaboration much easier."));

        video3.AddComment(new Comment(
            "Alice",
            "The demonstration was easy to follow."));

        video3.AddComment(new Comment(
            "Peter",
            "This helped me understand commits better."));


        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);


        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.GetTitle());
            Console.WriteLine("Author: " + video.GetAuthor());
            Console.WriteLine("Length: " + video.GetLength() + " seconds");
            Console.WriteLine("Number of comments: " + video.GetNumberOfComments());

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    comment.GetName() + ": " + comment.GetText());
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}