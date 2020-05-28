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

        //Human GetHuman(int humanId);

        //void CreateHuman(Human human);

        //void ModifyHuman(int humanId);

        //void KillHuman(int humanId);


    }
}
