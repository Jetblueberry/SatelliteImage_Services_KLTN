using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DTOs.V_GridInfo;
using Service_Design_KLTN.DTOs.DataLandsatDTOs;
using Service_Design_KLTN.DynamicFilters;
using Service_Design_KLTN.Models;
using Service_Design_KLTN.PageLists;
using Service_Design_KLTN.SortLists;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Service_Design_KLTN.Repo.DataLandsatRepo
{
    public class DataLandsatService : IDataLandsat
    {
        private readonly KLTNContext _kLTNContext;
        private readonly PageLists<DataLandsat> _pagelist;
        private readonly FilterLists<DataLandsat> _filterlist;
        private readonly SortLists<DataLandsat> _sortlist;
        public DataLandsatService(KLTNContext kLTNContext, PageLists<DataLandsat> pageList, FilterLists<DataLandsat> filterList, SortLists<DataLandsat> sortList) 
        {
            _kLTNContext = kLTNContext;
            _filterlist = filterList;
            _sortlist = sortList;
            _pagelist = pageList;
        }

        public async Task<IQueryable<DataLandsat>> LayDanhSachDataLandsat(GridInfo gridInfo)
        {
            var lsdList = _kLTNContext.DataLandsats.AsQueryable();
            //PageInfo
            lsdList = _pagelist.PageListing(lsdList, gridInfo.pageInfo.pageFrom, gridInfo.pageInfo.pageSize);

            //Sorts
            gridInfo.Sorts.ForEach(x => lsdList = _sortlist.Sorting(lsdList, x.field, x.dir));

            // Filters
            gridInfo.Filters.ForEach(x => lsdList = _filterlist.Filtering(lsdList, x.field, x.Operator, x.Value));

            return lsdList;
        }

        public Task<DataLandsat> LayDataLandsatTheoId(Guid Id)
        {
            var lsd = _kLTNContext.DataLandsats.FirstOrDefault(x => x.IdData == Id);
            if (lsd == null) throw new Exception($"Không tìm thấy bản ghi có id là: {Id}");
            return Task.FromResult(lsd);
        }

        public async Task<DataLandsat> ThemDataLandsat(DataLandsatDTO request)
        {
            var lsd = new DataLandsat();
            {
                lsd.IdData = new Guid();
                lsd.TenData = request.TenData;
                lsd.TenService = request.TenService;
                lsd.TitleService = request.TitleService;
                lsd.DiaChi = request.DiaChi;
                lsd.QuocGia = request.QuocGia;
                lsd.SoLop = request.SoLop;
                lsd.MaxChieuDai = request.MaxChieuDai;
                lsd.MaxChieuRong = request.MaxChieuRong;
                lsd.LoaiVeTinh = request.LoaiVeTinh;
                lsd.KinhDo_Tay = request.KinhDo_Tay;
                lsd.KinhDo_Dong = request.KinhDo_Dong;
                lsd.ViDo_Bac = request.ViDo_Bac;
                lsd.ViDo_Nam = request.ViDo_Nam;
                lsd.DefaultDate = request.DefaultDate;
                lsd.Description1 = request.Description1;
                lsd.Description2 = request.Description2;
                lsd.Description3 = request.Description3;
            }
            _kLTNContext.DataLandsats.Add(lsd);
            await _kLTNContext.SaveChangesAsync();
            return lsd;
        }

        public async Task<DataLandsat> CapNhapDataLandsat(Guid Id, DataLandsatDTO request)
        {
            var lsd = _kLTNContext.DataLandsats.FirstOrDefault(x => x.IdData == Id);
            if (lsd == null) throw new Exception("Không tồn tại bản ghi");
            {
                lsd.TenData = request.TenData;
                lsd.TenService = request.TenService;
                lsd.TitleService = request.TitleService;
                lsd.DiaChi = request.DiaChi;
                lsd.QuocGia = request.QuocGia;
                lsd.SoLop = request.SoLop;
                lsd.MaxChieuDai = request.MaxChieuDai;
                lsd.MaxChieuRong = request.MaxChieuRong;
                lsd.LoaiVeTinh = request.LoaiVeTinh;
                lsd.KinhDo_Tay = request.KinhDo_Tay;
                lsd.KinhDo_Dong = request.KinhDo_Dong;
                lsd.ViDo_Bac = request.ViDo_Bac;
                lsd.ViDo_Nam = request.ViDo_Nam;
                lsd.DefaultDate = request.DefaultDate;
                lsd.Description1 = request.Description1;
                lsd.Description2 = request.Description2;
                lsd.Description3 = request.Description3;
            }
            _kLTNContext.DataLandsats.Update(lsd);
            await _kLTNContext.SaveChangesAsync();
            return lsd;
        }

        public async Task<DataLandsat> XoaDataLandsat(Guid Id)
        {
            var lsd = _kLTNContext.DataLandsats.FirstOrDefault(x => x.IdData == Id);
            if (lsd == null) throw new Exception("Không tồn tại bản ghi");
            _kLTNContext.DataLandsats.Remove(lsd);
            await _kLTNContext.SaveChangesAsync();
            return lsd;
        }

    }
}
