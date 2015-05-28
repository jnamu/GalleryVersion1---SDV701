using System;
using System.Windows.Forms;

namespace GalleryVersion1
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private Single _Width;
        private Single _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPhotograph photoDialog;

        public override void EditDetails()
        {
            if (photoDialog == null)
            {
                photoDialog = new frmPhotograph();
            }
            photoDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            if(photoDialog.ShowDialog() == DialogResult.OK)
            {
                photoDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            }
        }
    }
}
