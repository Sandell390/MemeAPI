using MemeAPI.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI
{
    public interface IPostRepository
    {
        List<BOPost> GetAll();
        List<BOPost> GetAllUserPosts(int userid);
        BOPost GetById(int id);
        void Add(BOPost bOPost);
        void Delete(int id);
        void Save();
    }
}
