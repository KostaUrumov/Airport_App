using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiport_App_Structure.Models
{
    public class Aircraft
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Aicraft.ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;


    }
}
