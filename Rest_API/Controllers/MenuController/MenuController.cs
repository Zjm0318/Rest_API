using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_Rest_BLL;
using IOT_Rest_BLL.MenuBLL;
using IOT_Rest_Model.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rest_API.Controllers.MenuController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
       
        private IMenuBLL _menuBLL;
        public MenuController(IMenuBLL menuBLL)
        {
            _menuBLL = menuBLL;
        }

       

    }
}