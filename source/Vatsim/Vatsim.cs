using tfm;
using System;
using System.Collections.Generic;

using System.Globalization;

using FSUIPC;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace tfm.Vatsim
{
    public partial class VatsimDataBlock
    {
        [JsonProperty("general", NullValueHandling = NullValueHandling.Ignore)]
        public General General { get; set; }

        [JsonProperty("pilots", NullValueHandling = NullValueHandling.Ignore)]
        public List<Pilot> Pilots { get; set; }

        [JsonProperty("controllers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ati> Controllers { get; set; }

        [JsonProperty("atis", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ati> Atis { get; set; }

        [JsonProperty("servers", NullValueHandling = NullValueHandling.Ignore)]
        public List<ServerElement> Servers { get; set; }

        [JsonProperty("prefiles", NullValueHandling = NullValueHandling.Ignore)]
        public List<Prefile> Prefiles { get; set; }

        [JsonProperty("facilities", NullValueHandling = NullValueHandling.Ignore)]
        public List<Facility> Facilities { get; set; }

        [JsonProperty("ratings", NullValueHandling = NullValueHandling.Ignore)]
        public List<Facility> Ratings { get; set; }

        [JsonProperty("pilot_ratings", NullValueHandling = NullValueHandling.Ignore)]
        public List<PilotRating> PilotRatings { get; set; }
    }

    public partial class Ati
    {

        public string FacilityShortName { get; set; }
        public string RatingShortName { get; set; }

        [JsonProperty("cid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cid { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("callsign", NullValueHandling = NullValueHandling.Ignore)]
        public string Callsign { get; set; }

        [JsonProperty("frequency", NullValueHandling = NullValueHandling.Ignore)]
        public string Frequency { get; set; }

        [JsonProperty("facility", NullValueHandling = NullValueHandling.Ignore)]
        public long? Facility { get; set; }

        [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rating { get; set; }

        [JsonProperty("server", NullValueHandling = NullValueHandling.Ignore)]
        public ServerEnum? Server { get; set; }

        [JsonProperty("visual_range", NullValueHandling = NullValueHandling.Ignore)]
        public long? VisualRange { get; set; }

        [JsonProperty("atis_code")]
        public string AtisCode { get; set; }

        [JsonProperty("text_atis")]
        public List<string> TextAtis { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("logon_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LogonTime { get; set; }
    }

    public partial class Facility
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("short", NullValueHandling = NullValueHandling.Ignore)]
        public string Short { get; set; }

        [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
        public string Long { get; set; }
    }

    public partial class General
    {
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; set; }

        [JsonProperty("reload", NullValueHandling = NullValueHandling.Ignore)]
        public long? Reload { get; set; }

        [JsonProperty("update", NullValueHandling = NullValueHandling.Ignore)]
        public string Update { get; set; }

        [JsonProperty("update_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdateTimestamp { get; set; }

        [JsonProperty("connected_clients", NullValueHandling = NullValueHandling.Ignore)]
        public long? ConnectedClients { get; set; }

        [JsonProperty("unique_users", NullValueHandling = NullValueHandling.Ignore)]
        public long? UniqueUsers { get; set; }
    }

    public partial class PilotRating
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("short_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortName { get; set; }

        [JsonProperty("long_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LongName { get; set; }
    }

    public partial class Pilot
    {
        public string RatingShortName { get; set; }

        public double DistanceFrom
        {
            get
            {
                FsLatLonPoint point = new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value);
                return Math.Round(point.DistanceFromInNauticalMiles(new FsLatLonPoint(this.Latitude, this.Longitude)), 0);
            } // Get
        } // DistanceFrom

        public double BearingTo
        {
            get
            {
                FsLatLonPoint point = new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value);
                return Math.Round(point.BearingTo(new FsLatLonPoint(this.Latitude, this.Longitude)), 0);
            } // Get
        } // BearingTo

        [JsonProperty("cid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cid { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("callsign", NullValueHandling = NullValueHandling.Ignore)]
        public string Callsign { get; set; }

        [JsonProperty("server", NullValueHandling = NullValueHandling.Ignore)]
        public ServerEnum? Server { get; set; }

        [JsonProperty("pilot_rating", NullValueHandling = NullValueHandling.Ignore)]
        public long? PilotRating { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("altitude", NullValueHandling = NullValueHandling.Ignore)]
        public long? Altitude { get; set; }

        [JsonProperty("groundspeed", NullValueHandling = NullValueHandling.Ignore)]
        public long? Groundspeed { get; set; }

        [JsonProperty("transponder", NullValueHandling = NullValueHandling.Ignore)]
        public string Transponder { get; set; }

        [JsonProperty("heading", NullValueHandling = NullValueHandling.Ignore)]
        public long? Heading { get; set; }

        [JsonProperty("qnh_i_hg", NullValueHandling = NullValueHandling.Ignore)]
        public double? QnhIHg { get; set; }

        [JsonProperty("qnh_mb", NullValueHandling = NullValueHandling.Ignore)]
        public long? QnhMb { get; set; }

        [JsonProperty("flight_plan")]
        public FlightPlan FlightPlan { get; set; }

        [JsonProperty("logon_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LogonTime { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdated { get; set; }
    }

    public partial class FlightPlan
    {
        [JsonProperty("flight_rules", NullValueHandling = NullValueHandling.Ignore)]
        public FlightRules? FlightRules { get; set; }

        [JsonProperty("aircraft", NullValueHandling = NullValueHandling.Ignore)]
        public string Aircraft { get; set; }

        [JsonProperty("aircraft_faa", NullValueHandling = NullValueHandling.Ignore)]
        public string AircraftFaa { get; set; }

        [JsonProperty("aircraft_short", NullValueHandling = NullValueHandling.Ignore)]
        public string AircraftShort { get; set; }

        [JsonProperty("departure", NullValueHandling = NullValueHandling.Ignore)]
        public string Departure { get; set; }

        [JsonProperty("arrival", NullValueHandling = NullValueHandling.Ignore)]
        public string Arrival { get; set; }

        [JsonProperty("alternate", NullValueHandling = NullValueHandling.Ignore)]
        public string Alternate { get; set; }

        [JsonProperty("cruise_tas", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? CruiseTas { get; set; }

        [JsonProperty("altitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Altitude { get; set; }

        [JsonProperty("deptime", NullValueHandling = NullValueHandling.Ignore)]
        public string Deptime { get; set; }

        [JsonProperty("enroute_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EnrouteTime { get; set; }

        [JsonProperty("fuel_time", NullValueHandling = NullValueHandling.Ignore)]
        public string FuelTime { get; set; }

        [JsonProperty("remarks", NullValueHandling = NullValueHandling.Ignore)]
        public string Remarks { get; set; }

        [JsonProperty("route", NullValueHandling = NullValueHandling.Ignore)]
        public string Route { get; set; }

        [JsonProperty("revision_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? RevisionId { get; set; }

        [JsonProperty("assigned_transponder", NullValueHandling = NullValueHandling.Ignore)]
        public string AssignedTransponder { get; set; }
    }

    public partial class Prefile
    {
        [JsonProperty("cid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cid { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Name { get; set; }

        [JsonProperty("callsign", NullValueHandling = NullValueHandling.Ignore)]
        public string Callsign { get; set; }

        [JsonProperty("flight_plan", NullValueHandling = NullValueHandling.Ignore)]
        public FlightPlan FlightPlan { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdated { get; set; }
    }

    public partial class ServerElement
    {
        [JsonProperty("ident", NullValueHandling = NullValueHandling.Ignore)]
        public ServerEnum? Ident { get; set; }

        [JsonProperty("hostname_or_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string HostnameOrIp { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public ServerEnum? Name { get; set; }

        [JsonProperty("clients_connection_allowed", NullValueHandling = NullValueHandling.Ignore)]
        public long? ClientsConnectionAllowed { get; set; }

        [JsonProperty("client_connections_allowed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClientConnectionsAllowed { get; set; }

        [JsonProperty("is_sweatbox", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSweatbox { get; set; }
    }

    public enum ServerEnum { Amsterdam, Canada, Germany, Singapore, Uk, UsaEast, UsaWest };

    public enum FlightRules { I, V };

    public partial class VatsimDataBlock
    {
        public static VatsimDataBlock FromJson(string json) => JsonConvert.DeserializeObject<VatsimDataBlock>(json, Vatsim.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this VatsimDataBlock self) => JsonConvert.SerializeObject(self, Vatsim.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
        {
            ServerEnumConverter.Singleton,
            FlightRulesConverter.Singleton,
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
        };
    }

    internal class ServerEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ServerEnum) || t == typeof(ServerEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AMSTERDAM":
                    return ServerEnum.Amsterdam;
                case "CANADA":
                    return ServerEnum.Canada;
                case "GERMANY":
                    return ServerEnum.Germany;
                case "SINGAPORE":
                    return ServerEnum.Singapore;
                case "UK":
                    return ServerEnum.Uk;
                case "USA-EAST":
                    return ServerEnum.UsaEast;
                case "USA-WEST":
                    return ServerEnum.UsaWest;
            }
            throw new Exception("Cannot unmarshal type ServerEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ServerEnum)untypedValue;
            switch (value)
            {
                case ServerEnum.Amsterdam:
                    serializer.Serialize(writer, "AMSTERDAM");
                    return;
                case ServerEnum.Canada:
                    serializer.Serialize(writer, "CANADA");
                    return;
                case ServerEnum.Germany:
                    serializer.Serialize(writer, "GERMANY");
                    return;
                case ServerEnum.Singapore:
                    serializer.Serialize(writer, "SINGAPORE");
                    return;
                case ServerEnum.Uk:
                    serializer.Serialize(writer, "UK");
                    return;
                case ServerEnum.UsaEast:
                    serializer.Serialize(writer, "USA-EAST");
                    return;
                case ServerEnum.UsaWest:
                    serializer.Serialize(writer, "USA-WEST");
                    return;
            }
            throw new Exception("Cannot marshal type ServerEnum");
        }

        public static readonly ServerEnumConverter Singleton = new ServerEnumConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class FlightRulesConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FlightRules) || t == typeof(FlightRules?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "I":
                    return FlightRules.I;
                case "V":
                    return FlightRules.V;
            }
            throw new Exception("Cannot unmarshal type FlightRules");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FlightRules)untypedValue;
            switch (value)
            {
                case FlightRules.I:
                    serializer.Serialize(writer, "I");
                    return;
                case FlightRules.V:
                    serializer.Serialize(writer, "V");
                    return;
            }
            throw new Exception("Cannot marshal type FlightRules");
        }

        public static readonly FlightRulesConverter Singleton = new FlightRulesConverter();
    }
}