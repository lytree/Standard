using FreeSql;
using Repository.Admin.Repository.Config;
using Repository.Admin.Repository.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin.Repository.Setting;

public class ConfigRepository : AdminRepositoryBase<ConfigEntity>, IConfigRepository
{
	public ConfigRepository(UnitOfWorkManager uowm) : base(uowm)
	{
	}
}
