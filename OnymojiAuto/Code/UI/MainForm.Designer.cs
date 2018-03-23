namespace OnymojiAuto.Code.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.tabTasks = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReY = new System.Windows.Forms.TextBox();
            this.tbReX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRealY = new System.Windows.Forms.TextBox();
            this.tbRealX = new System.Windows.Forms.TextBox();
            this.btGenRePos = new System.Windows.Forms.Button();
            this.tabParty = new System.Windows.Forms.TabPage();
            this.tabSnake = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btDameSkills = new System.Windows.Forms.Button();
            this.btMasterSkills = new System.Windows.Forms.Button();
            this.btSpeedSkills = new System.Windows.Forms.Button();
            this.tabHunting = new System.Windows.Forms.TabPage();
            this.btClearMonster = new System.Windows.Forms.Button();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabTasks.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.tabSnake.SuspendLayout();
            this.tabHunting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btStart.Location = new System.Drawing.Point(30, 520);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(150, 30);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btStop.Location = new System.Drawing.Point(210, 520);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(150, 30);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = false;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.tabHome);
            this.tabTasks.Controls.Add(this.tabParty);
            this.tabTasks.Controls.Add(this.tabSnake);
            this.tabTasks.Controls.Add(this.tabHunting);
            this.tabTasks.Location = new System.Drawing.Point(1, 3);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.SelectedIndex = 0;
            this.tabTasks.Size = new System.Drawing.Size(380, 317);
            this.tabTasks.TabIndex = 6;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.label2);
            this.tabHome.Controls.Add(this.tbReY);
            this.tabHome.Controls.Add(this.tbReX);
            this.tabHome.Controls.Add(this.label1);
            this.tabHome.Controls.Add(this.tbRealY);
            this.tabHome.Controls.Add(this.tbRealX);
            this.tabHome.Controls.Add(this.btGenRePos);
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(372, 291);
            this.tabHome.TabIndex = 2;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Related";
            // 
            // tbReY
            // 
            this.tbReY.Location = new System.Drawing.Point(175, 44);
            this.tbReY.Name = "tbReY";
            this.tbReY.ReadOnly = true;
            this.tbReY.Size = new System.Drawing.Size(100, 20);
            this.tbReY.TabIndex = 5;
            // 
            // tbReX
            // 
            this.tbReX.Location = new System.Drawing.Point(68, 44);
            this.tbReX.Name = "tbReX";
            this.tbReX.ReadOnly = true;
            this.tbReX.Size = new System.Drawing.Size(100, 20);
            this.tbReX.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "RealCoor";
            // 
            // tbRealY
            // 
            this.tbRealY.Location = new System.Drawing.Point(174, 18);
            this.tbRealY.Name = "tbRealY";
            this.tbRealY.ReadOnly = true;
            this.tbRealY.Size = new System.Drawing.Size(100, 20);
            this.tbRealY.TabIndex = 2;
            // 
            // tbRealX
            // 
            this.tbRealX.Location = new System.Drawing.Point(68, 18);
            this.tbRealX.Name = "tbRealX";
            this.tbRealX.ReadOnly = true;
            this.tbRealX.Size = new System.Drawing.Size(100, 20);
            this.tbRealX.TabIndex = 1;
            // 
            // btGenRePos
            // 
            this.btGenRePos.Location = new System.Drawing.Point(280, 15);
            this.btGenRePos.Name = "btGenRePos";
            this.btGenRePos.Size = new System.Drawing.Size(75, 23);
            this.btGenRePos.TabIndex = 0;
            this.btGenRePos.Text = "Generate";
            this.btGenRePos.UseVisualStyleBackColor = true;
            this.btGenRePos.Click += new System.EventHandler(this.btGenRePos_Click);
            // 
            // tabParty
            // 
            this.tabParty.Location = new System.Drawing.Point(4, 22);
            this.tabParty.Name = "tabParty";
            this.tabParty.Padding = new System.Windows.Forms.Padding(3);
            this.tabParty.Size = new System.Drawing.Size(372, 291);
            this.tabParty.TabIndex = 3;
            this.tabParty.Text = "Party";
            this.tabParty.UseVisualStyleBackColor = true;
            // 
            // tabSnake
            // 
            this.tabSnake.Controls.Add(this.checkBox1);
            this.tabSnake.Controls.Add(this.btDameSkills);
            this.tabSnake.Controls.Add(this.btMasterSkills);
            this.tabSnake.Controls.Add(this.btSpeedSkills);
            this.tabSnake.Location = new System.Drawing.Point(4, 22);
            this.tabSnake.Name = "tabSnake";
            this.tabSnake.Padding = new System.Windows.Forms.Padding(3);
            this.tabSnake.Size = new System.Drawing.Size(372, 291);
            this.tabSnake.TabIndex = 4;
            this.tabSnake.Text = "Snake";
            this.tabSnake.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(106, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(107, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Turn Off when idl";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btDameSkills
            // 
            this.btDameSkills.Location = new System.Drawing.Point(187, 20);
            this.btDameSkills.Name = "btDameSkills";
            this.btDameSkills.Size = new System.Drawing.Size(75, 23);
            this.btDameSkills.TabIndex = 2;
            this.btDameSkills.Text = "Dame Skills";
            this.btDameSkills.UseVisualStyleBackColor = true;
            this.btDameSkills.Click += new System.EventHandler(this.btSkills_Click);
            // 
            // btMasterSkills
            // 
            this.btMasterSkills.Location = new System.Drawing.Point(106, 20);
            this.btMasterSkills.Name = "btMasterSkills";
            this.btMasterSkills.Size = new System.Drawing.Size(75, 23);
            this.btMasterSkills.TabIndex = 1;
            this.btMasterSkills.Text = "Master Skills";
            this.btMasterSkills.UseVisualStyleBackColor = true;
            this.btMasterSkills.Click += new System.EventHandler(this.btSkills_Click);
            // 
            // btSpeedSkills
            // 
            this.btSpeedSkills.Location = new System.Drawing.Point(25, 20);
            this.btSpeedSkills.Name = "btSpeedSkills";
            this.btSpeedSkills.Size = new System.Drawing.Size(75, 23);
            this.btSpeedSkills.TabIndex = 0;
            this.btSpeedSkills.Text = "Speed Skills";
            this.btSpeedSkills.UseVisualStyleBackColor = true;
            this.btSpeedSkills.Click += new System.EventHandler(this.btSkills_Click);
            // 
            // tabHunting
            // 
            this.tabHunting.Controls.Add(this.btClearMonster);
            this.tabHunting.Location = new System.Drawing.Point(4, 22);
            this.tabHunting.Name = "tabHunting";
            this.tabHunting.Padding = new System.Windows.Forms.Padding(3);
            this.tabHunting.Size = new System.Drawing.Size(372, 291);
            this.tabHunting.TabIndex = 5;
            this.tabHunting.Text = "Hunting";
            this.tabHunting.UseVisualStyleBackColor = true;
            // 
            // btClearMonster
            // 
            this.btClearMonster.Location = new System.Drawing.Point(47, 42);
            this.btClearMonster.Name = "btClearMonster";
            this.btClearMonster.Size = new System.Drawing.Size(168, 23);
            this.btClearMonster.TabIndex = 0;
            this.btClearMonster.Text = "Clear Monster";
            this.btClearMonster.UseVisualStyleBackColor = true;
            this.btClearMonster.Click += new System.EventHandler(this.btClearMonster_Click);
            // 
            // dgvPoints
            // 
            this.dgvPoints.AllowUserToAddRows = false;
            this.dgvPoints.AllowUserToDeleteRows = false;
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.color,
            this.action});
            this.dgvPoints.Location = new System.Drawing.Point(1, 322);
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.ReadOnly = true;
            this.dgvPoints.Size = new System.Drawing.Size(380, 159);
            this.dgvPoints.TabIndex = 2;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.FillWeight = 230.4274F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // color
            // 
            this.color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.color.FillWeight = 66.36618F;
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // action
            // 
            this.action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.action.FillWeight = 75.61619F;
            this.action.HeaderText = "Action";
            this.action.Name = "action";
            this.action.ReadOnly = true;
            this.action.Text = "Set";
            this.action.ToolTipText = "Set";
            this.action.UseColumnTextForButtonValue = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(380, 557);
            this.Controls.Add(this.tabTasks);
            this.Controls.Add(this.dgvPoints);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Onymoji 0.0.7";
            this.tabTasks.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.tabSnake.ResumeLayout(false);
            this.tabSnake.PerformLayout();
            this.tabHunting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
        private System.Windows.Forms.TabControl tabTasks;
        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewButtonColumn action;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabParty;
        private System.Windows.Forms.TabPage tabSnake;
        private System.Windows.Forms.Button btDameSkills;
        private System.Windows.Forms.Button btMasterSkills;
        private System.Windows.Forms.Button btSpeedSkills;
        private System.Windows.Forms.TextBox tbRealY;
        private System.Windows.Forms.TextBox tbRealX;
        private System.Windows.Forms.Button btGenRePos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReY;
        private System.Windows.Forms.TextBox tbReX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabHunting;
        private System.Windows.Forms.Button btClearMonster;
    }
}