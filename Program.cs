using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

// Routing
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    var computerRepository = new ComputerRepository(databaseConfig);

    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        var computers = computerRepository.GetAll();
        foreach(var computer in computers)
        {
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("Computer New");
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
    }

    if(modelAction == "Delete")
    {
        Console.WriteLine("Computer Delete");
        var id = Convert.ToInt32(args[2]);
        computerRepository.Delete(id);
    }
}

if(modelName == "Lab")
{
    var labRepository = new LabRepository(databaseConfig);

    if(modelAction == "List")
    {
        Console.WriteLine("Lab List");
        var labs = labRepository.GetAll();
        foreach(var lab in labs)
        {
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("Lab New");
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        var name = args[4];
        var block = args[5];
        var lab = new Lab(id, number, name, block);
        labRepository.Save(lab);
    }
}