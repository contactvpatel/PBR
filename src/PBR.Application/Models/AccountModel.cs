using PBR.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Application.Models
{
    public class AccountModel:BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Passoword { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public int ExpiresOn { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string AccountName { get; set; }
        public bool IsDelete { get; set; }
    }
}
