using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;

namespace SBD.Cashbook.Module.BusinessObjects
{
    [NavigationItem("Main")]
    [DefaultProperty("Code")]
    public class GLAccount : BasicBo
    {

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
    }
}