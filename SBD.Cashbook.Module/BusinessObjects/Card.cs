using System.ComponentModel.DataAnnotations;
using DevExpress.Persistent.Base;

namespace SBD.Cashbook.Module.BusinessObjects
{
    [NavigationItem("Main")]
    public class Card : BasicBo
    {
        [MaxLength(450)]
        public string Name { get; set; }
    }
}