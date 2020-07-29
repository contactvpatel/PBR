using PBR.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PBR.Core.Entities
{
    public class APPlication : Entity
    {
        public APPlication()
        {
        }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int Id { get; set; }
    }
}
