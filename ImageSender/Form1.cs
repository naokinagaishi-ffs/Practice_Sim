using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;


namespace ImageSender
{
    public partial class Form1 : Form
    {
        ImageInfo imageInfo;
        private Connecter connecter;

        /// <summary>
        /// １インチ当たりの長さmm
        /// </summary>
        const double MMperINCHI = 25.4;

        /// <summary>
        /// IPアドレス。ループバックなので、127.0.0.1で固定。
        /// </summary>
        const string IPADDRESS = "127.0.0.1";
        
        /// <summary>
        /// ポートナンバー。とりあえず9000で固定
        /// </summary>
        const int PORTNUMBER = 9000;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            OriginalInitialize();
         }

        /// <summary>
        /// 自動生成以外のコードの初期化
        /// </summary>
        private void OriginalInitialize()
        {
            this.connecter = new Connecter();
            this.imageInfo = new ImageInfo();
            this.filePath = null;
            this.buton_openFileDialog.Enabled = false;
        }

        /// <summary>
        /// 送るサイズにトリミングされたImage
        /// </summary>
        public Image SendImage { get; set; }

        /// <summary>
        /// 送る画像のファイルパス
        /// </summary>
        private string filePath;

        /// <summary>
        /// ファイルパスを取得し画像をセットするイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buton_openFileDialog_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.filePath = openFileDialog1.FileName;
                textBox_filePath.Text = Path.GetFileName( this.filePath);
                SetSelectImage(this.filePath);
            }
        }

        /// <summary>
        /// 画像サイズのcomboBoxが変更された際のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_ImageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectSize = comboBox_ImageSize.Text.ToString();
            if (SetImageSize(selectSize))
            {
                this.buton_openFileDialog.Enabled = true;
            }

        }

        /// <summary>
        /// ピクセル数に変換
        /// </summary>
        /// <param name="selectSize"></param>
        private bool SetImageSize(string selectSize)
        {
            if(selectSize == "8 x 10")
            {
                this.imageInfo.ImageWidth = (ushort)(8 * MMperINCHI / this.imageInfo.PixelWidth);
                this.imageInfo.ImageHeight = (ushort)(10 * MMperINCHI / this.imageInfo.PixelHeight);
            }
           else if(selectSize == "10 x 14")
            {
                this.imageInfo.ImageWidth = (ushort)(10 * MMperINCHI / this.imageInfo.PixelWidth);
                this.imageInfo.ImageHeight = (ushort)(14 * MMperINCHI / this.imageInfo.PixelHeight);
            }
            else if(selectSize == "4 x 17")
            {
                this.imageInfo.ImageWidth = (ushort)(14 * MMperINCHI / this.imageInfo.PixelWidth);
                this.imageInfo.ImageHeight = (ushort)(17 * MMperINCHI / this.imageInfo.PixelHeight);
            }
            else if(selectSize =="17 x 17")
            {
                this.imageInfo.ImageWidth = (ushort)(17 * MMperINCHI / this.imageInfo.PixelWidth);
                this.imageInfo.ImageHeight = (ushort)(17 * MMperINCHI / this.imageInfo.PixelHeight);
            }
            else
            {
                MessageBox.Show("画像サイズに誤りがあるか、設定さていません");
                this.imageInfo.ImageWidth = 0;
                this.imageInfo.ImageHeight = 0;
                return false;
            }

                return true;
        }

        /// <summary>
        /// ファイルパスで指定された画像をpictureBoxにセットするメソッド
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool SetSelectImage(string filePath)
        {
            if( (string.IsNullOrEmpty(filePath)) ||
                (! File.Exists(filePath)))
            {
                MessageBox.Show("ファイルパスが正しくありません");
                return false;
            }

            //送る画像のサンプルなので、自動スケーリングでOK
            pictureBox_SelectImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_SelectImage.Image = System.Drawing.Image.FromFile(filePath);
            return true;
        }

        /// <summary>
        /// デッドマンスイッチの半押時のイベント。通信を確立する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Half_Click(object sender, EventArgs e)
        {
           if(! this.connecter.Connect(IPADDRESS, PORTNUMBER))
            {
                string message = "通信が確立できませんでした。";
                listBox_Log.Items.Add(message);
                btn_Half.BackColor = Color.Red;

            }
            else
            {
                string message = "通信が確立できています.......";
                listBox_Log.Items.Add(message);
                btn_Half.BackColor = Color.Green;

            }
        }

        /// <summary>
        /// 解除ボタン押下じのイベント。通信を切断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.connecter.Close();
            string message = "通信を切断しました";
            listBox_Log.Items.Add(message);
            btn_Half.BackColor = Color.Gray;
            btn_Whole.BackColor = Color.Gray;
        }

        /// <summary>
        /// デッドマンスイッチの全押時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Whole_Click(object sender, EventArgs e)
        {
           if(! this.connecter.SendImage(this.imageInfo))
            {
                string message = "画像を送信できませんでした。";
                listBox_Log.Items.Add(message);
                btn_Whole.BackColor = Color.Red;
            }
            else
            {
                string message = "画像の送信に成功しました。";
                listBox_Log.Items.Add(message);
                btn_Whole.BackColor = Color.Green;
            }
        }
    }
}
