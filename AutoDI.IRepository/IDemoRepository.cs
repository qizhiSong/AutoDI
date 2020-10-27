using System;
using System.Threading.Tasks;

namespace AutoDI.IRepository
{
    /// <summary>
    /// Version: v1.0
    /// Author: Simonsong
    /// Date: 2020/10/22 星期四 21:39:35
    /// Description:
    /// </summary>
    public interface IDemoRepository<T> where T : class, new()
    {
        T GetObject(T Str);
    }
}
