using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Properties.Data.Navigraph
{

    [Table("tbl_enroute_waypoints")]
    [PrimaryKey(nameof(IcaoCode), nameof(WaypointIdentifier))]
    public class EnrouteWaypoint
    {

        [MaxLength(3)]
        [Column("area_code")]
        public string AreaCode { get; set; }

        [Required, MaxLength(2)]
        [Column("icao_code")]
        public string IcaoCode { get; set; }

        [Required, MaxLength(5)]
        [Column("waypoint_identifier")]
        public string WaypointIdentifier { get; set; }

        [MaxLength(25)]
        [Column("waypoint_name")]
        public string WaypointName { get; set; }

        [MaxLength(3)]
        [Column("waypoint_type")]
        public string WaypointType { get; set; }

        [MaxLength(2)]
        [Column("waypoint_usage")]
        public string WaypointUsage { get; set; }

        [MaxLength(9)]
        [Column("waypoint_latitude")]
        public float WaypointLatitude { get; set; }

        [MaxLength(10)]
        [Column("waypoint_longitude")]
        public float WaypointLongitude { get; set; }
    }
}
