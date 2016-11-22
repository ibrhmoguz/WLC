using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WLC.Domain.Entities
{
    public class KullaniciYapilanAp
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int KullaniciApId { get; set; }
        public int ID { get; set; }
        public string Kullanici { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
