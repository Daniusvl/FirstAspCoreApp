#pragma checksum "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "218df7f7a074d8aad23ea3b5c658bfd44d7bf8ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Register), @"mvc.1.0.view", @"/Views/User/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"218df7f7a074d8aad23ea3b5c658bfd44d7bf8ae", @"/Views/User/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"695d143dd7ccc555e0732e0fe9c503b1cc2ebb12", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserRegisterViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Register</h1>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.ValidationSummary(false));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Vartotojo vardas</p>\r\n");
#nullable restore
#line 10 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Vardas</p>\r\n");
#nullable restore
#line 13 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Pavardė</p>\r\n");
#nullable restore
#line 16 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Slaptažodis</p>\r\n");
#nullable restore
#line 19 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Pakartotik slaptažodį</p>\r\n");
#nullable restore
#line 22 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.ConfirmPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Tel. Numeris</p>\r\n");
#nullable restore
#line 25 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
            WriteLiteral("    <p>Miestas</p>\r\n");
#nullable restore
#line 30 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Adresas</p>\r\n");
#nullable restore
#line 33 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Pašto kodas</p>\r\n");
#nullable restore
#line 36 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
Write(Html.EditorFor(m => m.ZipCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <br />\r\n");
            WriteLiteral("    <input type=\"submit\" value=\"Registruotis\" />\r\n");
#nullable restore
#line 42 "C:\Users\User\source\repos\Shop\Terabaitas\Views\User\Register.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserRegisterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
