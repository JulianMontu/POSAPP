using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Persistence.Interfaces
{
    public interface IUnitsOfWork : IDisposable
    {
        //Declaracion con matricula de nuestras interfaces a nivel de repositorio
        ICategoryRepository Category { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    } 
}
