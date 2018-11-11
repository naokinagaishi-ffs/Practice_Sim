using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulater.Model;
using System.Drawing;

namespace Simulater.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class ConnectController
    {
        
        private ConnecterTcpClient connecter;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="imageInfo"></param>
        public ConnectController()
        {
            this.connecter = new ConnecterTcpClient();
        }

        /// <summary>
        /// 通信を確立するメソッドを呼ぶ
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            return this.connecter.Connect();
        }

        /// <summary>
        /// 通信を切断するメソッドを呼ぶ
        /// </summary>
        public void Close()
        {
            this.connecter.Close();
        }

        /// <summary>
        /// 画像を送信するメソッドを呼ぶ
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public bool SendImage(ImageInfo imageInfo)
        {
            return this.connecter.SendImage(imageInfo);
        }


    }
}
