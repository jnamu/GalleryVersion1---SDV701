using System;
using System.Windows.Forms;

namespace GalleryVersion1
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private Single _Width;
        private Single _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPainting paintDialog;

        public override void EditDetails()
        {
            if (paintDialog == null)
            {
                paintDialog = new frmPainting();
            }
            paintDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            if(paintDialog.ShowDialog() == DialogResult.OK)
            {
               paintDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            }
        }
    }
}
