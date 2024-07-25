using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlinhatro
{
    public class inhoadon
    {
        public int mahoadon { get; set; }
        public string hotenkh { get; set; }
        public int sophong { get; set; }
        public string hotenchutro { get; set; }
        public int thang { get; set; }
        public int madv { get; set; }
        public int gia { get; set; }
        public int soluong { get; set; }
        public double dongia { get; set; }
        public double tongtien
        {
            get
            {
                return gia + dongia * soluong;
            }
        }
        public string Sophong { get; set; }
        public string Thang { get; set; }

    }
}
