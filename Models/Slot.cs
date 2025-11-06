namespace Parkir.Models {
    public class Slot {
        public int Nomor { get; private set; }
        public Kendaraan? Terdaftar { get; private set; }
        public bool IsFree => Terdaftar == null;

        public Slot(int nomor) { Nomor = nomor; }
        public void ParkIn(Kendaraan kendaraan) { Terdaftar = kendaraan; }
        public void Leave() { Terdaftar = null; }
    }
}
