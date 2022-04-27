using System.Data.SqlClient;
using MvcApp1.Models;
using MvcApp1.Models.Request;
using MvcApp1.Mssql;

namespace MvcApp1.DataAccess
{
    public class CategoryDAO
    {
        IExternalDataResolver _dataresolver;
        public CategoryDAO(IExternalDataResolver dataresolver)
        {
            _dataresolver = dataresolver;
        }
        public void InsertCategory(CategoryRequest item)
        {
            List<SqlParameter>parameters=new List<SqlParameter>()
            {
                new SqlParameter("@Name",item.Name),
                new SqlParameter("@Detail",item.Detail),
            };
            _dataresolver.GetNonQueryExecutionResult("insert into Category Values(@Name,@Detail)",parameters);
        }
        public List<Category> InsertCategory()
        {            
            var items=_dataresolver.GetFromCommand<Category>("select * from Category");
            return items;
        }
    }
}
