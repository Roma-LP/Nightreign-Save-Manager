using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightreignSaveManager.Models
{
    internal sealed class BackupInfo
    {
        public string Name { get; init; } = string.Empty;

        public string FullPath { get; init; } = string.Empty;

        public DateTime CreatedAt { get; init; }

        public override string ToString()
        {
            return Name;
        }
    }
}
