//
// 指定の画像サイズをピクセル数に変換するクラス
//

using Simulater.View;

namespace Simulater.Model
{
    public class SetImageSize
    {
        //フィールド
        private ImageInfo imageInfo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="imageInfo"></param>
        public SetImageSize(ImageInfo imageInfo)
        {
            this.imageInfo = imageInfo;
        }

        /// <summary>
        /// １インチ当たりの長さmm
        /// </summary>
        const double MMperINCHI = 25.4;

        /// <summary>
        /// 引数のパネルサイズに合わせて、画像サイズを設定する
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool Execute(View.Form1.ImageSize size)
        {
            ushort width = 0;
            ushort height = 0;
            if( View.Form1.ImageSize.MUTSUGIRI == size)
            {
                width = 8;
                height = 10;
            }
            else if(View.Form1.ImageSize.YOTSUGIRI == size)
            {
                width = 10;
                height = 14;
            }
            else if (View.Form1.ImageSize.DIAKAKU == size)
            {
                width = 14;
                height = 14;
            }
            else if(View.Form1.ImageSize.HANSETSU == size)
            {
                width = 14;
                height = 17;
            }
            else
            {
                return false;
            }
            if(!ConvertPixel(width, height))
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// パネルのサイズをピクセル数に変換
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private bool ConvertPixel(ushort width, ushort height)
        {
            // 0割りチェック
            if ((0 == this.imageInfo.ImageWidth) && (0 == this.imageInfo.PixelHeight))
            {
                return false;
            }
            else
            {
                this.imageInfo.ImageWidth = (ushort)(width * MMperINCHI / this.imageInfo.PixelWidth);
                this.imageInfo.ImageHeight = (ushort)(height * MMperINCHI / this.imageInfo.PixelHeight);
                return true;
            }

        }
    }
}
