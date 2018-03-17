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
            this.tabParty = new System.Windows.Forms.TabPage();
            this.tabSnake = new System.Windows.Forms.TabPage();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabTasks.SuspendLayout();
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
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.tabHome);
            this.tabTasks.Controls.Add(this.tabParty);
            this.tabTasks.Controls.Add(this.tabSnake);
            this.tabTasks.Location = new System.Drawing.Point(1, 3);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.SelectedIndex = 0;
            this.tabTasks.Size = new System.Drawing.Size(380, 317);
            this.tabTasks.TabIndex = 6;
            // 
            // tabHome
            // 
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(372, 291);
            this.tabHome.TabIndex = 2;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
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
            this.tabSnake.Location = new System.Drawing.Point(4, 22);
            this.tabSnake.Name = "tabSnake";
            this.tabSnake.Padding = new System.Windows.Forms.Padding(3);
            this.tabSnake.Size = new System.Drawing.Size(372, 291);
            this.tabSnake.TabIndex = 4;
            this.tabSnake.Text = "Snake";
            this.tabSnake.UseVisualStyleBackColor = true;
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
            this.dgvPoints.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPoints_CellContentClick);
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
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(OnymojiAuto.Code.UI.MainForm);
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
            this.Text = "MainForm";
            this.tabTasks.ResumeLayout(false);
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
    }
}