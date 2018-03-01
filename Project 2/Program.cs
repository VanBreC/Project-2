// Brendan VandeVoorde
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 the first git starts when im already pretty far with the program
 since i was having trouble uploading this to git i ended up copying it and pasting it
 in a new project.
 Also AJ Thompson was kind enough to send me his code to look at since i was having trouble
 ill put comments at points were i used part of his code, i did what i could to change some parts
 so it wouldnt be just a copy paste of his code but i couldnt find a way to make certain parts work unless it was just like his code
*/

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
            // used from AJ's code to write the file
            using (StreamWriter FileWrite = new StreamWriter(newFilepath))
            {
                List1(ref ListAdd, FileWrite);
                FileWrite.WriteLine();
                Attending(ref ListAdd, FileWrite);
                FileWrite.WriteLine();
            }

            
            return;
        }
        //part of aj's code used here
        public static void List1(ref List<SBList1> ListAdd, StreamWriter FillInfo)
        {
            FillInfo.WriteLine("Winning Team of Each Super Bowl");
            FillInfo.WriteLine();
            for (var x = 0; x < ListAdd.Count; x++)
            {
                SBList1.FillInfo(ListAdd[x], FillInfo);
            }
            FillInfo.WriteLine("----- End of Winning Team List");
            FillInfo.WriteLine();
            return;
        }
        // part of aj's code, i changed the way its written to be written like the class example
        public static void Attending(ref List<SBList1> ListAdd, StreamWriter FileWrite)
        {
            var AttendList = (from order in ListAdd
                              orderby order.attendance descending
                              select order).Take(5).ToList();
            FileWrite.WriteLine("Top Attended Super Bowls");
            FileWrite.WriteLine();

            for (var x = 0; x < AttendList.Count(); x++ )
            {
                FileWrite.WriteLine($"- Date: {AttendList[x].date}");
                FileWrite.WriteLine($"- Winning Team: {AttendList[x].tWinner}");
                FileWrite.WriteLine($"- Losing Team: {AttendList[x].tLoser}");
                FileWrite.WriteLine($"- City: {AttendList[x].city}");
                FileWrite.WriteLine($"- State: {AttendList[x].state}");
                FileWrite.WriteLine($"- Stadium: {AttendList[x].stadium}");
                FileWrite.WriteLine();
            }
            FileWrite.WriteLine("----- End of Top Attended Super Bowls");
            FileWrite.WriteLine();
            FileWrite.WriteLine();
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
    //part of aj's code, i changed the way its written to be written like the class example
    public static void FillInfo(SBList1 ListAdd, StreamWriter FillInfo)
    {
        FillInfo.WriteLine($"- Winning Team: {ListAdd.tWinner}\n");
        FillInfo.WriteLine($"- Date: {ListAdd.date}\n");
        FillInfo.WriteLine($"- Winning Quarterback: {ListAdd.qbWinner}\n");
        FillInfo.WriteLine($"- Winning Coach: {ListAdd.cWinner}\n");
        FillInfo.WriteLine($"- MVP: {ListAdd.MVP}\n");
        FillInfo.WriteLine($"- Point Difference: {ListAdd.winPoints - ListAdd.losePoints}\n");
        FillInfo.WriteLine();
        
        return;
    }

}


