using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penghitung_Pajak_PPH21
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong gajiPokok, tunjanganLainnya, jaminanKeselamatanKerja, jaminanKematian, gajiBruto, biayaJabatan, iuranJaminanHariTua, jaminanPensiun, jumlahPengurang, gajiBersih, gajiBersihSetahun, penghasilanTidakKenaPajak, penghasilanKenaPajak, penghasilanKenaPajakDibulatkan, pajakDikenakanSetahun, pajakDikenakanSebulan;

            ulong[] PenghasilanTidakKenaPajak = new ulong[] { 54000000, 54000000 + 4500000, 108000000 };

            ulong statusKawin, jumlahAnak;

            Console.WriteLine("Masukkan Gaji Pokok Anda.");
            readLine(out gajiPokok);

            Console.WriteLine("Masukkan Total Tunjangan Anda.");
            readLine(out tunjanganLainnya);

            //jaminanKeselamatanKerja = gajiPokok * 0.0024;
            //jaminanKematian = gajiPokok * 0.003;

            gajiBruto = gajiPokok + tunjanganLainnya; // + jaminanKeselamatanKerja + jaminanKematian;

            biayaJabatan = gajiBruto / 20; //gajiBruto * 0.05
            iuranJaminanHariTua = gajiPokok / 50; //gajiPokok * 0.02
            jaminanPensiun = gajiPokok / 100; //gajiPokok * 0.01

            jumlahPengurang = biayaJabatan + iuranJaminanHariTua + jaminanPensiun;

            gajiBersih = gajiBruto - jumlahPengurang;

            gajiBersihSetahun = gajiBersih * 12;

            /*
            Console.WriteLine("Masukkan PTKP anda.");
            readLine(out penghasilanTidakKenaPajak);
            */

            Console.WriteLine("Sebutkan Status anda.");
            Console.WriteLine("1. Tidak Kawin");
            Console.WriteLine("2. Kawin");
            Console.WriteLine("3. Kawin dan Penghasilan Suami/Istri Digabung.");
            readLine(out statusKawin);

            Console.WriteLine("Sebutkan Berapa Jumlah Anak Anda.");
            readLine(out jumlahAnak);

            if (jumlahAnak > 3)
            {
                jumlahAnak = 3;
            }

            penghasilanTidakKenaPajak = PenghasilanTidakKenaPajak[statusKawin - 1] + (jumlahAnak * 4500000);

            penghasilanKenaPajak = gajiBersihSetahun - penghasilanTidakKenaPajak;

            penghasilanKenaPajakDibulatkan = roundToThousands(penghasilanKenaPajak);

            pajakDikenakanSetahun = hitungPajak(penghasilanKenaPajakDibulatkan);

            pajakDikenakanSebulan = pajakDikenakanSetahun / 12;

            Console.WriteLine("Pajak anda dalam sebulan dan setahun secara berurutan adalah {0} dan {1}. Sementara PTKP anda adalah {2}", pajakDikenakanSebulan, pajakDikenakanSetahun, penghasilanTidakKenaPajak);

            Console.ReadKey();
        }

        static private void readLine(out int inputText)
        {
            int.TryParse(Console.ReadLine(), out inputText);
        }

        static private void readLine(out ulong inputText)
        {
            ulong.TryParse(Console.ReadLine(), out inputText);
        }

        static private void readLine(out double inputText)
        {
            double.TryParse(Console.ReadLine(), out inputText);
        }

        static private double hitungPajak(double inputNominal)
        {
            if (inputNominal > 500000000)
            {
                return (inputNominal - 50000000) * 0.15;
            }

            if (inputNominal <= 500000000)
            {
                return (inputNominal - 250000000) * 0.15;
            }

            if (inputNominal <= 250000000)
            {
                return (inputNominal - 50000000) * 0.15;
            }

            if (inputNominal <= 50000000)
            {
                return inputNominal * 0.05;
            }

            return -1;
        }

        static private ulong hitungPajak(ulong inputNominal) {
            ulong totalPajak = 0;
            if (inputNominal > 500000000)
            {
                totalPajak += Convert.ToUInt64((inputNominal - 500000000) * 0.3);
            }

            if (inputNominal <= 500000000 && inputNominal > 250000000)
            {
                totalPajak += Convert.ToUInt64((inputNominal - 250000000) * 0.25);
            }

            if (inputNominal <= 250000000 && inputNominal > 50000000)
            {
                totalPajak += Convert.ToUInt64((inputNominal - 50000000) * 0.15);
            }

            if (inputNominal <= 50000000)
            {
                totalPajak += Convert.ToUInt64(inputNominal * 0.05);
            }

            return totalPajak;
        }

        static private double roundToThousands(double input)
        {
            return input - (input % 1000);
        }

        static private ulong roundToThousands(ulong input)
        {
            return input - (input % 1000);
        }
    }
}