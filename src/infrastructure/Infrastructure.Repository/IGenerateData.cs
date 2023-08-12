using Infrastructure.Repository;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

/// <summary>
/// 生成数据接口
/// </summary>
public interface IGenerateData
{
    Task GenerateDataAsync(IFreeSql db, AppConfig appConfig);
}
