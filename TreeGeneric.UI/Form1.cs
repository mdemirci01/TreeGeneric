using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeGeneric.BussinessLogic;

namespace TreeGeneric.UI
{
    public partial class Form1 : Form
    {
        private readonly ILifetimeScope scope;
        private readonly IRegionService regionService;
        public Form1(ILifetimeScope scope)
        {
            this.scope = scope;
            this.regionService = scope.Resolve<IRegionService>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = regionService.GetAll();
        }
    }
}
