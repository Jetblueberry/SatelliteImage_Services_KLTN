using System.ComponentModel.DataAnnotations;

namespace Service_Design_KLTN.Models
{
    public class DataSentinel
    {
        [Key]
        public Guid IdData { get; set; }
        [Required]
        public string TenData { get; set; } = null!;
        [Required]
        public string TenService { get; set; } = null!;
        public string? TitleService { get; set; }
        public string? DiaChi { get; set; }
        public string? QuocGia { get; set; }
        public int SoLop { get; set; }
        public double MaxChieuDai { get; set; }
        public double MaxChieuRong { get; set; }
        public string? LoaiVeTinh { get; set; }
        public double KinhDo_Tay { get; set; }
        public double KinhDo_Dong { get; set; }
        public double ViDo_Bac { get; set; }
        public double ViDo_Nam { get; set; }
        public DateTime DefaultDate { get; set; }
        [Required]
        public string Description1 { get; set; } = null!;
        [Required]
        public string Description2 { get; set; } = null!;
        public string? Description3 { get; set; }
    }
}
