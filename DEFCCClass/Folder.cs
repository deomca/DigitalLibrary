using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEFCCClass
{
    public class Folder
    {
        public int FolderId { get; set; }
        public int ParentId { get; set; }
        public string FolderName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ParentFolderName { get; set; }
       
    }
}
