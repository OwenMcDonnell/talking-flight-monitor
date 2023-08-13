using tfm.Properties.Data;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public partial class App : System.Windows.Application
    {

        public static NavigraphDataProvider Navigraph { get => new NavigraphDataProvider(); }
    } // App class.
}// tfm namespace.
