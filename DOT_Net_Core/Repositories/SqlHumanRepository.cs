using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_Net_Core.Models;
using DOT_Net_Core.Repository;

namespace DOT_Net_Core.Repository
{
    public class SqlHumanRepository : IHumanActions
    {
        //сообщение о результате выполнения операции
        

        private DOT_Net_CoreContext _context { get; set; }

        public SqlHumanRepository(DOT_Net_CoreContext context)
        {
            _context = context;
        }


        public List<Human> GetAllHumans()
        {
            return _context.Humans.ToList();
        }

        public List<Human> GetHuman(int humanId)
        {
            return (new List<Human> { (_context.Humans.FirstOrDefault(x => x.Id == humanId)) } );
        }


        public void Create(Human human)
        {
            if (human != null )
            { 
            _context.Humans.Add(human);
            _context.SaveChanges();
            }
        }


        public void ModifyHuman(int humanId, string firstName, string lastName, int age, bool isSick, string gender, int countryId)
        {
            var modifiedHuman = _context.Humans.FirstOrDefault(x => x.Id == humanId);
            if (firstName != null | firstName != "")
            { modifiedHuman.FirstName = firstName; }

            if (lastName != null | lastName != "")
            { modifiedHuman.LastName = lastName; }

            if (age != 0)
            { modifiedHuman.Age = age; }

            if (isSick != false )
            { modifiedHuman.IsSick= isSick; }

            if (gender != "")
            { modifiedHuman.Gender = gender; }


            if (countryId != 0)
            { modifiedHuman.CountryId = countryId; }

            
            _context.SaveChanges();
            

        }

        public void DeleteHuman(int humanId)
        {
            Human deleteHuman = _context.Humans.Find(humanId);
            if (deleteHuman != null)
            {
            _context.Humans.Remove(deleteHuman);
                _context.SaveChanges();
                
            }
            
        }
    }
}
