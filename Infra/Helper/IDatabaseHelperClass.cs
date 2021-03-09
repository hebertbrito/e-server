using System.Data.SqlClient;
using System.Text;

namespace Infra.Helper
{
    public interface IDatabaseHelperClass
    {
        SqlCommand command { get; set; }
        SqlConnection connection { get; set; }
        StringBuilder query { get; set; }
        dynamic reader { get; set; }
    }
}