using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterFactory.Filters
{
    public class AddHeaderFilter : ActionFilterAttribute
    {
        public string AddNameInHeader { get; set; }
        public string AddValueInHeader { get; set; }
        public AddHeaderFilter(string addNameInHeader, string addValueInHeader)
        {
            AddNameInHeader = addNameInHeader;
            AddValueInHeader = addValueInHeader;

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers[AddNameInHeader] = AddValueInHeader;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}