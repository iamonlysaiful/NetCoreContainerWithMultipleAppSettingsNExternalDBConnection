
namespace NETCoreAppWithMultipleAppSettings
{
    public sealed class DapperDBContext
    {
        public DapperDBContext(string connection) => Connection = connection;
        public string Connection { get; }
    }
}
