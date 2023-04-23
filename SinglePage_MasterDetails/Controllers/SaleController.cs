using Microsoft.AspNetCore.Mvc;
using SinglePage_MasterDetails.Models;
using SinglePage_MasterDetails.ViewModel;

namespace SinglePage_MasterDetails.Controllers
{
    public class SaleController : Controller
    {
        /*
         //this code is use for Migration, its can't work Scaffold

        private readonly MasterDBContext _dbContext;
        public SaleController(MasterDBContext dbContext)
        {
           _dbContext = dbContext;
        }  */

        MasterDBContext db = new MasterDBContext();
        public IActionResult Single(int? id)
        {
            VmSale oSale = new VmSale();
            var oSM = db.SaleMasters.Where(x => x.SaleId == id).FirstOrDefault();
            if (oSM != null)
            {
                oSale.SaleId = oSM.SaleId;
                oSale.CustomerName = oSM.CustomerName;
                oSale.CustomerAddress = oSM.CustomerAddress;
                oSale.Gender = oSM.Gender;
                oSale.CreateDate = oSM.CreateDate;
                var listDetail = new List<VmSale.VmSaleDetail>();
                var oSD = db.SaleDetails.Where(x => x.SaleId == id).ToList();
                foreach (var item in oSD)
                {
                    var oSaleDetial = new VmSale.VmSaleDetail();
                    oSaleDetial.SaleId = item.SaleId;
                    oSaleDetial.ProductName = item.ProductName;
                    oSaleDetial.Price = item.Price;
                    oSaleDetial.Qty = item.Qty;
                    listDetail.Add(oSaleDetial);
                }
                oSale.SaleDetails = listDetail;
            }
            oSale = oSale == null ? new VmSale() : oSale;
            ViewData["list"] = db.SaleMasters.ToList();
            return View(oSale);
        }
        [HttpPost]
        public IActionResult Single(VmSale model)
        {
            var oSalemaster = db.SaleMasters.Find(model.SaleId);
            if (oSalemaster == null)
            {
                oSalemaster = new SaleMaster();
                oSalemaster.SaleId = model.SaleId;
                oSalemaster.CreateDate = model.CreateDate;
                oSalemaster.CustomerName = model.CustomerName;
                oSalemaster.CustomerAddress = model.CustomerAddress;
                oSalemaster.Gender = model.Gender;
                db.SaleMasters.Add(oSalemaster);
            }
            else
            {
                oSalemaster.SaleId = model.SaleId;
                oSalemaster.CustomerName = model.CustomerName;
                oSalemaster.CustomerAddress = model.CustomerAddress;
                oSalemaster.Gender = model.Gender;
                oSalemaster.CreateDate = model.CreateDate;
                var listRem = db.SaleDetails.Where(x => x.SaleId == oSalemaster.SaleId).ToList();
                db.SaleDetails.RemoveRange(listRem);
            }
            db.SaveChanges();
            var listDetail = new List<SaleDetail>();
            for (var i = 0; i < model.ProductName.Length; i++)
            {
                if (!string.IsNullOrEmpty(model.ProductName[i]))
                {
                    var oSaleDetial = new SaleDetail();
                    oSaleDetial.SaleId = oSalemaster.SaleId;
                    oSaleDetial.ProductName = model.ProductName[i];
                    oSaleDetial.Price = model.Price[i];
                    oSaleDetial.Qty = model.Qty[i];
                    listDetail.Add(oSaleDetial);
                }
            }
            db.SaleDetails.AddRange(listDetail);
            db.SaveChanges();

            return RedirectToAction("Single");
        }
        public IActionResult Delete(int id)
        {
            var oSaleMaster = (from o in db.SaleMasters where o.SaleId == id select o).FirstOrDefault();
            var oDetail = (from o in db.SaleDetails where o.SaleId == id select o).ToList();
            if (oSaleMaster != null)
            {
                db.SaleMasters.Remove(oSaleMaster);
                db.SaleDetails.RemoveRange(oDetail);
                db.SaveChanges();
            }
            return RedirectToAction("Single");
        }

    }
}
