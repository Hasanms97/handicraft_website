#pragma checksum "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "230444181fa9df40087796bd2cecc49d02ccb7ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ViewCart), @"mvc.1.0.view", @"/Views/Customer/ViewCart.cshtml")]
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
#line 1 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/_ViewImports.cshtml"
using Handicraft_Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/_ViewImports.cshtml"
using Handicraft_Website.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"230444181fa9df40087796bd2cecc49d02ccb7ee", @"/Views/Customer/ViewCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30009ac49f87a5dda3fd4f9c770ce646bdb7ac0b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Customer_ViewCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<IEnumerable<CartProduct> , IEnumerable<Product>>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg0 p-t-75 p-b-85"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_Customer";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"sec-product-detail bg0 p-t-65 p-b-60\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "230444181fa9df40087796bd2cecc49d02ccb7ee5280", async() => {
                WriteLiteral(@"
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-10 col-xl-7 m-lr-auto m-b-50"">
                    <div class=""m-l-25 m-r--38 m-lr-0-xl"">
                        <div class=""wrap-table-shopping-cart"">
                            <table class=""table-shopping-cart"">
                                <tbody>
                                    <tr class=""table_head"">
                                        <th class=""column-1"">Product</th>
                                        <th class=""column-2""></th>
                                        <th class=""column-3"">Price</th>
                                        <th class=""column-4"">Quantity</th>
                                        <th class=""column-5"">Total</th>
                                    </tr>
");
#nullable restore
#line 22 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                                      
                                        int sum = 0;
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                                     foreach (var item in Model.Item1)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        <a href=""https://www.google.com/?client=safari"">
                                            <tr class=""table_row"">
                                                <td class=""column-1"">
                                                    <div class=""how-itemcart1"">
                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "230444181fa9df40087796bd2cecc49d02ccb7ee7365", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                                                     WriteLiteral(Url.Content("~/Images/" + item.Product.ImagePath));

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 32 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                                                    </div>\n                                                </td>\n                                                <td class=\"column-2\">");
#nullable restore
#line 35 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                                                                Write(item.Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                                                <td class=\"column-3\">");
#nullable restore
#line 36 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                                                                Write(item.Product.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" JOD</td>
                                                <td class=""column-4"">
                                                    <div class=""wrap-num-product flex-w m-l-auto m-r-0"">
                                                        <div class=""btn-num-product-down cl8 hov-btn3 trans-04 flex-c-m"">
                                                            <i class=""fs-16 zmdi zmdi-minus""></i>
                                                        </div>

                                                        <input class=""mtext-104 cl3 txt-center num-product"" type=""number""
                                                        name=""num-product1"" value=""1"">

                                                        <div class=""btn-num-product-up cl8 hov-btn3 trans-04 flex-c-m"">
                                                            <i class=""fs-16 zmdi zmdi-plus""></i>
                                                        </div>
                                                    </div>
      ");
                WriteLiteral("                                          </td>\n                                                <td class=\"column-5\">");
#nullable restore
#line 51 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                                                                Write(item.Product.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" JOD</td>\n                                            </tr>\n                                        </a>\n");
#nullable restore
#line 54 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"

                                        {
                                            sum = sum+((int)item.Product.Price*(int)item.Quantity);
                                        }
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


                                </tbody>
                            </table>
                        </div>

                        <div class=""flex-w flex-sb-m bor15 p-t-18 p-b-15 p-lr-40 p-lr-15-sm"">
                            <div class=""flex-w flex-m m-r-20 m-tb-5"">
                                <input class=""stext-104 cl2 plh4 size-117 bor13 p-lr-20 m-r-10 m-tb-5"" type=""text""
                                    name=""coupon"" placeholder=""Coupon Code"">

                                <div
                                    class=""flex-c-m stext-101 cl2 size-118 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-5"">
                                    Apply coupon
                                </div>
                            </div>

                            <div
                                class=""flex-c-m stext-101 cl2 size-119 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-10"">
                                Update Cart
                            </div>
                        </di");
                WriteLiteral(@"v>
                    </div>
                </div>

                <div class=""col-sm-10 col-lg-7 col-xl-5 m-lr-auto m-b-50"">
                    <div class=""bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm"">
                        <h4 class=""mtext-109 cl2 p-b-30"">
                            Cart Totals
                        </h4>

                        <div class=""flex-w flex-t bor12 p-b-13"">
                            <div class=""size-208"">
                                <span class=""stext-110 cl2"">
                                    Subtotal:
                                </span>
                            </div>

                            <div class=""size-209"">
                                <span class=""mtext-110 cl2"">
                                    ");
#nullable restore
#line 100 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                               Write(sum);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" JOD
                                </span>
                            </div>
                        </div>

                        <div class=""flex-w flex-t p-t-27 p-b-33"">
                            <div class=""size-208"">
                                <span class=""mtext-101 cl2"">
                                    Total:
                                </span>
                            </div>

                            <div class=""size-209 p-t-1"">
                                <span class=""mtext-110 cl2"">
                                    ");
#nullable restore
#line 114 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Customer/ViewCart.cshtml"
                               Write(sum);

#line default
#line hidden
#nullable disable
                WriteLiteral(" JOD\n                                </span>\n                            </div>\n                        </div>\n\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "230444181fa9df40087796bd2cecc49d02ccb7ee15546", async() => {
                    WriteLiteral("\n                            Proceed to Checkout\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    </div>\n                </div>\n            </div>\n        </div>\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<IEnumerable<CartProduct> , IEnumerable<Product>>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591