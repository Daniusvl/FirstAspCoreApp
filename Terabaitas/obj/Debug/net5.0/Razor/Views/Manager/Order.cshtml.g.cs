#pragma checksum "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59719b4106eb65121e66580ae4ef0be6da417f6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Order), @"mvc.1.0.view", @"/Views/Manager/Order.cshtml")]
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
using Terabaitas.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59719b4106eb65121e66580ae4ef0be6da417f6a", @"/Views/Manager/Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23bda1074c776207598365aaef2ceb73537a5523", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<(Order, OrderHelper)>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Užsakymas Nr. ");
#nullable restore
#line 3 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
             Write(Model.Item1.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p><b>Užsakymo data: </b>");
#nullable restore
#line 5 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
                    Write(Model.Item1.DateOrdered);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>\r\n    <b>Užsakytojo informacija:</b><br />\r\n");
#nullable restore
#line 8 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
      
        var user = await Model.Item2.GetUser(Model.Item1.Id);
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <b>Vardas: </b> ");
#nullable restore
#line 11 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
               Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n    <b>Pavardė: </b> ");
#nullable restore
#line 12 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
                Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n    <b>Miestas: </b> ");
#nullable restore
#line 13 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
                Write(user.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n    <b>Adresas: </b> ");
#nullable restore
#line 14 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
                Write(user.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n    <b>Pašto kodas: </b> ");
#nullable restore
#line 15 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
                    Write(user.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n</p>\r\n<p>\r\n    <b>Užsakyti produktai:</b><br />\r\n");
#nullable restore
#line 19 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
      
        var products = Model.Item2.GetProducts(Model.Item1.Id);
        decimal total_price = 0;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table cellpadding=\"15\">\r\n        <tr>\r\n            <th>Produkto pavadinimas</th>\r\n            <th>Produkto kaina</th>\r\n            <th>Kiekis</th>\r\n        </tr>\r\n");
#nullable restore
#line 29 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
         foreach (var item in products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
               Write(Html.ActionLink(item.Item1.Name, "Product", "Home", new { id = item.Item1.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
               Write(item.Item1.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
               Write(item.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 36 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
            total_price += (item.Item1.Price * item.Item2);
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <b>Bendra kaina: </b> ");
#nullable restore
#line 39 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
                     Write(total_price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n");
#nullable restore
#line 42 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"submit\" name=\"btn\" value=\"pristatyti\" />\r\n    <input type=\"submit\" name=\"btn\" value=\"atšaukti\" />\r\n");
#nullable restore
#line 47 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
Write(Html.ValidationSummary(false));

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\Order.cshtml"
                                  
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<(Order, OrderHelper)> Html { get; private set; }
    }
}
#pragma warning restore 1591
