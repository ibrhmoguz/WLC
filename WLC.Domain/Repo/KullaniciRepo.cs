using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLC.Domain.Concrete;
using WLC.Domain.Entities;
using WLC.Domain.Interface;

namespace WLC.Domain.Repo
{
    public class KullaniciRepo : IKullaniciRepo
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Kullanici> Kullanicilar
        {
            get { return context.Kullanicilar.ToList(); }
        }
    }
}
