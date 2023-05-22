using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public partial class App: System.Windows.Application
    {

        public static InstrumentPanel instrumentPanel
        {
            get => new InstrumentPanel();
        }
    }
}
