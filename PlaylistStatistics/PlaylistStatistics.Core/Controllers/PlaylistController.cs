using PlaylistStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistStatistics.Core.Controllers
{
    public class PlaylistController
    {
        #region [Fields]

        private CSVContext csvContext;

        #endregion


        #region [Properties]

        public CSVContext CSVContext
        {
            get { return csvContext; }
        }

        #endregion


        #region [Constructors]

        public PlaylistController(IEnumerable<PlaylistHistory> playlistHistories)
        {
            csvContext = new CSVContext(playlistHistories);
        }

        public PlaylistController(string filePath, char delimeter)
        {
            csvContext = new CSVContext(filePath, delimeter);
        }

        #endregion


        #region [Public Methods]

        public IEnumerable<ClientPlaylistHistory> ClientPlaylistHistories(DateTime date)
        {
            IQueryable<PlaylistHistory> playlistHistoryQuery = csvContext.PlaylistHistories.AsQueryable();

            // Only the data dated 10.08.2016 will be listed.
            playlistHistoryQuery = playlistHistoryQuery.Where(o => o.PlayTS.Date == date).OrderBy(o => o.ClientID);

            // The data was first grouped by ClientID value.
            // The number of different songs that each Client listens to is listed.
            var clientPlaylistHistories = playlistHistoryQuery.GroupBy(o => o.ClientID)
                                                    .Select(o => new ClientPlaylistHistory()
                                                    {
                                                        ClientID = o.Key,
                                                        DistinctPlayCount = o.Select(so => so.SongID).Distinct().Count()
                                                    });

            return clientPlaylistHistories.AsEnumerable();
        }


        public IEnumerable<PlaylistStatistic> PlaylistStatistics(DateTime date)
        {
            var clientPlaylistHistories = ClientPlaylistHistories(date);

            // Firstly, how many different music are played are grouped.
            // Then, how many users belong to grouped data are available.
            var playlistStatistics = clientPlaylistHistories.OrderBy(o => o.DistinctPlayCount)
                                                            .GroupBy(o => o.DistinctPlayCount)
                                                            .Select(o => new PlaylistStatistic()
                                                            {
                                                                DistinctPlayCount = o.Key,
                                                                ClientCount = o.Select(so => so.ClientID).Distinct().Count()
                                                            });

            return playlistStatistics.AsEnumerable();
        }


        public void WriteFileClientPlaylistHistories(IEnumerable<ClientPlaylistHistory> clientPlaylistHistories, string header, string outputPath, string fileName)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine(header);

            foreach (var item in clientPlaylistHistories)
            {
                strBuilder.AppendLine(item.ClientID + "\t" + item.DistinctPlayCount);
            }

            WriteFile(strBuilder.ToString(), outputPath, fileName);
        }

        public void WriteFilePlaylistStatistics(IEnumerable<PlaylistStatistic> playlistStatistics, string header, string outputPath, string fileName)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine(header);

            foreach (var item in playlistStatistics)
            {
                strBuilder.AppendLine(item.DistinctPlayCount + "\t" + item.ClientCount);
            }

            WriteFile(strBuilder.ToString(), outputPath, fileName);
        }

        #endregion


        #region [Private Methods]

        private void WriteFile(string content, string outputPath, string fileName)
        {
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(outputPath + "\\" + fileName);
            file.WriteLine(content);

            file.Close();
        }

        #endregion
    }
}
