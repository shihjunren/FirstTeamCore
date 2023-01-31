using FirstTeamCore.Models;
using FirstTeamCore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstTeamCore.Controllers
{
    public class SetController : Controller
    {
        IWebHostEnvironment _environment; //全域變數_environment
        public SetController(IWebHostEnvironment p)
        {
            _environment = p;
        }



        //<!-- ======= 自選飲食 ======= -->
        FTdbContext db = new FTdbContext();
        //查詢
        public IActionResult SetFood(CKeywordViewModel vm)
        
        {

            IEnumerable<SetFood> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
            {
                datas = from t in db.SetFoods
                        select t;
            }
            else
            {
                datas = db.SetFoods.Where(t => t.餐廳名.Contains(vm.txtKeyword) ||
                t.地址.Contains(vm.txtKeyword) || t.餐點細項.Contains(vm.txtKeyword));
            }

            return View(datas);
        }


        public IActionResult FoodCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FoodCreate(SetFood p)
        {

            db.SetFoods.Add(p);
            db.SaveChanges();
            return RedirectToAction("SetFood");
        }


        public IActionResult Delete(int? id)
        {
            if (id != null)
            {

                SetFood delSetFood = db.SetFoods.FirstOrDefault(t => t.餐廳id == id);
                if (delSetFood != null)
                {
                    db.SetFoods.Remove(delSetFood);
                    db.SaveChangesAsync();
                }
            }
            return RedirectToAction("SetFood");
        }


        //第一步找資料
        public IActionResult FoodEdit(int? id)
        {
            if (id != null)
            {

                SetFood x = db.SetFoods.FirstOrDefault(t => t.餐廳id == id);
                if (x != null)
                    return View(x);

            }
            return RedirectToAction("SetFood"); //刪除後回傳給List
        }
        [HttpPost]
        //存入資料庫
        public IActionResult FoodEdit(CSetFoodViewModel p)  //使用CSelfFoodViewModel
        {

            SetFood x = db.SetFoods.FirstOrDefault(t => t.餐廳id == p.餐廳ID);
            if (x != null)
            {
                x.地區 = p.地區;
                x.餐廳名 = p.餐廳名;
                x.餐廳電話 = p.餐廳電話;
                x.餐點細項 = p.餐點細項;
                

                db.SaveChangesAsync();
            }
            return RedirectToAction("SetFood");
        }


        

        //---------------餐廳---------------

        
        public IActionResult SetOrder()
        {
            return View();
        }
        //---------------訂單---------------
        public IActionResult SetDetail()
        {
            return View();
        }
        //---------------訂單細節---------------

    }
}
