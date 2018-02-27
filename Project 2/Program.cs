using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_2_1_
{
    public class FileRead
    {
        static void Main()
        {
            FileInfo();
        }
        public static void FileInfo()
        {

            List<SBList1> stuff = new List<SBList1>();

            SBList1 sbInfo;

            const char DELIMITER = ',';
            string[] columns;
            const string FilePath = @"C:\Users\vanbrec\Documents\Visual Studio 2017\Projects\Project 2(1)\Project 2(1)\bin\Debug\Super_Bowl_Project.csv";
            FileStream newfile = new FileStream("SuperBowlLists.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(newfile);
            try
            {

                FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                reader.ReadLine();




                while (!reader.EndOfStream)
                {
                    columns = reader.ReadLine().Split(DELIMITER);
                    sbInfo = new SBList1(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6], columns[7], columns[8], columns[9], columns[10], columns[11], columns[12], columns[13]);



                    stuff.Add(sbInfo);


                }




                writer.Close();
                reader.Close();
                file.Close();
                newfile.Close();

            }
            catch (Exception i)
            {
                Console.WriteLine(i.Message);
            }

        }
        class SBList1
        {
            public string date { get; set; }
            public string sbNumber { get; set; }
            public string attendance { get; set; }
            public string qbWinner { get; set; }
            public string cWinner { get; set; }
            public string tWinner { get; set; }
            public string winPoints { get; set; }
            public string qbLoser { get; set; }
            public string cLoser { get; set; }
            public string losePoints { get; set; }
            public string MVP { get; set; }
            public string stadium { get; set; }
            public string city { get; set; }
            public string state { get; set; }



            public SBList1(string date, string sbNumber, string attendance, string qbWinner, string cWinner, string tWinner, string winPoints, string qbLoser, string cLoser, string losePoints, string MVP, string stadium, string city, string state)
            {
                this.date = date;
                this.sbNumber = sbNumber;
                this.attendance = attendance;
                this.qbWinner = qbWinner;
                this.cWinner = cWinner;
                this.tWinner = tWinner;
                this.winPoints = winPoints;
                this.qbLoser = qbLoser;
                this.cLoser = cLoser;
                this.losePoints = losePoints;
                this.MVP = MVP;
                this.stadium = stadium;
                this.city = city;
                this.state = state;


            }


        }
    }

}
/*
  public string date { get; set; }
            public string sbNumber { get; set; }
            public int attendance { get; set; }
            public string qbWinner { get; set; }
            public string cWinner { get; set; }
            public string tWinner { get; set; }
            public int winPoints { get; set; }
            public string qbLoser { get; set; }
            public string cLoser { get; set; }
            public int losePoints { get; set; }
            public string MVP { get; set; }
            public string stadium { get; set; }
            public string city { get; set; }
            public string state { get; set; }



    Opening repositories:
C:\Users\vanbrec\Documents\Visual Studio 2017\Projects\Project 2(1)
Error encountered while pushing branch to the remote repository: Git failed with a fatal error.
HttpRequestException encountered.
   An error occurred while sending the request.
cannot spawn askpass: No such file or directory
could not read Username for 'https://github.com': terminal prompts disabled
Pushing to https://github.com/VanBreC/Project-2.git
*/

