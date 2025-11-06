using System;

class Kendaraan {
    public string Plat;
    public string Warna;
    public string TipeKendaraan Tipe { get; }

    public Kendaraan(string plat, string warna, TipeKendaraan tipe){
        Plat = plat;
        Warna = warna;
        Tipe = tipe;
    }
}

enum TipeKendaraan { Mobil, Motor }