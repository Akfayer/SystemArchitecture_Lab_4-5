using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DesignerBLL
    {
        public int DesignerId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public int Price { get; set; }

        public DesignerBLL(int DesignerId, string Name, string Specialization, int Experience, int Price)
        {
            this.DesignerId = DesignerId;
            this.Name = Name;
            this.Specialization = Specialization;
            this.Experience = Experience;
            this.Price = Price;
        }

        public override string ToString()
        {
            return $"{DesignerId}. Ім'я: {Name}\n" +
                $"Спеціалізація: {Specialization}\n" +
                $"Досвід роботи: {Experience}\n" +
                $"Ціна роботи: {Price}\n" +
                $"_________________________________\n";
        }

        public string Choosed()
        {
            return $"Ви обрали {Name} для {Specialization}\nЦіна послуг: {Price}, тому просимо оплатити якнайшвидше.";
        }
    }
}
