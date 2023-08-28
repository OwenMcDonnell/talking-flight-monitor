﻿using System;
using System.Collections.Generic;

namespace tfm.Properties.Data.Navdata;

public partial class TerminalWaypoint
{
    public string? AreaCode { get; set; }

    public string RegionCode { get; set; } = null!;

    public string IcaoCode { get; set; } = null!;

    public string WaypointIdentifier { get; set; } = null!;

    public string? WaypointName { get; set; }

    public string? WaypointType { get; set; }

    public double? WaypointLatitude { get; set; }

    public double? WaypointLongitude { get; set; }

    public string? Id { get; set; }
}
