using System.Threading.Tasks;

namespace Client
{
    public interface ISkinBootStrapper
    {
        Task InitializeAsync(string configFileName);
    }
}