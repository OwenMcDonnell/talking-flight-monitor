using System;
using System.Collections.Generic;

namespace tfm.Properties.Data.Navdata;

public partial class TblPathpoint
{
    public string? AreaCode { get; set; }

    public string? AirportIdentifier { get; set; }

    public string? IcaoCode { get; set; }

    public string? ApproachProcedureIdent { get; set; }

    public string? RunwayIdentifier { get; set; }

    public long? SbasServiceProviderIdentifier { get; set; }

    public string? ReferencePathIdentifier { get; set; }

    public double? LandingThresholdLatitude { get; set; }

    public double? LandingThresholdLongitude { get; set; }

    public double? LtpEllipsoidHeight { get; set; }

    public double? GlidepathAngle { get; set; }

    public double? FlightpathAlignmentLatitude { get; set; }

    public double? FlightpathAlignmentLongitude { get; set; }

    public double? CourseWidthAtThreshold { get; set; }

    public long? LengthOffset { get; set; }

    public long? PathPointTch { get; set; }

    public string? TchUnitsIndicator { get; set; }

    public long? Hal { get; set; }

    public long? Val { get; set; }

    public double? FpapEllipsoidHeight { get; set; }

    public double? FpapOrthometricHeight { get; set; }

    public double? LtpOrthometricHeight { get; set; }

    public string? ApproachTypeIdentifier { get; set; }

    public long? GnssChannelNumber { get; set; }
}
