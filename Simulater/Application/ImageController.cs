using Simulater.Model;
using System.Drawing;

namespace Simulater.Application
{
    /// <summary>
    /// Modelにロジックが追加されると、このクラスのメンバも追加される。
    /// </summary>
    public class ImageController
    {
        //フィールドの宣言
        private  ResizeImage imageResize;
        private SetImageSize setImageSize;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="imageInfo"></param>
        public ImageController(ImageInfo imageInfo)
        {
            this.imageResize = new ResizeImage(imageInfo);
            this.setImageSize = new SetImageSize(imageInfo);
        }

        /// <summary>
        /// 画像をリサイズする関数を呼ぶ
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Bitmap ResizeImage(string filePath)
        {
           return imageResize.Execute(filePath);
        }

        /// <summary>
        /// パネルサイズに合わせて画像サイズを設定する関数をよぶ
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool SetImageSize(View.Form1.ImageSize size)
        {
            return setImageSize.Execute(size);
        }
    }
}
