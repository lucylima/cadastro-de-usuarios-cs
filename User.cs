using System.ComponentModel.DataAnnotations;

// classe de usuário com as informações solicitadas, atributos públicos para que possamos acessar de fora da classe
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