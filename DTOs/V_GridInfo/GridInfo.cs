using Microsoft.AspNetCore.Mvc;

namespace QuanLySinhVien.DTOs.V_GridInfo
{
    public class GridInfo
    {
        public List<Filter> Filters { get; set; }
        public PageInfo pageInfo { get; set; }
        public List<Sort> Sorts { get; set; }
    }
}
