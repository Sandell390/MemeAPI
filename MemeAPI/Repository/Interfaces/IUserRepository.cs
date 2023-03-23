using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI
{
    public interface IUserRepository
    {
        List<BOUser> GetAll();
        BOUser GetById(int id);
        void Insert(BOUser user);
        void Update(BOUser user);
        void Delete(int id);
        void Save();
    }
}
