using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buoi12.Models
{
    public class DongHo
    {
        [Key]
        public int MaDH { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên đồng hồ")]
        public string TenDH { get; set; } = string.Empty;

        [Display(Name = "Thương hiệu")]
        public int MaTH { get; set; }

        [Display(Name = "Loại máy")]
        public int MaLM { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "Giá bán")]
        public decimal GiaBan { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "Giá khuyến mãi")]
        public decimal? GiaKhuyenMai { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int SoLuongTon { get; set; }

        [StringLength(255)]
        [Display(Name = "Ảnh bìa")]
        public string? AnhBia { get; set; }

        [StringLength(50)]
        [Display(Name = "Chất liệu dây")]
        public string? ChatLieuDay { get; set; }

        [StringLength(50)]
        public string? Kinh { get; set; }

        [StringLength(10)]
        public string? GioiTinh { get; set; }

        [Column(TypeName = "decimal(4,1)")]
        [Display(Name = "Đường kính")]
        public decimal? DuongKinh { get; set; }

        [Display(Name = "Chống nước")]
        public int? ChongNuoc { get; set; }

        [Display(Name = "Bảo hành")]
        public int? BaoHanh { get; set; }

        public string? MoTa { get; set; }

        [StringLength(20)]
        public string? PhongCach { get; set; }

        public int TrangThai { get; set; }

        public DateTime NgayTao { get; set; }

        public ThuongHieu? ThuongHieu { get; set; }

        public LoaiMay? LoaiMay { get; set; }
    }
}
