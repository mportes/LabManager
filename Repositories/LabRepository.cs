using LabManager.Models;
namespace LabManager.Repositories;

class LabRepository
{
    private readonly SystemContext _context;

    public LabRepository(SystemContext context)
    {
        _context = context;
    }

    public IEnumerable<Lab> GetAll() => _context.Labs;

    public Lab Save(Lab Lab)
    {
        _context.Labs.Add(Lab);
        _context.SaveChanges();
        return Lab;
    }

    public Lab Update(Lab lab)
    {
        Lab updateLab = _context.Labs.Find(lab.Id);
        updateLab.Number = lab.Number;
        updateLab.Name = lab.Name;
        updateLab.Block = lab.Block;
        _context.Labs.Update(updateLab);
        _context.SaveChanges();
        return lab;
    }

    public void Delete(int id)
    {
        _context.Labs.Remove(_context.Labs.Find(id));
        _context.SaveChanges();
    }

    public Lab GetById(int id) => _context.Labs.Find(id);

    public bool ExistsById(int id) => _context.Labs.Find(id) == null ? false : true;
}