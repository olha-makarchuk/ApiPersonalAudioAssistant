namespace ApiPersonalAudioAssistant
{
    public class SubUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string? UserName { get; set; }
        public required string? StartPhrase { get; set; }
        public string? EndPhrase { get; set; }
        public string? EndTime { get; set; }
        public required string? VoiceId { get; set; }
        public required List<double> UserVoice { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public required string UserId { get; set; }
        public required string PhotoPath { get; set; }
    }
}
