using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace SBD.Cashbook.Module.BusinessObjects
{
    [NavigationItem("Main")]
    [DefaultProperty("Code")]
    [VisibleInReports]
    [ListViewFilter("All", "1==1", "All", false, Index = 0)]
    [ListViewFilter("Assets", "[Category] = 1",Index=1)]
    [ListViewFilter("Liabilities", "[Category] = 2", Index = 2)]
    [ListViewFilter("Equity", "[Category] = 3", Index = 3)]
    [ListViewFilter("Income", "[Category] = 4", Index = 4)]
    [ListViewFilter("COGS", "[Category] = 5", Index = 5)]
    [ListViewFilter("Expenses", "[Category] = 6",Index=6)]
    [ListViewFilter("Other Assets", "[Category] = 7",Index=7)]
    [ListViewFilter("Other Liabilities", "[Category] = 8",Index=8)]


    public class GLAccount : BasicBo
    {
        [Browsable(false)]
        public int Category { get; set; }

        public GLAccount ParentAccount { get; set; }

        [MaxLength(60)] // so we can index it
        [System.ComponentModel.DataAnnotations.Schema.Index(IsUnique = true)]
        public string Code { get; set; }
        public string Notes { get; set; }

        public Decimal OpeningBalance { get; set; }
        [NotMapped]
    
        public GLCategory GlCategory
        {
            get => (GLCategory) Category;
            set => Category = (int) value;
        }
        [Browsable(false)]
        [RuleFromBoolProperty("ParentCategoryOk", DefaultContexts.Save,"Parent Category if present must match")]
        public bool ParentCategoryOk
        {
            get
            {
                if (ParentAccount == null) return true;
                return ParentAccount.Category == Category;
            }
        }
    }
}