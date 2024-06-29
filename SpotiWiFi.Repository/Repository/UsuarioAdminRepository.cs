using SpotiWiFi.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository.Repository
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>
    {
        public UsuarioAdminRepository(SpotiWiFiAdminContext context) : base(context)
        {
        }
    }
}
