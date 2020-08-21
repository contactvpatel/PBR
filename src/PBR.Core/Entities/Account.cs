using PBR.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace PBR.Core.Entities
{
   public class Account: Entity
    {
       public Account() 
        {
        }
        
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string  AccessToken { get; set; }
        public string  RefreshToken { get; set; }
        public long? ExpiresIn { get; set; }
        public long? ExpiresOn { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        [Display(Name = "AccounName")]
        [Required(ErrorMessage = "AccountName is UserName.")]
        public string ? AccountName { get; set; }
        public bool ? IsDelete { get; set; }

        //public static Account Create(int Id, string UserName, string Passoword ,string ClientId,string )
        //{
        //    var Account = new Account
        //    {
        //        Id = Id,
        //        CategoryName = name,
        //        Description = description
        //    };
        //    return category;
        //}
    }
}
