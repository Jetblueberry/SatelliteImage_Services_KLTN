using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.V_GridInfo;
using Service_Design_KLTN.DTOs.DataSentinelDTOs;
using Service_Design_KLTN.Mapper;
using Service_Design_KLTN.Repo.DataSentinelRepo;

namespace Service_Design_KLTN.Controllers
{
    [Route("api/DataSentinel")]
    [ApiController]
    public class DataSentinelController : ControllerBase
    {
        private readonly DataSentinelService _dataSentinelService;
        private readonly DataSentinelMapper _dataSentinelMapper;
        public DataSentinelController(DataSentinelService dataSentinelService, DataSentinelMapper dataSentinelMapper)
        {
            _dataSentinelService = dataSentinelService;
            _dataSentinelMapper = dataSentinelMapper;
        }

        [HttpPost("GetData")]
        public async Task<IActionResult> LayDanhSachDTS(GridInfo gridInfo)
        {
            var lsdLst = await _dataSentinelService.LayDanhSachDataSentinel(gridInfo);
            return Ok(_dataSentinelMapper.toDTOList(lsdLst));
        }

        [HttpGet("{IdData}")]
        public async Task<IActionResult> LayDanhSachDTSTheoID(Guid IdData)
        {
            var lsd = await _dataSentinelService.LayDataSentinelTheoId(IdData);
            return Ok(_dataSentinelMapper.toDTO(lsd));
        }

        [HttpPost]
        public async Task<IActionResult> ThemDanhSachDTS(DataSentinelDTO request)
        {
            var lsd = await _dataSentinelService.ThemDataSentinel(request);
            return Ok(_dataSentinelMapper.toDTO(lsd));
        }

        [HttpPut]
        public async Task<IActionResult> CapNhatDanhSachDTS(Guid Id, DataSentinelDTO request)
        {
            var lsd = await _dataSentinelService.CapNhapDataSentinel(Id, request);
            return Ok(_dataSentinelMapper.toDTO(lsd));
        }

        [HttpDelete]
        public async Task<IActionResult> XoaDanhSachDTS(Guid Id)
        {
            var lsd = await _dataSentinelService.XoaDataSentinel(Id);
            return Ok(_dataSentinelMapper.toDTO(lsd));
        }
    }
}
