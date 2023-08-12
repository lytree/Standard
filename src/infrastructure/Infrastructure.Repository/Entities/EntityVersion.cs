﻿using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace Infrastructure.Repository;

/// <summary>
/// 实体版本
/// </summary>
public class EntityVersion<TKey> : EntityBase, IVersion
{
    /// <summary>
    /// 版本
    /// </summary>
    [Description("版本")]
    [Column(Position = -30, IsVersion = true)]
    public virtual long Version { get; set; }
}

/// <summary>
/// 实体版本
/// </summary>
public class EntityVersion : EntityVersion<long>
{
}