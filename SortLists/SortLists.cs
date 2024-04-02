using System.Data.SqlClient;

namespace Service_Design_KLTN.SortLists
{
    public class SortLists<T> : List<T>
    {
        public SortLists() { }
        public IQueryable<T> Sorting<T>(IQueryable<T> lst, string orderBy, int dir)
        {
            if (dir == -1) // Giảm dần
            {
                lst = lst.ToList().OrderByDescending(o => GetPropertyValue(o, orderBy)).AsQueryable();
            }
            else if (dir == 1) // Tăng dần
            {
                lst = lst.ToList().OrderBy(o => GetPropertyValue(o, orderBy)).AsQueryable();
            }

            return lst;
        }

        // Helper method to get property value by name
        private object GetPropertyValue<T>(T obj, string propertyName)
        {
            var prop = typeof(T).GetProperty(propertyName);
            if (prop != null)
            {
                return prop.GetValue(obj);
            }
            else
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");
            }
        }

    }
}
