﻿using System;
using System.Collections.Generic;

namespace tfm.Properties.Data.Navdata;

public partial class AirportCommunication
{
    public string? AreaCode { get; set; }

    public string? IcaoCode { get; set; }

    public string? AirportIdentifier { get; set; }

    public string? CommunicationType { get; set; }

    public double? CommunicationFrequency { get; set; }

    public string? FrequencyUnits { get; set; }

    public string? ServiceIndicator { get; set; }

    public string? Callsign { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}