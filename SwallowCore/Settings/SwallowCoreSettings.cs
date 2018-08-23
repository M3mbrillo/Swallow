using Microsoft.Extensions.Configuration;
using SwallowCore.Settings.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SwallowCore.Settings
{
    public static class SwallowCoreSettings
    {
        private static SwallowCoreSettingContext context = new SwallowCoreSettingContext();

        public static UberApiSetting UberApiSetting => context.UberApiSetting;

        public static SwallowDatabaseSetting SwallowDatabase => context.SwallowDatabase;
    }


    internal class SwallowCoreSettingContext
    {
        private IConfigurationRoot root;

        public SwallowCoreSettingContext()
        {
            var configurationBuilder = new ConfigurationBuilder();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            this.root = configurationBuilder.Build();

            this.UberApiSetting = new UberApiSetting();
            this.SwallowDatabase = new SwallowDatabaseSetting();

            root.Bind("SwallowCoreSettings", this);
        }

        public UberApiSetting UberApiSetting { get; }

        public SwallowDatabaseSetting SwallowDatabase { get; }
    }
}
