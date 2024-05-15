using Appeon.SnapObjectsDemo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Service.Services
{
    public interface ISalesOrderService
    {
        IList<SalesOrder> Retrieve(bool includeEmbedded, params object[] parameters);

        SalesOrder LoadByKey(bool includeEmbedded, params object[] parameters);

        Page<SalesOrder> LoadByPage(int pageIndex, int pageSize, params object[] parameters);

        int Create(SalesOrder salesOrder);

        int Update(SalesOrder salesOrder);

        int DeleteByKey(params object[] parameters);
    }
}
