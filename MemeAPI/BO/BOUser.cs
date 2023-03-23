using MemeAPI.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI
{
    public class BOUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<BOPost> Upvotes { get; set; }

        public List<BOPost> Post { get; set; }
    }
}
