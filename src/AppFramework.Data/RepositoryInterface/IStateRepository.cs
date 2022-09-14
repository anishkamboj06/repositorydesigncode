using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IStateRepository:IGenericRepository<StateMaster>
    {
        Task<List<StateMaster>> GetAllAsync();
    }
}
