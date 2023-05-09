using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Refresh.GameServer.Types.Matching;

[SuppressMessage("Maintainability", "CA1507:Use nameof to express symbol names")]
public class SerializedRoomData
{
    [JsonProperty("Player")]
    public string? Player { get; set; }
    
    [JsonProperty("Players")]
    public List<string>? Players { get; set; }

    [JsonProperty("Reservations")]
    public List<int>? Reservations { get; set; }

    [JsonProperty("NAT")]
    public NatType? NatType { get; set; }

    [JsonProperty("Slot")]
    public List<int>? Slots { get; set; }

    [JsonProperty("RoomState")]
    public RoomState? RoomState { get; set; }

    [JsonProperty("HostMood")]
    public byte? HostMood { get; set; }

    [JsonProperty("PassedNoJoinPoint")]
    public bool? PassedNoJoinPoint { get; set; }

    [JsonProperty("Location")]
    public List<string>? Locations { get; set; }

    [JsonProperty("Language")]
    public byte? Language { get; set; }

    [JsonProperty("BuildVersion")]
    public int? BuildVersion { get; set; }

    [JsonProperty("Search")]
    public string? Search { get; set; }
}