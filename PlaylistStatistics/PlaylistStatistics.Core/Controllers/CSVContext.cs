using PlaylistStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistStatistics.Core.Controllers
{
    public class CSVContext
    {
        #region [Fields]

        private IEnumerable<PlaylistHistory> playlistHistories;

        #endregion


        #region [Properties]

        public IEnumerable<PlaylistHistory> PlaylistHistories
        {
            get { return playlistHistories; }
        }

        #endregion


        #region [Constructors]

        public CSVContext(IEnumerable<PlaylistHistory> playlistHistories)
        {
            this.playlistHistories = playlistHistories;
        }

        public CSVContext(string fileName)
        {
            var document = File.ReadLines(fileName, Encoding.UTF8);

            playlistHistories = CVSParse(document, ',');
        }

        public CSVContext(string fileName, char delimeter)
        {
            var document = File.ReadLines(fileName, Encoding.UTF8);

            playlistHistories = CVSParse(document, delimeter);
        }

        #endregion


        #region [Public Methods]


        #endregion


        #region [Private Methods]

        private IEnumerable<PlaylistHistory> CVSParse(IEnumerable<string> data, char delimeters)
        {
            var query = data.Select(o => o.Split(delimeters)).Skip(1)
                            .Select(o => new PlaylistHistory()
                            {
                                PlayID = o[0],
                                SongID = Convert.ToInt32(o[1]),
                                ClientID = Convert.ToInt32(o[2]),
                                PlayTS = Convert.ToDateTime(o[3])
                            });

            return query;
        }

        #endregion
    }
}
