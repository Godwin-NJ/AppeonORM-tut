using Appeon.SnapObjectsDemo.Service.DataContext;
using Appeon.SnapObjectsDemo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Service.Services.Impl
{
    public class SalesOrderService : ISalesOrderService
    {
        protected readonly AppeonDataContext _context;

        public SalesOrderService(AppeonDataContext context)
        {
            _context = context;
        }
        public int Create(SalesOrder salesOrder)
        {
            return _context.SqlModelMapper.TrackCreate<SalesOrder>(salesOrder)
                                   .SaveChanges()
                                   .InsertedCount;
        }

        public int DeleteByKey(params object[] parameters)
        {
            return _context.SqlModelMapper.TrackDeleteByKey<SalesOrder>(parameters)
                                  .SaveChanges()
                                  .DeletedCount;
        }

        public SalesOrder LoadByKey(bool includeEmbedded, params object[] parameters)
        {
            SalesOrder model = _context.SqlModelMapper.LoadByKey<SalesOrder>(parameters)
                                                .FirstOrDefault();
            return model;
        }

        public Page<SalesOrder> LoadByPage(int pageIndex, int pageSize, params object[] parameters)
        {
            int currentIndex = (pageIndex - 1) * pageSize;
            IList<SalesOrder> items = null;
            Page<SalesOrder> page = new Page<SalesOrder>();
            page.PageSize = pageSize;
            page.PageIndex = pageIndex;

            items = _context.SqlModelMapper.LoadByPage<SalesOrder>(
                                                currentIndex, pageSize, parameters).ToList();

            int totalItems = _context.SqlModelMapper.Count<SalesOrder>(parameters);
            page.TotalItems = totalItems;
            page.Items = items;
            return page;
        }

        public IList<SalesOrder> Retrieve(bool includeEmbedded, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int Update(SalesOrder salesOrder)
        {
            var oldSalesOrder = this.LoadByKey(true, salesOrder.SalesOrderID);

            return _context.SqlModelMapper.TrackUpdate(oldSalesOrder, salesOrder)
                                          .SaveChanges()
                                          .ModifiedCount;
        }
    }
}
