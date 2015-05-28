using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GalleryVersion1
{
    public partial class frmSculpture : GalleryVersion1.frmWork
    {

        
        public frmSculpture()
        {
            InitializeComponent();
        }

        public virtual void SetDetails(string prName, DateTime prDate, decimal prValue, Single prWeight, string prMaterial)
        {
            base.SetDetails(prName, prDate, prValue);
            txtWeight.Text = Convert.ToString(prWeight);
            txtMaterial.Text = prMaterial;
        }

        public virtual void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue, ref Single prWeight, ref string prMaterial)
        {
            base.GetDetails(ref prName, ref prDate, ref prValue);
            prWeight = Convert.ToSingle(txtWeight.Text);
            prMaterial = txtMaterial.Text;
        }

    }
}

