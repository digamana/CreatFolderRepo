using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreatFolder
{
    internal class Program
    {
        static void Main(string[] args)

        {   //取得當前exe檔執行的路徑
            string getCurrExePath = AppDomain.CurrentDomain.BaseDirectory;

            bool IsDevMode = !getCurrExePath.Contains("blog");
            //取得指定路徑底下的所有資料夾名稱
            if (IsDevMode) Console.WriteLine("編譯器開發模式");
            else Console.WriteLine("Bolg執行模式");
            
            //因為開時的專案資料夾跟blog的資料夾不同,所以
            //開發時,以"絕對"位置去找blog\assets\img
            //EXE運作時,以檔案本身開啟的"相對"位置去找blog\assets\img
            string[] subdirs = IsDevMode==true?
               Directory.GetDirectories(@"C:\Users\User\source\repos\blog\assets\img") :
               Directory.GetDirectories(Path.Combine(getCurrExePath, "assets", "img"));
            List<string> lstFolderName = new List<string>();
            Console.WriteLine("獲取當前 \\assets\\img 底下所有資料夾名稱");
            foreach (var item in subdirs)
            {
                var dir = new DirectoryInfo(item);
                var dirName = dir.Name;
                lstFolderName.Add(dirName);
                Console.WriteLine(dirName);

            }
                //
            string test = IsDevMode == true ? 
                @"C:\Users\User\source\repos\blog\_posts" :
                Path.Combine(getCurrExePath, "_posts");
            //取得指定路徑底下的所有普通檔案名稱
            DirectoryInfo d = new DirectoryInfo(test); //Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.md"); //Getting Text files
            Console.WriteLine("－－－－－－－－－－－－－－－－－－－");
            Console.WriteLine("獲取當前 \\_posts 底下所有.md的檔案名稱");
            Console.WriteLine("－－－－－－－－－－－－－－－－－－－");
            Console.WriteLine("準備執行建立資料夾作業");
            Console.WriteLine("－－－－－－－－－－－－－－－－－－－");
            foreach (var item in Files)
            {
                string FileName = item.Name.Substring(0, item.Name.Length - 3);
                if (!lstFolderName.Contains(FileName))
                {
                    Console.WriteLine($"缺少{FileName}，所以建立名為「{FileName}」的資料夾");
                    Directory.CreateDirectory(Path.Combine(getCurrExePath, "assets", "img", FileName));
                }
            //Console.WriteLine(item.Name.Substring(0, item.Name.Length-3));
            }
            Console.WriteLine("已完成資料夾作業");
            Console.WriteLine("－－－－－－－－－－－－－－－－－－－");





            Console.WriteLine($"準備IMG底下的PNG轉成png以防發佈到Github時,會因檔名不同造成無法顯示");
            Console.WriteLine("－－－－－－－－－－－－－－－－－－－");
            foreach (var item in subdirs)
            {
                var dir = new DirectoryInfo(item);
                var dirName = dir.Name;
                var getFileContext = dir.GetFiles("*.PNG");
                foreach (var item2 in getFileContext)
                {
                    var FileSplit = item2.Name.Split('.');
                    string FileName_Bore = item2.FullName;
                    string FileName_After = Path.Combine(item2.DirectoryName, $"{FileSplit[0]}.png");
                    System.IO.File.Move(FileName_Bore, FileName_After);
                }

            }
            Console.WriteLine($"PNG轉成png已完成");
            Console.WriteLine("－－－－－－－－－－－－－－－－－－－");

            Console.WriteLine($"偵測MD檔案是否有大寫PNG");
            foreach (var item in Files)
            {
                var FileReadLines = File.ReadLines(item.FullName);
                foreach (string line in FileReadLines)
                {
                    if (line.Contains("PNG"))
                    {
                        Console.WriteLine($".MD檔案中有大寫PNG,可能造成顯示錯誤 :{line}");
                    }
                }
            }
            Console.WriteLine("－－－－－－－－－－－－－－－－－－－");
            Console.WriteLine("執行完畢");
            Console.ReadKey();
        }
    }
}
