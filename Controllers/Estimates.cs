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
using Spire.Doc.Interface;
using System.Drawing;
using XHomes.Data;
using AutoMapper;
using XHomes.Dtos;

namespace XHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Estimates : ControllerBase
    {
        private readonly IEstimatePgRepo repo;
        private readonly IMapper mapper;

        public Estimates(IEstimatePgRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estimate>> GetAllEstimates()
        {

            var estimates = repo.GetAllEstimates();

            if (estimates.Count() == 0)
                return NotFound();


            return Ok(mapper.Map<IEnumerable<EstimateReadDto>>(estimates));
        }

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
            bookmarksNavigator.ReplaceBookmarkContent(estimate.city + "," + estimate.state + " " + estimate.zip, true);
            bookmarksNavigator.MoveToBookmark("Phone");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.phone, true);
            bookmarksNavigator.MoveToBookmark("Email");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.email, true);
            bookmarksNavigator.MoveToBookmark("Description");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.description, true);
            bookmarksNavigator.MoveToBookmark("JobType");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.jobType, true);
            bookmarksNavigator.MoveToBookmark("Condition");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.condition.ToString(), true);
            bookmarksNavigator.MoveToBookmark("Difficulty");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.difficulty.ToString(), true);
            var filePath = "C:\\Users\\Srankoin\\Downloads\\ExtremeHomes_" + estimate.firstName + "_" + estimate.lastName + ".docx";

            var section = document.AddSection();
            var paragraph = section.AddParagraph();
            ITable table = new Table(document);
            table.ResetCells(3, 3);
            table.Rows[0].Cells[0].AddParagraph().AppendText("Title");
            table.Rows[0].Cells[1].AddParagraph().AppendText("Description");
            table.Rows[0].Cells[2].AddParagraph().AppendText("Priority");
            table.Rows[0].IsHeader = true;
            table.Rows[0].RowFormat.BackColor = Color.AliceBlue;


            for (int i = 0; i < estimate.tasks.Count; i++) {
                var currentTask = estimate.tasks[i];
                table.AddRow();
                table.Rows[i + 1].Cells[0].AddParagraph().AppendText(currentTask.title);
                table.Rows[i + 1].Cells[1].AddParagraph().AppendText(currentTask.description);
                table.Rows[i + 1].Cells[2].AddParagraph().AppendText(currentTask.priority.ToString());

            }


            //   foreach (WorkTask task in estimate.tasks) {
            // bookmarksNavigator.InsertText(task.title + " " + task.description + " " + task.priority);
            //
            // }
            bookmarksNavigator.MoveToBookmark("WorkTasks");
            bookmarksNavigator.InsertTable(table);
            bookmarksNavigator.MoveToBookmark("MaterialDescription");
            bookmarksNavigator.ReplaceBookmarkContent(estimate.matDescription, true);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///2nd TABLE 2nd TAble 2nd TABle 2nd Table 2nd Table 2nd Table 2nd Table////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ITable table2 = new Table(document);
            table2.ResetCells(3, 3);
            table2.Rows[0].Cells[0].AddParagraph().AppendText("Material");
            table2.Rows[0].Cells[1].AddParagraph().AppendText("Description");
            table2.Rows[0].Cells[2].AddParagraph().AppendText("Price");
            table2.Rows[0].IsHeader = true;
            table2.Rows[0].RowFormat.BackColor = Color.AliceBlue;


            for (int i = 0; i < estimate.materials.Count; i++) {

                var currentTask = estimate.materials[i];
                table2.AddRow();
                table2.Rows[i + 1].Cells[0].AddParagraph().AppendText(currentTask.material);
                table2.Rows[i + 1].Cells[1].AddParagraph().AppendText(currentTask.matDescription);
                table2.Rows[i + 1].Cells[2].AddParagraph().AppendText("$" + currentTask.price);

            }
            bookmarksNavigator.MoveToBookmark("MaterialList");
            bookmarksNavigator.InsertTable(table2);



            ////SAVING AND EXPORTING OF FILE!!///////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////
            document.SaveToFile(filePath);
            string fileName = "ExtremeHomes_" + estimate.firstName + "_" + estimate.lastName + ".docx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            var mimeType = "application/....";
            var path = filePath;
            var estimatemodel = estimate;
            estimatemodel.tasks = new List<WorkTask>(estimate.tasks);
            estimatemodel.materials = estimate.materials;
            this.repo.SaveEstimate(estimatemodel);
            this.repo.SaveChanges();
            return File(System.IO.File.OpenRead(filePath), "application/msword");

        }


        [HttpDelete("{id}")]
        public ActionResult DeleteEstimate(int id) {

            var estimate = repo.GetEstimate(id);
            if (estimate == null)
                return NotFound();
            estimate.materials = null;
            Console.Write(estimate);

            repo.DeleteEstimate(estimate);

            repo.SaveChanges();

            return NoContent();
        }

        //api/estimates/id
        [HttpGet("{id}")]
        public ActionResult<EstimateReadDto> GetEstimate(int id) 
        {
            var estimateModel = repo.GetEstimate(id);

            if (estimateModel != null) {
                return this.mapper.Map<EstimateReadDto>(estimateModel);
            }

            return Ok(repo.GetEstimate(id));
        }

       
    }
}
