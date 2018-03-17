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

namespace OnymojiAuto.Code.UI
{
    public partial class MainForm : Form
    {

        private UIEffects uiEffects = new UIEffects();

        private string currentTab;
        private string _pointDataSection;
        private string[] _pointIds;

        public MainForm()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            tabTasks.SelectedIndexChanged += tabTasks_SelectedIndexChanged;
            tabTasks.SelectedIndex = 0;
            dgvPoints.CellClick += dgvPoints_CellClick;
        }

        private void dgvPoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                default:
                    break;
            }
        }

        private IDisposable _supscription;
        //private bool _firstClick = true;

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

                    if (message == (int)MouseMessages.WM_LBUTTONUP)
                    {
                        if (currentTab == "tabParty")
                        {
                            var _color = PartyQuest.window.PixelGetColor(x, y,null);
                            string[] _data = { x.ToString(), y.ToString(), _color.ToString() };
                            ScriptHelper.setPointDataToConfig(PartyQuest.SCRIPT_NAME, currentRow.Cells["id"].Value.ToString(), _data);
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
    }
}
