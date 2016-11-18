using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WLC.Admin.Models
{
    public class LoginViewModel
    {
        [Required]
        public string KullaniciAdi { get; set; }
        [Required]
        public string Sifre { get; set; }
    }
}