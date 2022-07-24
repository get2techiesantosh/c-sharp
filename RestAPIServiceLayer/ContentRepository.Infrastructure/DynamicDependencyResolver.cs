using ContentRepository.Infrastructure.Interface;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentRepository.Infrastructure
{
    public delegate IContentRepository ContentRepositoryServiceResolver(ServiceArgs serviceArgs);
}
