﻿using System;
using System.Diagnostics;

namespace FreeLauncher.Forms
{
    public partial class UpdateForm : Telerik.WinControls.UI.RadForm
    {
        private Configuration _configuration { get; }

        public UpdateForm(GitHubRelease release, Configuration configuration)
        {
            _configuration = configuration;
            InitializeComponent();
            LoadLocalization();
            autocheckCheckBox.Checked = _configuration.ApplicationConfiguration.CheckLauncherUpdates;
            Text = $"Found update: {release.Name}";
            changelogBox.Text = $"{release.Description}";
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Process.Start((supportCheckBox.Checked ? "https://github.com/Mc-Turk/Launcher/releases/" : string.Empty));
        }

        private void LoadLocalization()
        {
            ApplicationLocalization localization = _configuration.Localization;

            cancelButton.Text = localization.Cancel;
            supportCheckBox.Text = localization.SupportDeveloper;
            autocheckCheckBox.Text = localization.CheckUpdatesCheckBox;
            goButton.Text = localization.GoToGitHub;
        }
    }
}
