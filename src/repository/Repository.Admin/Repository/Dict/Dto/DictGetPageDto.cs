﻿namespace Repository.Admin.Repository.Dict.Dto;
public partial class DictGetPageDto
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public long DictTypeId { get; set; }

    /// <summary>
    /// 字典名称
    /// </summary>
    public string Name { get; set; }
}