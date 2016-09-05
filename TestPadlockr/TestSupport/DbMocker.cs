using System.Data;
using System.Linq;
using FizzWare.NBuilder;

namespace TestPadlockr.TestSupport
{
    public static class DbMocker
    {
        public static DataTable GenerateDataTable<T>(int rows)
        {
            var datatable = new DataTable(typeof(T).Name);
            typeof(T).GetProperties().ToList().ForEach(x => datatable.Columns.Add(x.Name));

            if (rows > 0)
            {
                Builder<T>.CreateListOfSize(rows).Build()
                .ToList().ForEach(x =>
                    datatable.LoadDataRow(x.GetType().GetProperties().Select(y =>
                        y.GetValue(x, null)).ToArray(), true));
            }

            return datatable;
        }
    }
}
