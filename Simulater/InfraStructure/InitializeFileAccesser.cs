using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simulater.InfraStructure
{
    /// <summary>
    /// Initializeファイルにアクセスするクラス
    /// </summary>
    public class InitializeFileAccesser
    {
        /// <summary>
        /// 指定ファイルパスの文字列のレコードをリストで返す。
        /// 各レコードはCSV形式。
        /// セミコロンはコメント行として呼び飛ばす。
        /// エラー時は空のリストを返す
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public List<string> GetInitializeFileInfo(string filePath)
        {
            List<string> retList = new List<string>();

            //引数チェック
            if(string.IsNullOrEmpty(filePath) || File.Exists(filePath))
            {
                return retList; 
            }

            using (StringReader fileStream = new StringReader(filePath))
            {
                //全ての文字列を読む
                while (fileStream.Peek() >= 0)
                {
                    string tmpLine = string.Empty;
                    tmpLine = fileStream.ReadLine();
                    tmpLine.Trim();
                    if ((string.IsNullOrEmpty(tmpLine)) || (';' == tmpLine[0]))
                    {
                        //if文の条件の順番気を付ける！　先に空白チェック。逆だとアクセスバイオレーション発生。
                        //空白行とコメントを呼び飛ばす
                        continue;
                    }
                    List<string> record = new List<string>();
                    record = tmpLine.Split(',').ToList();
                    retList.Add(record);
                }
            }

        }
    }
}
