using ContentRepository.Entities;
using ContentRepository.Infrastructure;
using ContentRepository.Infrastructure.Interface;
using ContentRepository.Services.Interface;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentRepository.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly ServiceArgs _serviceArgs;
        public ContentService() { }
      
        public ContentService(ContentRepositoryServiceResolver contentRepository, ServiceArgs serviceArgs)
        {
            _serviceArgs = serviceArgs;
            _contentRepository = contentRepository(_serviceArgs);
        }
        public async Task<List<Post>> GetPosts()
        {
            return await _contentRepository.GetPosts();
        }
    }
}
