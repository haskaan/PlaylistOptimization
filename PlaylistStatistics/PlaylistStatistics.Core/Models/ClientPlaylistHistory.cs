using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistStatistics.Core.Models
{
    public class ClientPlaylistHistory
    {
        public int ClientID { get; set; }

        public int DistinctPlayCount { get; set; }
    }
}
