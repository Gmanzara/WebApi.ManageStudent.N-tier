using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Repositories
{
    public interface IComposerRepository
    {
        Task<IEnumerable<Composer>> GetAllComposer();
        Task<Composer> Create( Composer composer); 
        Task<Composer> GetComposerById(string id);
        Task<bool> Delete(string id);
        void Update(string id,Composer composer);
     
    }
}
