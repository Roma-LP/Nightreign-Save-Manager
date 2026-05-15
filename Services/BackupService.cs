using NightreignSaveManager.Models;

namespace NightreignSaveManager.Services
{
    internal sealed class BackupService
    {
        private readonly string _nightreignPath;
        private readonly string _backupRootPath;

        public string BackupRootPath => _backupRootPath;

        public BackupService()
        {
            string appData = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData);

            _nightreignPath = Path.Combine(appData, "Nightreign");

            _backupRootPath = Path.Combine(appData, "NightreignBackups");

            Directory.CreateDirectory(_backupRootPath);
        }

        public IReadOnlyList<BackupInfo> GetBackups()
        {
            return Directory
                .GetDirectories(_backupRootPath, "Nightreign - SaveV*")
                .Select(path => new BackupInfo
                {
                    Name = Path.GetFileName(path),
                    FullPath = path,
                    CreatedAt = Directory.GetCreationTime(path)
                })
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }

        public async Task<BackupInfo> CreateBackupAsync()
        {
            ValidateSaveDirectory();

            int version = GetNextVersion("SaveV");

            string backupName =
                $"Nightreign - SaveV{version} - {DateTime.Now:yyyy-MM-dd HH-mm-ss}";

            string destination = Path.Combine(_backupRootPath, backupName);

            await CopyDirectoryAsync(_nightreignPath, destination);

            return new BackupInfo
            {
                Name = backupName,
                FullPath = destination,
                CreatedAt = DateTime.Now
            };
        }

        public async Task RestoreBackupAsync(BackupInfo backup)
        {
            if (!Directory.Exists(backup.FullPath))
            {
                throw new DirectoryNotFoundException(
                    "Selected backup no longer exists.");
            }

            if (Directory.Exists(_nightreignPath))
            {
                int version = GetNextVersion("RestoreV");

                string restoreName =
                    $"Nightreign - RestoreV{version} - {DateTime.Now:yyyy-MM-dd HH-mm-ss}";

                string restorePath = Path.Combine(_backupRootPath, restoreName);

                Directory.Move(_nightreignPath, restorePath);
            }

            await CopyDirectoryAsync(backup.FullPath, _nightreignPath);
        }

        public void DeleteBackup(BackupInfo backup)
        {
            if (Directory.Exists(backup.FullPath))
            {
                Directory.Delete(backup.FullPath, true);
            }
        }

        public void DeleteAllBackups()
        {
            foreach (string directory in Directory.GetDirectories(_backupRootPath))
            {
                Directory.Delete(directory, true);
            }
        }

        private void ValidateSaveDirectory()
        {
            if (!Directory.Exists(_nightreignPath))
            {
                throw new DirectoryNotFoundException(
                    "Nightreign save directory was not found.");
            }
        }

        private int GetNextVersion(string prefix)
        {
            return Directory
                .GetDirectories(_backupRootPath, $"Nightreign - {prefix}*")
                .Length + 1;
        }

        private static async Task CopyDirectoryAsync(
            string source,
            string destination)
        {
            await Task.Run(() =>
            {
                Directory.CreateDirectory(destination);

                foreach (string file in Directory.GetFiles(
                             source,
                             "*",
                             SearchOption.AllDirectories))
                {
                    string relativePath =
                        Path.GetRelativePath(source, file);

                    string destinationFile =
                        Path.Combine(destination, relativePath);

                    string? folder =
                        Path.GetDirectoryName(destinationFile);

                    if (!string.IsNullOrWhiteSpace(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    File.Copy(file, destinationFile, true);
                }
            });
        }
    }
}
