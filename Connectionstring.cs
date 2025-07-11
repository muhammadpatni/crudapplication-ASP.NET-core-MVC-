namespace crudapplication
{
    public static class Connectionstring
    {
        private static string constring = "Data Source=DESKTOP-GJBQRB1\\SQLEXPRESS;Initial Catalog = lms; Integrated Security = True; Encrypt=True;Trust Server Certificate=True";
        public static string getconstring { get => constring; }
    }
}
