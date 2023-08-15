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

    [Table("tbl_holdings")]
    [Keyless]
    public class Holding
    {

        [MaxLength(3)]
        [Column("area_code")]
        public string AreaCode { get; set; }

        [MaxLength(4)]
        [Column("region_code")]
        public string RegionCode { get; set; }

        [MaxLength(2)]
        [Column("icao_code")]
        public string IcaoCode { get; set; }

        [MaxLength(5)]
        [Column("fix_identifier")]
        public string FixIdentifier { get; set; }

        [MaxLength(25)]
        [Column("holding_name")]
        public string HoldingName { get; set; }

        [MaxLength(9)]
        [Column("fix_latitude")]
        public float FixLatitude { get; set; }

        [MaxLength(10)]
        [Column("fix_longitude")]
        public float FixLongitude { get; set; }

        [MaxLength(2)]
        [Column("duplicate_identifier")]
        public int DuplicateIdentifier { get; set; }

        [MaxLength(5)]
        [Column("inbound_holding_course")]
        public double InboundHoldingCourse { get; set; }

        [MaxLength(1)]
        [Column("turn_direction")]
        public string TurnDirection { get; set; }

        [MaxLength(3)]
        [Column("leg_length")]
        public double LegLength { get; set; }

        [MaxLength(2)]
        [Column("leg_time")]
        public double LegTime { get; set; }

        [MaxLength(5)]
        [Column("minimum_altitude")]
        public int MinimumAltitude { get; set; }

        [MaxLength(5)]
        [Column("maximum_altitude")]
        public int MaximumAltitude { get; set; }

        [MaxLength(3)]
        [Column("holding_speed")]
        public int HoldingSpeed { get; set; }
    }
}
