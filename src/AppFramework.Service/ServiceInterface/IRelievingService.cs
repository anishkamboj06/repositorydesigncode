using AppFramework.Domain.ApiModel.Relieving;
using AppFramework.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.ServiceInterface
{
    public interface IRelievingService
    {
        ServiceResult CreateRelieving(AddRelieving model);
    }

}
