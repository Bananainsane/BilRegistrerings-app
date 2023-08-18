public static class DateCalculator
{
    public static int CalculateCarAge(DateTime manufacturingDate)
    {
        int currentYear = DateTime.Now.Year;
        int carYear = manufacturingDate.Year;

        return currentYear - carYear;
    }
}
