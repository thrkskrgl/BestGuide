using BestGuide.Common.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace BestGuide.Modules
{
    public abstract class ControllerRoot : ControllerBase
    {
        protected ControllerRoot()
        {
        }

        protected virtual string GetPageIndexHeader()
        {
            return "page-index";
        }

        protected virtual string GetPageSizeHeader()
        {
            return "page-size";
        }

        protected virtual string GetCountHeader()
        {
            return "count";
        }

        protected virtual void SetRequestPageHeaders(SearchBaseModel args)
        {
            if (HttpContext.Request.Headers.TryGetValue(GetPageIndexHeader(), out var index) && int.TryParse(index[0], out var indexResult))
            {
                args.PageIndex = Math.Max(indexResult, 1);
            }

            if (HttpContext.Request.Headers.TryGetValue(GetPageSizeHeader(), out var size) && int.TryParse(size[0], out var sizeResult))
            {
                args.PageIndex = Math.Max(sizeResult, 1);
            }
        }

        protected virtual void SetResponsePageHeaders<T>(IListPaged<T> list)
        {
            if (list is not null)
            {
                string count = GetCountHeader();
                base.HttpContext.Response.Headers.Append(count, list.TotalCount.ToString());
            }
        }

        protected virtual ObjectResult ServerError()
        {
            return new ObjectResult(null)
            {
                StatusCode = 500
            };
        }
    }
}
