//
//Simulaterの画面を実装するクラス。画面は一つのみで、今後増える予定なし
//
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Simulater.Model;
using Simulater.Application;
using System.Collections.Generic;

namespace Simulater.View
{
    public partial class Form1 : Form
    {
        //フィールド変数
        private ImageInfo imageInfo;
        private Connecter connecter;
        private SimulaterApplication simulaterApp;
        private Dictionary<string, ImageSize> imageSizeDictionary;

        /// <summary>
        /// IPアドレス。ループバックなので、127.0.0.1で固定。
        /// </summary>
        const string IPADDRESS = "127.0.0.1";

        /// <summary>
        /// ポートナンバー。とりあえず9000で固定
        /// </summary>
        const int PORTNUMBER = 9000;

        /// <summary>
        /// 画像サイズの列挙値
        /// </summary>
        public enum ImageSize
        {
           MUTSUGIRI   = 0,     //四切
           YOTSUGIRI   = 1,      //六切
           DIAKAKU      = 2,      //大角
           HANSETSU    = 3,     //半切
        }

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
            this.simulaterApp = new SimulaterApplication(this.imageInfo);
            this.buton_openFileDialog.Enabled = false;
            this.btn_Whole.Enabled = false;
            this.btn_Half.Enabled = true;

            //combBoxのプルダウンの文字列と,ImageSizeを関連付けるため。
            this.imageSizeDictionary = new Dictionary<string, ImageSize>
            {
                { "8x10", ImageSize.MUTSUGIRI},
                {"10x14",ImageSize.YOTSUGIRI },
                {"14x14",ImageSize.DIAKAKU},
                {"14x17",ImageSize.HANSETSU }
            };
        }

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
                this.imageInfo.FilePath = openFileDialog1.FileName;
                textBox_filePath.Text = Path.GetFileName(this.imageInfo.FilePath);
                SetSelectImage(this.imageInfo.FilePath);
            }
        }

        /// <summary>
        /// 画像サイズのcomboBoxが変更された際のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_ImageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string textValue = comboBox_ImageSize.Text.ToString();
            ImageSize size = this.imageSizeDictionary[textValue];
            if (simulaterApp.SetImageSize(size))
            {
                this.buton_openFileDialog.Enabled = true;
            }
            else
            {
                //TODO::異常系の画面遷移を実装
            }
        }

        /// <summary>
        /// ファイルパスで指定された画像のサンプルをpictureBoxにセットするメソッド
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool SetSelectImage(string filePath)
        {
            if ((string.IsNullOrEmpty(filePath)) ||
                (!File.Exists(filePath)))
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
            if (!this.connecter.Connect(IPADDRESS, PORTNUMBER))
            {
                string message = "通信が確立できませんでした。";
                listBox_Log.Items.Add(message);
                btn_Half.BackColor = Color.Red;

            }
            else
            {
                string message = "通信が確立できています.......";
                listBox_Log.Items.Add(message);
                btn_Half.Enabled = false;
                btn_Whole.Enabled = true;
                btn_Half.BackColor = Color.Green;
            }
        }

        /// <summary>
        /// 解除ボタン押下時のイベント。通信を切断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.connecter.Close();
            string message = "通信を切断しました";
            listBox_Log.Items.Add(message);
            btn_Half.Enabled = true;
            btn_Whole.Enabled = true;
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
            btn_Whole.Enabled = false;
            Bitmap bitMap = this.simulaterApp.ResizeImage(this.imageInfo.FilePath);
            if (bitMap == null)
            {
                string message = "画像のリサイズに失敗ました";
                SwitchInitialize(message);
                btn_Whole.BackColor = Color.Red;
                return;
            }
            if (!this.connecter.SendImage(bitMap))
            {
                string message = "画像を送信できませんでした。";
                SwitchInitialize(message);
                btn_Whole.BackColor = Color.Red;
            }
            else
            {
                string message = "画像の送信に成功しました。";
                SwitchInitialize(message);
                btn_Whole.BackColor = Color.Gray;

            }
        }

        /// <summary>
        /// 通信を切断し、ログを出力し、デッドマンスイッチを初期状態に戻す
        /// </summary>
        private void SwitchInitialize(string msg)
        {
            listBox_Log.Items.Add(msg);
            this.connecter.Close();
        }
    }
}
    