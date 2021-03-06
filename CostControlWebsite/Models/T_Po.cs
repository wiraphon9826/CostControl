﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostControlWebsite.Models
{
    public class T_Po
    {
        List<T_Po> listPo = new List<T_Po>();


        public string PoID { get; set; } //T_PR หลัก PR_App ลอง Lift Otherjoin
        public string Nog { get; set; }
        public string Area { get; set; }
        public string PoNo { get; set; }
        public string PoType { get; set; }
        public int BOI { get; set; }
        public int NonBOI { get; set; }
        public string RefPr { get; set; }
        public DateTime PoDate { get; set; }
        public string PoMonth { get; set; }
        public string PoYear { get; set; }
        public string DelDate { get; set; }
        public string RefQ { get; set; }
        public string RevNo { get; set; }
        public string DocNo { get; set; }
        public string PoJob { get; set; }
        public string Attn { get; set; }
        public string VendorCode { get; set; }
        public string DelLoc { get; set; }
        public string PoBy { get; set; }
        public string Term { get; set; }
        public string Warranty { get; set; }
        public string MoneyType { get; set; }
        public string Money { get; set; }
        public string Disc { get; set; }
        public string StampDuty { get; set; }
        public string Total { get; set; }
        public int Vat { get; set; }
        public string VatAmt { get; set; }
        public string Amt { get; set; }
        public string Attached { get; set; }
        public string CBE { get; set; }
        public string TBE { get; set; }
        public int Chk1 { get; set; }
        public int Chk3 { get; set; }
        public int Chk5 { get; set; }
        public string Remark { get; set; }
        public bool Inactive { get; set; }
        public int Draft { get; set; }
        public int PoClose { get; set; }

        public int SmtStatus { get; set; }


    }
}