using System;

namespace Rivington.IG.Infrastructure.Persistence
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        Guid? CreatedBy { get; set; }
        DateTime LastUpdatedAt { get; set; }
        Guid? LastUpdatedBy { get; set; }
    }
}