using System.Collections.Generic;

namespace Diablo2API.Services.Classes
{
    public interface IClassesService
    {
        public ClassesService GetClassById(int id);
        public List<ClassesService> GetAllClasses();
    }
}