using System.Drawing;
using System.IO;

namespace Simulater.Model
{
    public class ResizeImage
    {
        private ImageInfo imageInfo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="imageInfo"></param>
        public ResizeImage(ImageInfo imageInfo)
        {
            this.imageInfo = imageInfo;
        }

        /// <summary>
        /// 指定の大きさにリサイズする関数
        /// </summary>
        /// <returns></returns>
        public Bitmap Execute(string filePath)
        {
            if ((string.IsNullOrEmpty(filePath)) || (!File.Exists(filePath)))
            {
                return null;
            }
            ushort resizeWidth = this.imageInfo.ImageWidth;
            ushort resizeHeight = this.imageInfo.ImageHeight;
            var buf = new Bitmap(filePath);
            return new Bitmap(buf, resizeWidth, resizeHeight);
        }
    }
}

