using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4_Task1
{
    class FortuneGetter : IFortuneGetter
    {
        private IFortuneLoader _fortuneLoaderInFortuneGetter;

        public FortuneGetter(IFortuneLoader fortuneLoaderInFortuneGetter)
        {
            _fortuneLoaderInFortuneGetter = fortuneLoaderInFortuneGetter;
        }

        public string FortuneGet()
        {
            return " you will see people today.\n";
        }
    }
}
