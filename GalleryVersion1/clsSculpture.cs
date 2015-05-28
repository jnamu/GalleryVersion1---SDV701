using System;
using System.Windows.Forms;

namespace GalleryVersion1
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private Single _Weight;
        private string _Material;

        [NonSerialized()]
        private static frmSculpture sculptureDialog;

        public override void EditDetails()
        {
            if (sculptureDialog == null)
            {
                sculptureDialog = new frmSculpture();
            }
            sculptureDialog.SetDetails(_Name, _Date, _Value, _Weight, _Material);
            if (sculptureDialog.ShowDialog() == DialogResult.OK)
            {
                sculptureDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Weight, ref _Material);
            }
        }
    }
}
