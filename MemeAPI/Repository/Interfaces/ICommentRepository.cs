using MemeAPI.BO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI.Repository.Interfaces
{
    public interface ICommentRepository
    {
        List<BOComment> GetAll();
        List<BOComment> GetAllUserComments(int userid);
        List<BOComment> GetAllPostComments(int postid);
        BOComment GetById(int id);
        void Add(BOComment bOComment, int postid);
        void Delete(int id);
        void Save();
    }
}
