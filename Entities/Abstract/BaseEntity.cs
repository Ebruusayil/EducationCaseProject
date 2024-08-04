using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            IsDeleted = false;
            CreationTime = DateTime.UtcNow;
            // CreatorId = CurrentUser.Id;

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsActive {get;set;}
        public bool IsDeleted {get;set;}
        public DateTime CreationTime {get;set;}= DateTime.UtcNow;
        public int? CreatorId {get;set;}
        public DateTime? LastModificationTime {get;set;}
        public int? LastModificatorId {get;set;}
        public DateTime? DeletionTime {get;set;}
        public int? DeleterId {get;set;}
    }
}
