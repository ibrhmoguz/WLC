using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLC.Domain.Entities
{
    public class WLCTanim
    {
        [Key]
        public int ID { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string OKULADI { get; set; }
        public string OKULKODU { get; set; }
        public string APSAYISI { get; set; }
        public string YAPILANAPSAYISI { get; set; }
        public string WLC1NAME { get; set; }
        public string WLC1IP { get; set; }
        public string WLC2NAME { get; set; }
        public string WLC2IP { get; set; }
        public string SERVERNAME { get; set; }
        public string FLEXCONNAME { get; set; }
        public string TESISKODU { get; set; }
        public string IP { get; set; }
        public string SUBNET { get; set; }
        public bool DONE { get; set; }
        public string KULLANICI { get; set; }
        public DateTime? TARIH { get; set; }
    }
}
