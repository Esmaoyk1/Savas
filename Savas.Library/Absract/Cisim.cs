using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // PictureBox için

namespace Savas.Library.Absract
{
    internal abstract class Cisim : PictureBox
    {
        protected Cisim()
        {
            SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
