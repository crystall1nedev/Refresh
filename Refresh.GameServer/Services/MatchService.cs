using Bunkum.HttpServer;
using Bunkum.HttpServer.Services;
using NotEnoughLogs;
using System.Globalization;

namespace Refresh.GameServer.Services;

public class MatchService : EndpointService
{
    public MatchService(LoggerContainer<BunkumContext> logger) : base(logger)
    {}

    public static (string, string) ExtractMethodAndBodyFromJson(string body)
    {
        string method = body.Substring(1, body.IndexOf(',') - 1);
        
        // skip until after second open bracket, replace with JSON object brackets
        int start = 3 + method.Length;
        body = string.Concat("{", body.AsSpan(start, body.Length - 2 - start), "}");
        
        // Fix double arrays
        body = body.Replace("[[", "[")
            .Replace("]]", "]");

        body = ReplaceHexValuesInStringWithIpAddresses(body);

        return (method, body);
    }

    public static string ReplaceHexValuesInStringWithIpAddresses(string body)
    {
        // Replace hex values with string values for easier parsing of IP addresses
        int hexValueLength = "0x17257bc9".Length; // should serialize into 23.39.123.201
        int hexIndex;
        while ((hexIndex = body.IndexOf("0x", StringComparison.Ordinal)) != -1)
        {
            string hex = body.Substring(hexIndex, hexValueLength);
            string ip = ConvertHexadecimalIpAddressToString(hex);
            body = string.Concat(body.AsSpan(0, hexIndex), '\"' + ip + '\"', body.AsSpan(hexIndex + hexValueLength));
        }

        return body;
    }

    // should serialize "0x17257bc9" into "23.39.123.201"
    public static string ConvertHexadecimalIpAddressToString(string hex)
    {
        // parse hex string as uint, stripping 0x header
        uint ip = uint.Parse(hex.Substring(2), NumberStyles.HexNumber);
        
        byte a = (byte)((ip >> 24) & 0xFF);
        byte b = (byte)((ip >> 16) & 0xFF);
        byte c = (byte)((ip >> 8) & 0xFF);
        byte d = (byte)(ip & 0xFF);
        
        return $"{a}.{b}.{c}.{d}"; // combine bytes into IP address string
    }
}