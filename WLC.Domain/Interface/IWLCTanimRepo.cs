using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLC.Domain.Entities;

namespace WLC.Domain.Interface
{
    public interface IWLCTanimRepo
    {
        IEnumerable<WLCTanim> WLCTanimlar { get; }
        bool WLCKaydet(string id, string kullanici);
        bool WLCCikar(string id, string kullanici);
    }
}
