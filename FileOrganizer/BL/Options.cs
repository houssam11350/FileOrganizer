using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileOrganizer.BL
{
    public class Options
    {

        public bool IsSameSiteLoadingEnabled = true;

        private static Options mInstance = null;
        public bool IsSimilarItemsLoad = true;
        public bool IsQuickListLoad= true;
        public bool IsIDM = true;

        private Options()
        {

        }

        public static Options GetInstance()
        {
            if (mInstance == null)
                mInstance = new Options();

            return mInstance;
        }

        public static void FreeInstance()
        {
            mInstance = null;    
        }
        

    }
}
