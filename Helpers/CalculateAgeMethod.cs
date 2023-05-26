namespace eventsApi.Helpers
{
    public static class CalculateAgeMethod
    {
        public static int Getcurrentage(this DateTimeOffset dateOfBirth)
        {
            var now = DateTime.Now;

            var currentYear = now.Year;
            var birthYear = dateOfBirth.Year;

            var age = currentYear - birthYear;

            if(dateOfBirth > now.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}