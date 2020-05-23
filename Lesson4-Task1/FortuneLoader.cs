using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson4_Task1
{
    class FortuneLoader : IFortuneLoader
    {
        
        public string LoadFortune()
        {
            return File.ReadAllText(@"..\..\..\resources\Fortunes.txt");
        }
    }
}
