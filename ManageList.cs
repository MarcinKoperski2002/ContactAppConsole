using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ContactAppConsole
{
    public class ManageList
    {
        static List<Person> people = new List<Person>();
        static string filePath = "contacts.json";

        public static void AddPerson()
        {
            Console.WriteLine("\nWpisz swoje imię:");
            var firstName = Console.ReadLine();

            Console.WriteLine("\nWpisz swoje nazwisko:");
            var lastName = Console.ReadLine();

            Console.WriteLine("\nWpisz swój adres e-mail:");
            var email = Console.ReadLine();

            Console.WriteLine("\nWpisz swój numer telefonu:");
            var phoneNumber = Console.ReadLine();

            Console.WriteLine("\nWpisz swoją datę urodzenia: (dd.MM.yyyy)");
            var dateOfBirthVar = Console.ReadLine();
            DateTime dateOfBirth = DateTime.Parse(dateOfBirthVar!);

            int ID;

            ID = people.Count + 1;
            Person person = new Person(firstName!, lastName!, email!, ID, dateOfBirth, phoneNumber!);
            people.Add(person);

            Console.WriteLine("\nOsoba została dodana do listy kontaktów!\n");

            SavePerson();

            Menu.MenuChoice();
        }

        public static void SavePerson()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(people);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception)
            {
                Console.WriteLine("\nWystąpił błąd podczas zapisywania kontaktów!\n");
            }
        }

        public static void LoadPerson()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    people = JsonConvert.DeserializeObject<List<Person>>(jsonData)!;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nWystąpił błąd podczas wczytywania kontaktów!\n");
                }
            }
        }

        public static void SearchPerson()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("\nBrak kontaktów do wyszukiwania!\n");
                Menu.MenuChoice();
            }
            else
            {
                Console.WriteLine("\nWpisz imię lub nazwisko wyszukiwanego kontaktu:");
                var searchContact = Console.ReadLine();

                List<Person> searchResults = people.Where(s => s.FirstName.Contains(searchContact!, StringComparison.OrdinalIgnoreCase)
                || s.LastName.Contains(searchContact!, StringComparison.OrdinalIgnoreCase)).ToList();

                if (searchResults.Count == 0)
                {
                    Console.WriteLine("\nBrak wyników wyszukiwania!\n");
                    Menu.MenuChoice();
                }
                else
                {
                    Console.WriteLine("\nWyniki wyszukiwania:\n");
                    foreach (var person in searchResults)
                    {
                        Console.WriteLine($"ID: {person.ID} \n" +
                                          $"Imię: {person.FirstName} \n" +
                                          $"Nazwisko: {person.LastName} \n" +
                                          $"Adres email: {person.Email} \n" +
                                          $"Numer telefonu: {person.PhoneNumber} \n" +
                                          $"Data urodzenia: {person.DateOfBirth} \n");
                    }

                    Menu.MenuChoice();
                }
            }
        }

        public static void ShowPeople()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("\nBrak kontaktów do wyświetlenia!\n");
                Menu.MenuChoice();
            }
            else
            {
                Console.WriteLine("\nLista kontaktów:\n");
                foreach (var person in people)
                {
                    Console.WriteLine($"ID: {person.ID} \n" +
                                      $"Imię: {person.FirstName} \n" +
                                      $"Nazwisko: {person.LastName} \n" +
                                      $"Adres email: {person.Email} \n" +
                                      $"Numer telefonu: {person.PhoneNumber} \n" +
                                      $"Data urodzenia: {person.DateOfBirth} \n");
                }
            }
            Menu.MenuChoice();
        }

        public static void EditPeople()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("\nBrak kontaktów do edytowania!\n");
                Menu.MenuChoice();
            }
            else
            {
                Console.WriteLine("Wpisz numer ID osoby:");

                int id = int.Parse(Console.ReadLine()!);

                Person person = people.Find(c => c.ID == id)!;

                if (person != null)
                {
                    Console.WriteLine("\nWybierz opcję do zmiany:\n\n" +
                    "1. Zmiana imienia\n" +
                    "2. Zmiana nazwiska\n" +
                    "3. Zmiana adresu e-mail\n" +
                    "4. Zmiana numeru telefonu\n" +
                    "5. Zmiana daty urodzenia\n" +
                    "6. Wróć do poprzedniej sekcji\n" +
                    "7. Zamknij program\n");

                    var userInput = Console.ReadLine()!;

                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("\nAktualne imię: " + person.FirstName);
                            Console.WriteLine("Wpisz swoje nowe imię:");
                            var newFirstName = Console.ReadLine();
                            person.FirstName = newFirstName!;
                            Console.WriteLine("Twoje imię zostało zmienione.\n");
                            SavePerson();
                            Menu.MenuChoice();
                            break;
                        case "2":
                            Console.WriteLine("\nAktualne nazwisko: " + person.LastName);
                            Console.WriteLine("Wpisz swoje nowe nazwisko:");
                            var newLastName = Console.ReadLine();
                            person.LastName = newLastName!;
                            Console.WriteLine("Twoje nazwisko zostało zmienione.\n");
                            SavePerson();
                            Menu.MenuChoice();
                            break;
                        case "3":
                            Console.WriteLine("\nAktualny adres e-mail: " + person.Email);
                            Console.WriteLine("Wpisz swój nowy adres e-mail:");
                            var newEmail = Console.ReadLine();
                            person.Email = newEmail!;
                            Console.WriteLine("Twój adres e-mail został zmieniony.\n");
                            SavePerson();
                            Menu.MenuChoice();
                            break;
                        case "4":
                            Console.WriteLine("\nAktualny numer telefonu: " + person.PhoneNumber);
                            Console.WriteLine("Wpisz swój nowy numer telefonu:");
                            var newPhoneNumber = Console.ReadLine();
                            person.PhoneNumber = newPhoneNumber!;
                            Console.WriteLine("Twój numer telefonu został zmieniony.\n");
                            SavePerson();
                            Menu.MenuChoice();
                            break;
                        case "5":
                            Console.WriteLine("\nAktualna data urodzenia: " + person.DateOfBirth);
                            Console.WriteLine("Wpisz swoją datę urodzenia:");
                            var newDateOfBirthVar = Console.ReadLine();
                            DateTime newDateOfBirth = DateTime.Parse(newDateOfBirthVar!);
                            person.DateOfBirth = newDateOfBirth;
                            Console.WriteLine("Twoja data urodzenia została zmieniona.\n");
                            SavePerson();
                            Menu.MenuChoice();
                            break;
                        case "6":
                            Menu.MenuChoice();
                            break;
                        case "7":
                            Environment.Exit(0);
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("\nWpisałeś/aś niewłaściwą cyfrę!\n");
                            Menu.MenuChoice();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nNie znaleziono kontaktu o podanym numerze ID!\n");
                    Menu.MenuChoice();
                }
            }
        }

        public static void DeletePeople()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("\nBrak kontaktów do usunięcia!\n");
                Menu.MenuChoice();
            }
            else
            {
                Console.WriteLine("Wpisz numer ID osoby:");

                int id = int.Parse(Console.ReadLine()!);

                Person person = people.Find(c => c.ID == id)!;

                if (person != null)
                {
                    Console.WriteLine("\nDane osoby do usunięcia:\n");

                    Console.WriteLine($"ID: {person.ID} \n" +
                                      $"Imię: {person.FirstName} \n" +
                                      $"Nazwisko: {person.LastName} \n" +
                                      $"Adres email: {person.Email} \n" +
                                      $"Numer telefonu: {person.PhoneNumber} \n" +
                                      $"Data urodzenia: {person.DateOfBirth} \n");

                    Console.WriteLine("Czy chcesz usunąć ten kontakt? (wpisz cyfrę)\n\n" +
                        "1. Tak" +
                        "\n2. Nie");

                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            people.Remove(person);
                            Console.WriteLine("\nOsoba została usunięta!\n");
                            SavePerson();
                            Menu.MenuChoice();
                            break;
                        case "2":
                            Menu.MenuChoice();
                            break;
                        default:
                            Console.WriteLine("\nWpisałeś/aś niewłaściwą cyfrę!");
                            Menu.MenuChoice();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nNie znaleziono kontaktu o podanym numerze ID!\n");
                    Menu.MenuChoice();
                }
            }
        }
    }
}