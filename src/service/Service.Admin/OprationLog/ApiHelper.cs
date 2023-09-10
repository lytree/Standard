﻿using Infrastructure.Core;
using Repository.Admin.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin.OprationLog;

/// <summary>
/// Api帮助类
/// </summary>
[SingleInstance]
public class ApiHelper
{
    private List<ApiHelperDto> _apis;
    private static readonly object _lockObject = new();

    private readonly IApiRepository _apiRepository;
    public ApiHelper(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }

    public List<ApiHelperDto> GetApis()
    {
        if (_apis != null && _apis.Any())
            return _apis;

        lock (_lockObject)
        {
            if (_apis != null && _apis.Any())
                return _apis;

            _apis = new List<ApiHelperDto>();

            var apis = _apiRepository.Select.ToList(a => new { a.Id, a.ParentId, a.Label, a.Path });

            foreach (var api in apis)
            {
                var parentLabel = apis.FirstOrDefault(a => a.Id == api.ParentId)?.Label;

                _apis.Add(new ApiHelperDto
                {
                    Label = parentLabel != null ? $"{parentLabel} / {api.Label}" : api.Label,
                    Path = api.Path?.ToLower().Trim('/')
                });
            }

            return _apis;
        }
    }
}

public class ApiHelperDto
{
    /// <summary>
    /// 接口名称
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// 接口地址
    /// </summary>
    public string Path { get; set; }
}