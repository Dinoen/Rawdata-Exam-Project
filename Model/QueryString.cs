using System;
namespace Raw5MovieDb_WebApi.Model
{
    public class QueryString
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 25;
    }
}
