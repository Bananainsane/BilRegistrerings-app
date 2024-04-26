namespace BilRegistrering_s_app
{
    // Each enum value is associated with a description detailing the reason for the recall.
    public enum RecalledCars
    {
        // Fiat Punto from 01/01/2010 was recalled due to a faulty exhaust.
        [Description("Faulty exhaust")]
        fiat_punto_01_01_2010,

        // Alfaromeo Giulia from 01/08/2019 was recalled due to a faulty steering wheel.
        [Description("Faulty steering wheel")]
        alfa_romeo_giulia_01_08_2019,
    }
}
