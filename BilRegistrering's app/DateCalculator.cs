
public static class DateCalculator
{
    // Calculates the age of a car based on its manufacturing date.
    public static int CalculateCarAge(DateTime manufacturingDate)
    {
        int currentYear = DateTime.Now.Year;
        int carYear = manufacturingDate.Year;

        return currentYear - carYear;
    }
}
