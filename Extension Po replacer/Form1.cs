using System;
using System.Windows.Forms;
using System.IO;

namespace Extension_Po_replacer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///load file
            OpenFileDialog Dialogloadfile = new OpenFileDialog();
            Dialogloadfile.Filter = "PO檔案|*.po|TXT|*.txt";
            Dialogloadfile.Title = "最早時間點的檔案";
            Dialogloadfile.ShowDialog();
            ///the string of path
            string path = Dialogloadfile.FileName;
            FileStream loadfile = new FileStream(path, FileMode.Open);
            ///count the number of file
            int Old_File_FstCount = 0, Old_File_SecCount = 0;
            ///stream reader
            string tempWords, tempWords2;
            StreamReader reader = new StreamReader(loadfile);
            while (reader.EndOfStream != true)
            {

                if (Convert.ToString(reader.Peek()) == "35")
                {
                    reader.ReadLine();

                    if (reader.Peek() == 109)
                    {
                        reader.ReadLine();
                        if (reader.Peek() == 109)
                        {
                            reader.ReadLine();
                            Old_File_FstCount++;
                        }
                    }

                }

                else
                {
                    reader.ReadLine();
                }

            }

            ///-----------------------------------------------------------------------------------------///

            OpenFileDialog Dialogloadfile2 = new OpenFileDialog();

            Dialogloadfile2.ShowDialog();

            string path2 = Dialogloadfile2.FileName;
            FileStream loadfile2 = new FileStream(path2, System.IO.FileMode.Open);

            int New_File_FstCount = 0, New_File_SecCount = 0;
            StreamReader reader2 = new StreamReader(loadfile2);

            while (reader2.EndOfStream != true)
            {

                if (Convert.ToString(reader2.Peek()) == "35")
                {
                    reader2.ReadLine();
                    if (reader2.Peek() == 109)
                    {
                        reader2.ReadLine();
                        if (reader2.Peek() == 109)
                        {
                            reader2.ReadLine();
                            New_File_FstCount++;
                        }
                    }

                }

                else
                {
                    reader2.ReadLine();
                }

            }


            /// pe te lai output e array



            ///-----------------------------------------------------------------------------------------///

            OpenFileDialog Dialogloadfile3 = new OpenFileDialog();

            Dialogloadfile3.ShowDialog();

            string path3 = Dialogloadfile3.FileName;
            FileStream loadfile3 = new FileStream(path3, System.IO.FileMode.Open);

            int Mass_File_FstCount = 0, Mass_File_SecCount = 0;
            StreamReader reader3 = new StreamReader(loadfile3);

            while (reader3.EndOfStream != true)
            {

                if (Convert.ToString(reader3.Peek()) == "35")
                {
                    reader3.ReadLine();
                    if (reader3.Peek() == 109)
                    {
                        reader3.ReadLine();
                        if (reader3.Peek() == 109)
                        {
                            reader3.ReadLine();
                            Mass_File_FstCount++;
                        }
                    }

                }

                else
                {
                    reader3.ReadLine();
                }

            }




            label1.Text = Convert.ToString(Old_File_FstCount);
            label2.Text = Convert.ToString(New_File_FstCount);
            /// 直接比較三個字的大小
            int pituase1 = New_File_FstCount, pituase2 = Old_File_FstCount, pituase3 = Mass_File_FstCount, pituaseTemp = 0;
            for (int i = 0; i < 2; i++)
            {
                if (pituase1 < pituase2)
                {
                    pituaseTemp = pituase1;
                    pituase1 = pituase2;
                    pituase2 = pituaseTemp;
                }
                if (pituase2 < pituase3)
                {
                    pituaseTemp = pituase3;
                    pituase3 = pituase2;
                    pituase2 = pituaseTemp;
                }
            }


            string[,] FileToBeCompare = new string[6, pituase1];


            ///  reader.Dispose();

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            ///reader = new StreamReader(loadfile);

            while (reader.EndOfStream != true)
            {

                if (Convert.ToString(reader.Peek()) == "35")
                {
                    reader.ReadLine();
                    if (reader.Peek() == 109)
                    {
                        tempWords = reader.ReadLine();
                        if (reader.Peek() == 109)
                        {
                            tempWords2 = reader.ReadLine();

                            FileToBeCompare[0, Old_File_SecCount] = tempWords;
                            FileToBeCompare[1, Old_File_SecCount] = tempWords2;
                            Old_File_SecCount++;
                        }
                    }

                }

                else
                {
                    reader.ReadLine();
                }

            }


            ///  reader.Dispose();

            reader2.BaseStream.Seek(0, SeekOrigin.Begin);
            ///reader = new StreamReader(loadfile);

            while (reader2.EndOfStream != true)
            {

                if (Convert.ToString(reader2.Peek()) == "35")
                {
                    reader2.ReadLine();
                    if (reader2.Peek() == 109)
                    {
                        tempWords = reader2.ReadLine();
                        if (reader2.Peek() == 109)
                        {

                            tempWords2 = reader2.ReadLine();
                            FileToBeCompare[2, New_File_SecCount] = tempWords;
                            FileToBeCompare[3, New_File_SecCount] = tempWords2;
                            New_File_SecCount++;
                        }
                    }

                }

                else
                {
                    reader2.ReadLine();
                }

            }
            loadfile2.Close();
            string[] arraychen = File.ReadAllLines(path2);

            string[] massedString = new string[pituase1];

            ///  reader.Dispose();

            reader3.BaseStream.Seek(0, SeekOrigin.Begin);
            ///reader = new StreamReader(loadfile);

            while (reader3.EndOfStream != true)
            {

                if (Convert.ToString(reader3.Peek()) == "35")
                {
                    reader3.ReadLine();
                    if (reader3.Peek() == 109)
                    {
                        tempWords = reader3.ReadLine();
                        if (reader3.Peek() == 109)
                        {

                            tempWords2 = reader3.ReadLine();
                            FileToBeCompare[4, Mass_File_SecCount] = tempWords;
                            FileToBeCompare[5, Mass_File_SecCount] = tempWords2;
                            Mass_File_SecCount++;
                        }
                    }

                }

                else
                {
                    reader3.ReadLine();
                }
            }

            for (int o = 1; o < pituase1; o++)
            {
                for (int c = 1; c < pituase1; c++)
                {
                    ///比較C跟A的英文
                    if (String.Compare(FileToBeCompare[0, o], FileToBeCompare[2, c], false) == 0)
                    {
                        for (int r = 0; r < pituase1; r++)
                        {
                            /// 比較C跟A的英文
                            ///    C         B              A
                            /// 最舊版     破壞版 	  最新版

                            if (String.Compare(FileToBeCompare[0, o], FileToBeCompare[4, r], false) == 0)
                            {
                                /// 比較B和C的漢字
                                if (String.Compare(FileToBeCompare[1, o], FileToBeCompare[5, r], false) != 0)
                                {
                                    /// 比較B和A的漢字
                                    if (String.Compare(FileToBeCompare[3, c], FileToBeCompare[5, r], false) == 0)
                                    {
                                        

                                        if (String.Compare(FileToBeCompare[1, o], FileToBeCompare[1, 0], false) == 0)
                                        {
                                            for (int replacerD = 0, an = 0; replacerD < arraychen.Length; replacerD++)

                                            {
                                                if (string.Compare(arraychen[replacerD], FileToBeCompare[2, c], false) == 0)
                                                {
                                                    arraychen[replacerD + 1] = FileToBeCompare[3, c];

                                                    massedString[an] = FileToBeCompare[3, c];
                                                    an++;
                                                    replacerD++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int replacerA = 0; replacerA < arraychen.Length; replacerA++)

                                        {
                                            if (string.Compare(arraychen[replacerA], FileToBeCompare[2, c], false) == 0)
                                            {
                                                arraychen[replacerA + 1] = FileToBeCompare[1, o];
                                                replacerA++;
                                            }
                                        }

                                    }
                                    }

                                    else
                                    {

                                        

                                        for (int replacerB = 0; replacerB < arraychen.Length; replacerB++)

                                        {
                                            if (string.Compare(arraychen[replacerB], FileToBeCompare[2, c], false) == 0)
                                            {
                                                arraychen[replacerB + 1] = FileToBeCompare[3, c];
                                                replacerB++;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                   

                                    for (int replacerC = 0; replacerC < arraychen.Length; replacerC++)

                                    {
                                        if (string.Compare(arraychen[replacerC], FileToBeCompare[2, c], false) == 0)
                                        {
                                            arraychen[replacerC + 1] = FileToBeCompare[3, c];
                                            replacerC++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }



            FileStream writing = new FileStream("output.po", FileMode.Create);

            //FileStream massstringwriting = new FileStream("problemstring.po", FileMode.Create);
            //StreamWriter massstirngwriter = new StreamWriter(massstringwriting);
            StreamWriter writer = new StreamWriter(writing);
            for (int xd = 0; xd < arraychen.Length; xd++)

            {
                writer.WriteLine(arraychen[xd]);

            }
            //for (int xP = 0; xP < massedString.Length; xP++)

            //{
            //   massstirngwriter.WriteLine(massedString[xP]);

            //}
            //massstringwriting.Flush();
            //massstringwriting.Close();
            writing.Flush();
            writer.Close();
            writing.Close();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
