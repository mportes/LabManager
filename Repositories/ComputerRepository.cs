using LabManager.Models;
namespace LabManager.Repositories;

class ComputerRepository
{
    private readonly SystemContext _context;

    public ComputerRepository(SystemContext context)
    {
        _context = context;
    }

    public IEnumerable<Computer> GetAll() => _context.Computers;

    public Computer Save(Computer computer)
    {
        _context.Computers.Add(computer);
        _context.SaveChanges();
        return computer;
    }

    public Computer Update(Computer computer)
    {
        Computer updateComputer = _context.Computers.Find(computer.Id);
        updateComputer.Ram = computer.Ram;
        updateComputer.Processor = computer.Processor;
        _context.Computers.Update(updateComputer);
        _context.SaveChanges();
        return computer;
    }

    public void Delete(int id)
    {
        _context.Computers.Remove(_context.Computers.Find(id));
        _context.SaveChanges();
    }

    public Computer GetById(int id) => _context.Computers.Find(id);

    public bool ExistsById(int id) => _context.Computers.Find(id) == null ? false : true;
}