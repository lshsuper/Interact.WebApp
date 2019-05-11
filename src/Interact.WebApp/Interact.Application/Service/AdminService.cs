using Interact.Application.Dto;
using Interact.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interact.Core.Entity;

namespace Interact.Application.Service
{
  public  class AdminService
    {
        private readonly IAdminRespository _adminRespository;
        public AdminService(IAdminRespository adminRespository)
        {
            _adminRespository = adminRespository;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public AdminDto  FindByLoginAndPwd(string login,string pwd)
        {
            var admin = _adminRespository.FindByLoginAndPwd(login,pwd);
            if (admin == null) return new AdminDto();
            return Mapper.Map<AdminDto>(admin); 
        }
        /// <summary>
        ///登录接口 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        public AdminDto Login(string login,string pwd,out string notify)
        {
            var admin = _adminRespository.FindByLoginAndPwd(login, pwd);
            if (admin == null)
            {
                notify = "登录失败";
                return null;
            }
            notify = "登录成功";
            return Mapper.Map<AdminDto>(admin);
        }
    }
}
