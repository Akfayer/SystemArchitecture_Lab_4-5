using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    public class Menu
    {
        string input;
        MainLogic logic = new MainLogic();
        int count = 0;

        public void StartMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Чи бажаєте Ви додати дані за замовчуванням:\n1-Так\n2-Ні\n3-Завершення програми");
                input = Console.ReadLine();
                if (input == "1")
                    AutoInfo();
                else if (input == "2")
                    MainMenu();
                else if (input == "3")
                    break;
                else
                    ErrorMessage();
            } while (input != "3");
        }

        void AutoInfo()
        {
            List<DesignerBLL> designers = new List<DesignerBLL>();


            designers.Add(new DesignerBLL(1, "Дмитро", "Дизайн сайтів", 3, 1120));
            designers.Add(new DesignerBLL(2, "Володимир", "Дизайн сайтів", 2, 1330));
            designers.Add(new DesignerBLL(3, "Михайло", "Дизайн кімнати", 7, 6120));
            designers.Add(new DesignerBLL(4, "Олег", "Дизайн будівлі", 8, 31120));
            designers.Add(new DesignerBLL(5, "Іван", "Дизайн кімнати", 4, 4120));
            designers.Add(new DesignerBLL(6, "Дмитро", "Дизайн будівлі", 4, 5120));
            designers.Add(new DesignerBLL(7, "Денис", "Дизайн сайтів", 3, 1330));
            designers.Add(new DesignerBLL(8, "Микола", "Дизайн сайтів", 2, 2020));
            designers.Add(new DesignerBLL(9, "Віктор", "Дизайн сайтів", 1, 500));
            designers.Add(new DesignerBLL(10, "Володими", "Дизайн кімнати", 2, 2300));
            designers.Add(new DesignerBLL(11, "Ярослав", "Дизайн кімнати", 8, 4500));
            designers.Add(new DesignerBLL(12, "Григорій", "Дизайн сайтів", 6, 3000));
            designers.Add(new DesignerBLL(13, "Тарас", "Дизайн будівлі", 5, 3000));
            designers.Add(new DesignerBLL(14, "Сергій", "Дизайн будівлі", 5, 11200));

            logic.DataBaseAddRange(designers);
            count += designers.Count();
            MainMenu();
        }

        void MainMenu()
        {
            do
            {
                count += logic.DataBaseGetAll().Count();
                Console.Clear();
                Console.WriteLine("1-Переглянути список дизайнерів\n2-Додати дизайнера\n3-Видалити дизайнера\n" +
                    "4-Відсортувати за зменшенням ціни послуг та переглянути список\n" +
                    "5-Відсортувати за збільшенням досвіду дизайнерів та переглянути список\n" +
                    "6-Змінити інформацію про дизайнера\n" +
                    "7-Обрати дизайнера для послуг\n0-Повернутися до головного меню");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowDesigners();
                        WaitMessage();
                        break;
                    case "2":
                        AddDesigner();
                        break;
                    case "3":
                        RemoveDesigner();
                        break;
                    case "4":
                        ShowLowPriceDesigners();
                        break;
                    case "5":
                        ShowHighExperienceDesigners();
                        break;
                    case "6":
                        UpdateDesigner();
                        break;
                    case "7":
                        ChooseDesigner();
                        break;
                    case "0":
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
            } while (input != "0");
        }

        public void DesignerInput(out string name, out string specialization, out string experience, out string price)
        {
            Console.Clear();
            Console.WriteLine("Введіть ім'я: ");
            name = Console.ReadLine();
            Console.WriteLine("Введіть спеціалізацію дизайнера: ");
            specialization = Console.ReadLine();
            Console.WriteLine("Введіть досвід роботи дизайнера: ");
            experience = Console.ReadLine();
            Console.WriteLine("Введіть ціну роботи дизайнера: ");
            price = Console.ReadLine();
        }

        public void AddDesigner()
        {
            string name, specialization, experience, price;
            DesignerInput(out name, out specialization, out experience, out price);

            if (logic.CheckIntInput(experience) && logic.CheckIntInput(price))
            {
                logic.DataBaseAdd(new DesignerBLL(count, name, specialization, int.Parse(experience), int.Parse(price)));
                count++;
            }
            else
                ErrorMessage();
            
        }

        public void RemoveDesigner()
        {
            ShowDesigners();
            Console.WriteLine("Введіть номер дизайнера, якого ви бажаєте видалити: ");
            string input = Console.ReadLine();
            if (logic.CheckIntInput(input))
            {
                int id = int.Parse(input);
                logic.DataBaseRemove(id);
            }
            else
                ErrorMessage();
        }

        public void ChooseDesigner()
        {
            ShowDesigners();
            Console.WriteLine("Введіть номер дизайнера, послуги якого ви бажаєте обрати: ");
            string input = Console.ReadLine();
            if (logic.CheckIntInput(input))
            {
                int id = int.Parse(input);
                if (logic.CheckIndex(id, count))
                {
                    Console.WriteLine(logic.DataBaseGetById(id).Choosed());
                    WaitMessage();
                }
                else
                    ErrorMessage();
            }
            else
                ErrorMessage();
        }

        public void UpdateDesigner()
        {
            ShowDesigners();
            Console.WriteLine("Введіть номер дизайнера, якого ви бажаєте змінити:");          
            string input = Console.ReadLine();
            if(logic.CheckIntInput(input))
            {
                int id = int.Parse(input);
                if (logic.CheckIndex(id, count))
                {
                    string name, specialization, experience, price;
                    DesignerInput(out name, out specialization, out experience, out price);
                    logic.DataBaseUpdate(new DesignerBLL(id, name, specialization, int.Parse(experience), int.Parse(price)), id);
                    Console.WriteLine((logic.DataBaseGetById(id)).ToString());
                    WaitMessage();
                }
                else
                    ErrorMessage();
            }    
            else
                ErrorMessage();
        }

        public void ShowDesigners()
        {
            Console.Clear();
            Console.WriteLine(logic.PrintDesigners(logic.DataBaseGetAll()));
        }

        public void ShowLowPriceDesigners()
        {
            Console.Clear();
            Console.WriteLine(logic.PrintDesigners(logic.DataBaseGetDesignerLowPrice()));
            WaitMessage();
        }

        public void ShowHighExperienceDesigners()
        {
            Console.Clear();
            Console.WriteLine(logic.PrintDesigners(logic.DataBaseGetDesignerExperience()));
            WaitMessage();
        }

        public void ErrorMessage()
        {
            Console.WriteLine("\nВи ввели некоректні дані. Будь ласка спробуйте ще.\n");
            WaitMessage();
        }

        public void WaitMessage()   
        {
            Console.WriteLine("Натисніть enter, щоб продовжити.");
            Console.ReadLine();
        }
    }
}
