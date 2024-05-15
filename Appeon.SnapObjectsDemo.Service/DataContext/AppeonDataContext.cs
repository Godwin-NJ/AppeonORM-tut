using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnapObjects.Data;
using SnapObjects.Data.SqlServer;

namespace Appeon.SnapObjectsDemo.Service.DataContext
{
    public class AppeonDataContext: SqlServerDataContext
    {
        public AppeonDataContext(string connectionString)
             : this(new SqlServerDataContextOptions<AppeonDataContext>(connectionString))
        {
        }

        public AppeonDataContext(IDataContextOptions<AppeonDataContext> options)
        : base(options)
        {
        }

        public AppeonDataContext(IDataContextOptions options)
            : base(options)
        {
        }
    }
}
