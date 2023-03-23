using MemeAPI.BO;
using MemeAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI.Repository.POGO
{
    public class PostRepository : IPostRepository
    {
        private readonly memedatabaseEntities3 _context;

        public PostRepository()
        {
            _context = new memedatabaseEntities3();
        }

        public void Add(BOPost bOPost)
        {
            post post = new post() { title = bOPost.Title, image = bOPost.Image, userid = bOPost.AutherId };
            _context.posts.Add(post);
        }

        public void Delete(int id)
        {
            _context.posts.Remove(_context.posts.Where(post => post.idpost == id).FirstOrDefault());
        }

        public List<BOPost> GetAll()
        {
            ICommentRepository commentcontext = new CommentRepository();
            List<BOPost> comments = new List<BOPost>();

            foreach (var item in _context.posts.ToList())
            {
                BOPost bOPost = new BOPost() { Id = item.idpost, AutherId = item.userid, Title = item.title, Image = item.image };
                bOPost.Comments = commentcontext.GetAllPostComments(item.idpost);
                bOPost.Upvotes = _context.upvotes.Where(upvote => upvote.postid == item.idpost).Count();
                comments.Add(bOPost);

            }
            return comments;
        }

        public List<BOPost> GetAllUserPosts(int userid)
        {
            ICommentRepository commentcontext = new CommentRepository();
            List<BOPost> comments = new List<BOPost>();

            foreach (var item in _context.posts.Where(post => post.userid == userid).ToList())
            {
                BOPost bOPost = new BOPost() { Id = item.idpost, AutherId = item.userid, Title = item.title, Image = item.image };
                bOPost.Comments = commentcontext.GetAllPostComments(item.idpost);
                bOPost.Upvotes = _context.upvotes.Where(upvote => upvote.postid == item.idpost).Count();
                comments.Add(bOPost);

            }
            return comments;
        }

        public BOPost GetById(int id)
        {
            ICommentRepository commentcontext = new CommentRepository();
            post post = _context.posts.Where(x => x.idpost == id).FirstOrDefault();
            BOPost bOPost = new BOPost() { Id = post.idpost, AutherId = post.userid, Title = post.title, Image = post.image };
            bOPost.Comments = commentcontext.GetAllPostComments(post.idpost);
            bOPost.Upvotes = _context.upvotes.Where(upvote => upvote.postid == post.idpost).Count();
            return bOPost;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
