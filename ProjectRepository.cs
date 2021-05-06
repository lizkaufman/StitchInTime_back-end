using System;
using Dapper;
using System.Collections.Generic;

namespace Stitch_BackEnd
{
    public class ProjectRepository : BaseRepository
    {
        public IEnumerable<Project> GetAllProjects()
        {
            using var connection = CreateConnection();
            return connection.Query<Project>("SELECT * FROM Projects;");
        }

        public Project GetProject(long id)
        {
            using var connection = CreateConnection();
            return connection.QuerySingle<Project>("SELECT * FROM Projects WHERE id = @id", new { id = id });
        }
        public Project CreateProject(Project project)
        {
            using var connection = CreateConnection();
            return connection.QuerySingle<Project>("INSERT INTO Projects (projectName, projectType, currentRowsDone, currentStitchesDone, rowTarget, stitchTarget, projectImageUrl, patternUrl, startDate, finishDate) VALUES (@ProjectName, @ProjectType, @CurrentRowsDone, @CurrentStitchesDone, @RowTarget, @StitchTarget, @ProjectImageUrl, @PatternUrl, @StartDate, @FinishDate) RETURNING *;", project);
        }
        public Project UpdateProject(Project project)
        {
            using var connection = CreateConnection();
            return connection.QuerySingle<Project>("UPDATE Projects SET projectName = @ProjectName, projectType = @ProjectType, currentRowsDone = @CurrentRowsDone, currentStitchesDone = @CurrentStitchesDone, rowTarget = @RowTarget, stitchTarget = @StitchTarget, projectImageUrl = @ProjectImageUrl, patternUrl = @PatternUrl, startDate = @StartDate, finishDate = @FinishDate WHERE id = @id RETURNING *;", project);
        }
        public string DeleteProject(long id)
        {
            using var connection = CreateConnection();
            connection.Execute("DELETE FROM Projects WHERE id = @id", new { id = id });
            return $"Project {id} has been deleted.";
        }
    }
}
