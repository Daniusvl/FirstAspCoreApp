#pragma checksum "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\AddProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42f288e21e78510a05a97e091ecee56c748ce0f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_AddProduct), @"mvc.1.0.view", @"/Views/Manager/AddProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42f288e21e78510a05a97e091ecee56c748ce0f4", @"/Views/Manager/AddProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"695d143dd7ccc555e0732e0fe9c503b1cc2ebb12", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_AddProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Add Product</h1>\r\n\r\n");
#nullable restore
#line 3 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\AddProduct.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\AddProduct.cshtml"
Write(Html.ValidationSummary(false));

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\AddProduct.cshtml"
                                  ;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <b>Pavadinimas:</b> <input type=""text"" name=""product.Name""/><br />
    <b>Aprašymas:</b> <textarea name=""product.Description""></textarea> <br />
    <b>Tipas:</b> <select name=""product.Type"">
        <option value=""Nešiojamieji kompiuteriai"">Nešiojamieji kompiuteriai</option>
        <option value=""Staliniai kompiuteriai"">Staliniai kompiuteriai</option>
        <option value=""Planšetiniai kompiuteriai"">Planšetiniai kompiuteriai</option>
        <option value=""Telefonai"">Telefonai</option>
        <option value=""Kompiuterių komponentai"">Kompiuterių komponentai</option>
        <option value=""Monitoriai & Televizoriai"">Monitoriai & Televizoriai</option>
        <option value=""Programinė įranga"">Programinė įranga</option>
        <option value=""Žaidimų įranga"">Žaidimų įranga</option>
    </select><br />
    <b>Kaina:</b> <input type=""text"" name=""product.Price""/><br />
    <b>Kiekis:</b> <input type=""text"" name=""product.Quantity""/><br />
    <input type=""submit"" value=""Sukurti""/>
");
#nullable restore
#line 21 "C:\Users\User\source\repos\Shop\Terabaitas\Views\Manager\AddProduct.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
