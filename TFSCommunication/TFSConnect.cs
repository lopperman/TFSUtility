using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Server;
using TFSCommunication.BusinessObjects;

namespace TFSCommunication
{
    public class TFSConnect
    {
        private string _projectName;
        private Project project = null;
        TfsTeamProjectCollection tfs = null;

        public TFSConnect(string tfsUri, string projectName)
        {
            this.TFSUri = tfsUri;
            this.ProjectName = projectName;

            ProjectCollection.EnsureAuthenticated();

            project = Projects().FirstOrDefault(x => x.Name == projectName);

        }

        public string TFSUri { get; }
        public string ProjectName { get; }

        public TfsTeamProjectCollection ProjectCollection
        {
            get
            {
                if (tfs == null)
                {
                    tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(TFSUri));
                }

                return tfs;
            }
        }


        public T GetService<T>() where T : ITfsTeamProjectCollectionObject
        {
            return ProjectCollection.GetService<T>();
        }

        private List<Project> Projects()
        {
            return GetService<WorkItemStore>()
                .Projects.Cast<Project>().ToList();
        }


        public List<TfsArea> GetTfsAreas()
        {
            List<TfsArea> areas = new List<TfsArea>();

            foreach (Node node in project.AreaRootNodes)
            {
                areas.AddRange(GetNodeNamesAndIds(node));
            }

            return areas;

        }

        public List<TfsArea> GetNodeNamesAndIds(Node node)
        {
            List<TfsArea> areas = new List<TfsArea>();

            if (node.IsAreaNode)
            {
                areas.Add(new TfsArea(node.Id, node.Name));
            }

            if (node.HasChildNodes)
            {
                foreach (Node child in node.ChildNodes)
                {
                    areas.AddRange(GetNodeNamesAndIds(child));
                }
            }

            return areas;
        }

    }
}