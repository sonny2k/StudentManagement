using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stdmanagement
{
    public partial class IndexClassForm : Form
    {
        private ClassManagement Business;
        public IndexClassForm()
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.Load += IndexClassForm_Load; // Show classes 
            this.btnCreate.Click += btnCreate_Click; // Add a class
            this.btnDelete.Click += btnDelete_Click; // Delete a class
            this.grdClasses.DoubleClick += grdClasses_DoubleClick; // Edit a class
        }

        private void loadAllClasses()
        {
            var classes = this.Business.GetClasses();
            this.grdClasses.DataSource = classes;
        }

        void grdClasses_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdClasses.SelectedRows.Count == 1)
            {
                var Class = (Class)this.grdClasses.SelectedRows[0].DataBoundItem;

                var UpdateForm = new UpdateClassForm(Class.id);
                UpdateForm.ShowDialog();
                this.loadAllClasses();
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createform = new CreateClassForm();
            createform.ShowDialog();
            this.loadAllClasses();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdClasses.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this?", "Confirm", MessageBoxButtons.YesNo) 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    var Class = (Class)this.grdClasses.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteClass(Class.id);
                    MessageBox.Show("Delete class successfully.");
                    this.loadAllClasses();
                }
            }


        }

        private void IndexClassForm_Load(object sender, EventArgs e)
        {
            this.loadAllClasses();
        }
    }
}
