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

    [Table("tbl_header")]
    [Keyless]
    public class NavigraphHeader
    {

        [Required, MaxLength(5)]
        [Column("version")]
        public string Version { get; set; }

        [Required, MaxLength(6)]
        [Column("arincversion")]
        public string ArincVersion { get; set; }

        [Required, MaxLength(2)]
        [Column("revision")]
        public string Revision { get; set; }

        [Required, MaxLength(8)]
        [Column("record_set")]
        public string RecordSet { get; set; }

        [Required, MaxLength(4)]
        [Column("current_airac")]
        public string CurrentAirac { get; set; }

        [Required, MaxLength(10)]
        [Column("effective_fromto")]
        public string EffectiveFromTo { get; set; }

        [Required, MaxLength(4)]
        [Column("previous_airac")]
        public string PreviousAirac { get; set; }

        [Required, MaxLength(10)]
        [Column("previous_fromto")]
        public string PreviousFromTo { get; set; }

        [Required, MaxLength(22)]
        [Column("parsed_at")]
        public string ParsedAt { get; set; }
    }
}
