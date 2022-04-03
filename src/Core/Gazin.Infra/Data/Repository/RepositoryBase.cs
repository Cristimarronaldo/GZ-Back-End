using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazin.Infra.Data.Repository
{
    public abstract class RepositoryBase
    {
        protected RepositoryBase()
        {
        }

        protected async Task Salvar(GazinContext context)
        {
            await context.SaveChangesAsync();
        }
    }
}
