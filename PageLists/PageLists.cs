using Service_Design_KLTN.Models;

namespace Service_Design_KLTN.PageLists
{
    public class PageLists<T> : List<T>
    {
        public PageLists() { }
        public IQueryable<T> PageListing(IQueryable<T> List, int pageFrom, int pageSize) 
        {
            if(pageSize == 0)
            {
                pageSize = 100;
            }
            if(pageFrom == 0)
            {
                pageFrom = 1;
            }
            var newList = List.Skip((pageFrom-1)*pageSize).Take(pageSize);
            return newList;
        }
    }
}
