using System.ComponentModel.DataAnnotations;

namespace ServiceName.Options;

internal sealed class InstanceOptions : BaseOptions
{
    public const string SectionKey = nameof(InstanceOptions);

    [Required]
    public required string ProdId { get; set; }
}
