//
//サーバーと通信を行うクラス
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Drawing;


namespace ImageSender
{
    class Connecter
    {
        public Connecter()
        {
            this.socket = new TcpClient();
            this.netStream = null;
        }

        /// <summary>
        /// privateメンバ変数
        /// </summary>
        private TcpClient socket;
        private NetworkStream netStream;

        /// <summary>
        /// 通信を確立するメソッド
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <param name="PortNumber"></param>
        /// <returns></returns>
        public bool Connect(string IPAddress, int PortNumber = 9000)
        {
            try
            {
                socket = new TcpClient();
                socket.Connect(IPAddress, PortNumber);
                netStream = socket.GetStream();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 接続中のサーバーとの接続を切断
        /// </summary>
        public void Close()
        {
            if ((this.netStream != null)) { this.netStream.Close(); }
            if (this.socket != null) { this.socket.Close(); }
        }

        /// <summary>
        /// 画像を送信するメソッド
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public bool SendImage(Image srcImage)
        {
            if (srcImage == null)
            {
                return false;
            }

            try
            {
                byte[] buf = ImageToByteArray(srcImage);
                byte[] tbuf = new byte[buf.Length + 1];
                tbuf[0] = (byte)'i';
                for (int i = 1; i < buf.Length + 1; i++)
                {
                    tbuf[i] = buf[i - 1];
                }
                netStream.Write(tbuf, 0, tbuf.Length);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// image型をbytel型配列に変換
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private byte[] ImageToByteArray(Image image)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(image, typeof(byte[]));
            return b;
        }
    }
}
