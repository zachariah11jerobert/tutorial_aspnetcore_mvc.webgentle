using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BookStore.Helpers
{
    [HtmlTargetElement("big")]
    [HtmlTargetElement(Attributes = "big")]
    public class BibTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h3";
            output.Attributes.RemoveAll("big");
            output.Attributes.SetAttribute("class", "h3");
        }
    }
}
