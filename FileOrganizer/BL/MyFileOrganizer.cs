//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FileOrganizer.BL;

//namespace FileOrganizer.BL
//{
//    public class MyFileOrganizer
//    {
//        List<WorkSpace> mWorkSpaceList;
//        public List<WorkSpace> WorkSpaceList
//        {
//            get { return mWorkSpaceList; }
//            //set { mWorkSpaceList = value; }
//        }


//        WorkSpace mWorkSpace;

//        public MyFileOrganizer()
//        {
//            mWorkSpaceList = new List<WorkSpace>();

//        }

//        public void LoadAllWorkSpaces()
//        {
//            mWorkSpace = new WorkSpace();
//            if (mWorkSpace.LoadAll())
//                mWorkSpaceList = mWorkSpace.AsList();
//        }

//        internal void AddNewWorkSpaceToList(WorkSpace pWorkSpace)
//        {
//            mWorkSpaceList.Add(pWorkSpace);
//        }
//    }
//}
