using ManageStudent.Core.Models;
using MongoDB.Driver;

namespace ManageStudent.Data.MongoDB.Setting
{
    public interface IDatabaseSettings
    {
        IMongoCollection<Composer> Composers { get; }
    }
}
