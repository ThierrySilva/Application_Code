using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Code
{   

    public partial class Default : System.Web.UI.Page
    {

        public string applicationDirectory;
        public string PathToOut;
        public string PathToSave;
        public ArrayList LinkList = new ArrayList();
        public ArrayList ValuesList = new ArrayList();
        public DateTime DataStart;
        public DateTime actualTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            var actualDay = DateTime.Now.Day;
            var actualMonth = DateTime.Now.Month;
            var actualHour = 22;
            var actualMinute = 30;
            DataStart = new DateTime(DateTime.Now.Year, actualMonth, actualDay,
                                        actualHour, actualMinute, 00);
        }

        protected void SalvarButton_Click(object sender, EventArgs e)
        {
try
{
                applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = FileUpload1.PostedFile.FileName;
                string PathToSave = @"Input\";
                ValuesList.Clear();
                if (fileName != "")
                {
                    if (!Directory.Exists(applicationDirectory + PathToSave))
                    {
                        Directory.CreateDirectory(applicationDirectory + PathToSave);
                    }
                    FileUpload1.SaveAs(applicationDirectory + PathToSave + fileName);
                    CreateEmailCard(applicationDirectory + PathToSave + fileName);

                }

                else
                {


                }

            }
            catch (IOException error)
            {
                Console.WriteLine("Falha ao ler o arquivo");
                Console.WriteLine(error.Message);
            }

        }

        private void CreateEmailCard(string archievePath)
        {
            using (StreamReader readerArchieve = new StreamReader(archievePath))
            {
                var ActualArchieve = new List<string>();
                var AuxiliarArray = new List<string>();
                var DuplicatedArray = new List<string>();
                var RemovedArray = new List<string>();

                int contAux = 0;
                int contArchieve = 1;
                int totalArchieves = 0;
                string Line;
                int TotalLines = File.ReadAllLines(archievePath).Length;


                for (int lineNumber = 0; lineNumber < TotalLines; lineNumber++)
                {
                    Line = readerArchieve.ReadLine();
                    if (Line.Trim() != "")
                        AuxiliarArray.Add(Line);
                }
                if (AuxiliarArray.Count % 5 == 0)
                    totalArchieves = AuxiliarArray.Count / 5;
                else
                    totalArchieves = (AuxiliarArray.Count / 5) + 1;

                while (contArchieve <= totalArchieves)
                {

                    if ((ActualArchieve.Count < 5) && (contAux < AuxiliarArray.Count))
                    {
                        if ((DuplicatedArray.Count > 0) &&
                            (VerifyDuplicate(ActualArchieve, DuplicatedArray)) &&
                            (contArchieve < totalArchieves))
                        {
                            foreach (string lineArray in DuplicatedArray)
                            {
                                if (!(ActualArchieve.Contains(lineArray.Trim())))
                                {
                                    ActualArchieve.Add(lineArray);
                                    RemovedArray.Add(lineArray);
                                }
                            }
                            foreach (string removed in RemovedArray)
                            {

                                DuplicatedArray.Remove(removed);
                            }
                            DuplicatedArray.Clear();
                        }
                        else
                        {

                            if (!(ActualArchieve.Contains(AuxiliarArray[contAux].Trim())))
                            {
                                ActualArchieve.Add(AuxiliarArray[contAux].Trim());
                            }
                            else
                            {
                                DuplicatedArray.Add(AuxiliarArray[contAux].Trim());
                            }
                            contAux++;

                        }

                    }

                    else
                    {
                        if (contArchieve == totalArchieves)
                        {
                            while (DuplicatedArray.Count > 0)
                            {
                                foreach (string lineArray in DuplicatedArray)
                                {
                                    if (!(ActualArchieve.Contains(lineArray)))
                                    {
                                        ActualArchieve.Add(lineArray);
                                        RemovedArray.Add(lineArray);
                                    }
                                }
                                foreach (string removedFinal in RemovedArray)
                                {

                                    DuplicatedArray.Remove(removedFinal);
                                }

                                GenerateCard(ActualArchieve, contArchieve);
                                ActualArchieve.Clear();
                                RemovedArray.Clear();
                                contArchieve++;
                            }

                        }
                        else
                        {
                            GenerateCard(ActualArchieve, contArchieve);
                            ActualArchieve.Clear();
                            contArchieve++;
                        }

                    }
                }
            }
            CreateJavascriptArray(LinkList);
            CreateRepeater();
        }

        private void CreateRepeater()
        {
            Repeater1.DataSource = ValuesList;
            Repeater1.DataBind();
        }

        private void GenerateRepeater(List<string> actualArchieve, int contArchieve)
        {
            
            int counter = 0;
            PositionData arrLines = new PositionData();
            arrLines.File = "Sessão " + contArchieve.ToString() + ".txt";

            if (contArchieve == 1)
            {
                actualTime = DataStart.AddDays(1);
            }
            else
            {
                if (actualTime.TimeOfDay.ToString() == "00:00:00")
                {
                    TimeSpan dfTime = new TimeSpan(22, 30, 0);
                    actualTime = actualTime.Date + dfTime;
                    actualTime = actualTime.AddDays(1);
                }
                else
                {
                    actualTime = actualTime.AddMinutes(30);
                }
            }



            
            

            arrLines.DaySession = actualTime.ToString("dd:mm:yyyy");
            arrLines.TimeSession = actualTime.ToString("HH:mm");


            _ = counter < actualArchieve.Count ? arrLines.Line1 = actualArchieve[counter] : arrLines.Line1 = "";
            counter++;
            _ = counter < actualArchieve.Count ? arrLines.Line2 = actualArchieve[counter] : arrLines.Line2 = "";
            counter++;
            _ = counter < actualArchieve.Count ? arrLines.Line3 = actualArchieve[counter] : arrLines.Line3 = "";
            counter++;
            _ = counter < actualArchieve.Count ? arrLines.Line4 = actualArchieve[counter] : arrLines.Line4 = "";
            counter++;
            _ = counter < actualArchieve.Count ? arrLines.Line5 = actualArchieve[counter] : arrLines.Line5 = "";
            counter++;


            arrLines.Link = PathToOut + contArchieve + ".txt";

            ValuesList.Add(arrLines);


        }

        private bool VerifyDuplicate(List<string> actualArchieve, List<string> duplicatedArray)
        {
            bool returnStr = false;
            for (int cont = 0; cont < duplicatedArray.Count; cont++)
            {
                if (!(actualArchieve.Contains(duplicatedArray[cont])))
                {
                    returnStr = true;
                }
            }

            return returnStr;
        }

        private void GenerateCard(List<string> actualArchieve, int archNumber)
        {

            PathToOut = @"Output\";
            string pathToDownload = applicationDirectory.Replace(@"\", @"\\") + "\\" + PathToOut.Replace(@"\", @"\\") + archNumber.ToString() + ".txt";
            if (!Directory.Exists(applicationDirectory + PathToOut))
            {
                Directory.CreateDirectory(applicationDirectory + PathToOut);
            }
            using (StreamWriter writeArchieve = new StreamWriter(applicationDirectory + PathToOut + @"\" + archNumber + ".txt"))
            {
                foreach (string ArchieveLine in actualArchieve)
                {
                    writeArchieve.WriteLine(ArchieveLine.Trim());
                }
            }

            LinkList.Add(pathToDownload);
            GenerateRepeater(actualArchieve, archNumber);


        }

        private void CreateJavascriptArray(ArrayList copyArchieveList)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("var _cardpathSend = [];");
            foreach (string st in copyArchieveList)
            {
                sb.Append("_cardpathSend.push('" + st + "');");
            }


            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "ArrayScript", sb.ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Script", "textGenerate()", true);

        }
    }
}