// Main variables
using Tarea_4;

byte choice = 0;
int contact_Id = 1, searchId = 0;
string name, phoneNumber, lastname, email, address;

// List to store contacts
List<Contact> contacts = new List<Contact>();

Console.WriteLine("Welcome to your personal agenda!");

do
{
    DisplayMenu();

    switch (choice)
    {
        case 1:
            AddContact();
            break;
        case 2:
            ViewContacts();
            break;
        case 3:
            EditContact();
            break;
        case 4:
            SearchForAContact();
            break;
        case 5:
            DeleteContact();
            break;
        case 6:
            Console.WriteLine("Exiting the program. Goodbye!");
            return;
    }
} while (choice != 6);

// Shows menu and validates input
void DisplayMenu()
{
    Console.WriteLine("\nPlease select an option:");
    Console.WriteLine(@"1. Add a new contact.
2. View contacts.
3. Edit contact.
4. Search contact.
5. Delete contact.
6. Exit.");

    Console.Write("Choice: ");

    while (!byte.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
    {
        Console.Write("Enter a valid option (1-6): ");
    }
}

// Adds a new contact
void AddContact()
{
    Console.WriteLine("\nAdding new contact...");

    Contact contact = new Contact();

    contact.Id = contact_Id;

    Console.Write("Name: ");
    contact.Name = Console.ReadLine();

    Console.Write("Lastname: ");
    contact.LastName = Console.ReadLine();

    Console.Write("Phone: ");
    contact.Phone = Console.ReadLine();

    Console.Write("Email: ");
    contact.Email = Console.ReadLine();

    Console.Write("Address: ");
    contact.Address = Console.ReadLine();

    contacts.Add(contact);

    contact_Id++;

    Console.WriteLine("Contact added successfully.");
}

// Shows all contacts
void ViewContacts()
{
    Console.WriteLine("\nContacts:");

    if (contacts.Count == 0)
    {
        Console.WriteLine("No contacts found.");
        return;
    }

    foreach (var contact in contacts)
    {
        Console.WriteLine($"ID: {contact.Id}, Name: {contact.FullName}, Phone: {contact.Phone}, Email: {contact.Email}, Address: {contact.Address}");
    }
}

// Finds a contact by ID
Contact FindContactById(int id)
{
    foreach (var contact in contacts)
    {
        if (contact.Id == id)
            return contact;
    }

    return null;
}

// Edit an existing contact
void EditContact()
{
    Console.Write("Enter ID to edit: ");
    int editId;

    while (!int.TryParse(Console.ReadLine(), out editId) || editId < 1)
    {
        Console.Write("Enter a valid ID: ");
    }

    Contact contact = FindContactById(editId);

    if (contact == null)
    {
        Console.WriteLine("Contact not found.");
        return;
    }

    Console.WriteLine("\nCurrent contact info:");
    ShowContact(contact);

    Console.WriteLine("\nWhat do you want to edit?");
    Console.WriteLine("1. Name");
    Console.WriteLine("2. Phone");
    Console.WriteLine("3. Email");
    Console.WriteLine("4. Address");
    Console.WriteLine("5. All");

    Console.Write("Choice: ");

    while (!byte.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
    {
        Console.Write("Enter a valid option (1-5): ");
    }

    switch (choice)
    {
        case 1:
            Console.Write($"New name ({contact.FullName}): ");
            name = Console.ReadLine();
            if (name != "") contact.Name = name;
            break;

        case 2:
            Console.Write($"New phone ({contact.Phone}): ");
            phoneNumber = Console.ReadLine();
            if (phoneNumber != "") contact.Phone = phoneNumber;
            break;

        case 3:
            Console.Write($"New email ({contact.Email}): ");
            email = Console.ReadLine();
            if (email != "") contact.Email = email;
            break;

        case 4:
            Console.Write($"New address ({contact.Address}): ");
            address = Console.ReadLine();
            if (address != "") contact.Address = address;
            break;

        case 5:
            EditAllContactInfo(contact);
            break;
    }

    Console.WriteLine("Contact updated.");
}

// Edit all fields
void EditAllContactInfo(Contact contact)
{
    Console.Write($"Name ({contact.FullName}): ");
    name = Console.ReadLine();
    if (name != "") contact.Name = name;

    Console.Write($"Lastname ({contact.LastName}): ");
    lastname = Console.ReadLine();
    if (lastname != "") contact.LastName = lastname;

    Console.Write($"Phone ({contact.Phone}): ");
    phoneNumber = Console.ReadLine();
    if (phoneNumber != "") contact.Phone = phoneNumber;

    Console.Write($"Email ({contact.Email}): ");
    email = Console.ReadLine();
    if (email != "") contact.Email = email;

    Console.Write($"Address ({contact.Address}): ");
    address = Console.ReadLine();
    if (address != "") contact.Address = address;
}

// Search contacts
void SearchForAContact()
{
    Console.WriteLine("\nSearch by:");
    Console.WriteLine("1. ID");
    Console.WriteLine("2. Phone");
    Console.WriteLine("3. Name");

    Console.Write("Choice: ");

    while (!byte.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
    {
        Console.Write("Enter valid option: ");
    }

    if (choice == 1)
    {
        Console.Write("Enter ID: ");

        while (!int.TryParse(Console.ReadLine(), out searchId) || searchId < 1)
        {
            Console.Write("Enter a valid ID: ");
        }

        Contact contact = FindContactById(searchId);

        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        ShowContact(contact);
    }
    else if (choice == 2)
    {
        Console.Write("Enter phone: ");
        phoneNumber = Console.ReadLine();

        foreach (var contact in contacts)
        {
            if (contact.Phone == phoneNumber)
            {
                ShowContact(contact);
                return;
            }
        }

        Console.WriteLine("Contact not found.");
    }
    else
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();

        foreach (var contact in contacts)
        {
            if (contact.FullName == name)
            {
                ShowContact(contact);
                return;
            }
        }

        Console.WriteLine("Contact not found.");
    }
}

// Shows one contact
void ShowContact(Contact contact)
{
    Console.WriteLine($"\nID: {contact.Id}, Name: {contact.FullName}, Phone: {contact.Phone}, Email: {contact.Email}, Address: {contact.Address}");
}

// Deletes a contact
void DeleteContact()
{
    Console.Write("Enter ID to delete: ");
    int deleteId;

    while (!int.TryParse(Console.ReadLine(), out deleteId) || deleteId < 1)
    {
        Console.Write("Enter a valid ID: ");
    }

    Contact contact = FindContactById(deleteId);

    if (contact == null)
    {
        Console.WriteLine("Contact not found.");
        return;
    }

    contacts.Remove(contact);

    Console.WriteLine("Contact deleted.");
}