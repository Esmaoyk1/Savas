﻿using Savas.Library.Absract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    internal class Ucaksavar : Cisim
    {
        public Ucaksavar(int panelGenisligi, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Left = (panelGenisligi - Width) / 2;
            Center = panelGenisligi / 2;
            HareketMesafesi = Width;
        }
    }
}
