using Service_Design_KLTN.Models;

namespace Service_Design_KLTN.DynamicFilters
{
    public class FilterLists<T> : List<T>
    {
        public FilterLists() { }
        
        public IQueryable<T> Filtering(IQueryable<T> lst, string field, string Operator, string Value)
        {
            if(Operator == "eq")
            {
               lst = lst.ToList().Where(i => getPropertyValue(i, field).ToString() == Value).AsQueryable();
            } 
            else if(Operator == "in")
            {
                lst = lst.ToList().Where(i => getPropertyValue(i, field).ToString().Contains(Value)).AsQueryable();
            }
            return lst;
        }
        
        public object getPropertyValue<T> (T obj, string propertyName)
        {
            var prop = typeof(T).GetProperty(propertyName);
            if (prop != null)
            {
                Console.WriteLine(prop.GetValue(obj));
                return prop.GetValue(obj);
            }
            else
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");
            }
        }
    }
}
