using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaCortex.DataSeeder.Methods
{
    public interface ISeeder<T> where T : class
    {
        Task Seed(T entity, string connection);
    }
}
