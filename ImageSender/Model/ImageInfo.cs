//
//画像の情報をハンドリングするクラス
//
namespace Simulater.Model
{
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
            this.FilePath = null;
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
        /// ピクセルの縦幅(mm)
        /// </summary>
        public double PixelHeight { get; set; }

        /// <summary>
        /// ピクセルの横幅(mm)
        /// </summary>
        public double PixelWidth { get; set; }

        /// <summary>
        /// 画像のファイルパス
        /// </summary>
        public string FilePath { get; set; }
    }


}
