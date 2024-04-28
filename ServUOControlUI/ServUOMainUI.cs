namespace ServUOControlUI
{
    public partial class ServUOMainUI : Form
    {
        private string ConfigFolder = string.Empty;

        public ServUOMainUI()
        {
            InitializeComponent();
        }

        private void ServUOMainUI_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.ServUOInfo.Default.ServUODir))
            {
                ServUODirBTN.Text = Properties.ServUOInfo.Default.ServUODir;

                ConfigFolder = Path.Combine(Properties.ServUOInfo.Default.ServUODir, "Config");

                LoadConfigFiles();
            }
        }

        private void LoadConfigFiles()
        {
            TryLoadFile(AccountsRTB, "Accounts.CFG");

            TryLoadFile(AutoRestartRTB, "AutoRestart.CFG");

            TryLoadFile(AutoSaveRTB, "AutoSave.CFG");

            TryLoadFile(ChampionsRTB, "Champions.CFG");

            TryLoadFile(ChatRTB, "Chat.CFG");

            TryLoadFile(CityLoyaltyRTB, "CityLoyalty.CFG");

            TryLoadFile(CityTradingRTB, "CityTrading.CFG");

            TryLoadFile(ClientRTB, "Client.CFG");

            TryLoadFile(DailyRaresRTB, "DailyRares.CFG");

            TryLoadFile(DataPathRTB, "DataPath.CFG");

            TryLoadFile(EmailRTB, "Email.CFG");

            TryLoadFile(ExpansionRTB, "Expansion.CFG");

            TryLoadFile(FactionsRTB, "Factions.CFG");

            TryLoadFile(GeneralRTB, "General.CFG");

            TryLoadFile(HonestyRTB, "Honesty.CFG");

            TryLoadFile(HousingRTB, "Housing.CFG");

            TryLoadFile(LootRTB, "Loot.CFG");

            TryLoadFile(PlayerCapsRTB, "PlayerCaps.CFG");

            TryLoadFile(ReportsRTB, "Reports.CFG");

            TryLoadFile(ServerRTB, "Server.CFG");

            TryLoadFile(ShadowGuardRTB, "ShadowGuard.CFG");

            TryLoadFile(SiegeRTB, "Siege.CFG");

            TryLoadFile(StaffRTB, "Staff.CFG");

            TryLoadFile(StoreRTB, "Store.CFG");

            TryLoadFile(TestCenterRTB, "TestCenter.CFG");

            TryLoadFile(TreasureMapsRTB, "TreasureMaps.CFG");

            TryLoadFile(VendorsRTB, "Vendors.CFG");

            TryLoadFile(VetRewardsRTB, "VetRewards.CFG");

            TryLoadFile(VvVRTB, "VvV.CFG");

            TryLoadFile(XmlSpawner2RTB, "XmlSpawner2.CFG");
        }

        private void TryLoadFile(RichTextBox rtb, string file)
        {
            try
            {
                if (File.Exists(Path.Combine(ConfigFolder, file)))
                {
                    rtb.LoadFile(Path.Combine(ConfigFolder, file), RichTextBoxStreamType.PlainText);

                    ServUOControlUtility.ApplyBoldFormatting(rtb);

                    ServUOControlUtility.AddRTB(rtb, file);
                }
            }
            catch (Exception ex)
            {
                ServUOControlUtility.SendError(ex.Message);
            }
        }

        private void ServUODirBTN_Click(object sender, EventArgs e)
        {
            string servUO_Dir = ServUOControlUtility.ShowFolderBrowserDialog();

            if (!string.IsNullOrEmpty(servUO_Dir))
            {
                ServUODirBTN.Text = servUO_Dir;

                Properties.ServUOInfo.Default.ServUODir = servUO_Dir;

                Properties.ServUOInfo.Default.Save();

                LoadConfigFiles();
            }
        }

        private void ServUOMainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.ServUOInfo.Default.ServUODir))
            {
                ServUOControlUtility.SaveFiles();
            }
        }

        private void CompileButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.ServUOInfo.Default.ServUODir))
            {
                if (ServUOControlUtility.IsAppRunning("Compile.WIN - Release"))
                {
                    ServUOControlUtility.SendMessageRunning("Compile.WIN - Release");
                }
                else
                {
                    ServUOControlUtility.RunProcess(Path.Combine(Properties.ServUOInfo.Default.ServUODir, "Compile.WIN - Release.bat"));
                }
            }
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.ServUOInfo.Default.ServUODir))
            {
                if (ServUOControlUtility.IsAppRunning("ServUO"))
                {
                    ServUOControlUtility.SendMessageRunning("ServUO");
                }
                else
                {
                    ServUOControlUtility.RunProcess(Path.Combine(Properties.ServUOInfo.Default.ServUODir, "ServUO.exe"));
                }
            }
        }

        // Resources
        private void UOButton_Click(object sender, EventArgs e)
        {
            ServUOControlUtility.RunProcess("https://uo.com/client-download/");
        }

        private void CUOButton_Click(object sender, EventArgs e)
        {
            ServUOControlUtility.RunProcess("https://www.classicuo.eu/");
        }

        private void UOFiddler_Click(object sender, EventArgs e)
        {
            ServUOControlUtility.RunProcess("https://www.uofiddler.polserver.com/");
        }

        private void CentredButton_Click(object sender, EventArgs e)
        {
            ServUOControlUtility.RunProcess("https://www.servuo.com/archive/centred-upload.1744/");
        }

        private void TutorialsButton_Click(object sender, EventArgs e)
        {
            ServUOControlUtility.RunProcess("https://www.servuo.com/archive/categories/tutorials.21/");
        }

        private void ResourcesButton_Click(object sender, EventArgs e)
        {
            ServUOControlUtility.RunProcess("https://www.servuo.com/archive/");
        }

        private void ContactButton_Click(object sender, EventArgs e)
        {
            ServUOControlUtility.RunProcess("https://www.servuo.com/members/wilson.12169/");
        }
    }
}
