using CostControlWebsite.Models;
using CostControlWebsite.QueryAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CostControlWebsite.Controllers;
using CostControlWebsite;

namespace CostControlWebsite.Controllers
{
    public class ShowController : Controller
    {
        
        private T_Po po = new T_Po();

        // GET: Show
        public ActionResult Index()
        {
            
            List<T_PoJoinPR> listTic = new List<T_PoJoinPR>();
            List<HoldingPO> listTic2 = new List<HoldingPO>();
            List<HoldingPR> listTic3 = new List<HoldingPR>();
            List<RejectPO> listTic4 = new List<RejectPO>();
            List<RejectPR> listTic5 = new List<RejectPR>();
            QueryCRUD qr = new QueryCRUD();
          
            listTic = qr.GetTPO();

            listTic2 = qr.GetTPOHolding();
            listTic3 = qr.GetT_PRHolding();
            listTic4 = qr.GetTPO_Reject();
            listTic5 = qr.GetTPR_Reject();

            if (listTic.Count == 0) {
                ViewBag.sumpo = "0";
                ViewBag.sumpr = "0";
            }

            listTic.ForEach((l) => {


                if (l.T_Po != null)
                {

                    ViewBag.sumpo = l.T_Po;
                    if (l.T_Po == "")
                    {

                        ViewBag.sumpo = "0";
                    }

                }

                if (l.T_PR != null)
                {
                    ViewBag.sumpr = l.T_PR;
                    if (l.T_PR == "")
                    {
                        ViewBag.sumpr = "0";
                    }
                }


            });
            try {
                if (listTic2.Count == 0)
                {

                    ViewBag.sumhopo = "0";
                }

                listTic2.ForEach((i) =>
                {
                    if (i.Area != null)
                    {
                       ViewBag.sumhopo = i.Area;
                    }
                });
                if (listTic3.Count == 0)
                {
                    ViewBag.sumhopr = "0";
                }
                listTic3.ForEach((li)=>{

                    if (li.Area != null)
                    {

                        ViewBag.sumhopr = li.Area;
                    }
                });
            } catch {
                return View();
            }
            try
            {
                if (listTic4.Count == 0)
                {

                    ViewBag.sumrepo = "0";
                }

                listTic4.ForEach((s) =>
                {
                    if (s.Area != null)
                    {
                        ViewBag.sumrepo = s.Area;
                    }
                });
                if (listTic5.Count == 0)
                {
                    ViewBag.sumrepr = "0";
                }
                listTic5.ForEach((si) => {

                    if (si.Area != null)
                    {

                        ViewBag.sumrepr = si.Area;
                    }
                });
            }
            catch
            {
                return View();
            }



            return View(listTic);
        } public ActionResult ShowPo()
        {
            ViewBag.Po = "Search";
           
            List<T_Po> listTic = new List<T_Po>();
            QueryCRUD qr = new QueryCRUD();

            listTic = qr.GetT_Po();


            return View(listTic);


        }
        public ActionResult ShowPR()
        {
            ViewBag.PR = "Search";
            List<T_PR> listTic = new List<T_PR>();
            QueryCRUD qr = new QueryCRUD();

            listTic = qr.GetT_PR();


            return View(listTic);


        }
        [HttpGet]
        public ActionResult Holding(string PoNo)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PoandPoApp().Find(ID => ID.PoNo == PoNo));


        }
        [HttpPost]
        [ActionName("Holding")]
        public ActionResult Holding(PoandPoApp poandPoApp)
        {
            QueryCRUD qr = new QueryCRUD();
            if (qr.Holding(poandPoApp))
            {

                return RedirectToAction("Index");


            }



            return View();
        }
        [HttpGet]
        public ActionResult HoldingPR(string PR_no)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PRandPrApp().Find(ID => ID.PR_no == PR_no));


        }
        [HttpPost]
        [ActionName("HoldingPR")]
        public ActionResult HoldingPR(PRandPRApp prandPRApp)
        {
            QueryCRUD qr = new QueryCRUD();
            if (qr.HoldingPR(prandPRApp))
            {

                return RedirectToAction("Index");


            }



            return View();
        }

   
       
        [HttpGet]
        [ActionName("Approved")]
        public ActionResult Approved(string PoNo)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PoandPoApp().Find(ID => ID.PoNo == PoNo));


        }
        [HttpPost]
        [ActionName("Approved")]
        public ActionResult Approved(PoandPoApp poandPoApp)
        {
            QueryCRUD qr = new QueryCRUD();
            if (qr.EditDt(poandPoApp))
            {

                return RedirectToAction("Index");


            }



            return View();
        }
        [HttpGet]
        [ActionName("ApprovedPR")]
        public ActionResult ApprovedPR(string PR_no)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PRandPrApp().Find(ID => ID.PR_no == PR_no));


        }
        [HttpPost]
        [ActionName("ApprovedPR")]
        public ActionResult ApprovedPR(PRandPRApp prandpra)
        {
            QueryCRUD qr = new QueryCRUD();

            if (qr.EditPR(prandpra)) {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public ActionResult ReJectPO(string PoNo)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PoandPoApp().Find(ID => ID.PoNo == PoNo));


        }
        [HttpPost]
        [ActionName("ReJectPO")]
        public ActionResult ReJectPO(PoandPoApp poandPoApp)
        {
            QueryCRUD qr = new QueryCRUD();
            if (qr.RejectPo(poandPoApp))
            {

                return RedirectToAction("Index");


            }



            return View();
        }
        [HttpGet]
       
        public ActionResult ReJectPR(string PR_no)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PRandPrApp().Find(ID => ID.PR_no == PR_no));


        }
        [HttpPost]
        [ActionName("ReJectPR")]
        public ActionResult ReJectPR(PRandPRApp prandpra)
        {
            QueryCRUD qr = new QueryCRUD();

            if (qr.RejectPR(prandpra))
            {
                return RedirectToAction("Index");

            }
            return View();
        }
      
        [HttpPost]
        [ActionName("Search")]
        public ActionResult Search(string Search)
        {

            List<T_Po> listTic = new List<T_Po>();
            QueryCRUD qr = new QueryCRUD();

            listTic = qr.SearchT_Po(Search);

            if (Search == "")
            {
                ViewBag.Po = "Search";

                listTic = qr.GetT_Po();

                return View("ShowPo", listTic);
            }



            ViewBag.Po = Search;
            return View("ShowPo", listTic);


        }
        [HttpPost]
        [ActionName("SearchPR")]
        public ActionResult SearchPR(string Search)
        {

            List<T_PR> listTic = new List<T_PR>();
            QueryCRUD qr = new QueryCRUD();

            listTic = qr.SearchT_PR(Search);

            if (Search == "")
            {
                ViewBag.PR = "Search";

                listTic = qr.GetT_PR();

                return View("ShowPR", listTic);
            }



            ViewBag.PR = Search;
            return View("ShowPR", listTic);


        }


    }

    }
