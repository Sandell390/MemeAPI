using MemeAPI.BO;
using MemeAPI.Repository.POGO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI
{
    internal class UserRepository : IUserRepository
    {
        private readonly memedatabaseEntities3 _context;

        public UserRepository()
        {
            _context
                    = new memedatabaseEntities3();
        }

        public void Delete(int id)
        {
            _context.users.Remove(_context.users.Where(user => user.iduser == id).FirstOrDefault());
        }

        List<BOUser> IUserRepository.GetAll()
        {
            IPostRepository postRepository = new PostRepository();
            List<BOUser> users = new List<BOUser>();

            foreach (var item in _context.users.ToList())
            {
                List<upvote> upvotes1 = _context.upvotes.Where(upvote => upvote.userid == item.iduser).ToList();
                List<BOPost> upvotes = postRepository.GetAll().Where(post => post.Id == (upvotes1.Where(upvote => upvote.postid == post.Id).FirstOrDefault()?.postid == null ? -1 : upvotes1.Where(upvote => upvote.postid == post.Id).FirstOrDefault().postid)).ToList();
                users.Add(new BOUser() { Id = item.iduser, Name = item.username, Password = item.password, Post = postRepository.GetAllUserPosts(item.iduser), Upvotes = upvotes });
            }

            return users;
        }

        BOUser IUserRepository.GetById(int id)
        {
            IPostRepository postRepository = new PostRepository();
            user user = _context.users.Where(x => x.iduser == id).FirstOrDefault();
            List<upvote> upvotes1 = _context.upvotes.Where(upvote => upvote.userid == id).ToList();
            List<BOPost> upvotes = postRepository.GetAll().Where(post => post.Id ==( upvotes1.Where(upvote => upvote.postid == post.Id).FirstOrDefault()?.postid == null ? -1 : upvotes1.Where(upvote => upvote.postid == post.Id).FirstOrDefault().postid)).ToList();
            return new BOUser() { Id = user.iduser, Name = user.username, Post = postRepository.GetAllUserPosts(user.iduser), Password = user.password, Upvotes = upvotes };
        }

        void IUserRepository.Insert(BOUser user)
        {
            _context.users.Add(new user() {username = user.Name, password = user.Password, karma = "0" });
        }

        void IUserRepository.Save()
        {
            _context.SaveChanges();
        }

        void IUserRepository.Update(BOUser user)
        {
            _context.users.AddOrUpdate(new user() { username = user.Name, password = user.Password, karma = "0" });
        }
    }
}
