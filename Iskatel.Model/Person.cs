namespace Iskatel.Model
{
    public class Person : Human
    {
        public Date BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public Date? DeathDate { get; set; }

        public Person(string firstName, string patronymic, string lastName, Date birthDate, string birthLocation, Date? deathDate = null)
        {
            FirstName = firstName;
            Patronymic = patronymic;
            LastName = lastName;
            BirthDate = birthDate;
            BirthLocation = birthLocation;
            DeathDate = deathDate;
        }
    }
}
