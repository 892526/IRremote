using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32.SafeHandles;
using USB_IR_Library;

namespace USB_IR_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void send_btn_all_Click(object sender, EventArgs e)
        {
            byte[] code = new byte[] { 0x08, 0xF6, 0x81, 0x7E };    // 赤外線コード 4byte * 8bit = 32bit
            int i_ret = 0;

            try
            {
                // USB DEVICEオープン
                int connect_num = USBIR.openUSBIR_all();
                if (connect_num > 0)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、リーダーコード、Bit0、Bit1、ストップコード、送信赤外線コード、赤外線コードのビット長]
                    // リーダーコード、Bit0、Bit1、ストップコード の 上位16bitはON時間　下位16bitはOFF時間
                    i_ret = USBIR.writeUSBIRCode_all(38000, 0x015700AA, 0x00170017, 0x0017003E, 0x00170619, code, 32);
                    if(i_ret != 0)
                    {
                        MessageBox.Show(string.Format("error No={0}", i_ret));
                    }
                }

            }
            catch
            {
            }
            finally
            {
                // USB DEVICEクローズ
                i_ret = USBIR.closeUSBIR_all();
            }
        }

        private void send_ex_btn_all_Click(object sender, EventArgs e)
        {
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
                int connect_num = USBIR.openUSBIR_all();
                if (connect_num > 0)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIRData_all(38000, code, 34);
                    if (i_ret != 0)
                    {
                        MessageBox.Show(string.Format("error No={0}", i_ret));
                    }
                }

            }
            catch
            {
            }
            finally
            {
                // USB DEVICEクローズ
                i_ret = USBIR.closeUSBIR_all();
            }
        }

        private void send_ex_byte_btn_all_Click(object sender, EventArgs e)
        {
            int i_ret = 0;
            try
            {
                if (txtbx_byte_data_all.Text != "")
                {
                    string[] tmp_str_arry;
                    byte[] code = new byte[1024];
                    uint ir_data_bit_len = 0;
                    tmp_str_arry = txtbx_byte_data_all.Text.Split(',');

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
                            int connect_num = USBIR.openUSBIR_all();
                            if (connect_num > 0)
                            {
                                // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、周波数、送信赤外線コード、赤外線コードのビット長]
                                i_ret = USBIR.writeUSBIRData_all(38000, code, ir_data_bit_len);
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                            // USB DEVICEクローズ
                            i_ret = USBIR.closeUSBIR_all();
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

        private void send_aeha_btn_all_Click(object sender, EventArgs e)
        {
            byte[] code = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC };    // 赤外線コード 6byte * 8bit = 48bit
            int i_ret = 0;
            try
            {
                // USB DEVICEオープン
                int connect_num = USBIR.openUSBIR_all();
                if (connect_num > 0)
                {
                    // USB DEVICEへ送信 パラメータ[USB DEVICEハンドル、フォーマット、送信赤外線コード、赤外線コードのビット長]
                    i_ret = USBIR.writeUSBIR_all(USBIR.IR_FORMAT.AEHA, code, 48);
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                // USB DEVICEクローズ
                i_ret = USBIR.closeUSBIR_all();
            }
        }

        private void send_nec_btn_all_Click(object sender, EventArgs e)
        {

        }

        private void send_sony_btn_all_Click(object sender, EventArgs e)
        {

        }

        private void send_mitsubishi_btn_all_Click(object sender, EventArgs e)
        {

        }
    }
}
