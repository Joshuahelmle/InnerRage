using System;
using System.IO;
using InnerRage.Core.Utilities;
using Styx.Helpers;

namespace InnerRage.Core.Managers
{
    internal class GlobalSettings : Settings
    {
        public GlobalSettings()
            : base(Path.Combine(CharacterSettingsDirectory, "InnerRage-Global.xml"))
        {
        }

        [Setting, DefaultValue("InnerRage-Raid")]
        public string LastUsedProfile { get; set; }

        public static string GetFullPathToProfile(string profileName)
        {
            if (profileName.Contains(".xml"))
                return Path.Combine(CharacterSettingsDirectory, "InnerRage", string.Format("{0}", profileName));
            return Path.Combine(CharacterSettingsDirectory, "InnerRage", string.Format("{0}.xml", profileName));
        }

        public void Init()
        {
            // Determine if the Preset settings files exist for the routine //
            var presetsDirectory = @"Routines\InnerRage\Presets";
            if (!Directory.Exists(presetsDirectory))
                throw new Exception("Presets directory is missing!");

            // Determine if the Preset settings files exist for the current character //
            var characterSettingsDirectory = Path.Combine(CharacterSettingsDirectory, "InnerRage");
            if (!Directory.Exists(characterSettingsDirectory))
            {
                Directory.CreateDirectory(characterSettingsDirectory);
                Log.Diagnostics("Character Settings Directory Established... loading default presets.");

                // Copy the presets file to the character settings directory
                var presetFiles = Directory.GetFiles(presetsDirectory, "*.xml");
                foreach (var file in presetFiles)
                {
                    File.Copy(file, Path.Combine(characterSettingsDirectory, Path.GetFileName(file)));
                }

                Log.Diagnostics(string.Format("...Finished copying {0} preset files", presetFiles.Length));
            }
        }

        #region singletons

        private static GlobalSettings _singletonInstance;


        public static GlobalSettings Instance
        {
            get { return _singletonInstance ?? (_singletonInstance = new GlobalSettings()); }
        }

        #endregion
    }
}