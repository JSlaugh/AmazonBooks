using AmazonBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonBooks.Infrastructure
{

    [HtmlTargetElement("div",Attributes ="page-model")]
    public class PaginationTagHelper : TagHelper
    {

        //Dyanimcally create the page links for us


        private IUrlHelperFactory uhf;

        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]

        //Allows for dyanimc attribute elements
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }


        //Different than the View Context
        //Name is following the attribute name on the div in the index page
        public PageInfo PageModel { get; set; }

        //Pulled from index page
        public string PageAction { get; set; }

        //We want styling
        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div");

            // Create Individual links


        for (int i = 0; i<PageModel.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                tb.InnerHtml.Append("Page "+(i+1).ToString());

                //Wrap up and add back to html
                final.InnerHtml.AppendHtml(tb);
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
            }
        //Add the final to the output back to the page
            output.Content.AppendHtml(final.InnerHtml);
        }

    }
}
