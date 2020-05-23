using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4_Task1
{
    class FortuneFacade : IFortuneFacade
    {
        private IFortuneTeller _fortuneTeller;

        private IFortuneGetter _fortuneGetter;

        public FortuneFacade(IFortuneTeller fortuneTeller, IFortuneGetter fortuneGetter)
        {
            _fortuneTeller = fortuneTeller;
            _fortuneGetter = fortuneGetter;
        }


        public void FortuneFacadeFromGetter()
        {
            var fortuneFromGetter = _fortuneGetter.FortuneGet();
            Console.WriteLine("This is fortune from FortuneFacadeFromGetter method with injected IFortuneGetter: " + fortuneFromGetter);
        }

        public void FortuneFacadeFromTeller()
        {
            _fortuneTeller.TellFortune();
            
        }
    }
}
