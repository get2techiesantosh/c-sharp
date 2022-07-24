using ContentRepository.Entities;
using ContentRepository.Infrastructure.Interface;
using Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentRepository.Infrastructure.SQL
{
    public class ContentDBRepository : IContentRepository
    {
        private readonly ServiceArgs _serviceArgs;
        public ContentDBRepository(){}

        public ContentDBRepository(ServiceArgs serviceArgs)
        {
            _serviceArgs = serviceArgs;
        }

        public async Task<List<Post>> GetPosts()
        {
            using var context = new ContentRepositoryContext(_serviceArgs.ConnectionString);

            return await context.Posts.ToListAsync();
            
        }
    }
}
