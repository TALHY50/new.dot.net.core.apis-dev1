using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Asp.Versioning;

public class ErrorObjectConverter : JsonConverter<ProblemDetails>
{
    public override void Write(
        Utf8JsonWriter writer,
        ProblemDetails value,
        JsonSerializerOptions options )
    {
        if ( IsSupported( value ) )
        {
            WriteErrorObject( writer, value, options );
        }
        else
        {
            options = new JsonSerializerOptions( options );
            options.Converters.Remove( this );
            JsonSerializer.Serialize( writer, value, options );
        }
    }

    protected virtual void WriteErrorObject(
        Utf8JsonWriter writer,
        ProblemDetails problemDetails,
        JsonSerializerOptions options )
    {
        writer.WriteStartObject();
        writer.WriteStartObject( "error" );

        if ( problemDetails.Extensions.TryGetValue( "code", out var value ) )
        {
            writer.WriteString( "code", value.ToString() );
        }

        writer.WriteString( "message", problemDetails.Title );

        if ( !string.IsNullOrEmpty( problemDetails.Instance ) )
        {
            writer.WriteString( "target", problemDetails.Instance );
        }

        if ( !string.IsNullOrEmpty( problemDetails.Detail ) )
        {
            writer.WriteStartArray( "details" );
            writer.WriteStringValue( problemDetails.Detail );
            writer.WriteEndArray();
        }

        writer.WriteEndObject();
        writer.WriteEndObject();
    }

    public override ProblemDetails Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options ) => throw new NotSupportedException();

    private static bool IsSupported( ProblemDetails problemDetails )
    {
        if ( problemDetails.Type == ProblemDetailsDefaults.Unsupported.Type )
        {
            return true;
        }

        if ( problemDetails.Type == ProblemDetailsDefaults.Unspecified.Type )
        {
            return true;
        }

        if ( problemDetails.Type == ProblemDetailsDefaults.Invalid.Type )
        {
            return true;
        }

        if ( problemDetails.Type == ProblemDetailsDefaults.Ambiguous.Type )
        {
            return true;
        }

        return false;
    }
}