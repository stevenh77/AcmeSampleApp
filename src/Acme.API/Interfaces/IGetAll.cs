using System.Collections.Generic;

namespace Acme.API.Interfaces
{
    // reference data
    public interface IGetAll<T>
    {
        IEnumerable<T> GetAll();
    }
}