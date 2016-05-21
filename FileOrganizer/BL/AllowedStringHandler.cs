using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileOrganizer.BL
{
    public class AllowedStringHandler
    {
        string mSmallLetter = " abcdefghijgklmnopqrstuvwxyz";

        public string SmallLetter
        {
            get { return mSmallLetter; }
            //set { mSmallLetter = value; }
        }

        string mCapitalLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string CapitalLetter
        {
            get { return mCapitalLetter; }
            //set { mCapitalLetter = value; }
        }

        string mDigit = "0123456789";
        public string Digit
        {
            get { return mDigit; }
           // set { mDigit = value; }
        }

        string mSymbol = "~'!@#$%^&*()-_=+[{]}|;:,<.>/?" + '"' + '\\' + '\r' + '\n';
        public string Symbol
        {
            get { return mSymbol; }
            //set { mSymbol = value; }
        }

        private static AllowedStringHandler mInstance = new AllowedStringHandler();


        private AllowedStringHandler()
        {
        }
        public static AllowedStringHandler GetInstance()
        {
            return mInstance;
        }

        public bool IsSingleStringOK(char pChar)
        {
            if (mSmallLetter.Contains(pChar))
                return true;
            if (mCapitalLetter.Contains(pChar))
                return true;
            if (mDigit.Contains(pChar))
                return true;
            if (mSymbol.Contains(pChar))
                return true;
            //Helper.MSG(pChar + "");
            return false;
        }
        public bool IsFullStringOK(String pString)
        {
            foreach (char s in pString)
            {
                if (!IsSingleStringOK(s))
                {
                    return false;
                }
            }

            return true;
        }


    }
}
