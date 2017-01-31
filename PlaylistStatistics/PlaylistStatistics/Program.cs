using PlaylistStatistics.Core.Controllers;
using PlaylistStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistStatistics
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Please enter the file name as the parameter. (File path together)" +
                                    Environment.NewLine +
                                    "Ex: PlaylistStatistics.exe \"C:\\document.csv\"");
                Console.ReadKey();

                return Environment.ExitCode;
            }

            ConsoleHeader();


            string outputPath = Path.GetDirectoryName(args[0]);
            DateTime processDate = new DateTime(2016, 08, 10);

            // In the .csv file provided to us, the data is divided by tab space(\t).
            PlaylistController playlistController = new PlaylistController(args[0], '\t');

            var clientPlaylistHistories = playlistController.ClientPlaylistHistories(processDate);
            playlistController.WriteFileClientPlaylistHistories(clientPlaylistHistories, "CLIENT_ID\tDISTINCT_PLAY_COUNT", outputPath, "ClientPlaylistHistories.txt");

            var playlistStatistics = playlistController.PlaylistStatistics(processDate);
            playlistController.WriteFilePlaylistStatistics(playlistStatistics, "DISTINCT_PLAY_COUNT\tCLIENT_COUNT", outputPath, "PlaylistStatistics.txt");


            Console.WriteLine("Çıkmak için enter'a basınız..");
            Console.ReadKey();

            return 0;
        }


        private static void ConsoleHeader()
        {
            Console.WriteLine("***********************************************************************************");
            Console.WriteLine("* VS ile direkt çalıştırıldığında çıktı sonuçları Resources altında oluşmaktadır. *");
            Console.WriteLine("*                                                                                 *");
            Console.WriteLine("* Eğer program manuel olarak parametre verilip çalıştırılırsa                     *");
            Console.WriteLine("* verilen parametredeki yol/dizin üzerinde oluşmaktadır.                          *");
            Console.WriteLine("*                                                                                 *");
            Console.WriteLine("* Çıktı Sonuçları;                                                                *");
            Console.WriteLine("* 1. ClientPlaylistHistories.txt -> ClientID başına farklı çalınan müzik sayısı.  *");
            Console.WriteLine("* 2. PlaylistStatistics.txt -> PDF üzerinde verilen istatistik sonuçları.(ÖNEMLİ) *");
            Console.WriteLine("***********************************************************************************");
        }
    }
}
