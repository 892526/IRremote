namespace USB_IR_ModelCode
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.send_btn = new System.Windows.Forms.Button();
            this.send_ex_btn = new System.Windows.Forms.Button();
            this.send_aeha_btn = new System.Windows.Forms.Button();
            this.send_nec_btn = new System.Windows.Forms.Button();
            this.send_sony_btn = new System.Windows.Forms.Button();
            this.send_mitsubishi_btn = new System.Windows.Forms.Button();
            this.send_ex_byte_btn = new System.Windows.Forms.Button();
            this.txtbx_byte_data = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_get_ir_code_size = new System.Windows.Forms.Label();
            this.btn_get_ir_code_send = new System.Windows.Forms.Button();
            this.btn_ir_code_get = new System.Windows.Forms.Button();
            this.btn_ir_code_rec_stop = new System.Windows.Forms.Button();
            this.btn_ir_code_rec_start = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxManualInput = new System.Windows.Forms.CheckBox();
            this.labelModelCode = new System.Windows.Forms.Label();
            this.textBoxModelCode = new System.Windows.Forms.TextBox();
            this.labelIRData = new System.Windows.Forms.Label();
            this.textBoxIRData = new System.Windows.Forms.TextBox();
            this.modelListBox = new System.Windows.Forms.ComboBox();
            this.labelModelSelect = new System.Windows.Forms.Label();
            this.send_model_code_btn = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(20, 18);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(200, 23);
            this.send_btn.TabIndex = 0;
            this.send_btn.Text = "赤外線コード送信 [テスト]";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // send_ex_btn
            // 
            this.send_ex_btn.Location = new System.Drawing.Point(246, 18);
            this.send_ex_btn.Name = "send_ex_btn";
            this.send_ex_btn.Size = new System.Drawing.Size(200, 23);
            this.send_ex_btn.TabIndex = 1;
            this.send_ex_btn.Text = "赤外線コード 送信 [データ版]";
            this.send_ex_btn.UseVisualStyleBackColor = true;
            this.send_ex_btn.Click += new System.EventHandler(this.send_ex_btn_Click);
            // 
            // send_aeha_btn
            // 
            this.send_aeha_btn.Location = new System.Drawing.Point(20, 94);
            this.send_aeha_btn.Name = "send_aeha_btn";
            this.send_aeha_btn.Size = new System.Drawing.Size(200, 23);
            this.send_aeha_btn.TabIndex = 2;
            this.send_aeha_btn.Text = "赤外線コード送信 [家電協]";
            this.send_aeha_btn.UseVisualStyleBackColor = true;
            this.send_aeha_btn.Click += new System.EventHandler(this.send_aeha_btn_Click);
            // 
            // send_nec_btn
            // 
            this.send_nec_btn.Location = new System.Drawing.Point(246, 94);
            this.send_nec_btn.Name = "send_nec_btn";
            this.send_nec_btn.Size = new System.Drawing.Size(200, 23);
            this.send_nec_btn.TabIndex = 3;
            this.send_nec_btn.Text = "赤外線コード送信 [NEC]";
            this.send_nec_btn.UseVisualStyleBackColor = true;
            this.send_nec_btn.Click += new System.EventHandler(this.send_nec_btn_Click);
            // 
            // send_sony_btn
            // 
            this.send_sony_btn.Location = new System.Drawing.Point(20, 127);
            this.send_sony_btn.Name = "send_sony_btn";
            this.send_sony_btn.Size = new System.Drawing.Size(200, 23);
            this.send_sony_btn.TabIndex = 4;
            this.send_sony_btn.Text = "赤外線コード送信 [SONY]";
            this.send_sony_btn.UseVisualStyleBackColor = true;
            this.send_sony_btn.Click += new System.EventHandler(this.send_sony_btn_Click);
            // 
            // send_mitsubishi_btn
            // 
            this.send_mitsubishi_btn.Location = new System.Drawing.Point(246, 127);
            this.send_mitsubishi_btn.Name = "send_mitsubishi_btn";
            this.send_mitsubishi_btn.Size = new System.Drawing.Size(200, 23);
            this.send_mitsubishi_btn.TabIndex = 5;
            this.send_mitsubishi_btn.Text = "赤外線コード送信 [MITSUBISHI]";
            this.send_mitsubishi_btn.UseVisualStyleBackColor = true;
            this.send_mitsubishi_btn.Click += new System.EventHandler(this.send_mitsubishi_btn_Click);
            // 
            // send_ex_byte_btn
            // 
            this.send_ex_byte_btn.Location = new System.Drawing.Point(20, 47);
            this.send_ex_byte_btn.Name = "send_ex_byte_btn";
            this.send_ex_byte_btn.Size = new System.Drawing.Size(200, 23);
            this.send_ex_byte_btn.TabIndex = 6;
            this.send_ex_byte_btn.Text = "赤外線コード 送信 [バイトデータ版]";
            this.send_ex_byte_btn.UseVisualStyleBackColor = true;
            this.send_ex_byte_btn.Click += new System.EventHandler(this.send_ex_byte_btn_Click);
            // 
            // txtbx_byte_data
            // 
            this.txtbx_byte_data.Location = new System.Drawing.Point(246, 49);
            this.txtbx_byte_data.Name = "txtbx_byte_data";
            this.txtbx_byte_data.Size = new System.Drawing.Size(200, 19);
            this.txtbx_byte_data.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.send_btn);
            this.groupBox1.Controls.Add(this.txtbx_byte_data);
            this.groupBox1.Controls.Add(this.send_ex_btn);
            this.groupBox1.Controls.Add(this.send_ex_byte_btn);
            this.groupBox1.Controls.Add(this.send_aeha_btn);
            this.groupBox1.Controls.Add(this.send_mitsubishi_btn);
            this.groupBox1.Controls.Add(this.send_nec_btn);
            this.groupBox1.Controls.Add(this.send_sony_btn);
            this.groupBox1.Location = new System.Drawing.Point(23, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 160);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "送信 （サンプルデータ）";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_get_ir_code_size);
            this.groupBox2.Controls.Add(this.btn_get_ir_code_send);
            this.groupBox2.Controls.Add(this.btn_ir_code_get);
            this.groupBox2.Controls.Add(this.btn_ir_code_rec_stop);
            this.groupBox2.Controls.Add(this.btn_ir_code_rec_start);
            this.groupBox2.Location = new System.Drawing.Point(23, 441);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "受信";
            // 
            // lbl_get_ir_code_size
            // 
            this.lbl_get_ir_code_size.AutoSize = true;
            this.lbl_get_ir_code_size.Location = new System.Drawing.Point(28, 75);
            this.lbl_get_ir_code_size.Name = "lbl_get_ir_code_size";
            this.lbl_get_ir_code_size.Size = new System.Drawing.Size(85, 12);
            this.lbl_get_ir_code_size.TabIndex = 4;
            this.lbl_get_ir_code_size.Text = "取得コードサイズ";
            // 
            // btn_get_ir_code_send
            // 
            this.btn_get_ir_code_send.Location = new System.Drawing.Point(246, 47);
            this.btn_get_ir_code_send.Name = "btn_get_ir_code_send";
            this.btn_get_ir_code_send.Size = new System.Drawing.Size(200, 23);
            this.btn_get_ir_code_send.TabIndex = 3;
            this.btn_get_ir_code_send.Text = "４．受信コード送信";
            this.btn_get_ir_code_send.UseVisualStyleBackColor = true;
            this.btn_get_ir_code_send.Click += new System.EventHandler(this.btn_get_ir_code_send_Click);
            // 
            // btn_ir_code_get
            // 
            this.btn_ir_code_get.Location = new System.Drawing.Point(20, 47);
            this.btn_ir_code_get.Name = "btn_ir_code_get";
            this.btn_ir_code_get.Size = new System.Drawing.Size(200, 23);
            this.btn_ir_code_get.TabIndex = 2;
            this.btn_ir_code_get.Text = "３．受信コード取得";
            this.btn_ir_code_get.UseVisualStyleBackColor = true;
            this.btn_ir_code_get.Click += new System.EventHandler(this.btn_ir_code_get_Click);
            // 
            // btn_ir_code_rec_stop
            // 
            this.btn_ir_code_rec_stop.Location = new System.Drawing.Point(246, 18);
            this.btn_ir_code_rec_stop.Name = "btn_ir_code_rec_stop";
            this.btn_ir_code_rec_stop.Size = new System.Drawing.Size(200, 23);
            this.btn_ir_code_rec_stop.TabIndex = 1;
            this.btn_ir_code_rec_stop.Text = "２．受信コード記録停止";
            this.btn_ir_code_rec_stop.UseVisualStyleBackColor = true;
            this.btn_ir_code_rec_stop.Click += new System.EventHandler(this.btn_ir_code_rec_stop_Click);
            // 
            // btn_ir_code_rec_start
            // 
            this.btn_ir_code_rec_start.Location = new System.Drawing.Point(20, 18);
            this.btn_ir_code_rec_start.Name = "btn_ir_code_rec_start";
            this.btn_ir_code_rec_start.Size = new System.Drawing.Size(200, 23);
            this.btn_ir_code_rec_start.TabIndex = 0;
            this.btn_ir_code_rec_start.Text = "１．受信コード記録開始";
            this.btn_ir_code_rec_start.UseVisualStyleBackColor = true;
            this.btn_ir_code_rec_start.Click += new System.EventHandler(this.btn_ir_code_rec_start_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxManualInput);
            this.groupBox3.Controls.Add(this.labelModelCode);
            this.groupBox3.Controls.Add(this.textBoxModelCode);
            this.groupBox3.Controls.Add(this.labelIRData);
            this.groupBox3.Controls.Add(this.textBoxIRData);
            this.groupBox3.Controls.Add(this.modelListBox);
            this.groupBox3.Controls.Add(this.labelModelSelect);
            this.groupBox3.Controls.Add(this.send_model_code_btn);
            this.groupBox3.Location = new System.Drawing.Point(23, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 237);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "送信（モデルコード）";
            // 
            // checkBoxManualInput
            // 
            this.checkBoxManualInput.AutoSize = true;
            this.checkBoxManualInput.Location = new System.Drawing.Point(231, 43);
            this.checkBoxManualInput.Name = "checkBoxManualInput";
            this.checkBoxManualInput.Size = new System.Drawing.Size(128, 16);
            this.checkBoxManualInput.TabIndex = 17;
            this.checkBoxManualInput.Text = "モデルコード手動入力";
            this.checkBoxManualInput.UseVisualStyleBackColor = true;
            this.checkBoxManualInput.CheckedChanged += new System.EventHandler(this.checkBoxManualInput_CheckedChanged);
            // 
            // labelModelCode
            // 
            this.labelModelCode.AutoSize = true;
            this.labelModelCode.Location = new System.Drawing.Point(18, 71);
            this.labelModelCode.Name = "labelModelCode";
            this.labelModelCode.Size = new System.Drawing.Size(61, 12);
            this.labelModelCode.TabIndex = 16;
            this.labelModelCode.Text = "モデルコード";
            // 
            // textBoxModelCode
            // 
            this.textBoxModelCode.Location = new System.Drawing.Point(20, 86);
            this.textBoxModelCode.Name = "textBoxModelCode";
            this.textBoxModelCode.ReadOnly = true;
            this.textBoxModelCode.Size = new System.Drawing.Size(100, 19);
            this.textBoxModelCode.TabIndex = 15;
            this.textBoxModelCode.TextChanged += new System.EventHandler(this.textBoxModelCode_TextChanged);
            // 
            // labelIRData
            // 
            this.labelIRData.AutoSize = true;
            this.labelIRData.Location = new System.Drawing.Point(18, 121);
            this.labelIRData.Name = "labelIRData";
            this.labelIRData.Size = new System.Drawing.Size(135, 12);
            this.labelIRData.TabIndex = 14;
            this.labelIRData.Text = "赤外線コード (バイトデータ)";
            // 
            // textBoxIRData
            // 
            this.textBoxIRData.Location = new System.Drawing.Point(20, 136);
            this.textBoxIRData.Name = "textBoxIRData";
            this.textBoxIRData.Size = new System.Drawing.Size(426, 19);
            this.textBoxIRData.TabIndex = 12;
            // 
            // modelListBox
            // 
            this.modelListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelListBox.FormattingEnabled = true;
            this.modelListBox.Location = new System.Drawing.Point(20, 39);
            this.modelListBox.Name = "modelListBox";
            this.modelListBox.Size = new System.Drawing.Size(145, 20);
            this.modelListBox.TabIndex = 13;
            this.modelListBox.SelectedIndexChanged += new System.EventHandler(this.modelList_SelectedIndexChanged);
            // 
            // labelModelSelect
            // 
            this.labelModelSelect.AutoSize = true;
            this.labelModelSelect.Location = new System.Drawing.Point(18, 24);
            this.labelModelSelect.Name = "labelModelSelect";
            this.labelModelSelect.Size = new System.Drawing.Size(126, 12);
            this.labelModelSelect.TabIndex = 8;
            this.labelModelSelect.Text = "モデルを選択してください。";
            // 
            // send_model_code_btn
            // 
            this.send_model_code_btn.Location = new System.Drawing.Point(20, 176);
            this.send_model_code_btn.Name = "send_model_code_btn";
            this.send_model_code_btn.Size = new System.Drawing.Size(426, 44);
            this.send_model_code_btn.TabIndex = 6;
            this.send_model_code_btn.Text = "赤外線コード 送信";
            this.send_model_code_btn.UseVisualStyleBackColor = true;
            this.send_model_code_btn.Click += new System.EventHandler(this.send_model_code_btn_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(364, 559);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(52, 12);
            this.version.TabIndex = 11;
            this.version.Text = "version : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 580);
            this.Controls.Add(this.version);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "赤外線リモコン-モデルコード送信ツール";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Button send_ex_btn;
        private System.Windows.Forms.Button send_aeha_btn;
        private System.Windows.Forms.Button send_nec_btn;
        private System.Windows.Forms.Button send_sony_btn;
        private System.Windows.Forms.Button send_mitsubishi_btn;
        private System.Windows.Forms.Button send_ex_byte_btn;
        private System.Windows.Forms.TextBox txtbx_byte_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_get_ir_code_send;
        private System.Windows.Forms.Button btn_ir_code_get;
        private System.Windows.Forms.Button btn_ir_code_rec_stop;
        private System.Windows.Forms.Button btn_ir_code_rec_start;
        private System.Windows.Forms.Label lbl_get_ir_code_size;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button send_model_code_btn;
        private System.Windows.Forms.TextBox textBoxIRData;
        private System.Windows.Forms.ComboBox modelListBox;
        private System.Windows.Forms.Label labelIRData;
        private System.Windows.Forms.Label labelModelSelect;
        private System.Windows.Forms.TextBox textBoxModelCode;
        private System.Windows.Forms.Label labelModelCode;
        private System.Windows.Forms.CheckBox checkBoxManualInput;
        private System.Windows.Forms.Label version;
    }
}

