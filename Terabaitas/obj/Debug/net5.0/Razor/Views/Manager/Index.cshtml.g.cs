#pragma checksum "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42802af6a896bb3483e6f6d8d2ea8efbde8c3d5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Index), @"mvc.1.0.view", @"/Views/Manager/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\source\repos\Shop\Terabaitas\Views\_ViewImports.cshtml"
using Terabaitas.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\Shop\Terabaitas\Views\_ViewImports.cshtml"
using Terabaitas.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\source\repos\Shop\Terabaitas\Views\_ViewImports.cshtml"
using Terabaitas.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\source\repos\Shop\Terabaitas\Views\_ViewImports.cshtml"
using Terabaitas.Core.Services.Abstract;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42802af6a896bb3483e6f6d8d2ea8efbde8c3d5b", @"/Views/Manager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"695d143dd7ccc555e0732e0fe9c503b1cc2ebb12", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<(List<OrderModel>, IOrderHelper)>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<table cellpadding=\"20\">\r\n    <tr>\r\n        <th>Vardas</th>\r\n        <th>Pavardė</th>\r\n        <th>Užsakymo data</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
     if(Model.Item1 != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
         foreach (var item in Model.Item1)
        {
            var user = await Model.Item2.GetUser(item.Id);


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
               Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
               Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
               Write(item.DateCreated.ToString("dd/mm/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
               Write(Html.ActionLink("Atidaryti", "Order", "Manager", new { order_id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 24 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Index.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<(List<OrderModel>, IOrderHelper)> Html { get; private set; }
    }
}
#pragma warning restore 1591
