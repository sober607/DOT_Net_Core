using System;
using Unity;

namespace Lesson4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<IFortuneLoader, FortuneLoader>();
            unityContainer.RegisterType<IFortuneTeller, FortuneTeller>();
            unityContainer.RegisterType<IFortuneGetter, FortuneGetter>();
            unityContainer.RegisterType<IFortuneFacade, FortuneFacade>();

            var fortuneTeller = unityContainer.Resolve<IFortuneFacade>();

            fortuneTeller.FortuneFacadeFromGetter();
            fortuneTeller.FortuneFacadeFromTeller();

            Console.ReadLine();
        }
    }
}
