using Service_Design_KLTN.DTOs.DataSentinelDTOs;
using Service_Design_KLTN.Models;

namespace Service_Design_KLTN.Mapper
{
    public class DataSentinelMapper
    {
        public DataSentinelDTO toDTO(DataSentinel request)
        {
            DataSentinelDTO DLT = new DataSentinelDTO();
            {
                DLT.IdData = request.IdData;
                DLT.TenData = request.TenData;
                DLT.TenService = request.TenService;
                DLT.TitleService = request.TitleService;
                DLT.DiaChi = request.DiaChi;
                DLT.QuocGia = request.QuocGia;
                DLT.SoLop = request.SoLop;
                DLT.MaxChieuDai = request.MaxChieuDai;
                DLT.MaxChieuRong = request.MaxChieuRong;
                DLT.LoaiVeTinh = request.LoaiVeTinh;
                DLT.KinhDo_Tay = request.KinhDo_Tay;
                DLT.KinhDo_Dong = request.KinhDo_Dong;
                DLT.ViDo_Bac = request.ViDo_Bac;
                DLT.ViDo_Nam = request.ViDo_Nam;
                DLT.DefaultDate = request.DefaultDate;
                DLT.Description1 = request.Description1;
                DLT.Description2 = request.Description2;
                DLT.Description3 = request.Description3;
            }
            return DLT;
        }

        public IQueryable<DataSentinelDTO> toDTOList(IQueryable<DataSentinel> DataSentinel)
        {
            var DLT = new List<DataSentinelDTO>();
            foreach (DataSentinel dlt in DataSentinel)
            {
                DLT.Add(toDTO(dlt));
            }
            return DLT.AsQueryable();
        }
    }
}
