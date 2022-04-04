using Newtonsoft.Json;
using System;
using ZaminEducationClone.Service.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Configurations;

namespace ZaminEducationClone.Service.Extensions
{
    public static class ExtensionPack
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams @params)
        {
            var metaData = new PaginationMetaData(source.Count(), @params);
            var json = JsonConvert.SerializeObject(metaData);

            if (AccesToContext.ResponseHeaders.Keys.Contains("X-Pagination"))
                AccesToContext.ResponseHeaders.Remove("X-Pagination");
            
            AccesToContext.Context.Response.Headers.Add("X-Pagination", json);

            return @params.PageSize > 0 && @params.PageIndex >= 0
                ? source.Skip(@params.PageSize * (@params.PageIndex - 1)).Take(@params.PageSize) : source;
        }
    }
}
