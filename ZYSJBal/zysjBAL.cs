using System;
using System.Collections.Generic;
using System.Text;
using ZYSJDal;
using ZYSJModer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.IO;

namespace ZYSJBal
{
    public class zysjBAL : Controller
    {
        private ZYSJDal.zysjDal db;

        public zysjBAL(ZYSJDal.zysjDal _db)
        {
            db = _db;
        }

        public  List<ZYSJModer.Moder.LY> LYslist()
        {
            var list = db.LY.OrderByDescending(X=>X.LYRQ).ToList();
            return list;
        }

        public JsonResult GetJLlist()
        {
            var list = (from jl in db.JL.ToList()
                        join u in db.Users.ToList() on jl.JUSER equals u.UID
                        select new
                        {
                            jluname = u.UNAME,
                            jltitle = jl.JTITLE,
                            jlxx = jl.JLXX,
                            jlimg = jl.JLIMG,
                            scnum = jl.DZNUM,
                            date = jl.DATE,
                            jlid=jl.JID
                        }).OrderByDescending(X=>X.date).ToList();
            
            return Json(new { list });
        }

        public List<ZYSJModer.Moder.BOOKS> GetBOOKs()
        {
            var list = db.BOOKS.ToList();
            return list;
        }

        public List<ZYSJModer.Moder.VIDES> GetVIDEs()
        {
            var list = db.VIDES.ToList();
            return list;
        }

        

        

    }
}
