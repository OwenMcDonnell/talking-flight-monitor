
using FSUIPC;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Threading.Tasks;

namespace tfm.Vatsim.Feed
{
        public partial class VatsimDataBlock
    {
        [JsonProperty("general")]
        public General General { get; set; }

        [JsonProperty("pilots")]
        public List<Pilot> Pilots { get; set; }

        [JsonProperty("controllers")]
        public List<Ati> Controllers { get; set; }

        [JsonProperty("atis")]
        public List<Ati> Atis { get; set; }

        [JsonProperty("servers")]
        public List<ServerElement> Servers { get; set; }

        [JsonProperty("prefiles")]
        public List<Prefile> Prefiles { get; set; }

        [JsonProperty("facilities")]
        public List<Facility> Facilities { get; set; }

        [JsonProperty("ratings")]
        public List<Facility> Ratings { get; set; }

        [JsonProperty("pilot_ratings")]
        public List<PilotRating> PilotRatings { get; set; }
    }

    public partial class Ati
    {
        [JsonProperty("cid")]
        public long Cid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("callsign")]
        public string Callsign { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("facility")]
        public long Facility { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("server")]
        public ServerEnum Server { get; set; }

        [JsonProperty("visual_range")]
        public long VisualRange { get; set; }

        [JsonProperty("atis_code")]
        public string AtisCode { get; set; }

        [JsonProperty("text_atis")]
        public List<string> TextAtis { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("logon_time")]
        public DateTimeOffset LogonTime { get; set; }
    }

    public partial class Facility
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }
    }

    public partial class General
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("reload")]
        public long Reload { get; set; }

        [JsonProperty("update")]
        public string Update { get; set; }

        [JsonProperty("update_timestamp")]
        public DateTimeOffset UpdateTimestamp { get; set; }

        [JsonProperty("connected_clients")]
        public long ConnectedClients { get; set; }

        [JsonProperty("unique_users")]
        public long UniqueUsers { get; set; }
    }

    public partial class PilotRating
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("long_name")]
        public string LongName { get; set; }
    }

    public partial class Pilot
    {
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
        [JsonProperty("cid")]
        public long Cid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("callsign")]
        public string Callsign { get; set; }

        [JsonProperty("server")]
        public ServerEnum Server { get; set; }

        [JsonProperty("pilot_rating")]
        public long PilotRating { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("altitude")]
        public long Altitude { get; set; }

        [JsonProperty("groundspeed")]
        public long Groundspeed { get; set; }

        [JsonProperty("transponder")]
        public string Transponder { get; set; }

        [JsonProperty("heading")]
        public long Heading { get; set; }

        [JsonProperty("qnh_i_hg")]
        public double QnhIHg { get; set; }

        [JsonProperty("qnh_mb")]
        public long QnhMb { get; set; }

        [JsonProperty("flight_plan")]
        public FlightPlan FlightPlan { get; set; }

        [JsonProperty("logon_time")]
        public DateTimeOffset LogonTime { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }


        private async Task<PilotRating[]> GetPilotRatings()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://data.vatsim.net/v3/vatsim-data.json");
            var block = tfm.Vatsim.Feed.VatsimDataBlock.FromJson(response);
            return block.PilotRatings.ToArray();
        } // GetPilotRatings

    }

    public partial class FlightPlan
    {
        [JsonProperty("flight_rules")]
        public FlightRules FlightRules { get; set; }

        [JsonProperty("aircraft")]
        public string Aircraft { get; set; }

        [JsonProperty("aircraft_faa")]
        public string AircraftFaa { get; set; }

        [JsonProperty("aircraft_short")]
        public string AircraftShort { get; set; }

        [JsonProperty("departure")]
        public string Departure { get; set; }

        [JsonProperty("arrival")]
        public string Arrival { get; set; }

        [JsonProperty("alternate")]
        public string Alternate { get; set; }

        [JsonProperty("cruise_tas")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CruiseTas { get; set; }

        [JsonProperty("altitude")]
        public string Altitude { get; set; }

        [JsonProperty("deptime")]
        public string Deptime { get; set; }

        [JsonProperty("enroute_time")]
        public string EnrouteTime { get; set; }

        [JsonProperty("fuel_time")]
        public string FuelTime { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("route")]
        public string Route { get; set; }

        [JsonProperty("revision_id")]
        public long RevisionId { get; set; }

        [JsonProperty("assigned_transponder")]
        public string AssignedTransponder { get; set; }
    }

    public partial class Prefile
    {
        [JsonProperty("cid")]
        public long Cid { get; set; }

        [JsonProperty("name")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Name { get; set; }

        [JsonProperty("callsign")]
        public string Callsign { get; set; }

        [JsonProperty("flight_plan")]
        public FlightPlan FlightPlan { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }

    public partial class ServerElement
    {
        [JsonProperty("ident")]
        public ServerEnum Ident { get; set; }

        [JsonProperty("hostname_or_ip")]
        public string HostnameOrIp { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("name")]
        public ServerEnum Name { get; set; }

        [JsonProperty("clients_connection_allowed")]
        public long ClientsConnectionAllowed { get; set; }

        [JsonProperty("client_connections_allowed")]
        public bool ClientConnectionsAllowed { get; set; }

        [JsonProperty("is_sweatbox")]
        public bool IsSweatbox { get; set; }
    }

    public enum ServerEnum { Amsterdam, Canada, Germany, Singapore, Uk, UsaEast, UsaWest };

    public enum FlightRules { I, V };

    public partial class VatsimDataBlock
    {
        public static VatsimDataBlock FromJson(string json) => JsonConvert.DeserializeObject<VatsimDataBlock>(json, tfm.Vatsim.Feed.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this VatsimDataBlock self) => JsonConvert.SerializeObject(self, tfm.Vatsim.Feed.Converter.Settings);
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
