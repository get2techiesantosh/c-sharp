using ContentRepository.Services.Interface;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentRepository.Services
{
    public delegate IContentService ContentServiceResolver(ServiceArgs serviceArgs);

}
