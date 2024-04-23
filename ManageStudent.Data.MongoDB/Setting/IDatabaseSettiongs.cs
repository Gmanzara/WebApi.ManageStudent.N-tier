using ManageStudent.Core.Models;
using MongoDB.Driver;

namespace ManageStudent.Data.MongoDB.Setting
{
    public interface IDatabaseSettiongs
    {
        IMongoCollection<Composer> Composers { get; }
    }
}
