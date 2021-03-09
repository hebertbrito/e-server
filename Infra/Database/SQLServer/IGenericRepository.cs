using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.SQLServer
{
    public interface IGenericRepository
    {
        string ID { get; set; }
        string TypeUser { get; set; }
        
        StringBuilder CreateQuery(string Name);
        void ExecutionQuery(StringBuilder sql);
        Task<string> GetUserByName(string Name);
        void Mapper(SqlDataReader reader);
    }
}