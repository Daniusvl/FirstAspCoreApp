#pragma checksum "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8614bcf55306b585d8a98e3c8b11876f12416787"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8614bcf55306b585d8a98e3c8b11876f12416787", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"695d143dd7ccc555e0732e0fe9c503b1cc2ebb12", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<(UserModel, bool)>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
 if (Model.Item2)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
Write(Html.ActionLink("Užsakymų sarašas", "Index", "Manager"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
                                                            ;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>redaguoti adresą</h1>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
Write(Html.ValidationSummary(false));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Miestas</p>\r\n    <input name=\"living_place.City\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 299, "\"", 324, 1);
#nullable restore
#line 16 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
WriteAttributeValue("", 307, Model.Item1.City, 307, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
            WriteLiteral("    <p>Adresas</p>\r\n    <input name=\"living_place.Address\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 402, "\"", 430, 1);
#nullable restore
#line 19 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
WriteAttributeValue("", 410, Model.Item1.Address, 410, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
            WriteLiteral("    <p>Pašto kodas</p>\r\n    <input name=\"living_place.ZipCode\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 512, "\"", 540, 1);
#nullable restore
#line 22 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
WriteAttributeValue("", 520, Model.Item1.ZipCode, 520, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
            WriteLiteral("    <br />\r\n    <br />\r\n");
            WriteLiteral("    <input type=\"submit\" value=\"Atnaujinti adresą\">\r\n");
#nullable restore
#line 28 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 31 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Index.cshtml"
Write(Html.ActionLink("Pakeisti slaptažodį", "ChangePassword", "User"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<(UserModel, bool)> Html { get; private set; }
    }
}
#pragma warning restore 1591
