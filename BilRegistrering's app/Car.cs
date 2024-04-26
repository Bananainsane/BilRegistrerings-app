namespace BilRegistrering_s_app
{
    // Represents a car with various details such as make, model, and service history.
    public class Car
    {
        // The last date the car was serviced.
        public DateTime LastServiceDate { get; set; } = DateTime.MinValue;

        public string Make { get; set; }
        public string Model { get; set; }

        // The date when the car was manufactured.
        public DateTime ManufacturingDate { get; set; } = DateTime.MinValue;

        public string LicensePlate { get; set; }

        // The engine size of the car.
        public decimal EngineSize { get; set; }

        // Contact information of the car owner.
        public string OwnerContactInfo { get; set; }

        // List of repairs that the car requires.
        public string RepairRequirements { get; set; }

        // Indicates if the car requires an inspection.
        public bool NeedsInspection { get; set; }

        // Indicates if the car has been recalled.
        public bool IsRecalled { get; set; }

        // Description of the reason for the recall.
        public string RecallDescription { get; set; }

        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Determines if the car requires a special inspection based on its age.
        public bool RequiresSpecialInspection()
        {
            int carAge = this.LastServiceDate != DateTime.MinValue ? DateCalculator.CalculateCarAge(this.LastServiceDate) : DateCalculator.CalculateCarAge(this.ManufacturingDate);
            return carAge > Constants.SpecialInspectionAge;
        }
        // Returns a string representation of the car details.
        public override string ToString()
        {
            return $"{Make} {Model} ({ManufacturingDate:dd/MM/yyyy}) - {LicensePlate}";
        }
    }
}
