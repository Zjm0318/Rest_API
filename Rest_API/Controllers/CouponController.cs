using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOT_Rest_BLL;
using IOT_Rest_Model.DBModels;

namespace Rest_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        CouponBLL bll = new CouponBLL();

        //展示优惠券
        [HttpGet]
        public List<tb_Coupon> ShowCoupon(int flag)
        {
            return bll.ShowCoupon(flag);
        }
        [HttpGet]
        public int LingQu(int UId)
        {
            return bll.LingQu(UId);
        }
    }
}