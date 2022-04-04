using System;
using ZaminEducationClone.Domain.Enums;

namespace ZaminEducationClone.Domain.Commons
{
    public interface IAuditable
    {
        public Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        ItemState Status { get; set; }
    }
}
