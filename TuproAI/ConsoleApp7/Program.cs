//Nama: Arif Yulianto
//NIM: 1301168560
//Kelas: IFX-40-01
//Tugas Program 2 AI - Fuzzy Logic 
using System;
using System.Collections;
class FuzzyLogic
{
    //1. proses fuzzification menggunakan 2 fungsi keanggotaan yakni Emosi dan Provokasi
    static ArrayList FuzzifikasiEmosi(int nEmosi)

    {

            ArrayList emosiAL = new ArrayList();
            if (nEmosi <= 39)
            {
                emosiAL.Add("rendah");
                emosiAL.Add((double)1);
            }
            else if (nEmosi > 39 && nEmosi < 40)
            {
                emosiAL.Add("rendah");
                emosiAL.Add((double)(-1 * (nEmosi - 40)) / (40 - 39));
                emosiAL.Add("sedang");
                emosiAL.Add((double)(nEmosi - 39) / (40 - 39));
            }
            else if (nEmosi == 40)
            {
                emosiAL.Add("sedang");
                emosiAL.Add((double)1);
            }
            else if (nEmosi > 40 && nEmosi < 41)
            {
                emosiAL.Add("sedang");
                emosiAL.Add((double)(-1 * (nEmosi - 41)) / (41 - 40));
                emosiAL.Add("tinggi");
                emosiAL.Add((double)(nEmosi - 40) / (41 - 40));
            }
            else if (nEmosi >= 41 && nEmosi <= 64)
            {
                emosiAL.Add("tinggi");
                emosiAL.Add((double)1);

            }
            else if (nEmosi > 64 && nEmosi < 70)
            {
                emosiAL.Add("tinggi");
                emosiAL.Add((double)(-1 * (nEmosi - 70)) / (70 - 60));
                emosiAL.Add("sangattinggi");
                emosiAL.Add((double)(nEmosi - 64) / (70 - 64));
            }
            else if (nEmosi >= 70)
            {
                emosiAL.Add("sangattinggi");
                emosiAL.Add((double)1);
            }
            return emosiAL;
        }
    static double bandingkecil(double a, double b)
    {
        double hasil;
        if (a <= b)
        {
            hasil = a;
        }
        else
            hasil = b;
        return hasil;
    }
    static ArrayList FuzzifikasiProvokasi(int nProvokasi)
    {
        ArrayList provokasiAL = new ArrayList();
        if (nProvokasi <= 60)
        {
            provokasiAL.Add("pasif");
            provokasiAL.Add((double)1);
        }
        else if (nProvokasi > 60 && nProvokasi < 66)
        {
            provokasiAL.Add("pasif");
            provokasiAL.Add((double)(-1 * (nProvokasi - 66)) / (65 - 60));
            provokasiAL.Add("biasa");
            provokasiAL.Add((double)(nProvokasi - 60) / (65 - 60));
        }
        else if (nProvokasi >= 65 && nProvokasi <= 76)
        {
            provokasiAL.Add("biasa");
            provokasiAL.Add((double)1);
        }
        else if (nProvokasi > 70 && nProvokasi < 76)
        {
            provokasiAL.Add("biasa");
            provokasiAL.Add((double)(-1 * (nProvokasi - 76)) / 10);
            provokasiAL.Add("aktif");
            provokasiAL.Add((double)(nProvokasi - 70) / 10);
        }
        else if (nProvokasi >= 76)
        {
            provokasiAL.Add("aktif");
            provokasiAL.Add((double)1);
        }
        return provokasiAL;
    }

    //3. Proses Rule Aggregration
    static string inferensikata(string emosi, string provokasi)
    {
        string hasil = "tidak terdeteksi";
        if (emosi == "rendah" && provokasi == "pasif")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "rendah" && provokasi == "biasa")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "rendah" && provokasi == "aktif")
        {
            hasil = "Hoax";
        }
        else if (emosi == "sedang" && provokasi =="pasif")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "sedang" && provokasi == "biasa")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "sedang" && provokasi == "aktif")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "tinggi" && provokasi == "pasif")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "tinggi" && provokasi == "biasa")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "tinggi" && provokasi == "aktif")
        {
            hasil = "Hoax";
        }
        else if (emosi == "sangattinggi" && provokasi == "pasif")
        {
            hasil = "Bukan Hoax";
        }
        else if (emosi == "sangattinggi" && provokasi == "biasa")
        {
            hasil = "Hoax";
        }
        else if (emosi == "sangattinggi" && provokasi == "aktif")
        {
            hasil = "Hoax";
        }

        return hasil;
    }

    // Proses Rule Evaluation, mencari nilai minimum
    static ArrayList Inferensi(ArrayList emosiAl, ArrayList provokasiAl)
    {
        ArrayList hasil = new ArrayList();
        Double a, b;
        for (int i = 0; i < emosiAl.Count; i += 2)
        {
            for (int j = 0; j < provokasiAl.Count; j += 2)
            {
                hasil.Add(inferensikata((string)emosiAl[i], (string)provokasiAl[j]));
                a = (double)provokasiAl[j + 1];
                b = (double)emosiAl[i + 1];
                hasil.Add(bandingkecil(a, b));
            }
        }
        return hasil;
    }
    //proses Defuzzyfication
    static ArrayList defuzzy(ArrayList hInferensi)
    {
        ArrayList hasil = new ArrayList();
        hasil.Add((string)hInferensi[0]);
        hasil.Add((double)hInferensi[1]);
        for (int i = 2; i < hInferensi.Count; i += 2)
        {
            if ((string)hasil[0] == (string)hInferensi[i] && (double)hasil[1] > (double)hInferensi[i + 1])
            {
                hasil[1] = hInferensi[i + 1];
            }
            if ((string)hasil[0] != (string)hInferensi[i])
            {
                hasil.Add(hInferensi[i]);
                hasil.Add(hInferensi[i + 1]);
            }
        }
        if (hasil.Count > 2)
        {
            for (int i = 2; i < hInferensi.Count; i += 2)
            {
                if ((string)hasil[2] == (string)hInferensi[i] && (double)hasil[3] > (double)hInferensi[i + 1])
                {
                    hasil[3] = hInferensi[i + 1];
                }
            }
        }
        return hasil;
    }
    static double ujikelayakan(ArrayList hasilinferensi)
    {
        double hasil = 0, bagi = 0;
        for (int i = 0; hasilinferensi.Count > i; i += 2)
        {
            if ((string)hasilinferensi[i] == "Bukan Hoax")
            {
                hasil += (10 + 20 + 30 + 40 + 50) * (double)hasilinferensi[i + 1];
                bagi += 5 * (double)hasilinferensi[i + 1];
            }
            if ((string)hasilinferensi[i] == "Hoax")
            {
                hasil += (60 + 70 + 80 + 90 + 100) * (double)hasilinferensi[i + 1];
                bagi += 5 * (double)hasilinferensi[i + 1];
            }
        }
        hasil /= bagi;
        return hasil;
    }

    static void Fuzz(int emo, int pro, int y)
    {
        ArrayList hasilFuzzPro;
        ArrayList hasilFuzzEm;
        ArrayList hasilInfern;
        ArrayList hasilDefuz;
        double kelayakan;
        Console.WriteLine("----- Data training B" + y + "-----");
        Console.WriteLine("                  ");
        hasilFuzzPro = FuzzifikasiProvokasi(pro);
        hasilFuzzEm = FuzzifikasiEmosi(emo);
        for (int i = 0; i < hasilFuzzEm.Count; i += 2)
        {
            Console.Write("  jenis emosi: " + (string)hasilFuzzEm[i] + " ");
            Console.WriteLine(hasilFuzzEm[i + 1]);
        }
        for (int i = 0; i < hasilFuzzPro.Count; i += 2)
        {
            Console.Write("  jenis provokasi: " + (string)hasilFuzzPro[i] + " ");
            Console.WriteLine(hasilFuzzPro[i + 1]);
        }
        hasilInfern = Inferensi(hasilFuzzEm, hasilFuzzPro);
        for (int i = 0; i < hasilInfern.Count; i += 2)
        {
            Console.Write("  hasil inferensi: " + (string)hasilInfern[i] + " ");
            Console.WriteLine(hasilInfern[i + 1]);
        }
        hasilDefuz = defuzzy(hasilInfern);
        for (int i = 0; i < hasilDefuz.Count; i += 2)
        {
            Console.Write("  hasil Defuzzy: " + (string)hasilDefuz[i] + " ");
            Console.WriteLine(hasilDefuz[i + 1]);
        }
        kelayakan = ujikelayakan(hasilDefuz);
        Console.WriteLine("  uji kelayakan: " + kelayakan);
        if (kelayakan >= 50)
        {
            Console.WriteLine("\n Output: Hoax");
        }
        else
            Console.WriteLine("\n Output: Bukan Hoax");
        Console.WriteLine("----------------------------");
    }
    static void Main()
    {

        int em, pr, x = 1;
        while (x != 0)
        {
            Console.Clear();
            Console.WriteLine("Fuzzy Logic - Mamdani | Arif Yulianto | 1301168560 - IFX40-01");
            Console.WriteLine("=============================================================");
            Console.WriteLine(" 1. Data Training(Given) ");
            Console.WriteLine(" 2. Data Test(Given) ");
            Console.WriteLine(" 3. Input Data Baru ");
            Console.WriteLine(" 0. Keluar");
            Console.WriteLine("=============================================================");
            Console.Write("Masukan Pilihan: ");
            x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                int[] emo = { 97, 36, 63, 82, 71, 79, 55, 57, 40, 57, 77, 68, 60, 82, 40, 80, 60, 50, 100, 11 };
                int[] pro = { 74, 85, 43, 90, 25, 81, 62, 45, 65, 45, 70, 75, 70, 90, 85, 68, 72, 95, 18, 99 };
                for (int y = 0; y < 20; y++)
                {
                    Fuzz(emo[y], pro[y], y + 1);
                }
                Console.ReadLine();

            }
            else if (x == 2)
            {
                int[] emotest = { 58, 68, 64, 57, 77, 98, 91, 50, 95, 27 };
                int[] protest = { 63, 70, 66, 77, 55, 64, 59, 95, 55, 79 };
                for (int y = 0; y < 10; y++)
                {
                    Fuzz(emotest[y], protest[y], y + 21);
                }
                Console.ReadLine();
            }
            else if (x == 3)
            {
                Console.WriteLine("Masukan nilai emosi: ");
                em = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Masukan nilai provokasi: ");
                pr = Convert.ToInt32(Console.ReadLine());
                Fuzz(em, pr, 3901);
                Console.ReadLine();
            }
        }
    }

}