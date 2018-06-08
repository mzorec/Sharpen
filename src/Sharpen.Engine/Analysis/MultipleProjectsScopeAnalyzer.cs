﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    public sealed class MultipleProjectsScopeAnalyzer : BaseScopeAnalyzer
    {
        private readonly Project[] projects;

        public MultipleProjectsScopeAnalyzer(Project[] projects)
        {
            this.projects = projects;
        }

        protected override string BuildCanExecuteScopeAnalysisErrorMessage()
        {
            // TODO-IG: Uncomment the commented code as soon as the analysis of multiple projects is implemented.
            return "Analyzing selected projects is currently not implemented.";

            //if (projects.Length <= 0)
            //{
            //    return "There are no projects selected.";
            //}
            //
            //if (!projects.Any(ProjectCanBeAnalyzed))
            //{
            //    return "The selected projects do not contain any C# project that can be analyzed.";
            //}
            //
            //if (!projects.SelectMany(project => project.Documents).Any(DocumentCanBeAnalyzed))
            //{
            //    return "The selected C# projects do not contain any C# files that could be analyzed.";
            //}

            //return null;
        }

        protected override string ScopeAnalysisHelpMessage => 
            null;
            // TODO-IG: Uncomment the commented code as soon as the analysis of multiple projects is implemented.
            //"To start project analysis, select at least one C# project with at least one non-generated C# file.";

        protected override IEnumerable<Document> GetDocumentsToAnalyze()
        {
            if (!projects.Any()) return Enumerable.Empty<Document>();

            return projects
                .Where(ProjectCanBeAnalyzed)
                .SelectMany(project => project.Documents)
                .Where(DocumentCanBeAnalyzed);
        }
    }
}