using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Services.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OperationResult = Microsoft.VisualStudio.Services.Licensing.OperationResult;

namespace ZYSJDal
{
    
    public class PagedInfo
    {
        private zysjDal dal;
        /// <summary>
        /// 当前页码
        /// </summary>
        public long CurrentPage { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalPages { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalItems { get; set; }

        /// <summary>
        /// 查询所有实体
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Query<T>() where T : class, new()
        {
            return dal.Set<T>();
        }

        /// <summary>
        /// 根据条件查询实体集合
        /// </summary>
        /// <param name="lamda">表达式</param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> lamda) where T : class, new()
        {
            return dal.Set<T>().Where(lamda);
        }

        /// <summary>
        /// 根据条件查询单个实体
        /// </summary>
        /// <param name="lamda">表达式</param>
        /// <returns></returns>
        public T QuerySingle<T>(Expression<Func<T, bool>> lamda) where T : class, new()
        {
            return dal.Set<T>().FirstOrDefault(lamda);
        }

        /// <summary>
        /// 根据条件查询实体是否存在
        /// </summary>
        /// <param name="lamda">表达式</param>
        /// <returns></returns>
        public bool IsExist<T>(Expression<Func<T, bool>> lamda) where T : class, new()
        {
            return dal.Set<T>().Any(lamda);
        }

        /// <summary>
        /// 根据条件查询实体总数量
        /// </summary>
        /// <param name="lamda">表达式</param>
        /// <returns></returns>
        public int QueryConut<T>(Expression<Func<T, bool>> lamda) where T : class, new()
        {
            return dal.Set<T>().Count(lamda);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
       public bool Ceart<T>(T data) where T : class, new()
        {
            try
            {
                dal.Set<T>().Add(data);
                int jg = dal.SaveChanges();
                if (jg==0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update<T>(T data) where T : class, new()
        {
            try
            {
                dal.Set<T>().Update(data);
                int jg = dal.SaveChanges();
                if (jg == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete<T>(T data) where T : class, new()
        {
            try
            {
                dal.Set<T>().Remove(data);
                int res = dal.SaveChanges();
                if (res == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


    }
}
