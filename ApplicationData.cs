using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace BallPark3
{
    public class ApplicationData
    {
        private string ApplicationFolder;
        private string CompanyFolder;
        public static string DefaultApplicationFolder;
        public static string DefaultCompanyFolder;
        public static string DefaultAdditionalPath;
        private static readonly string directory =
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        public ApplicationData(string companyFolder, string applicationFolder)
        {
            this.ApplicationFolder = applicationFolder;
            this.CompanyFolder = companyFolder;

            CreateFolders(true);
        }

        public ApplicationData()
        {
            this.ApplicationFolder = DefaultApplicationFolder;
            this.CompanyFolder = DefaultCompanyFolder;

            CreateFolders(true);
        }

        /// <summary>
        /// Returns the path of the application's data folder.
        /// </summary>
        /// <returns>The path of the application's data folder.</returns>
        public override string ToString()
        {
            return ApplicationFolderPath;
        }

        /// <summary>
        /// Gets the path of the application's data folder.
        /// </summary>
        public string ApplicationFolderPath
        {
            get { return Path.Combine(CompanyFolderPath, ApplicationFolder, DefaultAdditionalPath); }
        }

        /// <summary>
        /// Gets the path of the company's data folder.
        /// </summary>
        public string CompanyFolderPath
        {
            get { return Path.Combine(directory, CompanyFolder); }
        }

        private void CreateFolders(bool allUsers)
        {
            DirectoryInfo directoryInfo;
            DirectorySecurity directorySecurity;
            AccessRule rule;
            SecurityIdentifier securityIdentifier = new SecurityIdentifier
                (WellKnownSidType.BuiltinUsersSid, null);
            if (!Directory.Exists(CompanyFolderPath))
            {
                directoryInfo = Directory.CreateDirectory(CompanyFolderPath);
                bool modified;
                directorySecurity = directoryInfo.GetAccessControl();
                rule = new FileSystemAccessRule(
                        securityIdentifier,
                        FileSystemRights.Write |
                        FileSystemRights.ReadAndExecute |
                        FileSystemRights.Modify,
                        AccessControlType.Allow);
                directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            if (!Directory.Exists(ApplicationFolderPath))
            {
                directoryInfo = Directory.CreateDirectory(ApplicationFolderPath);
                if (allUsers)
                {
                    bool modified;
                    directorySecurity = directoryInfo.GetAccessControl();
                    rule = new FileSystemAccessRule(
                        securityIdentifier,
                        FileSystemRights.Write |
                        FileSystemRights.ReadAndExecute |
                        FileSystemRights.Modify,
                        InheritanceFlags.ContainerInherit |
                        InheritanceFlags.ObjectInherit,
                        PropagationFlags.InheritOnly,
                        AccessControlType.Allow);
                    directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                    directoryInfo.SetAccessControl(directorySecurity);
                }
            }
        }

    }
}
