using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _06ViewModel.Models;

namespace _06ViewModel.ViewModels
{
    public class VMDeptEmp
    {
        //public int a { get; set; }
        //public string b { get; set; }

        public List<tDepartment> department { get; set; }
        public List<tEmployee> employee { get; set; }
    }
}