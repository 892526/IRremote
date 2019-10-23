#define USE_FORMS_TIMER     // System.Windows.Forms.Timerを使用する場合
//#define USE_TIMERS_TIMER    // System.Timers.Timerを使用する場合 (テスト用です。タイマイベントは別スレッドで行いますが、排他処理は実装していませんので実使用はできません。)

using Microsoft.Win32.SafeHandles;
using System;
using System.Data;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using USB_IR_Library;

namespace USB_IR_ModelCode
{
    public partial class Form1 : Form
    {
        //モデルコードリスト(とりあえず配列のテーブルを持つようにする・・・)
        private readonly string[,] modelCodeRowData = {
            // 00
            {"Slect Model",     ""},

            // 01～10
            {"DDXGT700R A9",    "B9B410"},
            {"DDXGT700R2 A9",   "B9B430"},
            {"DDXGT700R3 A9",   "B9B431"},
            {"DDXGT701R A9",    "B9B411"},
            {"DDXGT702L M",     "B97470"},
            {"DDXGT702L A9",    "B9B412"},
            {"DDXGT704R M",     "B97413"},
            {"DDXGT705L M",     "B97432"},
            {"DDXGT705L A9",    "B9B433"},
            {"DDXGT706R R",     "B93434"},

            // 11～20
            {"DDXGT706R A9",    "B9B435"},
            {"DDXGT706L R",     "B93436"},
            {"DDXGT706L A9",    "B9B437"},
            {"DDXGT707R M",     "B97438"},
            {"DDXGT707R A9",    "B9B439"},
            {"DDXGT707L M",     "B9743A"},
            {"DDXGT707L A9",    "B9B43B"},
            {"DDXGT708L A9",    "B9B43C"},
            {"DDXGT709R A9",    "B9B43D"},
            {"DDXGT709L A9",    "B9B43E"},

            // 21～30
            {"DDXGT710R A9",    "B9B43F"},
            {"DDXGT711R A9",    "B9B440"},
            {"DDXGT712L A9",    "B9B441"},
            {"DDXGT713R A9",    "B9B442"},
            {"DDXGT714R A9",    "B9B443"},
            {"DDXGT715L A9",    "B9B444"},
            {"DDXGT717R A9",    "B9B445"},
            {"DDXGT500R A9",    "B9B420"},
            {"DDXGT500R2 A9",   "B9B480"},
            {"DDXGT500R4 A9",   "B9B481"},

            // 31～40
            {"DDXGT501R A9",    "B9B421"},
            {"DDXGT502L A9",    "B9B422"},
            {"DDXGT504R A9",    "B9B450"},
            {"DDXGT505L M",     "B97451"},
            {"DDXGT505L A9",    "B9B452"},
            {"DDXGT506R R",     "B93453"},
            {"DDXGT506R A9",    "B9B454"},
            {"DDXGT506L R",     "B93455"},
            {"DDXGT506L A9",    "B9B456"},
            {"DDXGT507R M",     "B97457"},

            // 41～50
            {"DDXGT507R A9",    "B9B458"},
            {"DDXGT507L M",     "B97459"},
            {"DDXGT507L A9",    "B9B45A"},
            {"DDXGT508L A9",    "B9B45B"},
            {"DDXGT509R A9",    "B9B45C"},
            {"DDXGT509L A9",    "B9B45D"},
            {"DDXGT510R M",     "B9745E"},
            {"DDXGT512L A9",    "B9B45F"},
            {"DDXGT513R A9",    "B9B460"},
            {"DDXGT514R A9",    "B9B461"},

            // 51～60
            {"DDXGT515L A9",    "B9B462"},
            {"DDXGT517R A9",    "B9B463"},
        };

        private bool isFormLoaded;          // formロード完了フラグ
#if USE_FORMS_TIMER
        private System.Windows.Forms.Timer timer;
#else
        private System.Timers.Timer timer;
#endif

        public Form1()
        {
            InitializeComponent();

            isFormLoaded = false;
            timer = null;
         }

        private void send_btn_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            byte[] code = new byte[] { 0x08, 0xF6, 0x81, 0x7E };    // 赤外線コード 4byte * 8bit = 32bit
            int i_ret = 0;

            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、リーダーコード、Bit0、Bit1、ストップコード、送信赤外線コード、赤外線コードのビット長]
                    // リーダーコード、Bit0、Bit1、ストップコード の 上位16bitはON時間　下位16bitはOFF時間
                    i_ret = USBIR.writeUSBIRCode(handle_usb_device, 38000, 0x015700AA, 0x00170017, 0x0017003E, 0x00170619, code, 32);

                    //test
                    //i_ret = USBIR.writeUSBIRCode(handle_usb_device, 25000, 0x012C0064, 0x00140014, 0x00140028, 0x00170619, code, 32);//test RC=12ms,4ms OFF=0.8ms,0.8ms ON=0.8ms,1.6ms
                    //i_ret = USBIR.writeUSBIRCode(handle_usb_device, 50000, 0x012C0064, 0x00140014, 0x00140028, 0x00170619, code, 32);//test RC=6ms,2ms OFF=0.4ms,0.4ms ON=0.4ms,0.8ms
                }

            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void send_ex_btn_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            // 送信データ ON時間とOFF時間の組み合わせ
            // [0][1] リーダコードのON,OFF
            // [2]-[65] 赤外線データ部 のON,OFFで１bit分のデータで32bit分
            // [66][67] ストップコードのON,OFF
            uint[] code = new uint[] {  0x0157,0x00AA,
                                        0x0017,0x0016, 0x0018,0x0016, 0x0017,0x0016, 0x0018,0x003D, 0x0018,0x0016, 0x0017,0x0017, 0x0017,0x0016, 0x0018,0x0016,
                                        0x0017,0x0016, 0x0018,0x003D, 0x0018,0x003D, 0x0018,0x0016, 0x0019,0x003D, 0x0017,0x003E, 0x0018,0x003D, 0x0018,0x003E,
                                        0x0017,0x003E, 0x0019,0x0015, 0x0017,0x0016, 0x0018,0x0016, 0x0017,0x0016, 0x0018,0x0016, 0x0017,0x0016, 0x0018,0x003E,
                                        0x0018,0x0016, 0x0017,0x003E, 0x0018,0x003E, 0x0017,0x003E, 0x0018,0x003D, 0x0019,0x003D, 0x0018,0x003D, 0x0018,0x0016,
                                        0x0018,0x061F};    // 送信データ
            int i_ret = 0;

            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIRData(handle_usb_device, 38000, code, 34);
                }

            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void send_aeha_btn_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            byte[] code = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC };    // 赤外線コード 6byte * 8bit = 48bit
            int i_ret = 0;

            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、フォーマット、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIR(handle_usb_device,USBIR.IR_FORMAT.AEHA, code, 48);
                }

            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void send_nec_btn_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            byte[] code = new byte[] { 0x08, 0xF6, 0x81, 0x7E };    // 赤外線コード 4byte * 8bit = 32bit
            int i_ret = 0;

            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、フォーマット、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIR(handle_usb_device, USBIR.IR_FORMAT.NEC, code, 32);
                }

            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void send_sony_btn_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            byte[] code = new byte[] { 0x08, 0xF6, 0x81, 0x7E };    // 赤外線コード 4byte * 8bit = 32bit
            int i_ret = 0;

            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、フォーマット、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIR(handle_usb_device, USBIR.IR_FORMAT.SONY, code, 32);
                }

            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void send_mitsubishi_btn_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            byte[] code = new byte[] { 0x08, 0xF6, 0x81, 0x7E };    // 赤外線コード 4byte * 8bit = 32bit
            int i_ret = 0;

            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、フォーマット、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIR(handle_usb_device, USBIR.IR_FORMAT.MITSUBISHI, code, 32);
                }

            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void send_ex_byte_btn_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            int i_ret = 0;
            try
            {
                if (txtbx_byte_data.Text != "")
                {
                    string[] tmp_str_arry;
                    byte[] code = new byte[1024];
                    uint ir_data_bit_len = 0;
                    tmp_str_arry = txtbx_byte_data.Text.Split(',');

                    bool error_flag = false;
                    if ((tmp_str_arry.Length % 4) == 0)
                    {
                        ir_data_bit_len = (uint)(tmp_str_arry.Length / 4);
                        code = new byte[tmp_str_arry.Length];

                        for (int fi = 0; fi < tmp_str_arry.Length; fi++)
                        {
                            try
                            {
                                code[fi] = (byte)(Convert.ToUInt32(tmp_str_arry[fi], 16) & 0xFF);
                            }
                            catch
                            {
                                error_flag = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        error_flag = true;
                    }

                    if (error_flag == false)
                    {
                        try
                        {
                            // USB DEVICEオープン
                            handle_usb_device = USBIR.openUSBIR(this.Handle);
                            if (handle_usb_device != null)
                            {
                                // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、送信赤外線コード、赤外線コードのビット長]
                                i_ret = USBIR.writeUSBIRData(handle_usb_device, 38000, code, ir_data_bit_len);
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                            if (handle_usb_device != null)
                            {
                                // USB DEVICEクローズ
                                i_ret = USBIR.closeUSBIR(handle_usb_device);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("赤外線送信データが正しくありません。また、データ数は４の倍数にしてください。 \n例：[0x01,0x50,0x00,0xAA,0x00,0x16,0x00,0x17, ...]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("赤外線送信データを、右のテキストボックスに設定してください。 \n例」[0x01,0x50,0x00,0xAA,0x00,0x16,0x00,0x17, ...]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
            }
            finally
            {
            }
        }

        private void btn_ir_code_rec_start_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            int i_ret = 0;
            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数]
                    i_ret = USBIR.recUSBIRData_Start(handle_usb_device, 38000);
                }
            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void btn_ir_code_rec_stop_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            int i_ret = 0;
            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル]
                    i_ret = USBIR.recUSBIRData_Stop(handle_usb_device);
                }
            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        byte[] ir_code = new byte[9600];
        uint ir_data_bit_len = 0;
        private void btn_ir_code_get_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            int i_ret = 0;
            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.readUSBIRData(handle_usb_device, ref ir_code, (uint)ir_code.Length, ref ir_data_bit_len);

                    if (i_ret == 0)
                    {   // 取得成功
                        lbl_get_ir_code_size.Text = string.Format("取得コードサイズ : {0}bits", ir_data_bit_len);
                    }
                    else
                    {
                        lbl_get_ir_code_size.Text = "取得エラー";
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }

        private void btn_get_ir_code_send_Click(object sender, EventArgs e)
        {
            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            int i_ret = 0;
            try
            {
                if (ir_data_bit_len > 0)
                {
                    // USB DEVICEオープン
                    handle_usb_device = USBIR.openUSBIR(this.Handle);
                    if (handle_usb_device != null)
                    {
                        // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、送信赤外線コード、赤外線コードのビット長]
                        i_ret = USBIR.writeUSBIRData(handle_usb_device, 38000, ir_code, ir_data_bit_len);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }
        }


        // モデルコード送信ボタン
        private void send_model_code_btn_Click(object sender, EventArgs e)
        {

            if (checkBoxSendPeriodic.Checked == false)
            {
                byte[] code = new byte[1];  // dammyで配列を確保
                uint result = convertIrdataToSendcode(textBoxIRData.Text, ref code);
                if (result == 0)
                {
                    send_model_code_irdata(code);
                }
                else
                {
                    showErrMessage(result);
                }
            }

        }

        // エラーメッセージ表示
        // param : convertIrdataToSendcodeの結果
        private void showErrMessage(uint errType)
        {

            if (errType == 0)
            {
                // nothing
            }
            else if (errType == 1)
            {
                MessageBox.Show("赤外線送信データがありません。モデルを選択するか、モデルコードを入力してください。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (errType == 2 || errType == 3)
            {
                MessageBox.Show("赤外線送信データが正しくありません。また、データ数は４の倍数にしてください。 \n例：[0x01,0x50,0x00,0xAA,0x00,0x16,0x00,0x17, ...]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("赤外線送信データが正しくありません。データを確認してください。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // 文字列のIRデータを送信用コードに変換する
        // return : 結果 (0:データ変換成功 / 1:データなし / 2:データ異常(バイト数が4の倍数でない) / 3:データ異常(16進数でない))
        private uint convertIrdataToSendcode(string inIrdataStr, ref byte[] outCode)
        {
            uint lResult = 0;

            try
            {
                if (inIrdataStr == "")
                {
                    lResult = 1;    // データ異常(データなし)
                }
                else
                {

                    string[] tmp_str_arry;
                    uint ir_data_bit_len = 0;
                    tmp_str_arry = inIrdataStr.Split(',');
                    Array.Resize(ref outCode, tmp_str_arry.Length);

                    if ((tmp_str_arry.Length % 4) == 0)
                    {
                        ir_data_bit_len = (uint)(tmp_str_arry.Length / 4);

                        for (int fi = 0; fi < tmp_str_arry.Length; fi++)
                        {
                            try
                            {
                                outCode[fi] = (byte)(Convert.ToUInt32(tmp_str_arry[fi], 16) & 0xFF);
                            }
                            catch
                            {
                                lResult = 3;    // データ異常(16進数でない)
                                break;
                            }
                        }
                    }
                    else
                    {
                        lResult = 2;    // データ異常(バイト数が4の倍数でない)
                    }

                    // debug
                    //foreach (var val in outCode) {
                    //    Console.WriteLine("IRcode : {0:X}", val);
                    //}

                }

            }
            catch
            {
            }
            finally
            {
            }

            return lResult;
        }

        // モデルコードのIRデータ送信
        // return : 結果 (true:OK / false:NG)
        private bool send_model_code_irdata(byte[] code)
        {
            bool lResult = false;

            if (code == null) {
                Console.WriteLine("send_model_code ERR. input code is null.");
                return false;
            }

            if ( (code.Length % 4) != 0)
            {
                Console.WriteLine("send_model_code ERR. input code is not multiple of 4.");
                return false;
            }

            SafeFileHandle handle_usb_device = null;    // USB DEVICEハンドル
            int i_ret = 0;
            try
            {
                // USB DEVICEオープン
                handle_usb_device = USBIR.openUSBIR(this.Handle);
                if (handle_usb_device != null)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIRData(handle_usb_device, 38000, code, ir_data_bit_len);
                    // 関数が成功すると0 が返ります。失敗すると-1 が返ります。
                    if (i_ret == 0)
                    {
                        lResult = true;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (handle_usb_device != null)
                {
                    // USB DEVICEクローズ
                    i_ret = USBIR.closeUSBIR(handle_usb_device);
                }
            }

            return lResult;
        }


        private void modelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelListBox.SelectedIndex != -1)
            {
                //対応するモデルコードを表示
                textBoxModelCode.Text = modelListBox.SelectedValue.ToString();
            }
        }

        private void textBoxModelCode_TextChanged(object sender, EventArgs e)
        {
            if (isFormLoaded == false)
            {
                return;
            }

            // 3byte未満は無効値とする (1byteあたり2文字)
            if (textBoxModelCode.Text.Length < 6)
            {
                textBoxIRData.Text = "";
                return;
            }

            //テキストボックス入力値からIRデータを生成
            string irdata = "";
            bool result = createIrdata(textBoxModelCode.Text, ref irdata);
            if (result == false)
            {
                MessageBox.Show("モデルコードが正しくありません。値は３バイトの１６進数を入力してください。 \n例：[B9B410]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBoxIRData.Text = irdata;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isFormLoaded = false;

            //項目をモデルリストボックスに追加
            DataTable modelTable = new DataTable();
            modelTable.Columns.Add("MODEL", typeof(string));
            modelTable.Columns.Add("CODE", typeof(string));

            for (int i = 0; i < modelCodeRowData.GetLength(0); i++)
            {
                //新しい行を作成
                DataRow row = modelTable.NewRow();
                //各列に値をセット
                row["MODEL"] = modelCodeRowData[i, 0];   // モデル名
                row["CODE"] = modelCodeRowData[i, 1];    // 送信コード

                //DataTableに行を追加
                modelTable.Rows.Add(row);
            }

            modelTable.AcceptChanges();

            //コンボボックスのDataSourceにDataTableを割り当てる
            modelListBox.DataSource = modelTable;

            //表示される値はDataTableのMODEL列
            modelListBox.DisplayMember = "MODEL";

            //対応する値はDataTableのCODE列
            modelListBox.ValueMember = "CODE";

            //初期表示項目設定
            modelListBox.SelectedIndex = 0;
            textBoxModelCode.Text = modelListBox.SelectedValue.ToString();

            //初期フォーカス設定
            ActiveControl = send_model_code_btn;

            //バージョン表示
            version.Text = "version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            isFormLoaded = true;
        }


        // IRデータ 固定値定義
        readonly byte[] leader_code = { 0x01, 0x58, 0x00, 0xAC };   // learder code
        readonly byte[] stop        = { 0x00, 0x16, 0x1E, 0x0D };   // stop bit and frame space
        readonly byte[] data_0      = { 0x00, 0x16, 0x00, 0x17 };   // data 0
        readonly byte[] data_1      = { 0x00, 0x16, 0x00, 0x42 };   // data 1

        // IRデータ作成
        // (文字列のIRデータを生成する)
        private bool createIrdata(string inModelCode, ref string outIrdata)
        {

            if (inModelCode == null) {
                Console.WriteLine("createIrdata ERR. input model code is null.");
                return false;
            }

            if (inModelCode.Length < 2)
            {
                Console.WriteLine("createIrdata ERR. input model code is too short. length={0}", inModelCode.Length);
                return false;
            }

            char[] checkArray = new char[inModelCode.Length];
            checkArray = inModelCode.ToCharArray();
            foreach (char str in checkArray) {
                if ( !Uri.IsHexDigit(str) )
                {
                    Console.WriteLine("createIrdata ERR. Can not convert to byte data. model_code={0} errStr={1}", inModelCode, str);
                    return false;
                }
            }

            // モデルコード文字列を16進値配列に変換
            int length = inModelCode.Length / 2;
            byte[] modelcode = new byte[length + 1];

            for (int i = 0; i < length; i++) {
                string substr = inModelCode.Substring(i*2, 2);
                modelcode[i] = Convert.ToByte(substr, 16);
            }

            modelcode[length] = (byte)(~modelcode[length - 1]); // 最終バイトのデータを反転して追加

            // debug
            string dstr = "";
            foreach (byte code in modelcode)
            {
                dstr += code.ToString("X2");
            }
            Console.WriteLine("modelcode = {0}", dstr);


            // 送信用IRデータ作成
            string irdata = "";

            // リーダー部分のIRデータを作成
            for (int i = 0; i < leader_code.Length; i++)
            {
                irdata = irdata + "0x" + leader_code[i].ToString("X2") + ",";
            }

            Console.WriteLine("IRdata add leader_code : {0}", irdata);


            // data部分のIRデータを作成
            for (int i = 0; i < modelcode.Length; i++)
            {

                // 1bitづつデータ作成
                int temp = modelcode[i];
                for (int j = 0; j < 8; j++)
                {
                    int bit = temp & 0x1;

                    byte[] data = new byte[data_1.Length];
                    if (bit == 1)
                    {
                        data = data_1;
                    }
                    else
                    {
                        data = data_0;
                    }

                    for (int k = 0; k < data.Length; k++)
                    {
                        irdata = irdata + "0x" + data[k].ToString("X2") + ",";
                    }

                    temp = temp >> 1;
                }

            }

            Console.WriteLine("IRdata add data : {0}", irdata);


            // ストップ部分のIRデータを作成
            for (int i = 0; i < stop.Length; i++)
            {
                irdata = irdata + "0x" + stop[i].ToString("X2") + ",";
            }
            irdata = irdata.TrimEnd(',');   // 末尾の","は削除

            Console.WriteLine("IRdata add stop : {0}", irdata);

            outIrdata = irdata;
            return true;
        }

        // モデルコード手動入力モードチェックボックス変更
        private void checkBoxManualInput_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxManualInput.Checked == true)
            {
                textBoxModelCode.ReadOnly = false;
            }
            else
            {
                textBoxModelCode.ReadOnly = true;
            }
        }

        // 周期送信モードチェックボックス変更
        private void checkBoxSendPeriodic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSendPeriodic.Checked == true)
            {
                changeSendSyclikMode(true);
            }
            else
            {
                changeSendSyclikMode(false);
            }
        }

        // 周期送信モード変更
        private void changeSendSyclikMode(Boolean isEnable)
        {
            if (isEnable == true)
            {
                send_model_code_btn.Enabled = false;
                numericUpDownPeriodic.Enabled = true;

                startPeriodicSend();
            }
            else
            {
                stopPeriodicSend();

                send_model_code_btn.Enabled = true;
                numericUpDownPeriodic.Enabled = false;
            }

            // チェックボックス表示更新
            if (checkBoxSendPeriodic.Checked != isEnable)
            {
                checkBoxSendPeriodic.Checked = isEnable;
            }

        }

        // 周期送信用タイマ開始
        private void startPeriodicSend()
        {
#if USE_FORMS_TIMER
            // System.Windows.Forms.Timerを使用する場合
            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler(timerSendPeriodicEvent);
                timer.Interval = getPeriodeicSendTime();
            }
#else
            // System.Timers.Timerを使用する場合
            if (timer == null)
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += new ElapsedEventHandler(timerSendPeriodicEvent);
                timer.Interval = getPeriodeicSendTime();
            }
#endif

            timer.Start();
        }

        // 周期送信用タイマ停止
        private void stopPeriodicSend()
        {
            timer.Stop();
        }

        // 周期送信イベント
#if USE_FORMS_TIMER
        private void timerSendPeriodicEvent(object sender, EventArgs e)
#else
        private void timerSendPeriodicEvent(object sender, ElapsedEventArgs e)
#endif
        {
            Console.WriteLine("Periodec sending : {0}", DateTime.Now);    // debug

            byte[] code = new byte[1];  // dammyで配列を確保
            uint lResult = convertIrdataToSendcode(textBoxIRData.Text, ref code);
            if (lResult == 0)
            {
                send_model_code_irdata(code);
            }
            else
            {
                Console.WriteLine("Stop periodic sending");
                if (this.InvokeRequired) {
                    Invoke(new Action<Boolean>(changeSendSyclikMode), false);
                } else {
                    changeSendSyclikMode(false);
                }

                showErrMessage(lResult);
            }
        }

        private void numericUpDownPeriodic_ValueChanged(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Interval = getPeriodeicSendTime();
            }
        }

        // 周期送信時間取得
        // return : 周期送信時間 [msec]
        private int getPeriodeicSendTime()
        {
            decimal val = numericUpDownPeriodic.Value * 1000;   // msecに変換

            // 範囲外補正
            if (val < 500)
            {
                val = 500;
            }
            else if (val > 5000)
            {
                val = 5000;
            }

            return (int)val;
        }

    }
}
