using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLC.Domain.Entities;

namespace WLC.Domain.Interface
{
    public interface IKullaniciYapilanAp
    {
        IEnumerable<KullaniciYapilanAp> KullaniciYapilanApler { get; }
        bool KullaniciYapilanApKaydet(string id, string kullanici);
        bool KullaniciYapilanApCikar(string id, string kullanici);
    }
}
