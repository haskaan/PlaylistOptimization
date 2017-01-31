using PlaylistStatistics.Core.Controllers;
using PlaylistStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistStatistics.Test
{
    class Program
    {
        #region [Test Data]

        private static List<PlaylistHistory> testPlaylistHistory = new List<PlaylistHistory>()
        {
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2493964E053CF0A000AB546",
                SongID = 6164,
                ClientID = 1,
                PlayTS = Convert.ToDateTime("09/08/2016 09:16:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC24A3964E053CF0A000AB546",
                SongID = 544,
                ClientID = 3,
                PlayTS = Convert.ToDateTime("10/08/2016 13:54:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC24B3964E053CF0A000AB546",
                SongID = 9648,
                ClientID = 3,
                PlayTS = Convert.ToDateTime("08/08/2016 06:08:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC24C3964E053CF0A000AB546",
                SongID = 7565,
                ClientID = 2,
                PlayTS = Convert.ToDateTime("10/08/2016 17:30:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC24D3964E053CF0A000AB546",
                SongID = 8995,
                ClientID = 1,
                PlayTS = Convert.ToDateTime("11/08/2016 02:40:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC24E3964E053CF0A000AB546",
                SongID = 4407,
                ClientID = 1,
                PlayTS = Convert.ToDateTime("08/08/2016 07:30:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC24F3964E053CF0A000AB546",
                SongID = 5839,
                ClientID = 2,
                PlayTS = Convert.ToDateTime("10/08/2016 02:40:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2503964E053CF0A000AB546",
                SongID = 548,
                ClientID = 3,
                PlayTS = Convert.ToDateTime("09/08/2016 20:45:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2513964E053CF0A000AB546",
                SongID = 376,
                ClientID = 3,
                PlayTS = Convert.ToDateTime("10/08/2016 04:57:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2523964E053CF0A000AB546",
                SongID = 3403,
                ClientID = 2,
                PlayTS = Convert.ToDateTime("08/08/2016 21:14:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2533964E053CF0A000AB546",
                SongID = 7256,
                ClientID = 2,
                PlayTS = Convert.ToDateTime("10/08/2016 06:29:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2543964E053CF0A000AB546",
                SongID = 4291,
                ClientID = 3,
                PlayTS = Convert.ToDateTime("08/08/2016 09:26:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2553964E053CF0A000AB546",
                SongID = 5722,
                ClientID = 2,
                PlayTS = Convert.ToDateTime("08/08/2016 23:33:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2563964E053CF0A000AB546",
                SongID = 9857,
                ClientID = 1,
                PlayTS = Convert.ToDateTime("10/08/2016 22:05:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2573964E053CF0A000AB546",
                SongID = 3122,
                ClientID = 2,
                PlayTS = Convert.ToDateTime("09/08/2016 08:35:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2583964E053CF0A000AB546",
                SongID = 217,
                ClientID = 2,
                PlayTS = Convert.ToDateTime("10/08/2016 13:20:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC2593964E053CF0A000AB546",
                SongID = 3022,
                ClientID = 1,
                PlayTS = Convert.ToDateTime("10/08/2016 17:06:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC25A3964E053CF0A000AB546",
                SongID = 9857,
                ClientID = 1,
                PlayTS = Convert.ToDateTime("10/08/2016 15:06:00")
            },
            new PlaylistHistory()
            {
                PlayID = "44BB190BC25B3964E053CF0A000AB546",
                SongID = 2168,
                ClientID = 3,
                PlayTS = Convert.ToDateTime("11/08/2016 13:30:33")
            }
        };

        #endregion


        static void Main(string[] args)
        {
            string outputPath = Environment.CurrentDirectory;
            DateTime processDate = new DateTime(2016, 08, 10);

            // In the .csv file provided to us, the data is divided by tab space(\t).
            PlaylistController playlistController = new PlaylistController(testPlaylistHistory);

            var clientPlayliesHistories = playlistController.ClientPlaylistHistories(processDate);
            playlistController.WriteFileClientPlaylistHistories(clientPlayliesHistories, "CLIENT_ID\tDISTINCT_PLAY_COUNT", outputPath, "ClientPlaylistHistories.txt");

            var playlistStatistics = playlistController.PlaylistStatistics(processDate);
            playlistController.WriteFilePlaylistStatistics(playlistStatistics, "DISTINCT_PLAY_COUNT\tCLIENT_COUNT", outputPath, "PlaylistStatistics.txt");

        }
    }
}
