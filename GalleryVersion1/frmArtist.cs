using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GalleryVersion1
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsArtistList _ArtistList;
        private clsWorksList _WorksList;
        private byte _sortOrder; // 0 = Name, 1 = Date
        private clsArtist _Artist;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_sortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }
            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());

        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }

        //public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        //{
        //    prName = txtName.Text;
        //    prSpeciality = txtSpeciality.Text;
        //    prPhone = txtPhone.Text;
        //    _WorksList.SortOrder = _sortOrder;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _WorksList.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_ArtistList.Contains(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _WorksList.EditWork(lcIndex);
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _sortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            _ArtistList = _ArtistList.ArtistList;
            _WorksList = _ArtistList.WorksList;
            _sortOrder = _Artist.WorksList.SortOrder;
            UpdateDisplay();
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
            _WorksList.SortOrder = _sortOrder;
        }
    }
}