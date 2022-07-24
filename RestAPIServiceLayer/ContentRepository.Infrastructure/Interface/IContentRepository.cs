using ContentRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentRepository.Infrastructure.Interface
{
    public interface IContentRepository
    {
        Task<List<Post>> GetPosts();
    }
}
