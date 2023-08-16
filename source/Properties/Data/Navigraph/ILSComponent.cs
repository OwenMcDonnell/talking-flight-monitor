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

    [Table("tbl_localizers_glideslopes")]
    [PrimaryKey(nameof(AirportIdentifier), nameof(LLZIdentifier))]
    public class ILSComponent
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

        [MaxLength(3)]
        [Column("runway_identifier")]
        public string RunwayIdentifier { get; set; }

        [Required, MaxLength(4)]
        [Column("llz_identifier")]
        public string LLZIdentifier { get; set; }

        [MaxLength(9)]
        [Column("llz_latitude")]
        public double LLZLatitude { get; set; }

        [MaxLength(10)]
        [Column("llz_longitude")]
        public double LLZLongitude { get; set; }

        [MaxLength(6)]
        [Column("llz_frequency")]
        public double LLZFrequency { get; set; }

        [MaxLength(6)]
        [Column("llz_bearing")]
        public double LLZBearing { get; set; }

        [MaxLength(6)]
        [Column("llz_width")]
        public double LLZWidth { get; set; }

        [MaxLength(1)]
        [Column("ils_mls_gls_category")]
        public string LLZCategory { get; set; }

        [MaxLength(9)]
        [Column("gs_latitude")]
        public double GSLatitude { get; set; }

        [MaxLength(10)]
        [Column("gs_longitude")]
        public double GSLongitude { get; set; }

        [MaxLength(4)]
        [Column("gs_angle")]
        public double GSAngle { get; set; }

        [MaxLength(5)]
        [Column("gs_elevation")]
        public int GSElevation { get; set; }

        [MaxLength(5)]
        [Column("station_declination")]
        public double StationDeclination { get; set; }


    }
}
