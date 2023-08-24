using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPagingAndCart.Tags
{
    [HtmlTargetElement("pager")]
    public class PagerTagHelper: TagHelper
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentCategory { get; set; }
        public String Url { get; set; }
        public String ActiveClass { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (TotalPage > 1) { 
                output.TagName = "div";
                output.TagMode = TagMode.StartTagAndEndTag;
                for(int i=1; i<=TotalPage; ++i)
                {
                    if(i == CurrentPage)
                    {
                        output.Content.AppendHtml($"<a href='{Url}/{CurrentCategory}/{i}' class='{ActiveClass}' style='margin-right: 5px;'>{i}</a>");
                    }
                    else
                    {
                        output.Content.AppendHtml($"<a href='{Url}/{CurrentCategory}/{i}' style='margin-right: 5px;'>{i}</a>");
                    }
                }
            }
        }
    }
}
