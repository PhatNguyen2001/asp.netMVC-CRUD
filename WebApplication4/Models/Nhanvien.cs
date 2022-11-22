using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class Nhanvien
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
