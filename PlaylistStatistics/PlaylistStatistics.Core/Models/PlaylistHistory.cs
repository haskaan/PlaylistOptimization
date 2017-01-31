using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistStatistics.Core.Models
{
    public class PlaylistHistory
    {
        public string PlayID { get; set; }

        public int SongID { get; set; }

        public int ClientID { get; set; }

        public DateTime PlayTS { get; set; }
    }
}
