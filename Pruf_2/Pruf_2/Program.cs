namespace Pruf_dReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string codePruf_d = File.ReadAllText("Pruf_d.txt");
            string drevo = "";
            string[] masCodePruf_d = codePruf_d.Split(";");
            int[] mas = new int[10];

            int dtm = 0;

            for (int i = 0; i < mas.Length; i++) mas[i] = i + 1;
            while (codePruf_d[codePruf_d.Length - 1] != 0)
            {
                int[] minmm = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int min = int.MaxValue;
                for (int j = mas.Length - 1; j >= 0; j--)
                {
                    if (mas[j] != 0)
                    {
                        for (int i = 0; i < masCodePruf_d.Length; i++)
                        {
                            if (mas[j] == Convert.ToInt32(masCodePruf_d[i])) break;
                            else if (i == masCodePruf_d.Length - 1) minmm[j] = mas[j];
                        }
                    }
                }

                for (int i = 0; i < minmm.Length; i++)
                    if (minmm[i] != 0 && minmm[i] < min) min = minmm[i];

                if (masCodePruf_d[masCodePruf_d.Length - 1] == "0")
                {
                    for (int i = 0; i < mas.Length; i++) if (mas[i] != 0) drevo += $" {mas[i]}";
                    
                    break;
                }

                if (masCodePruf_d[masCodePruf_d.Length - 1] != "0")
                {

                    for (int i = 0; i < masCodePruf_d.Length; i++)
                        if (masCodePruf_d[i] != "0")
                        {
                            drevo += masCodePruf_d[i];
                            break;
                        }
                    drevo += $"-{min}, ";
                    masCodePruf_d[dtm] = "0";

                    mas[min - 1] = 0;
                }
                else
                    break;
                
                dtm++;
            }
            Console.WriteLine($"Ребра: {drevo}");
            string Otvet_d = "Otvet_d.txt";
            File.WriteAllText(Otvet_d, drevo);
        }
    }
}