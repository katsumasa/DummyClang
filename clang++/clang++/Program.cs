using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.IO;

// 使い方
// clang++.exeを_clang++.exeにリネームし同フォルダに本ファイルをコピーして使用します。
// clang++に渡すオプションを置換できます。
// 現状置き換え（と削除）のみの対応となります。
namespace clang__
{
    class Program
    {
        // 引数置き換え用のテーブル
        // {"置き換え前の文字列","置き換え後の文字列"},
        static string[,] replaceWordTbl = new string[,]
        {
          {"-fvisibility=default",""},                          // -fvisibility=default を削除
//            {"-fvisibility=hidden","-fvisibility=default"},   // -fvisibility=hiddenを-fvisibility=default　に置き換え
        };



        static void Main(string[] args)
        {
            var stl = Environment.CommandLine;
            string[] cmds = System.Environment.GetCommandLineArgs();

            //StreamWriter writer = new StreamWriter(@"d:\tmp.txt",true);
            //writer.WriteLine(stl);
            if (stl.LastIndexOf('\"') > 0)
            {
                stl = stl.Replace(cmds[0], "");
                stl = stl.Remove(0, stl.IndexOf(" "));
            }


            if (args.Length > 1)
            {
                stl = stl.Remove(0, 1);
            }

            var exe = cmds[0];
            var find = exe.LastIndexOf("clang++");
            exe = exe.Remove(find, exe.Length - find);
            exe = exe + "_clang++";

            for (var i = 0; i < replaceWordTbl.GetLength(0); i++){
                stl = stl.Replace(replaceWordTbl[i, 0], replaceWordTbl[i, 1]);
            }

            var t = string.Format("{0} {1}", exe, stl);
            //writer.WriteLine(t);

            var startInfo = new ProcessStartInfo()
            {
                Arguments = stl,
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName = exe
                
            };
            //Console.Write(exe + " " + stl +"\n");            
            try
            {
                var process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
              //  writer.Close();
                Environment.Exit(process.ExitCode);
            } catch (Exception e)
            {                      
                //writer.WriteLine(e.Message);
                //writer.Close();
                Environment.Exit(1);
            }
        }
    }
}
