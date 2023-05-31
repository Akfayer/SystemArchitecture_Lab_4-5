using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL
{
    public class DesignStudioRepository : Repository<Designer>, IDesignStudioRepository
    {
        public DesignStudioRepository(DataContext context):base(context)
        {
        }

        public IEnumerable<Designer> GetDesignStudiosLowPrice()
        {
            return Context.Designers.OrderBy(designer => designer.Price).ToList();
        }

        public IEnumerable<Designer> GetDesignStudiosExperience()
        {
            return Context.Designers.OrderByDescending(designer => designer.Experience).ToList();
        }

    }
}
