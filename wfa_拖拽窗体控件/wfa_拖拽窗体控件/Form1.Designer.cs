namespace zsbApps
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSetDrag = new System.Windows.Forms.Button();
            this.btnSaveDrag = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSaveDragSource = new System.Windows.Forms.Button();
            this.btnLoadSet = new System.Windows.Forms.Button();
            this.btnLoadDragSource = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveControlsInfo = new System.Windows.Forms.Button();
            this.btnCloseDrag = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 21);
            this.textBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(222, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(332, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // btnSetDrag
            // 
            this.btnSetDrag.Location = new System.Drawing.Point(189, 307);
            this.btnSetDrag.Name = "btnSetDrag";
            this.btnSetDrag.Size = new System.Drawing.Size(75, 23);
            this.btnSetDrag.TabIndex = 4;
            this.btnSetDrag.Text = "开启设置";
            this.btnSetDrag.UseVisualStyleBackColor = true;
            this.btnSetDrag.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnSaveDrag
            // 
            this.btnSaveDrag.Location = new System.Drawing.Point(285, 307);
            this.btnSaveDrag.Name = "btnSaveDrag";
            this.btnSaveDrag.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDrag.TabIndex = 5;
            this.btnSaveDrag.Text = "保存";
            this.btnSaveDrag.UseVisualStyleBackColor = true;
            this.btnSaveDrag.Click += new System.EventHandler(this.btnSaveDrag_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(332, 107);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 21);
            this.textBox2.TabIndex = 6;
            // 
            // btnSaveDragSource
            // 
            this.btnSaveDragSource.Location = new System.Drawing.Point(162, 401);
            this.btnSaveDragSource.Name = "btnSaveDragSource";
            this.btnSaveDragSource.Size = new System.Drawing.Size(119, 23);
            this.btnSaveDragSource.TabIndex = 8;
            this.btnSaveDragSource.Text = "设为还原点";
            this.btnSaveDragSource.UseVisualStyleBackColor = true;
            this.btnSaveDragSource.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadSet
            // 
            this.btnLoadSet.Location = new System.Drawing.Point(189, 353);
            this.btnLoadSet.Name = "btnLoadSet";
            this.btnLoadSet.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSet.TabIndex = 7;
            this.btnLoadSet.Text = "加载设置";
            this.btnLoadSet.UseVisualStyleBackColor = true;
            this.btnLoadSet.Click += new System.EventHandler(this.btnLoadSet_Click);
            // 
            // btnLoadDragSource
            // 
            this.btnLoadDragSource.Location = new System.Drawing.Point(296, 401);
            this.btnLoadDragSource.Name = "btnLoadDragSource";
            this.btnLoadDragSource.Size = new System.Drawing.Size(91, 23);
            this.btnLoadDragSource.TabIndex = 9;
            this.btnLoadDragSource.Text = "加载还原点";
            this.btnLoadDragSource.UseVisualStyleBackColor = true;
            this.btnLoadDragSource.Click += new System.EventHandler(this.btnLoadDragSource_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(510, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 332);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(166, 199);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(95, 20);
            this.comboBox2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(166, 48);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 21);
            this.textBox3.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // btnSaveControlsInfo
            // 
            this.btnSaveControlsInfo.Location = new System.Drawing.Point(56, 224);
            this.btnSaveControlsInfo.Name = "btnSaveControlsInfo";
            this.btnSaveControlsInfo.Size = new System.Drawing.Size(92, 23);
            this.btnSaveControlsInfo.TabIndex = 11;
            this.btnSaveControlsInfo.Text = "保存控件列表";
            this.btnSaveControlsInfo.UseVisualStyleBackColor = true;
            this.btnSaveControlsInfo.Click += new System.EventHandler(this.btnSaveControlsInfo_Click);
            // 
            // btnCloseDrag
            // 
            this.btnCloseDrag.Location = new System.Drawing.Point(382, 307);
            this.btnCloseDrag.Name = "btnCloseDrag";
            this.btnCloseDrag.Size = new System.Drawing.Size(75, 23);
            this.btnCloseDrag.TabIndex = 12;
            this.btnCloseDrag.Text = "关闭设置";
            this.btnCloseDrag.UseVisualStyleBackColor = true;
            this.btnCloseDrag.Click += new System.EventHandler(this.btnCloseDrag_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 460);
            this.Controls.Add(this.btnCloseDrag);
            this.Controls.Add(this.btnSaveControlsInfo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnLoadDragSource);
            this.Controls.Add(this.btnSaveDragSource);
            this.Controls.Add(this.btnLoadSet);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnSaveDrag);
            this.Controls.Add(this.btnSetDrag);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSetDrag;
        private System.Windows.Forms.Button btnSaveDrag;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSaveDragSource;
        private System.Windows.Forms.Button btnLoadSet;
        private System.Windows.Forms.Button btnLoadDragSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSaveControlsInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseDrag;
    }
}

