using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Aiport_App_Structure.Models;

namespace Airport_App_Core.Models.AirplaneModels
{
    public class AddNewPlane
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstraints.Aicraft.ModelMaxLength)]
        [MinLength(DataConstraints.Aicraft.ModelMinLength)]
        [DisplayName("Type model of the Aircraft")]
        public string Model { get; set; } = null!;

        [Required]
        [DisplayName("Add all seats available")]
        public int Capacity { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [DisplayName("Select Manufacturer")]
        public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
    }
}
