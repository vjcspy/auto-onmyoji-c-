using OnymojiAuto.Code.Hooks;
using OnymojiAuto.Code.Model;
using OnymojiAuto.Code.Sample;
using OnymojiAuto.Code.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OnymojiAuto.Code.Hooks.HookHelper;
using AutoIt;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Media;
using System.Diagnostics;
using Newtonsoft.Json;
using OnymojiAuto.Code.Services;

namespace OnymojiAuto.Code.UI
{
    public partial class MainForm : Form
    {

        private UIEffects uiEffects = new UIEffects();

        private string currentTab;
        private string _pointDataSection;
        private string[] _pointIds;

        private IObservable<long> _runingTaskInteval = Observable.Interval(TimeSpan.FromSeconds(1));
        private IDisposable _runingTaskSubscription;
        private IDisposable _checkIdlSubscription;

        private static SoundPlayer soundPlayer;

        public MainForm()
        {
            InitializeComponent();
            InitializeControl();
            soundPlayer = new SoundPlayer(@"c:\Users\Khoi\Music\pacman_death.wav");
        }

        private void InitializeControl()
        {
            tabTasks.SelectedIndexChanged += tabTasks_SelectedIndexChanged;
            tabTasks.SelectedIndex = 0;
            dgvPoints.CellClick += dgvPoints_CellClick;
            btStop.Enabled = false;
            btStart.Enabled = true;
        }

        // Change Tab
        private void tabTasks_SelectedIndexChanged(Object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;

            switch (tc.SelectedTab.Name)
            {
                case "tabHome":
                    break;
                case "tabParty":
                    currentTab = "tabParty";
                    _pointDataSection = PartyQuest.SCRIPT_NAME;
                    _pointIds = PartyQuest.PartyQuestPoints;
                    InitPointData();
                    break;
                case "tabSnake":
                    currentTab = "tabSnake";
                    _pointDataSection = Snake.SCRIPT_NAME;
                    _pointIds = Snake.Points;
                    InitPointData();
                    initStateButton();
                    break;
                case "tabHunting":
                    currentTab = "tabHunting";
                    _pointDataSection = Hunter.SCRIPT_NAME;
                    _pointIds = Hunter.Points;
                    InitPointData();
                    break;
                default:
                    break;
            }
        }

        private IDisposable _supscription;
        //private bool _firstClick = true;

        // Set point data in datagridview
        private void dgvPoints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var pointsGrid = (DataGridView)sender;
            var currentRow = pointsGrid.Rows.Cast<DataGridViewRow>().Where(r => r.Index.Equals(e.RowIndex))
                .First();

            if (e.ColumnIndex == dgvPoints.Columns["action"].Index)
            {



                if (_supscription != null)
                {
                    uiEffects.stopMouseHook();
                    _supscription.Dispose();
                }

                uiEffects.installMouseHoook();

                _supscription = uiEffects.MouseActions
                    .Subscribe((ob =>
                {
                    AutoItX.ToolTip("Click on point");

                    var t = ob.GetType();
                    var pX = t.GetProperty("x");
                    var pY = t.GetProperty("y");
                    var pMouseMessage = t.GetProperty("mouseMessage");
                    int x = Convert.ToInt32(pX.GetValue(ob));
                    int y = Convert.ToInt32(pY.GetValue(ob));
                    int message = Convert.ToInt32(pMouseMessage.GetValue(ob));

                    if (message == (int)MouseMessages.WM_RBUTTONUP)
                    {
                        if (currentTab == "tabParty")
                        {
                            var _relatedPoint = ScriptHelper.window.getPositionRelatedWindow(x, y);
                            var _color = ScriptHelper.window.getColorOfPixelByRelatedPos(_relatedPoint[0], _relatedPoint[1]);
                            string[] _data = { _relatedPoint[0].ToString(), _relatedPoint[1].ToString(), _color.ToString() };
                            ScriptHelper.setPointDataToConfig(PartyQuest.SCRIPT_NAME, currentRow.Cells["id"].Value.ToString(), _data);
                        }

                        if (currentTab == "tabSnake")
                        {
                            var _relatedPoint = ScriptHelper.window.getPositionRelatedWindow(x, y);
                            var _color = ScriptHelper.window.getColorOfPixelByRelatedPos(_relatedPoint[0], _relatedPoint[1]);
                            string[] _data = { _relatedPoint[0].ToString(), _relatedPoint[1].ToString(), _color.ToString() };
                            ScriptHelper.setPointDataToConfig(Snake.SCRIPT_NAME, currentRow.Cells["id"].Value.ToString(), _data);
                        }

                        if (currentTab == "tabHunting")
                        {

                            var id = currentRow.Cells["id"].Value.ToString();
                            if (id.IndexOf("MON") > -1)
                            {
                                Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                                Graphics g = Graphics.FromImage(screenCapture);

                                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                                 Screen.PrimaryScreen.Bounds.Y,
                                                 0, 0,
                                                 screenCapture.Size,
                                                 CopyPixelOperation.SourceCopy);

                                var _data = new List<object>();
                                for (var k = 0; k < 10; k++)
                                {
                                    var _color = screenCapture.GetPixel(x + k, y);
                                    _data.Add(new { x = k, y, color = Color.Black.ToArgb().ToString() });
                                }

                                ScriptHelper.setDataToConfig(Hunter.SCRIPT_NAME, id, JsonConvert.SerializeObject(_data));
                            }
                            else
                            {
                                var _relatedPoint = ScriptHelper.window.getPositionRelatedWindow(x, y);
                                var _color = ScriptHelper.window.getColorOfPixelByRelatedPos(_relatedPoint[0], _relatedPoint[1]);
                                string[] _data = { _relatedPoint[0].ToString(), _relatedPoint[1].ToString(), _color.ToString() };
                                ScriptHelper.setPointDataToConfig(Hunter.SCRIPT_NAME, currentRow.Cells["id"].Value.ToString(), _data);
                            }
                        }

                        uiEffects.stopMouseHook();
                        _supscription.Dispose();
                        _supscription = null;
                        AutoItX.ToolTip(String.Empty);
                        InitPointData();
                    }
                }));
            }
        }

        // Initilize point data in datagridview
        private void InitPointData()
        {
            dgvPoints.Rows.Clear();
            List<string[]> points = new List<string[]>();

            _pointIds.ToList().ForEach((x =>
            {
                var point = ScriptHelper.getPointColorFromConfig(_pointDataSection, x);
                string[] data = { point.id, point.color.ToString() };

                dgvPoints.Rows.Add(data);
            }));
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            btStop_Click(null, null);
            btStop.Enabled = true;
            btStart.Enabled = false;

            _runingTaskSubscription = _runingTaskInteval.Subscribe((x =>
            {
                try
                {
                    if (ScriptHelper._checkInterruptAuto > 3)
                    {
                        btStop_Click(null, null);
                        soundPlayer.PlayLooping(); // can also use soundPlayer.PlaySync()
                        return;
                    }

                    switch (currentTab)
                    {
                        case "tabParty":
                            PartyQuest.Run();
                            break;
                        case "tabSnake":
                            Snake.run();
                            break;
                        case "tabHunting":
                            Hunter.run(); ;
                            break;

                    }
                }
                catch
                {

                }

            }));

            _checkIdlSubscription = ScriptHelper.checkIdlSubject
                .Throttle(TimeSpan.FromSeconds(150))
                .Subscribe((data =>
                {
                    soundPlayer.PlayLooping(); // can also use soundPlayer.PlaySync()

                    //var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                    //psi.CreateNoWindow = true;
                    //psi.UseShellExecute = false;
                    //Process.Start(psi);
                }));

        }

        private void btStop_Click(object sender, EventArgs e)
        {
            btStop.Enabled = false;
            btStart.Enabled = true;
            if (_runingTaskSubscription != null)
            {
                _runingTaskSubscription.Dispose();
                _runingTaskSubscription = null;
            }

            if (_checkIdlSubscription != null)
            {
                _checkIdlSubscription.Dispose();
                _checkIdlSubscription = null;
            }

            soundPlayer.Stop();
        }

        private void btSkills_Click(object sender, EventArgs e)
        {
            var _bt = (Button)sender;
            switch (_bt.Name)
            {
                case "btSpeedSkills":
                    Snake.saveSkillsData(Snake.SKILLS_SPEED);
                    break;
                case "btMasterSkills":
                    Snake.saveSkillsData(Snake.SKILLS_MASTER);
                    break;
                case "btDameSkills":
                    Snake.saveSkillsData(Snake.SKILLS_DAMAGE);
                    break;
            }

            initStateButton();
        }

        private void initStateButton()
        {
            if (Snake.isExistedDataSkill(Snake.SKILLS_MASTER))
            {
                btMasterSkills.BackColor = Color.Green;
            }
            else
            {
                btMasterSkills.BackColor = Color.Red;
            }

            if (Snake.isExistedDataSkill(Snake.SKILLS_DAMAGE))
            {
                btDameSkills.BackColor = Color.Green;
            }
            else
            {
                btDameSkills.BackColor = Color.Red;
            }

            if (Snake.isExistedDataSkill(Snake.SKILLS_SPEED))
            {
                btSpeedSkills.BackColor = Color.Green;
            }
            else
            {
                btSpeedSkills.BackColor = Color.Red;
            }
        }

        private void btGenRePos_Click(object sender, EventArgs e)
        {
            if (_supscription != null)
            {
                uiEffects.stopMouseHook();
                _supscription.Dispose();
            }

            uiEffects.installMouseHoook();

            _supscription = uiEffects.MouseActions
                .Subscribe((ob =>
                {
                    AutoItX.ToolTip("Click on point");

                    var t = ob.GetType();
                    var pX = t.GetProperty("x");
                    var pY = t.GetProperty("y");
                    var pMouseMessage = t.GetProperty("mouseMessage");
                    int x = Convert.ToInt32(pX.GetValue(ob));
                    int y = Convert.ToInt32(pY.GetValue(ob));
                    int message = Convert.ToInt32(pMouseMessage.GetValue(ob));

                    if (message == (int)MouseMessages.WM_RBUTTONUP)
                    {
                        var _relatedPoint = ScriptHelper.window.getPositionRelatedWindow(x, y);
                        var _color = ScriptHelper.window.getColorOfPixelByRelatedPos(_relatedPoint[0], _relatedPoint[1]);
                        string[] _data = { _relatedPoint[0].ToString(), _relatedPoint[1].ToString(), _color.ToString() };

                        tbReX.Text = _relatedPoint[0].ToString();
                        tbReY.Text = _relatedPoint[1].ToString();

                        tbRealX.Text = x.ToString();
                        tbRealY.Text = y.ToString();

                        uiEffects.stopMouseHook();
                        _supscription.Dispose();
                        _supscription = null;
                        AutoItX.ToolTip(String.Empty);
                    }
                }));
        }

        private void btClearMonster_Click(object sender, EventArgs e)
        {
            ConfigurationService.clearKey(Hunter.SCRIPT_NAME, Hunter.MONSTER_1);
            ConfigurationService.clearKey(Hunter.SCRIPT_NAME, Hunter.MONSTER_2);
            ConfigurationService.clearKey(Hunter.SCRIPT_NAME, Hunter.MONSTER_3);
            ConfigurationService.clearKey(Hunter.SCRIPT_NAME, Hunter.MONSTER_4);
            ConfigurationService.clearKey(Hunter.SCRIPT_NAME, Hunter.MONSTER_5);
        }
    }
}
