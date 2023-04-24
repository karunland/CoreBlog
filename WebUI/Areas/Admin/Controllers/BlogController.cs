using Microsoft.AspNetCore.Mvc;
using ClosedXML;
using ClosedXML.Excel;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class BlogController : Controller
    {
        [HttpGet("ExportStaticExcelBlog/")]
        public IActionResult ExportStaticExcelBlog()
        {

            using (var wb = new XLWorkbook())
            {
                var worksheet = wb.Worksheets.Add("Blog List");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";

                int blogCount = 2;
                foreach (var item in GetBlogList() as List<BlogModel>)
                {
                    worksheet.Cell(blogCount, 1).Value = item.Id;
                    worksheet.Cell(blogCount, 2).Value = item.Name;
                    blogCount++;
                }

                using (var stream = new  MemoryStream())
                {
                    wb.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "myDocument.xlsx");
                }
            }
        }

        List<BlogModel> GetBlogList()
        {
            return new List<BlogModel>
            {
                new BlogModel { Id = 0, Name = "C# girisi 101"}
                , new BlogModel { Id = 1, Name = "New Cars with electricty"}
                , new BlogModel { Id = 2, Name = "C/C++ girisi 101"}
            };
        }

        [HttpGet("BlogListExcel/")]
        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
