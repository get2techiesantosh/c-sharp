using System.Reflection;
using Microsoft.AspNetCore.Http;
using System;
namespace Framework
{
    public class ServiceArgsHelper : IServiceArgsHelper
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public ServiceArgsHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public ServiceArgs GetUserSpecficArgs()
        {
            ServiceArgs obj = _httpContextAccessor?.HttpContext?.Features[typeof(ServiceArgs)] as ServiceArgs;
            if (obj != null)
            {
                if (IsBase64Encoded(obj.ConnectionString))
                {
                    SetValue(obj, "ConnectionString", obj.ConnectionString);
                }
            }
            return _httpContextAccessor?.HttpContext?.Features[typeof(ServiceArgs)] as ServiceArgs;
        }
        public bool IsBase64Encoded(string value)
        {
            try
            {
                return Convert.TryFromBase64String(value, null, out var _);
            }
            catch
            {
                return false;
            }
        }
        public static void SetValue<T>(T obj, string propertyName, object value)
        {
            Type type = typeof(T);
            PropertyInfo pi = type.GetProperty(propertyName);
            pi.SetValue(obj, Convert.ChangeType(value, pi.PropertyType), null);
        }
    }
    public interface IServiceArgsHelper
    {
        ServiceArgs GetUserSpecficArgs();
    }
    public class ServiceArgs
    {
        public string DatabaseRepositoryType { get; set; }
        public string ConnectionString { get; set; }
        public string FileSystemType { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } //test

    }
}
