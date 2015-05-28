using System;
using System.Collections;

namespace GalleryVersion1
{
    class clsDateComparer : IComparer
    {
        public int Compare(Object x, Object y)
        {
            clsWork lcWorkX = (clsWork)x;
            clsWork lcWorkY = (clsWork)y;
            DateTime lcDateX = lcWorkX.GetDate();
            DateTime lcDateY = lcWorkY.GetDate();

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
