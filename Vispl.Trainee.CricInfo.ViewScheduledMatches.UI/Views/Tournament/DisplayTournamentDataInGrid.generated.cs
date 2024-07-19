﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Syncfusion.EJ2;
    using Vispl.Trainee.CricInfo.ViewScheduledMatches.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Tournament/DisplayTournamentDataInGrid.cshtml")]
    public partial class _Views_Tournament_DisplayTournamentDataInGrid_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<Vispl.Trainee.CricInfo.ViewScheduledMatches.VO.clsTournamentVO>>
    {
        public _Views_Tournament_DisplayTournamentDataInGrid_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Tournament\DisplayTournamentDataInGrid.cshtml"
  
    ViewBag.Title = "DisplayTournamentDataInGrid";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"form-container\"");

WriteLiteral(">\r\n    <h2>Tournament List</h2>\r\n\r\n    <div");

WriteLiteral(" id=\"TournamentGrid\"");

WriteLiteral("></div>\r\n\r\n");

DefineSection("scripts", () => {

            
            #line 13 "..\..\Views\Tournament\DisplayTournamentDataInGrid.cshtml"
    
            
            #line default
            #line hidden
WriteLiteral("\r\n        <script");

WriteLiteral(" src=\"https://cdn.syncfusion.com/ej2/dist/ej2.min.js\"");

WriteLiteral("></script>\r\n        <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 429), Tuple.Create("\"", 464)
, Tuple.Create(Tuple.Create("", 436), Tuple.Create<System.Object, System.Int32>(Href("~/Content/ej2/bootstrap5.css")
, 436), false)
);

WriteLiteral(@">

        <script>
        function formatDate(serializedDate) {
            var date = new Date(parseInt(serializedDate.substr(6)));
            var day = ('0' + date.getDate()).slice(-2);
            var month = ('0' + (date.getMonth() + 1)).slice(-2);
            var year = date.getFullYear();
            var hours = ('0' + date.getHours()).slice(-2);
            var minutes = ('0' + date.getMinutes()).slice(-2);

            return `${day}-${month}-${year} ${hours}:${minutes}`;
        }

        $(function () {
            var tournaments = ");

            
            #line 30 "..\..\Views\Tournament\DisplayTournamentDataInGrid.cshtml"
                         Write(Html.Raw(Json.Encode(Model)));

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var isUserLoggedIn = ");

            
            #line 31 "..\..\Views\Tournament\DisplayTournamentDataInGrid.cshtml"
                            Write(Html.Raw(Json.Encode(ViewBag.IsUserLoggedIn)));

            
            #line default
            #line hidden
WriteLiteral(";\r\n\r\n            // Apply date formatting to the tournaments data\r\n            to" +
"urnaments.forEach(function (tournament) {\r\n                tournament.StartDate " +
"= formatDate(tournament.StartDate);\r\n                tournament.EndDate = format" +
"Date(tournament.EndDate);\r\n            });\r\n\r\n            var grid = new ej.grid" +
"s.Grid({\r\n                dataSource: tournaments,\r\n                allowPaging:" +
" true,\r\n                allowSorting: true,\r\n                allowFiltering: tru" +
"e,\r\n                toolbar: [\'Search\'],\r\n                columns: [\r\n          " +
"          { field: \'TournamentID\', headerText: \'ID\', width: \'50\' },\r\n           " +
"         { field: \'TournamentName\', headerText: \'Name\', width: \'200\' },\r\n       " +
"             { field: \'StartDate\', headerText: \'Start Date\', width: \'150\' },\r\n  " +
"                  { field: \'EndDate\', headerText: \'End Date\', width: \'150\' },\r\n " +
"                   { field: \'MatchType\', headerText: \'Match Type\', width: \'150\' " +
"},\r\n                ],\r\n                childGrid: {\r\n                    queryS" +
"tring: \'TournamentID\',\r\n                    columns: [\r\n                        " +
"{ field: \'FirstTeam\', headerText: \'First Team\', width: \'150\' },\r\n               " +
"         { field: \'SecondTeam\', headerText: \'Second Team\', width: \'150\' },\r\n    " +
"                    { field: \'ScheduledTime\', headerText: \'Scheduled Time\', widt" +
"h: \'150\' },\r\n                        { field: \'Venue\', headerText: \'Venue\', widt" +
"h: \'150\' },\r\n                        {\r\n                            headerText: " +
"\'Action\', width: \'100\', template: isUserLoggedIn ? \'<button class=\"btn-submit\" o" +
"nclick=\"startMatch(${TournamentID})\">Start Match</button>\' : \'\'\r\n               " +
"         }\r\n                    ],\r\n                    dataBound: function () {" +
"\r\n                        var childGridObj = this;\r\n                        var " +
"parentRecord = this.parentDetails.parentRowData;\r\n                        var to" +
"urnamentID = parentRecord.TournamentID;\r\n\r\n                        // Check if t" +
"he tournament has already been loaded\r\n                        if (!tournaments." +
"find(t => t.TournamentID === tournamentID).isLoaded) {\r\n                        " +
"    $.ajax({\r\n                                url: \'");

            
            #line 71 "..\..\Views\Tournament\DisplayTournamentDataInGrid.cshtml"
                                 Write(Url.Action("GetMatchesByTournament", "Tournament"));

            
            #line default
            #line hidden
WriteLiteral(@"',
                                type: 'GET',
                                data: { tournamentID: tournamentID },
                                success: function (data) {
                                    console.log(""Matches data fetched: "", data); // Log the fetched data

                                    // Format ScheduledTime here
                                    data.forEach(function (match) {
                                        match.ScheduledTime = formatDate(match.ScheduledTime);
                                    });

                                    childGridObj.dataSource = data;
                                    childGridObj.refresh();
                                    tournaments.find(t => t.TournamentID === tournamentID).isLoaded = true;
                                },
                                error: function (xhr, status, error) {
                                    console.error('Error fetching matches: ', error); // Log any errors
                                }
                            });
                        }
                    }
                }
            });
            grid.appendTo('#TournamentGrid');
        });

        function startMatch(id) {
            window.location.href = '");

            
            #line 98 "..\..\Views\Tournament\DisplayTournamentDataInGrid.cshtml"
                               Write(Url.Action("Index", "Toss"));

            
            #line default
            #line hidden
WriteLiteral("?Id=\' + id;\r\n        }\r\n        </script>\r\n    ");

});

WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
