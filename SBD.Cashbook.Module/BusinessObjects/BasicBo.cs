using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp;

namespace SBD.Cashbook.Module.BusinessObjects
{
    public class BasicBo : IXafEntityObject
    {
        [Key]
        public int Id { get; set; }
        public void OnCreated()
        {
             
        }

        public void OnSaving()
        {
            
        }

        public void OnLoaded()
        {
            
        }
    }
}