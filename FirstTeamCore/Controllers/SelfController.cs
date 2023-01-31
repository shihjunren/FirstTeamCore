using Microsoft.AspNetCore.Mvc;
using FirstTeamCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using FirstTeamCore.ViewModel;

namespace FirstTeamCore.Controllers
{
    public class SelfController : Controller
    {

        IWebHostEnvironment _environment; //全域變數_environment
        public SelfController(IWebHostEnvironment p)
        {
            _environment = p;
        }



        //<!-- ======= 自選飲食 ======= -->
        FTdbContext db = new FTdbContext();
        //查詢
        public IActionResult SelfFood(CKeywordViewModel vm)
        //public IActionResult SelfFood(string txtKeyword)
        {
          
            IEnumerable<SelfFood> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
            {
                datas = from t in db.SelfFoods
                        select t;
            }
            else
            {
                datas = db.SelfFoods.Where(t => t.商品名稱.Contains(vm.txtKeyword)||
                t.商品內容.Contains(vm.txtKeyword));
            }               

            return View(datas);
        }
    
       
        public IActionResult FoodCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FoodCreate(SelfFood p, IFormFile photo)
        {
            
            if (photo != null)
            {
                string photoName = Guid.NewGuid().ToString() + ".jpg";
                string path = _environment.WebRootPath + "/images/" + photoName;
                p.圖片 = photoName;
                photo.CopyTo(new FileStream(path, FileMode.Create));
            }
            else
            {
                p.圖片 = "empty.jpg";
            }
         
            db.SelfFoods.Add(p);
            db.SaveChanges();
            return RedirectToAction("SelfFood");
        }


        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                
                SelfFood delSelfFood = db.SelfFoods.FirstOrDefault(t => t.自選飲食編號id == id);
                if (delSelfFood != null)
                {
                    db.SelfFoods.Remove(delSelfFood);
                    db.SaveChangesAsync();
                }
            }
            return RedirectToAction("SelfFood");
        }


        //第一步找資料
        public IActionResult FoodEdit(int? id)
        {
            if (id != null)
            {
                
                SelfFood x = db.SelfFoods.FirstOrDefault(t => t.自選飲食編號id == id);
                if (x != null)
                    return View(x);

            }
            return RedirectToAction("SelfFood"); //刪除後回傳給List
        }
        [HttpPost]
        //存入資料庫
        public IActionResult FoodEdit(CSelfFoodViewModel p)  //使用CSelfFoodViewModel
        {
            
            SelfFood x = db.SelfFoods.FirstOrDefault(t => t.自選飲食編號id == p.自選飲食id);
            if (x != null)
            {
                if (p.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    string path = _environment.WebRootPath + "/images/" + photoName;
                    x.圖片 = photoName;
                    p.photo.CopyTo(new FileStream(path, FileMode.Create));
                }

                x.商品名稱 = p.商品名稱;
                x.商品內容 = p.商品內容;
                x.需求人數 = p.需求人數; 
                x.需求份數 = p.需求份數;
                x.單價 = p.單價;
                
                db.SaveChangesAsync();
            }
            return RedirectToAction("SelfFood");
        }


        //<!-- ======= End自選飲食 ======= -->



        //<!-- ======= 自選訂單 ======= -->

        public IActionResult SelfOrder()
        {
            return View();
        }


         

        //<!-- ======= 自選細項 ======= -->

        public IActionResult SelfDetail()
        {
            return View();
        }


     



    }
}
