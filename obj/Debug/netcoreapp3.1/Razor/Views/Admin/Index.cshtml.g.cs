#pragma checksum "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Admin/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57427e9d06647296cc8ed34c52e6e8397e44bc4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57427e9d06647296cc8ed34c52e6e8397e44bc4e", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30009ac49f87a5dda3fd4f9c770ce646bdb7ac0b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Handicraft_Website.Models.Userr>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dashboard_assets/img/product-1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dashboard_assets/img/product-2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dashboard_assets/img/product-3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dashboard_assets/img/product-4.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dashboard_assets/img/product-5.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Admin/Index.cshtml"
  
    Layout = "_AdminDashboard";
    ViewBag.adminID = ViewBag.adminInfo;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Start #main -->
<main id=""main"" class=""main"">

    <div class=""pagetitle"">
        <h1>Dashboard</h1>
        <nav>
            <ol class=""breadcrumb"">
                <li class=""breadcrumb-item""><a href=""index.html"">Home</a></li>
                <li class=""breadcrumb-item active"">Dashboard</li>
            </ol>
        </nav>
    </div><!-- End Page Title -->

    <section class=""section dashboard"">
        <div class=""row justify-content-center"">

            <!-- Left side columns -->
            <div class=""col-lg-8"">
                <div class=""row"">

                    <!-- Sales Card -->
                    <div class=""col-xxl-4 col-md-6"">
                        <div class=""card info-card sales-card"">



                            <div class=""card-body"">
                                <h5 class=""card-title"">Products</h5>

                                <div class=""d-flex align-items-center"">
                                    <div
                                        class=""card-icon ro");
            WriteLiteral(@"unded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-cart""></i>
                                    </div>
                                    <div class=""ps-3"">
                                        <h6>");
#nullable restore
#line 42 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Admin/Index.cshtml"
                                       Write(ViewBag.numberOfProduct);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div><!-- End Sales Card -->

                    <!-- Revenue Card -->
                    <div class=""col-xxl-4 col-md-6"">
                        <div class=""card info-card revenue-card"">


                            <div class=""card-body"">
                                <h5 class=""card-title"">Revenue</h5>

                                <div class=""d-flex align-items-center"">
                                    <div
                                        class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-currency-dollar""></i>
                                    </div>
                                    <div class=""ps-3"">
                                        <h6>$3,264</h6>
                                    </div>
                      ");
            WriteLiteral(@"          </div>
                            </div>

                        </div>
                    </div><!-- End Revenue Card -->

                    <!-- Revenue Card -->
                    <div class=""col-xxl-4 col-md-6"">
                        <div class=""card info-card revenue-card"">


                            <div class=""card-body"">
                                <h5 class=""card-title"">Total Customers</h5>

                                <div class=""d-flex align-items-center"">
                                    <div
                                        class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-people""></i>
                                    </div>
                                    <div class=""ps-3"">
                                        <h6>");
#nullable restore
#line 87 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Admin/Index.cshtml"
                                       Write(ViewBag.numberOfCustomers);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- End Revenue Card -->

                    <!-- Customers Card -->
                    <div class=""col-xxl-4 col-xl-12"">

                        <div class=""card info-card customers-card"">


                            <div class=""card-body"">
                                <h5 class=""card-title"">Total Craftsman</h5>

                                <div class=""d-flex align-items-center"">
                                    <div
                                        class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-hammer""></i>
                                    </div>
                                    <div class=""ps-3"">
                                        <h6>");
#nullable restore
#line 111 "/Users/hasanal-shannag/Desktop/first project MVC/Handicraft Website/Views/Admin/Index.cshtml"
                                       Write(ViewBag.numberOfCraftsman);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div><!-- End Customers Card -->

                    <!-- Reports -->
                    <div class=""col-12"">
                        <div class=""card"">

                            <div class=""filter"">
                                <a class=""icon"" href=""#"" data-bs-toggle=""dropdown""><i class=""bi bi-three-dots""></i></a>
                                <ul class=""dropdown-menu dropdown-menu-end dropdown-menu-arrow"">
                                    <li class=""dropdown-header text-start"">
                                        <h6>Filter</h6>
                                    </li>

                                    <li><a class=""dropdown-item"" href=""#"">Today</a></li>
                                    <li><a class=""dropdown-item"" href=""#"">This Month</a></li>
                                    <li><a class=""dropdown-item"" hr");
            WriteLiteral(@"ef=""#"">This Year</a></li>
                                </ul>
                            </div>

                            <div class=""card-body"">
                                <h5 class=""card-title"">Reports <span>/Today</span></h5>

                                <!-- Line Chart -->
                                <div id=""reportsChart""></div>

                                <script>
                                    document.addEventListener(""DOMContentLoaded"", () => {
                                        new ApexCharts(document.querySelector(""#reportsChart""), {
                                            series: [{
                                                name: 'Sales',
                                                data: [31, 40, 28, 51, 42, 82, 56],
                                                
                                            }, {
                                                name: 'Revenue',
                                                data: [11, 32, 45, 32, 34,");
            WriteLiteral(@" 52, 41]
                                            }, {
                                                name: 'Customers',
                                                data: [15, 11, 32, 18, 9, 24, 11]
                                            }],
                                            chart: {
                                                height: 350,
                                                type: 'area',
                                                toolbar: {
                                                    show: false
                                                },
                                            },
                                            markers: {
                                                size: 4
                                            },
                                            colors: ['#4154f1', '#2eca6a', '#ff771d'],
                                            fill: {
                                                type: ""gradient"",
         ");
            WriteLiteral(@"                                       gradient: {
                                                    shadeIntensity: 1,
                                                    opacityFrom: 0.3,
                                                    opacityTo: 0.4,
                                                    stops: [0, 90, 100]
                                                }
                                            },
                                            dataLabels: {
                                                enabled: false
                                            },
                                            stroke: {
                                                curve: 'smooth',
                                                width: 2
                                            },
                                            xaxis: {
                                                type: 'datetime',
                                                categories: [""2018-09-19T00:00:00.000");
            WriteLiteral(@"Z"", ""2018-09-19T01:30:00.000Z"", ""2018-09-19T02:30:00.000Z"", ""2018-09-19T03:30:00.000Z"", ""2018-09-19T04:30:00.000Z"", ""2018-09-19T05:30:00.000Z"", ""2018-09-19T06:30:00.000Z""]
                                            },
                                            tooltip: {
                                                x: {
                                                    format: 'dd/MM/yy HH:mm'
                                                },
                                            }
                                        }).render();
                                    });
                                </script>
                                <!-- End Line Chart -->

                            </div>

                        </div>
                    </div><!-- End Reports -->

                    <!-- Recent Sales -->
                    <div class=""col-12"">
                        <div class=""card recent-sales overflow-auto"">

                            <div class=""filter"">
             ");
            WriteLiteral(@"                   <a class=""icon"" href=""#"" data-bs-toggle=""dropdown""><i class=""bi bi-three-dots""></i></a>
                                <ul class=""dropdown-menu dropdown-menu-end dropdown-menu-arrow"">
                                    <li class=""dropdown-header text-start"">
                                        <h6>Filter</h6>
                                    </li>

                                    <li><a class=""dropdown-item"" href=""#"">Today</a></li>
                                    <li><a class=""dropdown-item"" href=""#"">This Month</a></li>
                                    <li><a class=""dropdown-item"" href=""#"">This Year</a></li>
                                </ul>
                            </div>

                            <div class=""card-body"">
                                <h5 class=""card-title"">Recent Sales <span>| Today</span></h5>

                                <table class=""table table-borderless datatable"">
                                    <thead>
                       ");
            WriteLiteral(@"                 <tr>
                                            <th scope=""col"">#</th>
                                            <th scope=""col"">Customer</th>
                                            <th scope=""col"">Product</th>
                                            <th scope=""col"">Price</th>
                                            <th scope=""col"">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope=""row""><a href=""#"">#2457</a></th>
                                            <td>Brandon Jacob</td>
                                            <td><a href=""#"" class=""text-primary"">At praesentium minu</a></td>
                                            <td>$64</td>
                                            <td><span class=""badge bg-success"">Approved</span></td>
                                        </tr");
            WriteLiteral(@">
                                        <tr>
                                            <th scope=""row""><a href=""#"">#2147</a></th>
                                            <td>Bridie Kessler</td>
                                            <td><a href=""#"" class=""text-primary"">Blanditiis dolor omnis similique</a>
                                            </td>
                                            <td>$47</td>
                                            <td><span class=""badge bg-warning"">Pending</span></td>
                                        </tr>
                                        <tr>
                                            <th scope=""row""><a href=""#"">#2049</a></th>
                                            <td>Ashleigh Langosh</td>
                                            <td><a href=""#"" class=""text-primary"">At recusandae consectetur</a></td>
                                            <td>$147</td>
                                            <td><span class=""badge bg-succes");
            WriteLiteral(@"s"">Approved</span></td>
                                        </tr>
                                        <tr>
                                            <th scope=""row""><a href=""#"">#2644</a></th>
                                            <td>Angus Grady</td>
                                            <td><a href=""#"" class=""text-primar"">Ut voluptatem id earum et</a></td>
                                            <td>$67</td>
                                            <td><span class=""badge bg-danger"">Rejected</span></td>
                                        </tr>
                                        <tr>
                                            <th scope=""row""><a href=""#"">#2644</a></th>
                                            <td>Raheem Lehner</td>
                                            <td><a href=""#"" class=""text-primary"">Sunt similique distinctio</a></td>
                                            <td>$165</td>
                                            <td><span class=""badge ");
            WriteLiteral(@"bg-success"">Approved</span></td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div><!-- End Recent Sales -->

                    <!-- Top Selling -->
                    <div class=""col-12"">
                        <div class=""card top-selling overflow-auto"">

                            <div class=""filter"">
                                <a class=""icon"" href=""#"" data-bs-toggle=""dropdown""><i class=""bi bi-three-dots""></i></a>
                                <ul class=""dropdown-menu dropdown-menu-end dropdown-menu-arrow"">
                                    <li class=""dropdown-header text-start"">
                                        <h6>Filter</h6>
                                    </li>

                                    <li><a class=""dropdown-item"" href=""#"">Today</a></li>
                                    <li><a class=""dropdo");
            WriteLiteral(@"wn-item"" href=""#"">This Month</a></li>
                                    <li><a class=""dropdown-item"" href=""#"">This Year</a></li>
                                </ul>
                            </div>

                            <div class=""card-body pb-0"">
                                <h5 class=""card-title"">Top Selling <span>| Today</span></h5>

                                <table class=""table table-borderless"">
                                    <thead>
                                        <tr>
                                            <th scope=""col"">Preview</th>
                                            <th scope=""col"">Product</th>
                                            <th scope=""col"">Price</th>
                                            <th scope=""col"">Sold</th>
                                            <th scope=""col"">Revenue</th>
                                        </tr>
                                    </thead>
                                    <tbody>
             ");
            WriteLiteral("                           <tr>\n                                            <th scope=\"row\"><a href=\"#\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "57427e9d06647296cc8ed34c52e6e8397e44bc4e22648", async() => {
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
            WriteLiteral(@"</a></th>
                                            <td><a href=""#"" class=""text-primary fw-bold"">Ut inventore ipsa voluptas
                                                    nulla</a></td>
                                            <td>$64</td>
                                            <td class=""fw-bold"">124</td>
                                            <td>$5,828</td>
                                        </tr>
                                        <tr>
                                            <th scope=""row""><a href=""#"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "57427e9d06647296cc8ed34c52e6e8397e44bc4e24301", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a></th>
                                            <td><a href=""#"" class=""text-primary fw-bold"">Exercitationem similique
                                                    doloremque</a></td>
                                            <td>$46</td>
                                            <td class=""fw-bold"">98</td>
                                            <td>$4,508</td>
                                        </tr>
                                        <tr>
                                            <th scope=""row""><a href=""#"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "57427e9d06647296cc8ed34c52e6e8397e44bc4e25956", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a></th>
                                            <td><a href=""#"" class=""text-primary fw-bold"">Doloribus nisi
                                                    exercitationem</a></td>
                                            <td>$59</td>
                                            <td class=""fw-bold"">74</td>
                                            <td>$4,366</td>
                                        </tr>
                                        <tr>
                                            <th scope=""row""><a href=""#"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "57427e9d06647296cc8ed34c52e6e8397e44bc4e27605", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a></th>
                                            <td><a href=""#"" class=""text-primary fw-bold"">Officiis quaerat sint rerum
                                                    error</a></td>
                                            <td>$32</td>
                                            <td class=""fw-bold"">63</td>
                                            <td>$2,016</td>
                                        </tr>
                                        <tr>
                                            <th scope=""row""><a href=""#"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "57427e9d06647296cc8ed34c52e6e8397e44bc4e29258", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a></th>
                                            <td><a href=""#"" class=""text-primary fw-bold"">Sit unde debitis delectus
                                                    repellendus</a></td>
                                            <td>$79</td>
                                            <td class=""fw-bold"">41</td>
                                            <td>$3,239</td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div><!-- End Top Selling -->

                </div>
            </div>
            <!-- End Left side columns -->



        </div>
    </section>

</main>
<!-- End #main -->

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Handicraft_Website.Models.Userr> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
