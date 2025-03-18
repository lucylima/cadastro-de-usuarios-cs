using System.ComponentModel.DataAnnotations;

class User
{
    public string name;
    public string email;
    public int age;
    public User(string name, string email, int age)
    {
        this.name = name;
        this.email = email;
        this.age = age;
    }
}