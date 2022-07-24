using ContentRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentRepository.Services.Interface
{
    public interface IContentService
    {
        Task<List<Post>> GetPosts();
    }
}
