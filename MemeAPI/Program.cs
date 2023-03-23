using MemeAPI.Repository.Interfaces;
using MemeAPI.Repository.POGO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();
            IPostRepository postRepository = new PostRepository();
            ICommentRepository commentRepository = new CommentRepository();

            //userRepository.Insert(new user() { username="User2", password="123", karma="0"});
            userRepository.Save();
            foreach (var user in userRepository.GetAll()) 
            {
                Console.WriteLine(user.Name);
            }

            postRepository.Add(new BO.BOPost() { AutherId= 1, Comments = new List<BO.BOComment>(), Image = "asd", Title="Test",Upvotes=0});
            postRepository.Save();

            commentRepository.Add(new BO.BOComment() {UserId = 1, Comment = "This is a comment" }, 1004);
            commentRepository.Save();

            foreach (var post in postRepository.GetAll())
            {
                Console.WriteLine(post.Title);
                Console.WriteLine(userRepository.GetById(post.AutherId).Name);
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine($"{comment.Id}. {userRepository.GetById(comment.UserId).Name}: {comment.Comment}");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            commentRepository.Delete(commentRepository.GetAll().First().Id);
            commentRepository.Save();

            foreach (var post in postRepository.GetAll())
            {
                Console.WriteLine(post.Title);
                Console.WriteLine(userRepository.GetById(post.AutherId).Name);
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine($"{comment.Id}. {userRepository.GetById(comment.UserId).Name}: {comment.Comment}");
                }
            }

            Console.Read();
        }
    }
}
