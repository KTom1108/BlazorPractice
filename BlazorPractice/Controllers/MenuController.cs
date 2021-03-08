using BlazorPractice.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


namespace BlazorPractice.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MenuController : Controller
    {
        private const string Path = "wwwroot/data/Menu.json";
        private List<Menu> Model;

        public MenuController()
        {
            var txtTranslate = System.IO.File.ReadAllText(Path);
            Model = JsonSerializer.Deserialize<List<Menu>>(txtTranslate);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Menu> Get(int menuNo)
        {
            return Model.Where(x => x.no == menuNo).ToList();
        }

        [HttpGet]
        public List<Menu> Get()
        {
            return Model;
        }

        [HttpPost]
        public StdResult Add(string title, int depth, int order, string icon, string memo)
        {
            try
            {
                Model.Add(new Menu() { title = title, depth = depth, order = order, icon = icon, memo = memo });

                string strModel = JsonSerializer.Serialize(Model);
                System.IO.File.WriteAllText(Path, strModel);

                return new StdResult() { ResultCode = 0, ResultMessage = "Success" };
            }
            catch (Exception ex)
            {
                return new StdResult() { ResultCode = -99, ResultMessage = ex.Message };
            }            
        }

        [HttpPost]
        public StdResult Delete(int menuNo)
        {
            try
            {
                var delMenu = Model.Where(x => x.no == menuNo).FirstOrDefault();
                Model.Remove(delMenu);

                string strModel = JsonSerializer.Serialize(Model);
                System.IO.File.WriteAllText(Path, strModel);

                return new StdResult() { ResultCode = 0, ResultMessage = "Success" };
            }
            catch (Exception ex)
            {
                return new StdResult() { ResultCode = -99, ResultMessage = ex.Message };
            }           
        }
    }
}
