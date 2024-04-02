using QuanLySinhVien.DTOs.V_GridInfo;
using Service_Design_KLTN.DTOs.DataSentinelDTOs;
using Service_Design_KLTN.Models;

namespace Service_Design_KLTN.Repo.DataSentinelRepo
{
    public interface IDataSentinel
    {
        Task<IQueryable<DataSentinel>> LayDanhSachDataSentinel(GridInfo gridInfo);
        Task<DataSentinel> LayDataSentinelTheoId(Guid Id);
        Task<DataSentinel> ThemDataSentinel(DataSentinelDTO request);
        Task<DataSentinel> CapNhapDataSentinel(Guid Id, DataSentinelDTO request);
        Task<DataSentinel> XoaDataSentinel(Guid Id);
    }
}
