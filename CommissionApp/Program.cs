using CommissionApp.Data;
using CommissionApp.Entities;
using CommissionApp.Repositories;
using CommissionApp.Audit;

var customerRepository = new SqlRepository<Customer>(new CommissionAppDbContext(), CustomerAdded);
var carRepository = new SqlRepository<Car>(new CommissionAppDbContext(), CarAdded);

string action = "[System report: Error!]";
string itemData = "[System report: Error!]";

var auditRepository = new JsonAudit($"{action}", $"{itemData}");

customerRepository.ItemAdded += CustomerRepositoryOnItemAdded;
customerRepository.ItemAdded += EventCustomerAdded;
customerRepository.ItemRemoved += EventItemCustomerRemoved;
customerRepository.AllRemoved += EventAllCustomersRemoved;
customerRepository.NewAuditEntry += EventNewAuditEntry;
carRepository.ItemAdded += CarRepositoryOnItemAdded;
carRepository.ItemAdded += EventCarAdded;
carRepository.ItemRemoved += EventItemCarRemoved;
carRepository.AllRemoved += EventAllCarsRemoved;
carRepository.NewAuditEntry += EventNewAuditCarEntry;
static void CustomerRepositoryOnItemAdded(object? sender, Customer e)
{
    TextColoring(ConsoleColor.Red, $"Event: Customer {e.FirstName} added from repository => {sender?.GetType().Name}!");
}
void EventCustomerAdded(object? sender, Customer item)
{
    action = auditRepository.Action = $"new {item.GetType().Name} added";
    itemData = auditRepository.ItemData = $"{item.GetType().Name}  Id: {item.Id}, Name and surname: {item.FirstName} {item.LastName}";
}
void EventItemCustomerRemoved(object? sender, Customer item)
{
    TextColoring(ConsoleColor.Magenta, $"[{item.GetType().Name}] {item.FirstName} {item.LastName} with ID: {item.Id} was removed from the database.");
    action = auditRepository.Action = $"{item.GetType().Name} removed from the database";
    itemData = auditRepository.ItemData = $"[Delated] {item.GetType().Name} Id: {item.Id}, Name and surname: {item.FirstName} {item.LastName}";
}
void EventAllCustomersRemoved(object? sender, Customer item)
{
    TextColoring(ConsoleColor.Red, $"[{item.GetType().Name}] {item.FirstName} with ID: {item.Id} was removed from the database.");
    action = auditRepository.Action = $"{item.GetType().Name} removed from the database";
    itemData = auditRepository.ItemData = $"[Delated] {item.GetType().Name} Id: {item.Id}, Car brand and model : {item.FirstName} {item.LastName} ";
}
void EventNewAuditEntry(object? sender, Customer item)
{
    TextColoring(ConsoleColor.Blue, $"\nNew entry about {item.GetType().Name} in the AuditFile!");
}
void EventCarAdded(object? sender, Car item)
{
    action = auditRepository.Action = $"new {item.GetType().Name} added";
    itemData = auditRepository.ItemData = $"{item.GetType().Name}  Id: {item.Id}, Car brand and model : {item.CarBrand} {item.CarModel} ";
}
void EventItemCarRemoved(object? sender, Car item)
{
    TextColoring(ConsoleColor.Red, $"[{item.GetType().Name}] {item.CarBrand} with ID: {item.Id} was removed from the database.");
    action = auditRepository.Action = $"{item.GetType().Name} removed from the database";
    itemData = auditRepository.ItemData = $"[Delated] {item.GetType().Name} Id: {item.Id}, Car brand and model : {item.CarBrand} {item.CarModel} ";
}
void EventAllCarsRemoved(object? sender, Car item)
{
    TextColoring(ConsoleColor.Red, $"[{item.GetType().Name}] {item.CarBrand} with ID: {item.Id} was removed from the database.");
    action = auditRepository.Action = $"{item.GetType().Name} removed from the database";
    itemData = auditRepository.ItemData = $"[Delated] {item.GetType().Name} Id: {item.Id}, Car brand and model : {item.CarBrand} {item.CarModel} ";
}

static void CarRepositoryOnItemAdded(object? sender, Car e)
{
    TextColoring(ConsoleColor.Red, $"Event: Car {e.CarBrand} added from repository => {sender?.GetType().Name}!");
}

void EventNewAuditCarEntry(object? sender, Car item)
{
    TextColoring(ConsoleColor.Blue, $"\nNew entry about {item.GetType().Name} in the AuditFile!");
}

static void CustomerAdded(Customer item)

{
    TextColoring(ConsoleColor.Red, $"Action: {item.FirstName}, Added!");
}

static void CarAdded(Car item)
{
    TextColoring(ConsoleColor.Red, $"Action: {item.CarBrand}, Added!");
}

Console.WriteLine("Welcome to Customers and Cars DataBase APP");
Console.WriteLine("This program is the used car dealer");
string input;
do
{
    Console.WriteLine("\n================MENU================");
    Console.WriteLine("1. Add customer");
    Console.WriteLine("2. Add car");
    Console.WriteLine("3. Display all customers");
    Console.WriteLine("4. Display all cars");
    Console.WriteLine("5. Display all customers and cars");
    Console.WriteLine("6. Remove all customers");
    Console.WriteLine("7. Remove all cars");
    Console.WriteLine("8. Remove all customers and cars");
    Console.WriteLine("9. Remove customer by Id");
    Console.WriteLine("10. Remove car by Id");
    Console.WriteLine("11. Display audit file");
    Console.WriteLine(" Press q to exit program: ");
    input = Console.ReadLine();
    Console.WriteLine();

    switch (input)
    {
        case "1":
            AddCustomers(customerRepository);
            break;

        case "2":
            {
                AddCars(carRepository);
            }
            break;
        case "3":
            {
                if (WriteIdToConsoleId(customerRepository) == true)
                {
                    WriteAllToConsole(customerRepository);
                }
                else
                {
                    Console.WriteLine("Incorrect Data! The object was not created.");
                }
            }
            break;
        case "4":
            {
                if (WriteIdToConsoleId(carRepository) == true)
                {
                    WriteAllToConsole(carRepository);
                }
                else
                {
                    Console.WriteLine("Incorrect Data! The object was not created.");
                }
            }
            break;
        case "5":
            {
                if (WriteIdToConsoleId(customerRepository) == true || WriteIdToConsoleId(carRepository) == true)
                {
                    WriteAllToConsole(customerRepository);
                    WriteAllToConsole(carRepository);
                }
                else
                {
                    Console.WriteLine("Incorrect Data! The object was not created.");
                }
            }
            break;
        case "6":
            TextColoring(ConsoleColor.DarkGreen, "\n- - Removing an customers - -");
            RemoveAllItem<Customer>(customerRepository);
            break;
        case "7":
            TextColoring(ConsoleColor.DarkGreen, "\n- - Removing an cars - -");
            RemoveAllItem<Car>(carRepository);
            break;
        case "8":
            TextColoring(ConsoleColor.DarkGreen, "\n- - Removing an customers and cars - -");
            RemoveAllItem<Customer>(customerRepository);
            RemoveAllItem<Car>(carRepository);
            break;
        case "9":
            {
                TextColoring(ConsoleColor.DarkGreen, "\n- - Removing an customer - -");
                RemoveItemById<Customer>(customerRepository);
            }
            break;
        case "10":
            {
                TextColoring(ConsoleColor.DarkGreen, "\n- - Removing an car - -");
                RemoveItemById<Car>(carRepository);
            }
            break;
        case "11":
            {
                WriteAllFromAuditFileToConsole();
            }
            break;
        case "q":
            break;
        default:
            Console.WriteLine("Invalid input. Please try again.");
            break;
    }
} while (input != "q");

bool AddCustomers(IRepository<Customer> customerRepository)
{
    Console.WriteLine("Adding Customer :");
    Console.Write("Enter first name: ");
    var firstname = Console.ReadLine();
    Console.Write("Enter last name: ");
    var lastname = Console.ReadLine();
    Console.Write("Is Premium Client ( true or false): ");
    var email = Console.ReadLine();
    Console.Write("Enter Price: ");
    var price = Console.ReadLine();
    if (firstname != null && lastname != null && email != null && price != null)
    {
        if (firstname == "")
        {
            firstname = "unknown";
        }
        if (lastname == "")
        {
            lastname = "unknown";
        }
        if (email != "true" && email != "false")
        {
            email = "false";
        }
            while (float.TryParse(price, out float stringToFloat)==false)
            {
            Console.Write("the value is incorrect!  ");
            price=Console.ReadLine();
            }

        customerRepository.Add(new Customer { FirstName = firstname, LastName = lastname, Email = bool.Parse(email), Price = float.Parse(price) });
        customerRepository.Save();
        auditRepository.AddEntryToFile();
        auditRepository.SaveAuditFile();
        return true;
    }
    else
    {
        return false;
    }
}
bool AddCars(IWriteRepository<Car> repository)
{
    Console.WriteLine("\nAdding Car :");
    Console.Write("Enter car's brand : ");
    var carbrand = Console.ReadLine();
    Console.Write("Enter car's model : ");
    var carmodel = Console.ReadLine();
    repository.Add(new Car { CarBrand = carbrand, CarModel = carmodel });
    repository.Save();
    auditRepository.AddEntryToFile();
    auditRepository.SaveAuditFile();
    return true;
}
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
bool WriteIdToConsoleId(IReadRepository<IEntity> repository)
{
    var item = repository.GetById(1);
    if (item == null)
    {
        return false;
    }
    else
    {
        return true;
    }
}
void RemoveItemById<T>(IRepository<T> repository)
    where T : class, IEntity
{
    bool isIdCorrect = true;
    do
    {
        Console.WriteLine($"\nEnter the ID of the person you want to remove from the database:\n(Press 'q' button + 'ENTER' button to quit and back to main menu)");

        var input = Console.ReadLine();
        if (input == "q")
        {
            break;
        }

        try
        {
            isIdCorrect = int.TryParse(input, out int id);
            repository.Remove(repository.GetById(id));
            auditRepository.AddEntryToFile();
        }
        catch (Exception exception)
        {
            TextColoring(ConsoleColor.DarkRed, $"\nWarning! Exception catched:\n{exception.Message}\n");
            TextColoring(ConsoleColor.DarkRed, "This ID is not existing! Try again!\n\t(Tip: View the list from the main menu to check the ID of the person you want to remove from the database)\n");
        }
        finally
        {
            repository.Save();
            auditRepository.SaveAuditFile();
        }
    } while (false);
}
void RemoveAllItem<T>(IRepository<T> repository)
    where T : class, IEntity
{  
    do
    {
        Console.WriteLine($"\nEnter \"y\" to remove all {repository.GetType().Name} from the database:\n(Press 'q' button + 'ENTER' button to quit and back to main menu)");

        var input = Console.ReadLine();
        if (input != "y")
        {
            break;
        }
        try
        {
            repository.RemoveAll();
            auditRepository.AddEntryToFile();
        }
        catch (Exception exception)
        {
            TextColoring(ConsoleColor.DarkRed, "This DataBase is not existing! Try again!\n");
            TextColoring(ConsoleColor.DarkRed, $"\nWarning! Exception catched:\n{exception.Message}\n");
        }
        finally
        {
            repository.Save();
            auditRepository.SaveAuditFile();
        }
    } while (input!="q");
}
void WriteAllFromAuditFileToConsole()
{
    var items = auditRepository.ReadAuditFile();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
static void TextColoring(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

