using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AutoMapper;
using DAL;

namespace BLL
{
    public class MainLogic
    {
        UnitOfWork unitOfWork;
        readonly IMapper mapper = AutoMapperInitializer.InitializeAutomapper();

        public int DataBaseAdd(DesignerBLL entity)
        {        
            using (unitOfWork = new UnitOfWork())
            {
                unitOfWork.studioRepository.Add(mapper.Map<Designer>(entity));
                return unitOfWork.Save();
            }
        }

        public int DataBaseAddRange(List<DesignerBLL> entities)
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Designer> designers = new List<Designer>();
                foreach (DesignerBLL designer in entities)
                {
                    designers.Add(mapper.Map<Designer>(designer));
                }
                unitOfWork.studioRepository.AddRange(designers);
                return unitOfWork.Save();
            }
        }

        public List<DesignerBLL> DataBaseGetAll()
        {
            List<DesignerBLL> designersList = new List<DesignerBLL>();
            using (unitOfWork = new UnitOfWork())
            {
                List<Designer> designers = unitOfWork.studioRepository.GetAll() as List<Designer>;
                foreach (Designer designer in designers)
                {
                    designersList.Add(mapper.Map<DesignerBLL>(designer));
                }
                return designersList;
            }       
        }

        public DesignerBLL DataBaseGetById(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Designer data = unitOfWork.studioRepository.Get(id);
                DesignerBLL designerBLL = mapper.Map<DesignerBLL>(data);
                return designerBLL;
            }
        }

        public void DataBaseRemove(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                unitOfWork.studioRepository.Remove(id);
                unitOfWork.Save();
            }
        }

        public void DataBaseUpdate(DesignerBLL designer, int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Designer designerEntity = unitOfWork.studioRepository.Get(id);
                designerEntity.Name = designer.Name;
                designerEntity.Experience = designer.Experience;
                designerEntity.Price = designer.Price;
                designerEntity.Specialization = designer.Specialization;
                unitOfWork.studioRepository.Update(designerEntity);
                unitOfWork.Save();
            }
        }

        public List<DesignerBLL> DataBaseGetDesignerLowPrice()
        {
            List<DesignerBLL> designersList = new List<DesignerBLL>();
            using (unitOfWork = new UnitOfWork())
            {
                List<Designer> designers = unitOfWork.studioRepository.GetDesignStudiosLowPrice() as List<Designer>;
                foreach (Designer designer in designers)
                {
                    designersList.Add(mapper.Map<DesignerBLL>(designer));
                }
                return designersList;
            }
        }

        public List<DesignerBLL> DataBaseGetDesignerExperience()
        {
            List<DesignerBLL> designersList = new List<DesignerBLL>();
            using (unitOfWork = new UnitOfWork())
            {
                List<Designer> designers = unitOfWork.studioRepository.GetDesignStudiosExperience() as List<Designer>;
                foreach (Designer designer in designers)
                {
                    designersList.Add(mapper.Map<DesignerBLL>(designer));
                }
                return designersList;
            }
        }

        public string PrintDesigners(List<DesignerBLL> designersList)
        {
            string data = "";
            foreach(DesignerBLL designer in designersList)
            {
                data += designer.ToString();
            }
            return data;
        }

        public bool CheckIntInput(string input)
        {
            return int.TryParse(input, out int num);
        }

        public bool CheckIndex(int index, int count)
        {
            if (index > 0 && index <= count)
            {
                return true;
            }
            else
                return false;
        }
    }
}
