#pragma checksum "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d14d045836560cb86b707be467c61937aa3a5e62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d14d045836560cb86b707be467c61937aa3a5e62", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RazasPerros.Models.Razas>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/Home/Agregar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("b"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml"
   Layout = "_Layout";
                int x = 1; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Lista de Perros</h1>\r\n\r\n<table>\r\n    <colgroup>\r\n        <col style=\"width:50px\" />\r\n        <col style=\"width:40px\" />\r\n        <col />\r\n        <col style=\"width:50%\" />\r\n    </colgroup>\r\n    <caption>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d14d045836560cb86b707be467c61937aa3a5e623961", async() => {
                WriteLiteral("<i class=\"fa fa-plus\"></i> Agregar Raza");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </caption>\r\n    <thead>\r\n        <tr class=\"subt\">\r\n            <th id=\"num\">#</th>\r\n            <th id=\"raza\">Raza</th>\r\n            <th id=\"acciones\">Acciones</th>\r\n        </tr>\r\n    </thead>\r\n");
#nullable restore
#line 24 "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tbody>\r\n            <tr>\r\n                <td class=\"numero\">");
#nullable restore
#line 28 "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml"
                               Write(x++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"nombre\">");
#nullable restore
#line 29 "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml"
                              Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td id=\"acc\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 833, "\"", 869, 2);
            WriteAttributeValue("", 840, "/Admin/Home/Editar/", 840, 19, true);
#nullable restore
#line 31 "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 859, item.Id, 859, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"b\"><i class=\"fa fa-edit\"></i> Editar</a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 939, "\"", 975, 3);
            WriteAttributeValue("", 946, "javascript:eliminar(", 946, 20, true);
#nullable restore
#line 32 "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 966, item.Id, 966, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 974, ")", 974, 1, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"b\"><i class=\"fa fa-remove\"></i> Eliminar</a>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n");
#nullable restore
#line 36 "E:\tony1\Desktop\RazasPerros\RazasPerros\Areas\Admin\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RazasPerros.Models.Razas>> Html { get; private set; }
    }
}
#pragma warning restore 1591