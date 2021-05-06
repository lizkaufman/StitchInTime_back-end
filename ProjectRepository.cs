using System;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stitch_BackEnd
{
    public class ProjectRepository : BaseRepository
    {
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Project>("SELECT * FROM Projects;");
        }

        public async Task<Project> GetProject(long id)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Project>("SELECT * FROM Projects WHERE id = @id", new { id = id });
        }
        public async Task<Project> CreateProject(Project project)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Project>("INSERT INTO Projects (projectName, projectType, currentRowsDone, currentStitchesDone, rowTarget, stitchTarget, projectImageUrl, patternUrl, startDate, finishDate) VALUES (@ProjectName, @ProjectType, @CurrentRowsDone, @CurrentStitchesDone, @RowTarget, @StitchTarget, @ProjectImageUrl, @PatternUrl, @StartDate, @FinishDate) RETURNING *;", project);
        }
        public async Task<Project> UpdateProject(Project project)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Project>("UPDATE Projects SET projectName = @ProjectName, projectType = @ProjectType, currentRowsDone = @CurrentRowsDone, currentStitchesDone = @CurrentStitchesDone, rowTarget = @RowTarget, stitchTarget = @StitchTarget, projectImageUrl = @ProjectImageUrl, patternUrl = @PatternUrl, startDate = @StartDate, finishDate = @FinishDate WHERE id = @id RETURNING *;", project);
        }
        public async Task<Project> DeleteProject(long id)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Project>("DELETE FROM Projects WHERE id = @id", new { id = id });
        }
    }
}
