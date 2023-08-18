using System;

namespace BilRegistrering_s_app
{
    public class Car
    {
        public DateTime LastServiceDate { get; set; } = DateTime.MinValue;
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingDate { get; set; } = DateTime.MinValue;
        public string LicensePlate { get; set; }
        public decimal EngineSize { get; set; }
        public string OwnerContactInfo { get; set; }
        public string RepairRequirements { get; set; }
        public bool NeedsInspection { get; set; }
        public bool IsRecalled { get; set; }
        public string RecallDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



        public bool RequiresSpecialInspection()
        {
            int carAge = this.LastServiceDate != DateTime.MinValue ? DateCalculator.CalculateCarAge(this.LastServiceDate) : DateCalculator.CalculateCarAge(this.ManufacturingDate);
            return carAge > Constants.SpecialInspectionAge;
        }



        public override string ToString()
        {
            return $"{Make} {Model} ({ManufacturingDate:dd/MM/yyyy}) - {LicensePlate}";
        }
    }
}
