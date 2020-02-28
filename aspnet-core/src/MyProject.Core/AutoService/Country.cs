using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.AutoService
{
    [Table(nameof(Country))]
    public class Country : FullAuditedEntity
    {
        public string Name { get; set; }
    }
}
