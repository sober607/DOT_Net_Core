using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_Net_Core.Models;

namespace DOT_Net_Core.Repository
{
    public interface IHumanActions
    {
        IEnumerable<Human> GetAllHumans();

        IEnumerable<Human> GetHuman(int humanId);

        void CreateHuman(string firstName, string lastName, int age, bool isSick, string gender, int countryId);

        void ModifyHuman(int humanId, string firstName, string lastName, int age, bool isSick, string gender, int countryId);

        void DeleteHuman(int humanId);


    }
}
