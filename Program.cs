using System;
using System.Xml.XPath;

namespace CadastroDePessoas
{
    class Program
    {
        static List<User> database = new List<User>();
        public static string menuOption;
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------+");
            Console.WriteLine("| Olá, seja bem-vindo ao progrma de cadastro de usuários");
            Console.WriteLine("| Digite uma opção:");
            Console.WriteLine("| 1 - Cadastrar novo usuário");
            Console.WriteLine("| 2 - Pesquisar um usuário");
            Console.WriteLine("| 3 - Listar todos os usuários");
            Console.WriteLine("| 4 - Sair do programa.");
            Console.Write("\n| >>> ");
            menuOption = Console.ReadLine();
            Console.WriteLine("+------------------------------------------------------+");

            switch (menuOption)
            {
                case "1":
                    CreateUser();
                    break;

                case "2":
                    SearchUser();
                    break;

                case "3":
                    ReadUsers();
                    break;

                case "4":
                    Console.WriteLine("Até mais! :)");
                    break;

                default:
                    Console.WriteLine("\nOps! digite um número válido\n");
                    Menu();
                    break;
            }
        }

        static void CreateUser()
        {
            Console.Clear();
            string name;
            string email;
            int age;
            Console.WriteLine("+------------------------------------------------------");
            Console.WriteLine("| Digite seus dados");
            Console.Write("| Nome completo: ");
            name = Console.ReadLine();
            if (name == "") { CreateUser(); }

            Console.Write("| Email: ");
            email = Console.ReadLine();
            if (email == "") { CreateUser(); }

            Console.Write("| Idade: ");
            bool ageParseSucess;
            ageParseSucess = int.TryParse(Console.ReadLine(), out age);

            if (!ageParseSucess)
            {
                CreateUser();
            }

            User newUser = new User(name, email, age);

            database.Add(newUser);
            Menu();
        }

        static void ReadUsers()
        {
            Console.Clear();
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|   Todos os usuários  |");
            Console.WriteLine("+----------------------+");
            Console.WriteLine("");

            foreach (var person in database)
            {
                Console.WriteLine("+-------------------------+");
                Console.WriteLine($"| Nome:  {person.name}    ");
                Console.WriteLine($"| Email: {person.email}   ");
                Console.WriteLine($"| Idade: {person.age}     ");
                Console.WriteLine("+-------------------------+");
                Console.WriteLine("");
            }

            Console.WriteLine("+----------------------+");
            Console.WriteLine("| Deseja voltar para o menu?");
            Console.WriteLine("| 1 - Voltar para o menu");
            Console.WriteLine("| 2 - Pesquisar um usuário específico");
            Console.WriteLine("| 3 - Sair do programa");
            Console.Write("| >>> ");
            menuOption = Console.ReadLine();
            Console.WriteLine("+----------------------+");

            switch (menuOption)
            {
                case "1":
                    Menu();
                    break;

                case "2":
                    SearchUser();
                    break;

                case "3":
                    Console.WriteLine("Até mais! :)");
                    break;

                default:
                    Menu();
                    break;
            }
        }
        static void SearchUser()
        {
            Console.Clear();
            string search = "";
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Digite um nome:");
            Console.Write("| >>> ");
            search = Console.ReadLine();
            Console.WriteLine("+-------------------------+\n");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Resultados encontrados: |");
            Console.WriteLine("+-------------------------+");
            var result = database.FindAll(user => user.name == search);
            int resultLength = result.Count();

            if (resultLength == 0)
            {
                Console.WriteLine("| Sem resultados para a pesquisa.");
            }
            else
            {
                foreach (var person in result)
                {
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine($"| Nome:  {person.name}    ");
                    Console.WriteLine($"| Email: {person.email}   ");
                    Console.WriteLine($"| Idade: {person.age}     ");
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("+-------------------------+");
            Console.Write("| Deseja voltar para o menu?");
            Console.WriteLine("\n| 1 - Voltar para o menu");
            Console.WriteLine("| 2 - Pesquisar outro usuário");
            Console.WriteLine("| 3 - Sair do programa");
            Console.Write("| >>> ");
            menuOption = Console.ReadLine();
            Console.WriteLine("\n+-------------------------+");

            switch (menuOption)
            {
                case "1":
                    Menu();
                    break;

                case "2":
                    SearchUser();
                    break;

                case "3":
                    Console.WriteLine("Até mais! :)");
                    break;

                default:
                    Menu();
                    break;
            }
        }
        static void Main()
        {
            Menu();
        }
    }
}