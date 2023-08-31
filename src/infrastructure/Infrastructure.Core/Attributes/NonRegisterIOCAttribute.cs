using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core;


/// <summary>
/// 不注册到第三方IOC容器
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class NonRegisterIOCAttribute : Attribute
{
}
