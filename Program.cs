using System;
using System.Collections.Generic;
using System.IO;

namespace fileDeleter
{
    class Program
    {
        static void Main(string[] args)
        {
            // this program will remove some specificated file that will come of the args[]
            // -p flag for path
            // -e for extenstion
            // -n for name
            string path = null;
            var extenstion = string.Empty;
            var fileName = string.Empty;
            for (int i = 0 ; i < args.Length; i++) {
                var current = args[i].Trim();
                if (current == "-p") {
                   
                    if (i + 1 >= args.Length)
                        Console.WriteLine("path ro vared bokon ;/");
                    else 
                        path = args[++i].Trim();
                } else if (current == "-e") {
                    if (i + 1 >= args.Length)
                        Console.WriteLine("alaan mn bayad chio hazf knm dqiqn ?????????");
                    else {
                        var next = args[++i].Trim().Replace("'","");
                        if (next.Length > 1) {
                            if (next[0] == '.') {
                                extenstion = next;
                            }else 
                                Console.WriteLine("professor , pasvande ba '.' shorooe mishe");
                        }else {
                            Console.WriteLine("na namoosan in pasvande ke vared kardi ? ;/");
                        }
                    }
                }else if (current == "-n") {
                    fileName = current;
                }
            }
            path = path ?? System.Environment.CurrentDirectory;
            if (string.IsNullOrEmpty(fileName) && string.IsNullOrEmpty(extenstion)) {
                Console.WriteLine("ridi golm");
            }else {
                Console.WriteLine("khob besmellah : ");
                var names = new List<string>();
                if (Directory.Exists(path)) {
                    if (!string.IsNullOrEmpty(extenstion))
                        names.AddRange(Directory.GetFiles(path,"*" + extenstion));
                    if (!string.IsNullOrEmpty(fileName))
                        names.AddRange(Directory.GetFiles(path , fileName));
                    foreach (var item in names){
                       if (File.Exists(item)) {
                            File.Delete(item);
                            Console.WriteLine($"{item} raft peye karesh");
                       }else {
                            Console.WriteLine($"khaste nabashe , {item} peyda nashod D:");
                       }
                    }     
                }else {
                    Console.WriteLine("masir peyda nashod daw");
                }
            }
        }
    }
}
