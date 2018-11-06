using Jayfolio.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jayfolio.Data
{
    public interface IProject
    {
        Project GetById(int _id);
        IEnumerable<Project> GetAll();

        Task Create(Project _project);
        Task Delete(int _projectId);
        Task UpdateProjectTitle(int _projectId, string _newTitle);
        Task UpdateProjectDescription(int _porjectId, string _newDescription);
    }
}
