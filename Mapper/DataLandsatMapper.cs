using Azure.Core;
using Service_Design_KLTN.DTOs.DataLandsatDTOs;
using Service_Design_KLTN.Models;

namespace Service_Design_KLTN.Mapper
{
    public class DataLandsatMapper
    {
        public DataLandsatDTO toDTO(DataLandsat request)
        {
            DataLandsatDTO DLT = new DataLandsatDTO();
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

        public IQueryable<DataLandsatDTO> toDTOList(IQueryable<DataLandsat> DataLandsat)
        {
            var DLT = new List<DataLandsatDTO>();
            foreach (DataLandsat dlt in DataLandsat)
            {
                DLT.Add(toDTO(dlt));
            }
            return DLT.AsQueryable();
        }
    }
}
