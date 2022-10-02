using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace cp_2_enterprise.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        public string? Message { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            if (!string.IsNullOrEmpty(Message))
            {
                output.Attributes.SetAttribute("class", "alert alert-info");
                output.Content.SetContent(Message);
            }
        }
    }
}

