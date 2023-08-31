﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

/// <summary>
/// 分页信息输出
/// </summary>
public class PageOutput<T>
{
    /// <summary>
    /// 数据总数
    /// </summary>
    public long Total { get; set; } = 0;

    /// <summary>
    /// 数据
    /// </summary>
    public IList<T> List { get; set; }
}