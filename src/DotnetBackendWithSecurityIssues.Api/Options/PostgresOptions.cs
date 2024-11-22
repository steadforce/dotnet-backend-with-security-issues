using System.ComponentModel.DataAnnotations;

namespace DotnetBackendWithSecurityIssues.Api.Options
{
    public class PostgresOptions
    {
        public const string OptionsKey = "Postgres";

        [Required]
        public required string Hostname { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid port number. Port must be greater than 0.")]
        public required int Port { get; set; }

        [Required]
        public required string Database { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password {  get; set; }

    }
}
