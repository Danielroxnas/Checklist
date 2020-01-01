using System;

namespace Checklist.Models
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}