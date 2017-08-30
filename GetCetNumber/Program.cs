using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using CET4;
using CET6;

namespace GetCetNumber
{
    class Program
    {
        private static Stopwatch watch = new Stopwatch();

        private static int intStudentsCount = 275;

        private static string[] strName = new string[intStudentsCount];
        private static string[] strCet = new string[intStudentsCount];

        private static Student4[] stu4 = new Student4[intStudentsCount];
        private static Student6[] stu6 = new Student6[intStudentsCount];
        //MySchool, MyClass
        private static string pathName = "d:\\CET\\MySchool\\Name.txt";
        private static string pathCet = "d:\\CET\\MySchool\\text.txt";
        private static string pathCet4 = "d:\\CET\\MySchool\\cet4.txt";
        private static string pathCet6 = "d:\\CET\\MySchool\\cet6.txt";

        /// <summary>
        /// 获取姓名列表
        /// </summary>
        private static void ReadName()
        {
            FileStream fs = new FileStream(pathName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; sr.EndOfStream != true ; i++)
            {
                strName[i] = sr.ReadLine();
            }

            sr.Close();
        }

        /// <summary>
        /// 切割cet4
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static Student4 CutNumber4(string temp)
        {
            string[] str = temp.Split(':');
            Student4 stuTemp = new Student4()
            {
                Name = Convert.ToString(str[0]),
                Cet = Convert.ToString(str[1]),
            };

            return stuTemp;
        }

        /// <summary>
        /// 切割cet6
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static Student6 CutNumber6(string temp)
        {
            string[] str = temp.Split(':');
            Student6 stuTemp = new Student6()
            {
                Name = Convert.ToString(str[0]),
                Cet = Convert.ToString(str[1]),
            };

            return stuTemp;
        }

        /// <summary>
        /// 获取四级准考证列表
        /// </summary>
        private static void ReadCet4()
        {
            FileStream fs = new FileStream(pathCet4, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            string strTemp = string.Empty;

            for (int i = 0; sr.EndOfStream != true ; i++)
            {
                strTemp = sr.ReadLine();
                stu4[i] = CutNumber4(strTemp);
            }

            sr.Close();
        }

        /// <summary>
        /// 获取六级准考证列表
        /// </summary>
        private static void ReadCet6()
        {
            FileStream fs = new FileStream(pathCet6, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            string strTemp = string.Empty;

            for (int i = 0; sr.EndOfStream != true; i++)
            {
                strTemp = sr.ReadLine();
                stu6[i] = CutNumber6(strTemp);
            }

            sr.Close();
        }

        static void Main(string[] args)
        {
            ReadCet4();
            ReadCet6();
            ReadName();

            watch.Start();

            FileStream fs = new FileStream(pathCet, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            int intCount = 1;

            for (int i = 0; i < strName.Length; i++)
            {
                foreach (var item in stu4)
                {
                    if (strName[i] == item.Name)
                    {
                        Console.WriteLine("{0,-4} {1}",(intCount++).ToString(), item.Name +"\t" + item.Cet);
                        //sw.WriteLine("{0,-4} {1}", (intCount++).ToString(), item.Name + "\t" + item.Cet);
                        break;
                    }             
                }
                foreach (var item in stu6)
                {
                    if (strName[i] == item.Name)
                    {
                        Console.WriteLine("{0,-4} {1}", (intCount++).ToString(), item.Name + "\t" + item.Cet);
                        //sw.WriteLine("{0,-4} {1}", (intCount++).ToString(), item.Name + "\t" + item.Cet);
                        break;
                    }
                }
            }

            watch.Stop();
            Console.WriteLine(((double)watch.ElapsedMilliseconds/1000).ToString());

            sw.Close();

            Console.WriteLine("输入任意键退出");
            Console.ReadKey(true);       
        }
    }
}
