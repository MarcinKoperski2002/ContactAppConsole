using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppConsole
{
    public class Menu
    {
        static void Main(string[] args)
        {
            ManageList.LoadPerson();
            MenuChoice();
        }

        static string MenuInfo()
        {
            var infoM = "KSIĄŻKA DANYCH OSOBOWYCH\n\n" +
                "1. Wszystkie kontakty\n" +
                "2. Szukaj kontaktów\n" +
                "3. Dodaj kontakt\n" +
                "4. Edytuj kontakt\n" +
                "5. Usuń kontakt\n" +
                "6. Informacje\n" +
                "7. Zamknij program\n";

            return infoM;
        }

        public static void MenuChoice()
        {
            Console.WriteLine(MenuInfo());

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ManageList.ShowPeople();
                    break;
                case "2":
                    ManageList.SearchPerson();
                    break;
                case "3":
                    ManageList.AddPerson();
                    break;
                case "4":
                    ManageList.EditPeople();
                    break;
                case "5":
                    ManageList.DeletePeople();
                    break;
                case "6":
                    Console.WriteLine(Info());
                    MenuChoice();
                    break;
                case "7":
                    ManageList.SavePerson();
                    Environment.Exit(0);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Wpisałeś/aś niewłaściwą cyfrę!");
                    MenuChoice();
                    break;
            }
        }

        static string Info()
        {
            var info = "\nContactApp jest aplikacją, która jest rejestrem dodanych przez użytkownika kontaktów. \n" +
                "Aplikacja umożliwia dodawanie, edytowanie i usuwanie kontaktów oraz ich wyszukiwanie. \n" +
                "Plik listy kontaktów znajduje się wewnątrz plików programu. \n" +
                "© Marcin Koperski | 2023\n";

            return info;
        }
    }
}