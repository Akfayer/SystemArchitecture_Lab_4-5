using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Designer
    {
        public int DesignerId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public int Price { get; set; }

        public Designer()
        {

        }
        public Designer(int DesignerId, string Name, string Specialization, int Experience, int Price)
        {
            this.DesignerId = DesignerId;
            this.Name = Name;
            this.Specialization = Specialization;
            this.Experience = Experience;
            this.Price = Price;
        }
    }
}
