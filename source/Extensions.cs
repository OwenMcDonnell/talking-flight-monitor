using tfm.PMDG.PanelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public static class Extensions
    {

        public static void Add(this List<PanelObject> list, SingleStateToggle toggle, bool condition)
        {
            if (condition)
            {
                list.Add(toggle);
            }
        } // Add
    } // ListExtensions
} // TFM namespace
