using AutoDI.IRepository;
using AutoDI.Other;
using System;
using System.Threading.Tasks;

namespace AutoDI.Repository
{
    /// <summary>
    /// Version: v1.0
    /// Author: Simonsong
    /// Date: 2020/10/22 星期四 20:40:14
    /// Description:
    /// </summary>
    public class DemoRepository<T> : IDemoRepository<T> where T : class, new()
    {
        private readonly DemoDbContext context;

        public DemoRepository(DemoDbContext context)
        {
            this.context = context;
        }
        public T GetObject(T Str)
        {
            var helloStr = this.context.GetString();
            return Str;
        }
    }
}
