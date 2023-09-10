using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin;

public class PageInput<T> : Infrastructure.PageInput<T>
{

    /// <summary>
    /// 高级查询条件
    /// </summary>
    public virtual FreeSql.Internal.Model.DynamicFilterInfo DynamicFilter { get; set; } = null;
}
