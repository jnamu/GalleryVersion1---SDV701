using System;
using System.Collections;

namespace GalleryVersion1
{
    class clsNameComparer : IComparer
    {
        public int Compare(Object x, Object y)
        {
            clsWork workClassX = (clsWork)x;
            clsWork workClassY = (clsWork)y;
            string lcNameX = workClassX.GetName();
            string lcNameY = workClassY.GetName();

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
