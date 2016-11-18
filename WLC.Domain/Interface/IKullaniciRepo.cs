using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLC.Domain.Entities;

namespace WLC.Domain.Interface
{
    public interface IKullaniciRepo
    {
        IEnumerable<Kullanici> Kullanicilar { get; }
    }
}
