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

    [Table("tbl_runways")]
    [PrimaryKey(nameof(AirportIdentifier), nameof(RunwayIdentifier))]
    public class Runway
    {

        [MaxLength(3)]
        [Column("area_code")]
        public string AreaCode { get; set; }

        [MaxLength(2)]
        [Column("icao_code")]
        public string IcaoCode { get; set; }

        [Required, MaxLength(4)]
        [Column("airport_identifier")]
        public string AirportIdentifier { get; set; }

        [Required, MaxLength(3)]
        [Column("runway_identifier")]
        public string RunwayIdentifier { get; set; }

        [MaxLength(9)]
        [Column("runway_latitude")]
        public double RunwayLatitude { get; set; }

        [MaxLength(10)]
        [Column("runway_longitude")]
        public double RunwayLongitude { get; set; }

        [MaxLength(5)]
        [Column("runway_gradiant")]
        public int RunwayGradiant { get; set; }

        [MaxLength(6)]
        [Column("runway_magnetic_bearing")]
        public double RunwayMagneticBearing { get; set; }

        [MaxLength(7)]
        [Column("runway_true_bearing")]
        public double RunwayTrueBearing { get; set; }

        [MaxLength(5)]
        [Column("landing_threshold_elevation")]
        public int LandingThresholdElevation { get; set; }

        [MaxLength(4)]
        [Column("displaced_threshold_distance")]
        public int DisplacedThresholdDistance { get; set; }

        [MaxLength(2)]
        [Column("threshold_crossing_height")]
        public int ThresholdCrossingHeight { get; set; }

        [MaxLength(5)]
        [Column("runway_length")]
        public int RunwayLength { get; set; }

        [MaxLength(3)]
        [Column("runway_width")]
        public int RunwayWidth { get; set; }

        [MaxLength(4)]
        [Column("llz_identifier")]
        public string LLZIdentifier { get; set; }

        [MaxLength(1)]
        [Column("llz_mls_gls_category")]
        public string LLZCategory { get; set; }


    }
}
