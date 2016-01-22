using System;

namespace RepositoryT.EntityFramework.Interfaces
{
    public interface ISupportAudit
    {
        DateTime CreateDate { get; set; }
        int CreateUser { get; set; }
        DateTime? UpdateDate { get; set; }
        int? UpdateUser { get; set; }
    }

    public interface ISupportSoftDelete
    {
        bool IsDeleted { get; set; }
        bool IsActive { get; set; }
    }
}