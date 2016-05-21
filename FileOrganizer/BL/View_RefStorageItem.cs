/*
'===============================================================================
'  Generated From - CSharp_dOOdads_View.vbgen
'
'  The supporting base class OleDbEntity is in the 
'  Architecture directory in "dOOdads".
'===============================================================================
*/

using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileOrganizer.BL
{

    public partial class View_RefStorageItemRow
    {
        public string GetPathIcon()
        {
            return StorageItemRow.GetPathIconForStorageItem(this.s_FullPath, this.s_ItemName);
        }
	}
    public partial class View_RefStorageItemDT
    {

    }
}
