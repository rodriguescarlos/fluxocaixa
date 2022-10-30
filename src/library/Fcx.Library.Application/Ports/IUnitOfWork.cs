using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Library.Application.Port
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
