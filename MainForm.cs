using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NightreignSaveManager
{
    public partial class MainForm : Form
    {
        private readonly string appDataPath;
        private readonly string nightreignPath;
        private readonly string backupRootPath;

        private string? cachedLatestSave;

        public MainForm()
        {
            InitializeComponent();

            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            nightreignPath = Path.Combine(appDataPath, "Nightreign");

            backupRootPath = Path.Combine(appDataPath, "NightreignBackups");

            Directory.CreateDirectory(backupRootPath);
        }

        private async void bttn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(nightreignPath))
                {
                    MessageBox.Show("Папка сохранений Nightreign не найдена.");
                    return;
                }

                int nextVersion = GetNextSaveVersion();

                string backupFolderName =
                    $"Nightreign - SaveV{nextVersion} - {DateTime.Now:yyyy-MM-dd HH-mm-ss}";

                string backupPath = Path.Combine(backupRootPath, backupFolderName);

                await CopyDirectoryAsync(nightreignPath, backupPath);

                cachedLatestSave = backupPath;

                MessageBox.Show($"Backup создан:\n{backupFolderName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка backup:\n{ex.Message}");
            }
        }

        private async void bttn_restoreSaves_Click(object sender, EventArgs e)
        {
            try
            {
                string? latestBackup = cachedLatestSave;

                if (string.IsNullOrWhiteSpace(latestBackup) ||
                    !Directory.Exists(latestBackup))
                {
                    latestBackup = FindLatestBackup();
                }

                if (latestBackup == null)
                {
                    MessageBox.Show("Backup не найден.");
                    return;
                }

                if (Directory.Exists(nightreignPath))
                {
                    int restoreVersion = GetNextRestoreVersion();

                    string restoreFolderName =
                        $"Nightreign - RestoreV{restoreVersion} - {DateTime.Now:yyyy-MM-dd HH-mm-ss}";

                    string restorePath = Path.Combine(
                        backupRootPath,
                        restoreFolderName);

                    Directory.Move(nightreignPath, restorePath);
                }

                await CopyDirectoryAsync(latestBackup, nightreignPath);

                MessageBox.Show("Сохранение восстановлено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка восстановления:\n{ex.Message}");
            }
        }

        private int GetNextSaveVersion()
        {
            var dirs = Directory.GetDirectories(backupRootPath, "Nightreign - SaveV*");

            return dirs.Length + 1;
        }

        private int GetNextRestoreVersion()
        {
            var dirs = Directory.GetDirectories(backupRootPath, "Nightreign - RestoreV*");

            return dirs.Length + 1;
        }

        private string? FindLatestBackup()
        {
            var latest = Directory
                .GetDirectories(backupRootPath, "Nightreign - SaveV*")
                .OrderByDescending(d => Directory.GetCreationTime(d))
                .FirstOrDefault();

            cachedLatestSave = latest;

            return latest;
        }

        private async Task CopyDirectoryAsync(string sourceDir, string destinationDir)
        {
            await Task.Run(() =>
            {
                Directory.CreateDirectory(destinationDir);

                foreach (string file in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
                {
                    string relativePath = Path.GetRelativePath(sourceDir, file);

                    string destinationFile = Path.Combine(destinationDir, relativePath);

                    string? destinationFolder = Path.GetDirectoryName(destinationFile);

                    if (!string.IsNullOrEmpty(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    File.Copy(file, destinationFile, true);
                }
            });
        }
    }
}