﻿using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class frmNearbyAircraft : Form
    {
        AIPlaneInfo groundTraffic;
        AIPlaneInfo airbornTraffic;
        public frmNearbyAircraft(AIPlaneInfo groundTraffic, AIPlaneInfo airbornTraffic)
        {
            InitializeComponent();
            this.groundTraffic = groundTraffic;
            this.airbornTraffic = airbornTraffic;
        }

        private void frmNearbyAircraft_Load(object sender, EventArgs e)
        {

        }
    }
}