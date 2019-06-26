using MyApp.Areas.Admin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.GetUserSummaries
{
    public class GetUserSummariesResponse: ResponseBase
    {
        public GetUserSummariesResponse(List<UserSummary> summaries)
        {
            Summaries = summaries;
        }

        public GetUserSummariesResponse(string errorMessage): base(errorMessage) { }

        public List<UserSummary> Summaries { get; }
    }
}