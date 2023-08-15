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

    [Table("tbl_enroute_airways")]
    [Keyless]
    public class EnrouteAirway
    {

        [MaxLength(3)]
        [Column("area_code")]
        public string AreaCode { get; set; }

        [MaxLength(5)]
        [Column("route_identifier")]
        public string RouteIdentifier { get; set; }

        [MaxLength(4)]
        [Column("seqno")]
        public int SequenceNumber { get; set; }

        [MaxLength(2)]
        [Column("icao_code")]
        public string IcaoCode { get; set; }

        [MaxLength(5)]
        [Column("fix_identifier")]
        public string FixIdentifier { get; set; }

        [MaxLength(9)]
        [Column("fix_latitude")]
        public float FixLatitude { get; set; }

        [MaxLength(10)]
        [Column("fix_longitude")]
        public float FixLongitude { get; set; }

        [MaxLength(4)]
        [Column("waypoint_description_code")]
        public string WaypointDescriptionCode { get; set; }

        [MaxLength(1)]
        [Column("route_type")]
        public string RouteType { get; set; }

        [MaxLength(1)]
        [Column("flightlevel")]
        public string FlightLevel { get; set; }

        [MaxLength(1)]
        [Column("directional_restriction")]
        public string DirectionalRestriction { get; set; }

        [MaxLength(2)]
        [Column("cruise_table_identifier")]
        public string CruiseTableIdentifier { get; set; }

        [MaxLength(5)]
        [Column("minimum_altitude1")]
        public int MinimumAltitude1 { get; set; }

        [MaxLength(5)]
        [Column("minimum_altitude2")]
        public int MinimumAltitude2 { get; set; }

        [MaxLength(5)]
        [Column("maximum_altitude")]
        public int MaximumAltitude { get; set; }

        [MaxLength(5)]
        [Column("outbound_course")]
        public double OutboundCourse { get; set; }

        [MaxLength(5)]
        [Column("inbound_course")]
        public double InboundCourse { get; set; }

        [MaxLength(5)]
        [Column("inbound_distance")]
        public double InboundDistance { get; set; }
                    }
}
