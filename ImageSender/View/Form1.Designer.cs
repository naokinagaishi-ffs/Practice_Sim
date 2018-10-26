namespace Simulater.View
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buton_openFileDialog = new System.Windows.Forms.Button();
            this.comboBox_ImageSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox_SelectImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Half = new System.Windows.Forms.Button();
            this.btn_Whole = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.listBox_Log = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ファイルパス";
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Enabled = false;
            this.textBox_filePath.Location = new System.Drawing.Point(145, 22);
            this.textBox_filePath.Multiline = true;
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.Size = new System.Drawing.Size(208, 28);
            this.textBox_filePath.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buton_openFileDialog
            // 
            this.buton_openFileDialog.Location = new System.Drawing.Point(371, 25);
            this.buton_openFileDialog.Name = "buton_openFileDialog";
            this.buton_openFileDialog.Size = new System.Drawing.Size(49, 27);
            this.buton_openFileDialog.TabIndex = 2;
            this.buton_openFileDialog.Text = "・・・";
            this.buton_openFileDialog.UseVisualStyleBackColor = true;
            this.buton_openFileDialog.Click += new System.EventHandler(this.buton_openFileDialog_Click);
            // 
            // comboBox_ImageSize
            // 
            this.comboBox_ImageSize.FormattingEnabled = true;
            this.comboBox_ImageSize.Items.AddRange(new object[] {
            "8x10",
            "10 x14",
            "14x14",
            "14x17"});
            this.comboBox_ImageSize.Location = new System.Drawing.Point(154, 80);
            this.comboBox_ImageSize.Name = "comboBox_ImageSize";
            this.comboBox_ImageSize.Size = new System.Drawing.Size(199, 26);
            this.comboBox_ImageSize.TabIndex = 3;
            this.comboBox_ImageSize.Text = "横  x 縦 (inch)";
            this.comboBox_ImageSize.SelectedIndexChanged += new System.EventHandler(this.comboBox_ImageSize_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "画像サイズ";
            // 
            // pictureBox_SelectImage
            // 
            this.pictureBox_SelectImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox_SelectImage.Location = new System.Drawing.Point(402, 80);
            this.pictureBox_SelectImage.Name = "pictureBox_SelectImage";
            this.pictureBox_SelectImage.Size = new System.Drawing.Size(371, 383);
            this.pictureBox_SelectImage.TabIndex = 5;
            this.pictureBox_SelectImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "ログ";
            // 
            // btn_Half
            // 
            this.btn_Half.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Half.Location = new System.Drawing.Point(91, 149);
            this.btn_Half.Name = "btn_Half";
            this.btn_Half.Size = new System.Drawing.Size(75, 45);
            this.btn_Half.TabIndex = 8;
            this.btn_Half.Text = "半押";
            this.btn_Half.UseVisualStyleBackColor = false;
            this.btn_Half.Click += new System.EventHandler(this.btn_Half_Click);
            // 
            // btn_Whole
            // 
            this.btn_Whole.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Whole.Location = new System.Drawing.Point(226, 149);
            this.btn_Whole.Name = "btn_Whole";
            this.btn_Whole.Size = new System.Drawing.Size(75, 45);
            this.btn_Whole.TabIndex = 9;
            this.btn_Whole.Text = "全押";
            this.btn_Whole.UseVisualStyleBackColor = false;
            this.btn_Whole.Click += new System.EventHandler(this.btn_Whole_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Clear.Location = new System.Drawing.Point(90, 211);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 45);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "解除";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // listBox_Log
            // 
            this.listBox_Log.FormattingEnabled = true;
            this.listBox_Log.ItemHeight = 18;
            this.listBox_Log.Location = new System.Drawing.Point(43, 310);
            this.listBox_Log.Name = "listBox_Log";
            this.listBox_Log.Size = new System.Drawing.Size(328, 130);
            this.listBox_Log.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 489);
            this.Controls.Add(this.listBox_Log);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Whole);
            this.Controls.Add(this.btn_Half);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox_SelectImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_ImageSize);
            this.Controls.Add(this.buton_openFileDialog);
            this.Controls.Add(this.textBox_filePath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_filePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buton_openFileDialog;
        private System.Windows.Forms.ComboBox comboBox_ImageSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox_SelectImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Half;
        private System.Windows.Forms.Button btn_Whole;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.ListBox listBox_Log;
    }
}

