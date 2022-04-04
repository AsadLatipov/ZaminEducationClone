using Microsoft.AspNetCore.Http;

namespace ZaminEducationClone.Service.Helpers
{
    public class AccesToContext
    {
        public static IHttpContextAccessor Accessor;
        public static HttpContext Context => Accessor?.HttpContext;
        public static IHeaderDictionary ResponseHeaders => Context?.Response?.Headers;
    }
}
