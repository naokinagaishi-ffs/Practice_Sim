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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Simulater.Model
{
    public class ConnecterTcpClient
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConnecterTcpClient()
        {
            this.netStream = null;
        }


        /// <summary>
        /// IPアドレス。ループバックなので、127.0.0.1で固定。
        /// </summary>
        private const string IPADDRESS = "127.0.0.1";

        /// <summary>
        /// ポートナンバー。とりあえず9000で固定
        /// </summary>
        private const int PORTNUMBER = 9000;

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
        public bool Connect()
        {
            try
            {
                this.socket = new TcpClient();
                this.socket.Connect(IPADDRESS, PORTNUMBER);
                this.netStream = socket.GetStream();
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
        public bool SendImage(ImageInfo imageInfo)
        {
            if ((imageInfo == null) || (this.netStream == null))
            {
                return false;
            }

            try
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(this.netStream, imageInfo);
                //this.Close();
                
            }
            catch
            {
                //TODO::ログの書き込み
                return false;
            }
            return true;
        }

        //    /// <summary>
        //    /// image型をbytel型配列に変換
        //    /// </summary>
        //    /// <param name="image"></param>
        //    /// <returns></returns>
        //    private byte[] ImageToByteArray()
        //    {
        //        ImageConverter imgconv = new ImageConverter();
        //        byte[] b = (byte[])imgconv.ConvertTo(this.imageInfo, typeof(byte[]));
        //        return b;
        //    }
        //}
    }
}
