using QuanLySinhVien.DTOs.V_GridInfo;
using Service_Design_KLTN.DTOs.DataSentinelDTOs;
using Service_Design_KLTN.DynamicFilters;
using Service_Design_KLTN.Models;
using Service_Design_KLTN.PageLists;
using Service_Design_KLTN.SortLists;

namespace Service_Design_KLTN.Repo.DataSentinelRepo
{
    public class DataSentinelService : IDataSentinel
    {
        private readonly KLTNContext _kLTNContext;
        private readonly PageLists<DataSentinel> _pagelist;
        private readonly FilterLists<DataSentinel> _filterlist;
        private readonly SortLists<DataSentinel> _sortlist;
        public DataSentinelService(KLTNContext kLTNContext, PageLists<DataSentinel> pageList, FilterLists<DataSentinel> filterList, SortLists<DataSentinel> sortList)
        {
            _kLTNContext = kLTNContext;
            _filterlist = filterList;
            _sortlist = sortList;
            _pagelist = pageList;
        }

        public Task<IQueryable<DataSentinel>> LayDanhSachDataSentinel(GridInfo gridInfo)
        {
            var lsdList = _kLTNContext.DataSentinels.AsQueryable();
            //PageInfo
            lsdList = _pagelist.PageListing(lsdList, gridInfo.pageInfo.pageFrom, gridInfo.pageInfo.pageSize);

            //Sorts
            gridInfo.Sorts.ForEach(x => lsdList = _sortlist.Sorting(lsdList, x.field, x.dir));

            // Filters
            gridInfo.Filters.ForEach(x => lsdList = _filterlist.Filtering(lsdList, x.field, x.Operator, x.Value));

            return Task.FromResult(lsdList);
        }

        public Task<DataSentinel> LayDataSentinelTheoId(Guid Id)
        {
            var lsd = _kLTNContext.DataSentinels.FirstOrDefault(x => x.IdData == Id);
            if (lsd == null) throw new Exception($"Không tìm thấy bản ghi có id là: {Id}");
            return Task.FromResult(lsd);
        }

        public async Task<DataSentinel> ThemDataSentinel(DataSentinelDTO request)
        {
            var lsd = new DataSentinel();
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
            _kLTNContext.DataSentinels.Add(lsd);
            await _kLTNContext.SaveChangesAsync();
            return lsd;
        }

        public async Task<DataSentinel> CapNhapDataSentinel(Guid Id, DataSentinelDTO request)
        {
            var lsd = _kLTNContext.DataSentinels.FirstOrDefault(x => x.IdData == Id);
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
            _kLTNContext.DataSentinels.Update(lsd);
            await _kLTNContext.SaveChangesAsync();
            return lsd;
        }

        public async Task<DataSentinel> XoaDataSentinel(Guid Id)
        {
            var lsd = _kLTNContext.DataSentinels.FirstOrDefault(x => x.IdData == Id);
            if (lsd == null) throw new Exception("Không tồn tại bản ghi");
            _kLTNContext.DataSentinels.Remove(lsd);
            await _kLTNContext.SaveChangesAsync();
            return lsd;
        }
    }
}
