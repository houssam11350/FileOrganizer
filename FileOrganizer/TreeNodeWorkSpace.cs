using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;
using System.Drawing;

namespace FileOrganizer
{
    public class TreeNodeWorkSpace : TreeNode
    {
        WorkSpaceRow mWorkSpace;
        public WorkSpaceRow WorkSpace
        {
            get { return mWorkSpace; }
            set { mWorkSpace = value; }
        }

        public TreeNodeWorkSpace()
            : base()
        {
        }

        
        public void PutColorAsChecked()
        {
            if (this.Checked)
            {

                this.BackColor = SystemColors.Highlight;
                this.ForeColor = SystemColors.Window;
            }
            else
            {
                this.BackColor = SystemColors.Window;
                this.ForeColor = SystemColors.WindowText;
            }


        }
    }
}
