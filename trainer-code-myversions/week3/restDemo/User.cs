public class User
{
    public int ID { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }

    public User(int id, string firstName, string lastName)
    {
        ID = id;
        firstName = firstName;
        lastName = lastName;
    }
}