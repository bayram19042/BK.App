using Bk.App.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetBankAccountCount:TagHelper
    {
        public int ApplicationUserId  { get; set; }
        private readonly BKContext _context;
        public GetBankAccountCount(BKContext context)
        {
            _context = context;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x => x.ApplicationUserId == ApplicationUserId);
            var html = $"<span class='badge badge-danger badge-pill'>{accountCount}</span>";
            output.Content.SetHtmlContent(html);
        }
    }
}
