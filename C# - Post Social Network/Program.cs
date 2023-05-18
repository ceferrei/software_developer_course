namespace Post_Social_Network
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post post = new Post(DateTime.Parse("21/10/2023 13:10:02"), "Traveling to New Zealand", "I'm going to visit ths wonderful country", 12);

            Comment c1 = new Comment("Have a nice trip!");
            Comment c2 = new Comment("Wooow, that's awesome!");

            post.AddComment(c1);
            post.AddComment(c2);
            Post post2 = new Post(DateTime.Parse("16/05/2023 14:36:13"), "Here we are!", "Next stop coffee!", 1024);
            Comment c3 = new Comment("Have fun!");
            Comment c4 = new Comment("Next trip with me! :)");
            Comment c5 = new Comment("Wonderfull");

            post2.AddComment(c3); 
            post2.AddComment(c4);
            post2.AddComment(c5);

            Console.WriteLine(post);
            Console.WriteLine(post2);
        }
    }
}