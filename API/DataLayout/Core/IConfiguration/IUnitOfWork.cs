using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
