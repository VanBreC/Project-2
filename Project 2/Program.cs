using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_2_1_
{
    class Program
    {
        

        
        static void Main()
        {
            List<SBList1> ListAdd = new List<SBList1>();
            SBList1 sbInfo;

            //
            const char DELIMITER = ',';
            string[] columns;
            const string FilePath = @"C:\Users\vanbrec\Documents\Advance Programing\Visual Studio 2017\Projects\Project 2\Project 2\Super_Bowl_Project.csv";
            string newFilepath = @"C:\Users\vanbrec\Documents\Advance Programing\Visual Studio 2017\Projects\Project 2\Project 2\List.txt";
            
            //"SuperBowlLists.txt"
            try
            {

                FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                reader.ReadLine();




                while (!reader.EndOfStream)
                {
                    
                    columns = reader.ReadLine().Split(DELIMITER);
                    sbInfo = new SBList1(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6], columns[7], columns[8], columns[9], columns[10], columns[11], columns[12], columns[13], columns[14]);
                    
                    ListAdd.Add(sbInfo);

                }

                reader.Close();
                file.Close();


            }
            catch (Exception i)
            {
                Console.WriteLine(i.Message);
            }
            using (StreamWriter FileWrite = new StreamWriter(newFilepath))
            {
                List1(ref ListAdd, FileWrite);
                FileWrite.WriteLine();
            }

            
            return;
        }

        public static void List1(ref List<SBList1> ListAdd, StreamWriter FillInfo)
        {
            FillInfo.WriteLine("All SuperBowl Winners");
            FillInfo.Write("{0, -25}", "Winning Team");
            FillInfo.Write("{0, -6}", "Year");
            FillInfo.Write("{0, -30}", "Winning QB");
            FillInfo.Write("{0, -25}", "Winning Coach");
            FillInfo.Write("{0, -30}", "MVP");
            FillInfo.Write("{0, -10}", "Score Diff");
            FillInfo.WriteLine("\n\n");
            for (var x = 0; x < ListAdd.Count; x++)
            {
                SBList1.FillInfo(ListAdd[x], FillInfo);
            }
            return;
        }
    }
}
class SBList1
{
    public string date { get; set; }
    public string sbNumber { get; set; }
    public int attendance { get; set; }
    public string qbWinner { get; set; }
    public string cWinner { get; set; }
    public string tWinner { get; set; }
    public int winPoints { get; set; }
    public string qbLoser { get; set; }
    public string cLoser { get; set; }
    public string tLoser { get; set; }
    public int losePoints { get; set; }
    public string MVP { get; set; }
    public string stadium { get; set; }
    public string city { get; set; }
    public string state { get; set; }



    public SBList1(string date, string sbNumber, string attendance, string qbWinner, string cWinner, string tWinner, string winPoints, string qbLoser, string cLoser, string tLoser, string losePoints, string MVP, string stadium, string city, string state)
    {
        this.date = date;
        this.sbNumber = sbNumber;
        this.attendance = int.Parse(attendance);
        this.qbWinner = qbWinner;
        this.cWinner = cWinner;
        this.tWinner = tWinner;
        this.winPoints = int.Parse(winPoints);
        this.qbLoser = qbLoser;
        this.cLoser = cLoser;
        this.tLoser = tLoser;
        this.losePoints = int.Parse(losePoints);
        this.MVP = MVP;
        this.stadium = stadium;
        this.city = city;
        this.state = state;


    }
    public static void FillInfo(SBList1 ListAdd, StreamWriter FillInfo)
    {
        //FillInfo.Write(ListAdd.tWinner, "\n");
        //FillInfo.Write( ListAdd.date, "\n");
        //FillInfo.Write( ListAdd.qbWinner, "\n");
        //FillInfo.Write( ListAdd.cWinner, "\n");
        //FillInfo.Write( ListAdd.MVP, "\n");
       // FillInfo.Write( Convert.ToString(ListAdd.winPoints - ListAdd.losePoints), "\n");
        FillInfo.Write($"Winning Team: {ListAdd.tWinner}");
        FillInfo.WriteLine();
        return;
    }

}


