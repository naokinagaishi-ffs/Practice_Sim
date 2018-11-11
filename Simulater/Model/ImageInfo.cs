//
//画像の情報をハンドリングするクラス
//
using System;
using System.Drawing;

namespace Simulater.Model
{

    [Serializable()]
    public class ImageInfo
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ImageInfo()
        {
            this.ImageWidth = 0;
            this.PixelHeight = 0.15;
            this.PixelWidth = 0.15;
            this.Bitmap = null;
        }

        /// <summary>
        /// 画像の横幅(ピクセル数)のプロパティ
        /// </summary>
        public ushort ImageWidth { get; set; }

        /// <summary>
        /// 画像の縦幅(ピクセル数)のプロパティ
        /// </summary>
        public ushort ImageHeight { get; set; }

        /// <summary>
        /// ピクセルの縦幅(mm)のプロパティ
        /// </summary>
        public double PixelHeight { get; set; }

        /// <summary>
        /// ピクセルの横幅(mm)のプロパティ
        /// </summary>
        public double PixelWidth { get; set; }


        /// <summary>
        /// 画像のBitMapのプロパティ
        /// </summary>
        public Bitmap Bitmap { get; set; }
    }


}
