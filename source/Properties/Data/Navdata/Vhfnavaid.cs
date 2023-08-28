using System;
using System.Collections.Generic;

namespace tfm.Properties.Data.Navdata;

public partial class Vhfnavaid
{
    public string? AreaCode { get; set; }

    public string? AirportIdentifier { get; set; }

    public string IcaoCode { get; set; } = null!;

    public string VorIdentifier { get; set; } = null!;

    public string? VorName { get; set; }

    public double? VorFrequency { get; set; }

    public string? NavaidClass { get; set; }

    public double? VorLatitude { get; set; }

    public double? VorLongitude { get; set; }

    public string? DmeIdent { get; set; }

    public double? DmeLatitude { get; set; }

    public double? DmeLongitude { get; set; }

    public long? DmeElevation { get; set; }

    public double? IlsdmeBias { get; set; }

    public long? Range { get; set; }

    public double? StationDeclination { get; set; }

    public double? MagneticVariation { get; set; }

    public string? Id { get; set; }
}
