#pragma checksum "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "037bd000054615c30190a94fecd8efb6ba945137"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DolasciOdlasci_AdminDolasciDetalji), @"mvc.1.0.view", @"/Views/DolasciOdlasci/AdminDolasciDetalji.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DolasciOdlasci/AdminDolasciDetalji.cshtml", typeof(AspNetCore.Views_DolasciOdlasci_AdminDolasciDetalji))]
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
#line 1 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using Seminarski_fitness_centar_IB130116;

#line default
#line hidden
#line 2 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using Seminarski_fitness_centar_IB130116.Models;

#line default
#line hidden
#line 1 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
using Seminarski_fitness_centar_IB130116.Helper;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"037bd000054615c30190a94fecd8efb6ba945137", @"/Views/DolasciOdlasci/AdminDolasciDetalji.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7adf9685225585dc35a44130ea54e1ced4cf2ee5", @"/Views/_ViewImports.cshtml")]
    public class Views_DolasciOdlasci_AdminDolasciDetalji : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Seminarski_fitness_centar_IB130116.ViewModels.DolasciOdlasciSingleVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
   User user = Context.GetLoggedUser(); 

#line default
#line hidden
            BeginContext(131, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
  
    ViewData["Title"] = "Lista dolazaka i odlazaka";

#line default
#line hidden
            BeginContext(194, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(275, 35, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1>");
            EndContext();
            BeginContext(311, 17, false);
#line 13 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(328, 60, true);
            WriteLiteral("</h1>\r\n    <br />\r\n    <hr />\r\n    <div class=\"jumbotron\">\r\n");
            EndContext();
#line 17 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
         if (Model.Rows.Count > 0)
        {


#line default
#line hidden
            BeginContext(437, 44, true);
            WriteLiteral("            <p>Odlasci i dolasci KORISNIKA: ");
            EndContext();
            BeginContext(482, 19, false);
#line 20 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                                       Write(Model.User.Username);

#line default
#line hidden
            EndContext();
            BeginContext(501, 311, true);
            WriteLiteral(@"</p>
            <table class=""table table-striped table-bordered table-hover"">
                <thead>
                    <tr>
                        <th>Vrijeme dolaska</th>
                        <th>Vrijeme odlaska</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 29 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                     foreach (var dolazak_odlazak in Model.Rows)
                    {

#line default
#line hidden
            BeginContext(901, 26, true);
            WriteLiteral("                    <tr>\r\n");
            EndContext();
#line 32 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                         if (dolazak_odlazak.VrijemeOdlaska.ToString() == "1/1/0001 12:00:00 AM")
                        {

#line default
#line hidden
            BeginContext(1053, 28, true);
            WriteLiteral("                        <td>");
            EndContext();
            BeginContext(1082, 30, false);
#line 34 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                       Write(dolazak_odlazak.VrijemeDolaska);

#line default
#line hidden
            EndContext();
            BeginContext(1112, 46, true);
            WriteLiteral(" </td>\r\n                        <td> / </td>\r\n");
            EndContext();
#line 36 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1242, 28, true);
            WriteLiteral("                        <td>");
            EndContext();
            BeginContext(1271, 30, false);
#line 39 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                       Write(dolazak_odlazak.VrijemeDolaska);

#line default
#line hidden
            EndContext();
            BeginContext(1301, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1337, 30, false);
#line 40 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                       Write(dolazak_odlazak.VrijemeOdlaska);

#line default
#line hidden
            EndContext();
            BeginContext(1367, 8, true);
            WriteLiteral(" </td>\r\n");
            EndContext();
#line 41 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                        }

#line default
#line hidden
            BeginContext(1402, 27, true);
            WriteLiteral("                    </tr>\r\n");
            EndContext();
#line 43 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                    }

#line default
#line hidden
            BeginContext(1452, 50, true);
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n");
            EndContext();
#line 47 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1538, 24, true);
            WriteLiteral("            <p>Korisnik ");
            EndContext();
            BeginContext(1563, 19, false);
#line 50 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                   Write(Model.User.Username);

#line default
#line hidden
            EndContext();
            BeginContext(1582, 38, true);
            WriteLiteral(" nema prijavljenih dolazaka/odlazaka. ");
            EndContext();
            BeginContext(1621, 102, false);
#line 50 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
                                                                             Write(Html.ActionLink("Pregledaj druge zaposlenike?", "Zaposlenici", "DolasciOdlasci", htmlAttributes: null));

#line default
#line hidden
            EndContext();
            BeginContext(1723, 7, true);
            WriteLiteral(" </p>\r\n");
            EndContext();
#line 51 "D:\REPOS\repos\WebApplication3\WebApplication3\Views\DolasciOdlasci\AdminDolasciDetalji.cshtml"
        }

#line default
#line hidden
            BeginContext(1741, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2826, 28, true);
            WriteLiteral("\r\n            </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Seminarski_fitness_centar_IB130116.ViewModels.DolasciOdlasciSingleVM> Html { get; private set; }
    }
}
#pragma warning restore 1591