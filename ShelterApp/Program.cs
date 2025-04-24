using ShelterApp.Data;
using ShelterApp.Data.Entities;
using ShelterApp.Data.Repositories;
using ShelterApp.Data.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new ShelterAppDbContext(), EmployeeAdded);
employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

static void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
}

AddEmployees(employeeRepository);
AddManagers(employeeRepository);

static void EmployeeAdded(object item)
{
    var employee = (Employee)item;
    Console.WriteLine($"{employee.FirstName} added");
}

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee { FirstName ="Andrzej"},
        new Employee { FirstName = "Monika"},
        new Employee { FirstName = "Ewa"}
    };

    employeeRepository.AddBatch(employees);
}

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Łukasz" });
    managerRepository.Add(new Manager { FirstName = "Dorota" });
    managerRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
Console.Clear();
Console.WriteLine("Welcome to Shelter App");
Console.WriteLine("############################################################");
Console.WriteLine();

while (true)
{
    Console.WriteLine("Choose on of the option:");
    Console.WriteLine("1. Show employees.");
    Console.WriteLine("2. Add employees - will be added soon.");
    Console.WriteLine("3. Show animals - will be added soon.");
    Console.WriteLine("4. Begin adoption - will be added soon.");
    Console.WriteLine();
    Console.WriteLine("To quit press Q.");
    Console.WriteLine("Then press Enter to confirm.");

    string input = Console.ReadLine();
    Console.Clear();

    if (input == "Q" || input == "q")
    {
        break;
    }
    switch (input)
    {
        case "1":
            WriteAllToConsole(employeeRepository);
            Console.WriteLine();
            break;
        case "2":
            Console.WriteLine("Option not added yet");
            Console.WriteLine();
            break;
        case "3":
            Console.WriteLine("Option not added yet");
            Console.WriteLine();
            break;
        case "4":
            Console.WriteLine("Option not added yet");
            Console.WriteLine();
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Exception catched: {input} is not good choice. Please try again.");
            Console.WriteLine();
            break;
    }
}
