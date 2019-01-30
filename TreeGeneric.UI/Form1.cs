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
using TreeGeneric.Model;

namespace TreeGeneric.UI
{
    public partial class Form1 : Form
    {
        private readonly ILifetimeScope scope;
        private readonly IRegionService regionService;
        private readonly ITreeTypeService treeTypeService;
        public Form1(ILifetimeScope scope)
        {
            this.scope = scope;
            this.regionService = scope.Resolve<IRegionService>();
            this.treeTypeService = scope.Resolve<ITreeTypeService>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DataSource = regionService.GetAll();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var treeType = new TreeType();
            treeType.Name = "Çam Ağacı";
            treeType.IsActive = true;
            treeType.AvailabilityCount = 1;
            treeType.PlantingPrice = 10;
            treeType.TreePrice = 10;
            treeType.Commision = 5;
            treeType.Photo = "cam.jpg";
            var region = regionService.Find(int.Parse(this.comboBox1.SelectedValue.ToString()));
            treeType.Regions.Add(region);
            this.treeTypeService.Insert(treeType);
        }
    }
}
