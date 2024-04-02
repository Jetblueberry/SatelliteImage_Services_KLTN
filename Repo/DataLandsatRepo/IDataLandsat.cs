using QuanLySinhVien.DTOs.V_GridInfo;
using Service_Design_KLTN.DTOs.DataLandsatDTOs;
using Service_Design_KLTN.Models;

namespace Service_Design_KLTN.Repo.DataLandsatRepo
{
    public interface IDataLandsat
    {
        Task<IQueryable<DataLandsat>> LayDanhSachDataLandsat(GridInfo gridInfo);
        Task<DataLandsat> LayDataLandsatTheoId(Guid Id);
        Task<DataLandsat> ThemDataLandsat(DataLandsatDTO request);
        Task<DataLandsat> CapNhapDataLandsat(Guid Id, DataLandsatDTO request);
        Task<DataLandsat> XoaDataLandsat(Guid Id);
    }
}
