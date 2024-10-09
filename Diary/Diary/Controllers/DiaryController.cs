using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    /// <summary>
    /// Diary
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiaryController : Controller
    {
       
        // GET: DiaryController/Create
        public ActionResult Create()
        {
            return View();
        }

      
        // GET: DiaryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
       
    }
}
