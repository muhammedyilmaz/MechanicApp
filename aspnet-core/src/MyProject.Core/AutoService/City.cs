using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.AutoService
{
    [Table(nameof(City))]
    public class City : FullAuditedEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
