using Interact.Application.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Autofac;
namespace Interact.Test
{
    /// <summary>
    /// 签到相关测试
    /// </summary>
    [TestClass]
   public class SignInTest:BaseTest
    {
        public SignInService _signInService;
        public SignInTest()
        {
            _signInService = _container.Resolve<SignInService>();
        }
        /// <summary>
        /// 测试签到
        /// </summary>
        [TestMethod]
        public void TestSignIn()
        {
            string notify;
            bool result=_signInService.SignIn(new Core.Entity.SignInRecord() {
                    OpenId="1234567890",
                    ActivityId=1,
                    NickName="lsh",
            },out notify);
            //Assert.IsTrue(result);
        }
    }
}
