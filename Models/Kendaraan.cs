using System;
using Parkir.Enums;

namespace Parkir.Models
{
    public class Kendaraan
    {
        public string Reg { get; private set; }
        public string Warna { get; private set; }
        public TipeKendaraan Tipe { get; private set; }
        public DateTime WaktuReg { get; private set; }

        public Kendaraan(string reg, string warna, TipeKendaraan tipe)
        {
            Reg = reg;
            Warna = warna;
            Tipe = tipe;
            WaktuReg = DateTime.Now;
        }
    }
}