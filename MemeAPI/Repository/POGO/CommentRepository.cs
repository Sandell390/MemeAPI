using MemeAPI.BO;
using MemeAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI.Repository.POGO
{
    public class CommentRepository : ICommentRepository
    {
        private readonly memedatabaseEntities3 _context;
        public CommentRepository() 
        {
            _context = new memedatabaseEntities3();
        }
        public void Add(BOComment bOComment, int postid)
        {
            _context.comments.Add(new comment() { postid = postid, userid = bOComment.UserId, text = bOComment.Comment});
        }

        public void Delete(int id)
        {
            _context.comments.Remove(_context.comments.Where(comment => comment.idcomment == id).FirstOrDefault());
        }

        public List<BOComment> GetAll()
        {
            List<BOComment> comments= new List<BOComment>();

            foreach (var item in _context.comments.ToList())
            {
                comments.Add(new BOComment() { Id = item.idcomment, Comment = item.text, UserId = item.userid});
            }

            return comments;
        }

        public List<BOComment> GetAllPostComments(int postid)
        {
            List<BOComment> comments = new List<BOComment>();

            foreach (var item in _context.comments.Where(comment => comment.postid == postid).ToList())
            {
                comments.Add(new BOComment() { Id = item.idcomment, Comment = item.text, UserId = item.userid });
            }

            return comments;
        }

        public BOComment GetById(int id)
        {
            comment comment = _context.comments.Where(x => x.idcomment == id).FirstOrDefault();
            return new BOComment() { Id = comment.idcomment,UserId = comment.userid, Comment = comment.text };
        }

        public List<BOComment> GetAllUserComments(int userid)
        {
            List<BOComment> comments = new List<BOComment>();

            foreach (var item in _context.comments.Where(comment => comment.userid == userid).ToList())
            {
                comments.Add(new BOComment() { Id = item.idcomment, Comment = item.text, UserId = item.userid });
            }

            return comments;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
