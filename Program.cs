using System;
using Parkir.Enums;
using Parkir.Models;

namespace Parkir
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LotParkir? lot = null;
            Console.WriteLine("=== PARKING SYSTEM ===");
            Console.WriteLine("Type 'exit' to end the program. ");

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                var parts = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var cmd = parts[0].ToLower();

                if (cmd == "exit") break;

                try
                {
                    switch (cmd)
                    {
                        case "create_parking_lot":
                            int kapasitas = int.Parse(parts[1]);
                            lot = new LotParkir(kapasitas);
                            Console.WriteLine($"Created a parking lot with {kapasitas} slots");
                            break;

                        case "park":
                            if (lot == null)
                            {
                                Console.WriteLine("Create a parking lot first!");
                                break;
                            }

                            var plat = parts[1];
                            var warna = parts[2];
                            if (!Enum.TryParse(parts[3], true, out TipeKendaraan tipe))
                            {
                                Console.WriteLine("Vehicle type only available for 'Mobil' and 'Motor'");
                                break;
                            }

                            var kendaraan = new Kendaraan(plat, warna, tipe);
                            var slotNomor = lot.ParkIn(kendaraan);
                            if (slotNomor == null)
                                Console.WriteLine("Sorry, parking lot is full");
                            else
                                Console.WriteLine($"Allocated slot number: {slotNomor}");
                            break;

                        case "keluar":
                        case "leave":
                            if (lot == null)
                            {
                                Console.WriteLine("Not found.");
                                break;
                            }

                            int slotKeluar = int.Parse(parts[1]);
                            if (lot.Leave(slotKeluar, out double tarif))
                                Console.WriteLine($"Slot number {slotKeluar} is free");
                            else
                                Console.WriteLine("Not found.");
                            break;

                        case "status":
                            lot?.CetakStatus();
                            break;

                        case "type_of_vehicles":
                            if (lot == null) break;
                            Enum.TryParse(parts[1], true, out TipeKendaraan tipeHitung);
                            Console.WriteLine(lot.typeOfVehicles(tipeHitung));
                            break;

                        case "registration_numbers_for_vehicles_with_odd_plate":
                        case "plat_ganjil":
                            Console.WriteLine(string.Join(", ", lot!.oddEvenRegistrationNo("odd")));
                            break;

                        case "registration_numbers_for_vehicles_with_even_plate":
                        case "plat_genap":
                            Console.WriteLine(string.Join(", ", lot!.oddEvenRegistrationNo("even")));
                            break;

                        case "registration_numbers_for_vehicles_with_colour":
                        case "plat_warna":
                            Console.WriteLine(string.Join(", ", lot!.registrationNumbersForVehiclesColor(parts[1])));
                            break;

                        case "slot_numbers_for_vehicles_with_colour":
                        case "slot_warna":
                            Console.WriteLine(string.Join(", ", lot!.SlotNumberForVehicleColor(parts[1])));
                            break;

                        case "slot_number_for_registration_number":
                        case "cari_slot_plat":
                            var hasil = lot!.SlotNumberForRegistrationNo(parts[1]);
                            Console.WriteLine(hasil?.ToString() ?? "Tidak ditemukan");
                            break;

                        default:
                            Console.WriteLine("Perintah tidak dikenal.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
                }
            }
        }
    }
}
