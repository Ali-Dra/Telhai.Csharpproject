using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.Csharpproject.UIPattern.MVC
{
    public class CounterController
    {
        private readonly CounterModel _model;

        public CounterController(CounterModel model)
        {
            _model = model;
        }

        public void Increment()
        {
            _model.Value++;
        }
        public void Increment(int num)
        {
            _model.Value += num;
        }

        public int GetValue() => _model.Value;
    }

}
