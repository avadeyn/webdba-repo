using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace system_SIS.Models.AdminBackEnd
{
    public class AdminSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        [StringLength(50)]
        public required string Day { get; set; }

        [Required]
        [StringLength(50)]
        public required string Session { get; set; }

        [Required]
        [StringLength(100)]
        public required string Subject { get; set; }

        [Required]
        [JsonConverter(typeof(TimeSpanJsonConverter))]
        public TimeSpan Start { get; set; }

        [Required]
        [JsonConverter(typeof(TimeSpanJsonConverter))]
        public TimeSpan End { get; set; }

        public bool IsDeleted { get; set; } = false;
    }

    public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.Parse(value ?? "00:00");
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(@"hh\:mm"));
        }
    }
}