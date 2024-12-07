using ShelterApp.Data;
using ShelterApp.Data.Entities;
using ShelterApp.Data.Repositories;

var employeeRepository = new SqlRepository<Employee>(new ShelterAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
WriteAllToConsole(employeeRepository);

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Andrzej" });
    employeeRepository.Add(new Employee { FirstName = "Monika" });
    employeeRepository.Add(new Employee { FirstName = "Ewa" });
    employeeRepository.Save();
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