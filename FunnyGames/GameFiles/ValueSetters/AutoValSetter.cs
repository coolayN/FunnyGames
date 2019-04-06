using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyGames.GameFiles.ValueSetters
{
    enum Level
    {
        Easy = 10,
        Middle = 50, 
        Hard = 100
    }

    class AutoValSetter : BaseStartValSetter
    {
        Level _level;
        Random rand;
        int _min;
        int _max;

        public AutoValSetter(Level level)
        {
            _level = level;
            rand = new Random();
            GenerateMin();
            GenerateMax();
            SetStartValues(_min, _max, GenerateVal());
        }

        private void GenerateMin()
        {
            _min = rand.Next(0, 100);
        }
        private void GenerateMax()
        {
            _max = _min + (int)_level;
        }
        private int GenerateVal()
        {
            return rand.Next(_min, _max);
        }
    }
}
