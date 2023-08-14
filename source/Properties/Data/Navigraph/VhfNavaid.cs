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
    
    [Table("tbl_vhfnavaids")]
    [PrimaryKey(nameof(IcaoCode), nameof(VorIdentifier))]    
    public class VhfNavaid
    {
        [MaxLength(3)]
                [Column("area_code")]
        public string AreaCode { get; set; }

        [MaxLength(4)]
        [Column("airport_identifier")]
        public string AirportIdentifier { get; set; }


        [Required, MaxLength(2)]
                [Column("icao_code")]
        public string IcaoCode { get; set; }

        
        [Required, MaxLength(4)]
        [Column("vor_identifier")]
        public string VorIdentifier { get; set; }

        [MaxLength(30)]
        [Column("vor_name")]
        public string VorName { get; set; }

        [MaxLength(30)]
        [Column("vor_frequency")]
        public float VorFrequency { get; set; }

        [MaxLength(5)]
        [Column("navaid_class")]
        public string NavaidClass { get; set; }

        [MaxLength(9)]
        [Column("vor_latitude")]
        public float VorLatitude { get; set; }

        [MaxLength(10)]
        [Column("vor_longitude")]
        public float VorLongitude { get; set; }

        [MaxLength(4)]
        [Column("dme_ident")]
        public string DMEIdent { get; set; }

        [MaxLength(9)]
        [Column("dme_latitude")]
        public float DMELatitude { get; set; }

        [MaxLength(10)]
        [Column("dme_longitude")]
        public float DMELongitude { get; set; }

        [MaxLength(5)]
        [Column("dme_elevation")]
        public int DMEElevation { get; set; }

        [MaxLength(3)]
        [Column("ilsdme_bias")]
        public float IlsDMEBias { get; set; }

        [MaxLength(3)]
        [Column("range")]
        public int Range { get; set; }

        [MaxLength(5)]
        [Column("station_declination")]
        public float StationDeclination { get; set; }
   }
}
