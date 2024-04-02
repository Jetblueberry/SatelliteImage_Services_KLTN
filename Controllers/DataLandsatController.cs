using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.V_GridInfo;
using Service_Design_KLTN.DTOs.DataLandsatDTOs;
using Service_Design_KLTN.Mapper;
using Service_Design_KLTN.Models;
using Service_Design_KLTN.Repo.DataLandsatRepo;

namespace Service_Design_KLTN.Controllers
{
    [Route("api/DataLandsat")]
    [ApiController]
    public class DataLandsatController : ControllerBase
    {
        private readonly DataLandsatService _dataLandsatService;
        private readonly DataLandsatMapper _dataLandsatMapper;
        public DataLandsatController(DataLandsatService dataLandsatService, DataLandsatMapper dataLandsatMapper)
        {
            _dataLandsatService = dataLandsatService;
            _dataLandsatMapper = dataLandsatMapper;
        }

        [HttpPost("GetData")]
        public async Task<IActionResult> LayDanhSachDTL(GridInfo gridInfo)
        {
            var lsdLst = await _dataLandsatService.LayDanhSachDataLandsat(gridInfo);
            return Ok(_dataLandsatMapper.toDTOList(lsdLst));
        }

        [HttpGet("{IdData}")]
        public async Task<IActionResult> LayDanhSachDTLTheoID(Guid IdData)
        {
            var lsd = await _dataLandsatService.LayDataLandsatTheoId(IdData);
            return Ok(_dataLandsatMapper.toDTO(lsd));
        }

        [HttpPost]
        public async Task<IActionResult> ThemDanhSachDTL(DataLandsatDTO request)
        {
            var lsd = await _dataLandsatService.ThemDataLandsat(request);
            return Ok(_dataLandsatMapper.toDTO(lsd));
        }

        [HttpPut]
        public async Task<IActionResult> CapNhatDanhSachDTL(Guid Id, DataLandsatDTO request)
        {
            var lsd = await _dataLandsatService.CapNhapDataLandsat(Id, request);
            return Ok(_dataLandsatMapper.toDTO(lsd));
        }

        [HttpDelete]
        public async Task<IActionResult> XoaDanhSachDTL(Guid Id)
        {
            var lsd = await _dataLandsatService.XoaDataLandsat(Id);
            return Ok(_dataLandsatMapper.toDTO(lsd));
        }
    }
}
