using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleData
{
    internal class File
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    internal class ResultView
    {
        public int EmployeeId { get; set; }
        public string FileType { get; set; }
        public string Reason { get; set; }

    }
}
