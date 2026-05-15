using NightreignSaveManager.Models;
using NightreignSaveManager.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NightreignSaveManager
{
    public partial class MainForm : Form
    {
        private const string RepositoryUrl = "https://github.com/Roma-LP";

        private readonly BackupService _backupService;

        public MainForm()
        {
            InitializeComponent();

            _backupService = new BackupService();

            LoadBackups();
        }

        private async void bttn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Creating backup...");

                BackupInfo backup =
                    await _backupService.CreateBackupAsync();

                Log($"Backup created: {backup.Name}");

                LoadBackups();
            }
            catch (Exception ex)
            {
                Log($"ERROR: {ex.Message}");
            }
        }

        private async void bttn_restoreSaves_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBackups.SelectedItem is not BackupInfo backup)
                {
                    Log("No backup selected.");
                    return;
                }

                Log($"Restoring backup: {backup.Name}");

                await _backupService.RestoreBackupAsync(backup);

                Log("Restore completed.");
            }
            catch (Exception ex)
            {
                Log($"ERROR: {ex.Message}");
            }
        }

        private void bttn_deleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBackups.SelectedItem is not BackupInfo backup)
                {
                    Log("No backup selected.");
                    return;
                }

                _backupService.DeleteBackup(backup);

                Log($"Deleted backup: {backup.Name}");

                LoadBackups();
            }
            catch (Exception ex)
            {
                Log($"ERROR: {ex.Message}");
            }
        }

        private void bttn_deleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete all backups?",
                    "Confirm deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    Log("Delete all operation cancelled.");
                    return;
                }

                _backupService.DeleteAllBackups();

                Log("All backups deleted.");

                LoadBackups();
            }
            catch (Exception ex)
            {
                Log($"ERROR: {ex.Message}");
            }
        }

        private void LoadBackups()
        {
            IReadOnlyList<BackupInfo> backups =
                _backupService.GetBackups();

            listBackups.DataSource = backups;

            if (backups.Count > 0)
            {
                listBackups.SelectedIndex = 0;
            }
        }

        private void Log(string message)
        {
            string line =
                $"[{DateTime.Now:HH:mm:ss}] {message}";

            txtLogs.AppendText(line + Environment.NewLine);

            txtLogs.SelectionStart = txtLogs.Text.Length;

            txtLogs.ScrollToCaret();
        }

        private void MenuItem_gitRepository_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = RepositoryUrl,
                    UseShellExecute = true
                });

                Log("GitHub repository opened.");
            }
            catch (Exception ex)
            {
                Log($"ERROR: {ex.Message}");
            }
        }

        private void MenuItem_clearLogs_Click(object sender, EventArgs e)
        {
            txtLogs.Clear();
        }

        private void MenuItem_openBackupFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _backupService.BackupRootPath,
                    UseShellExecute = true
                });

                Log("Backup folder opened.");
            }
            catch (Exception ex)
            {
                Log($"ERROR: {ex.Message}");
            }
        }
    }
}