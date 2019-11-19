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
    public partial class UpdateClassForm : Form
    {
        private ClassManagement Business;
        private int ClassID;
        public UpdateClassForm(int id)
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.ClassID = id;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Load += UpdateClassForm_Load;
        }

        void UpdateClassForm_Load(object sender, EventArgs e)
        {
            var oldClass = this.Business.GetClass(this.ClassID);
            this.txtName.Text = oldClass.Name;
            this.txtDescription.Text = oldClass.Description;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var description = this.txtDescription.Text;
            this.Business.EditClass(this.ClassID, name, description);
            MessageBox.Show("Update class successfully.");
        }
    }
}
