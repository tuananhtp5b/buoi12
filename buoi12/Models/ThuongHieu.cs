using System.ComponentModel.DataAnnotations;

namespace buoi12.Models
{
    public class ThuongHieu
    {
        [Key]
        public int MaTH { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTH { get; set; } = string.Empty;

        public string? MoTa { get; set; }

        public int TrangThai { get; set; }

        public ICollection<DongHo> DongHos { get; set; } = new List<DongHo>();
    }
}
