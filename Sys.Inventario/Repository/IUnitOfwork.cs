using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    //hacer tralacional nuestro crud
    public interface IUnitOfwork
    {
        int Save();
    }
}
