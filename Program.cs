﻿using Microsoft.Data.Sqlite;
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
        var computers = computerRepository.GetAll();
        foreach(var computer in computers)
        {
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
    }

    if(modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

        if(computerRepository.ExistsById(id))
        {
            var computer = new Computer(id, ram, processor);
            computerRepository.Update(computer);
        }
        else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }

    if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            computerRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }

    if(modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);
        
        if(computerRepository.ExistsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
        else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }
}

if(modelName == "Lab")
{
    var labRepository = new LabRepository(databaseConfig);

    if(modelAction == "List")
    {
        var labs = labRepository.GetAll();
        foreach(var lab in labs)
        {
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
    }

    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var number = Convert.ToInt32(args[3]);
        var name = args[4];
        var block = args[5];
        var lab = new Lab(id, number, name, block);
        labRepository.Save(lab);
    }

    if(modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        var number = Convert.ToInt32(args[3]);
        var name = args[4];
        var block = args[5];

        if(labRepository.ExistsById(id))
        {
            var lab = new Lab(id, number, name, block);
            labRepository.Update(lab);
        }
        else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
    }

    if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            labRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
    }

    if(modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var lab = labRepository.GetById(id);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
        else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
    }
}