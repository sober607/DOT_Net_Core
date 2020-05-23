using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4_Task1
{
    class FortuneTeller : IFortuneTeller
    {
        private IFortuneLoader _fortuneLoader;

        public FortuneTeller(IFortuneLoader fortuneVariable)
        {
            _fortuneLoader = fortuneVariable;
        }

        public void TellFortune()
        {
            var fortune = _fortuneLoader.LoadFortune();
            Console.WriteLine(fortune);
        }
    }
}
