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
    [Table("tbl_enroute_ndbnavaids")]
    [PrimaryKey(nameof(IcaoCode), nameof(NDBIdentifier))]
    public class EnrouteNDB
    {

        [MaxLength(3)]
        [Column("area_code", TypeName ="TEXT(3)")]
        public string AreaCode { get; set; }

        [Required, MaxLength(2)]
        [Column("[icao_code", TypeName ="TEXT(2)")]
        public string IcaoCode { get; set; }

        [Required, MaxLength(4)]
        [Column("ndb_identifier", TypeName ="TEXT(4)")]
        public string NDBIdentifier { get; set; }

        [MaxLength(30)]
        [Column("ndb_name", TypeName ="TEXT(30)")]
        public string NDBName { get; set; }

        [MaxLength(5)]
        [Column("ndb_frequency", TypeName ="REAL(5)")]
        public float NDBFrequency { get; set; }

        [MaxLength(5)]
        [Column("navaid_class")]
        public string NavaidClass { get; set; }

        [MaxLength(9)]
        [Column("ndb_latitude")]
        public float NDBLatitude { get; set; }

        [MaxLength(10)]
        [Column("ndb_longitude")]
        public float NDBLongitude { get; set; }


    }
}
