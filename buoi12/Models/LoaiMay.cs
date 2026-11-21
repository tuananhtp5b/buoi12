using System.ComponentModel.DataAnnotations;

namespace buoi12.Models
{
    public class LoaiMay
    {
        [Key]
        public int MaLM { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLM { get; set; } = string.Empty;

        public string? MoTa { get; set; }

        public int TrangThai { get; set; }

        public ICollection<DongHo> DongHos { get; set; } = new List<DongHo>();
    }
}
