using System;
using System.Collections.Generic;

namespace tfm.Properties.Data.Navdata;

public partial class Header
{
    public string Version { get; set; } = null!;

    public string Arincversion { get; set; } = null!;

    public string RecordSet { get; set; } = null!;

    public string CurrentAirac { get; set; } = null!;

    public string Revision { get; set; } = null!;

    public string EffectiveFromto { get; set; } = null!;

    public string PreviousAirac { get; set; } = null!;

    public string PreviousFromto { get; set; } = null!;

    public string ParsedAt { get; set; } = null!;
}
