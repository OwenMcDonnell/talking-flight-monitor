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

    [Table("tbl_airports")]
    [PrimaryKey(nameof(IcaoCode), nameof(AirportIdentifier))]
    public class Airport
    {

        [MaxLength(3)]
        [Column("area_code")]
        public string AreaCode { get; set; }

        [Required, MaxLength(2)]
        [Column("icao_code")]
        public string IcaoCode { get; set; }

        [Required, MaxLength(4)]
        [Column("airport_identifier")]
        public string AirportIdentifier { get; set; }

        [MaxLength(3)]
        [Column("airport_identifier_3letter")]
        public string AirportIdentifier3Letter { get; set; }

        [MaxLength(30)]
        [Column("airport_name")]
        public string AirportName { get; set; }

        [MaxLength(9)]
        [Column("airport_ref_latitude")]
        public double AirportLatitude { get; set; }

        [MaxLength(9)]
        [Column("airport_ref_longitude")]
        public double AirportLongitude { get; set; }

        [MaxLength(1)]
        [Column("ifr_capability")]
        public string IFRCapability { get; set; }

        [MaxLength(1)]
        [Column("longest_runway_surface_code")]
        public string LongestRunwaySurfaceCode { get; set; }

        [MaxLength(5)]
        [Column("elevation")]
        public int Elevation { get; set; }

        [MaxLength(5)]
        [Column("transition_altitude")]
        public int TransitionAltitude { get; set; }

        [MaxLength(3)]
        [Column("speed_limit")]
        public int SpeedLimit { get; set; }

        [MaxLength(5)]
        [Column("speed_limit_altitude")]
        public int SpeedLimitAltitude { get; set; }

        [MaxLength(3)]
        [Column("iata_ata_designator")]
        public string IataATADesignator { get; set; }


    }
}
