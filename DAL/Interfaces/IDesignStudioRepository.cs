using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDesignStudioRepository : IRepository<Designer>
    {
        IEnumerable<Designer> GetDesignStudiosLowPrice();
        IEnumerable<Designer> GetDesignStudiosExperience();
    }
}
