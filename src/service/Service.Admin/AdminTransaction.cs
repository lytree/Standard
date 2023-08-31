using Infrastructure.Service;
using Repository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
	/// <summary>
	/// 启用权限库事务
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true)]
	public class AdminTransactionAttribute : TransactionAttribute
	{
		public AdminTransactionAttribute() : base(DbKeys.AdminDb)
		{
		}
	}
}
