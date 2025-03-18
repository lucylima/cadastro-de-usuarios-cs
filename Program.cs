﻿using System;
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
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Digite seus dados");
            Console.Write("\nNome completo: ");
            name = Console.ReadLine();
            Console.Write("\nEmail: ");
            email = Console.ReadLine();
            Console.Write("\nIdade: ");
            age = Convert.ToInt32(Console.ReadLine());
            User newUser = new User(name, email, age);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Seus dados: ");
            Console.WriteLine("Nome   -   Email   -   Idade");
            Console.WriteLine(newUser.name + " | " + newUser.email + " | " + newUser.age);
            database.Add(newUser);
            Menu();
        }

        static void ReadUsers()
        {
            Console.Clear();
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|   Todos os usuários  |");
            Console.WriteLine("+----------------------+");
            Console.WriteLine("+------+-------+-------+");
            Console.WriteLine("| Nome | Email | Idade |");
            Console.WriteLine("+------+-------+-------+");

            foreach (var person in database)
            {
                Console.WriteLine($"| {person.name} | {person.email} | {person.age}");
            }

            Console.WriteLine("+----------------------+");
            Console.Write("\nDeseja voltar para o menu?");
            Console.WriteLine("1 - Voltar para o menu");
            Console.WriteLine("2 - Pesquisar um usuário específico");
            Console.Write("\n>>> ");
            menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    Menu();
                    break;

                case "2":
                    SearchUser();
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
            Console.WriteLine("digite um nome");
            Console.Write("\n>>>");
            search = Console.ReadLine();
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Resultados encontrados: |");
            Console.WriteLine("+-------------------------+");
            var result = database.FindAll(user => user.name.ToLower() == search.ToLower());

            foreach (var person in result)
            {
                Console.WriteLine("+-------------------------+");
                Console.WriteLine($"| Nome:  {person.name}    ");
                Console.WriteLine($"| Email: {person.email}   ");
                Console.WriteLine($"| Idade: {person.age}     ");
                Console.WriteLine("+-------------------------+");
            }
            Console.WriteLine("");
            Console.Write("\nDeseja voltar para o menu?");
            Console.WriteLine("1 - Voltar para o menu");
            Console.WriteLine("2 - Pesquisar outro usuário");
            Console.Write("\n>>> ");
            menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    Menu();
                    break;

                case "2":
                    SearchUser();
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