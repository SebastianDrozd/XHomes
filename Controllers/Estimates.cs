using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.PlatformAbstractions;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using XHomes.Models;

namespace XHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Estimates : ControllerBase
    {
        [HttpPost]
        public ActionResult DownloadWordDocumentAsync(Estimate estimate) {
            Console.WriteLine(estimate.ToString());
            Document document = new Document("C:\\Users\\Srankoin\\Downloads\\Extreme Homes.docx");
            var bookmarksNavigator = new BookmarksNavigator(document);
            bookmarksNavigator.MoveToBookmark("CustomerName");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.firstName + " " + estimate.lastName, true);
            bookmarksNavigator.MoveToBookmark("Date");
            bookmarksNavigator.ReplaceBookmarkContent(DateTime.Now.ToShortDateString(), true);
            bookmarksNavigator.MoveToBookmark("Address");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.city + "," + estimate.state + " " + estimate.zip , true);
            bookmarksNavigator.MoveToBookmark("Phone");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.phone, true);
            bookmarksNavigator.MoveToBookmark("Email");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.email, true);
            bookmarksNavigator.MoveToBookmark("Description");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.description, true);
            var filePath = "C:\\Users\\Srankoin\\Downloads\\ExtremeHomes_" + estimate.firstName + "_" + estimate.lastName + ".docx";
            document.SaveToFile(filePath);
            string fileName = "ExtremeHomes_" + estimate.firstName + "_" + estimate.lastName + ".docx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            var mimeType = "application/....";
            var path = filePath;

            return File(System.IO.File.OpenRead(filePath), "application/msword");

        }

       
    }
}
