//this program written by MuMMy.
using System;
//added namespaces
using System.Collections;
using System.Threading;

namespace ConsoleUI_byMuMMy
{
    class students
    {
        public ArrayList stuNo = new ArrayList(), stuName = new ArrayList(), stuAddress = new ArrayList(), stuDepartment = new ArrayList()
        , stuMidterm = new ArrayList(), stuAbsences = new ArrayList(), stuFinal = new ArrayList(), stuMakeup = new ArrayList();

        public int totalStudent
        {
            get
            {
                return stuNo.Count;
            }
        }

        public int totalGrade { get; set; }

    }

    class Program
    {
        static students students = new students(); //a student class was created to keep the data
        static string[] options = { "Reg Entry", "Grade Entry", "Listing", "Searching", "Reg Modify", "Grade Modify", "Deletion", "Exit" };
        //menu options set
        //also, additional menu options can be entered here and there is no need to write any graphic code
        //Kernel commands are added to the interiorDisplayCore() function so that codes can be created more flexibly
        static int choice = 1; //the first option is made to be selected by default
        static int consoleWidth = 150, consoleHeight = 50; //console screen sizes adjusted
        static int logoStart = 6;//length of rope hanging down
        static int mainStartLine = 16;//start line specified
        static bool openingLogoEffect = true;//splash screen logo effect
        static bool interiorLogoEffect = true;//interior screen logo effect active

        static void graphicsInterface(ConsoleColor background, bool logoEffect)
        {
            Console.CursorVisible = false;
            //cursor is hidden

            Console.BackgroundColor = background;
            Console.Clear();
            //main background color created

            int effectSpeed = 1;
            int afterLogoWait = 100;

            if (openingLogoEffect)
            {
                effectSpeed = 15;
                afterLogoWait = 1000;
            }

            Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;

            //left frame line starts
            cursor(consoleWidth / 2 - 14, logoStart + 2); wrt(" ");
            cursor(consoleWidth / 2 - 14, logoStart + 3); wrt(" ");
            cursor(consoleWidth / 2 - 14, logoStart + 4); wrt(" ");
            cursor(consoleWidth / 2 - 14, logoStart + 5); wrt(" ");
            cursor(consoleWidth / 2 - 14, logoStart + 6); wrt(" ");
            //left frame line ends

            //right frame line starts
            cursor(consoleWidth / 2 + 13, logoStart + 2); wrt(" ");
            cursor(consoleWidth / 2 + 13, logoStart + 3); wrt(" ");
            cursor(consoleWidth / 2 + 13, logoStart + 4); wrt(" ");
            cursor(consoleWidth / 2 + 13, logoStart + 5); wrt(" ");
            cursor(consoleWidth / 2 + 13, logoStart + 6); wrt(" ");
            //right frame line ends

            //subframe line starts
            cursor(consoleWidth / 2 - 14, logoStart + 6); wrt("                            ");
            //subframe line ends

            if (logoEffect)
            {
                //--in-frame rendering1 starts
                Console.ForegroundColor = background; Console.BackgroundColor = ConsoleColor.White;

                cursor(consoleWidth / 2 - 13, logoStart + 1); wrt("                          ");
                cursor(consoleWidth / 2 - 13, logoStart + 2); wrt("                          ");
                cursor(consoleWidth / 2 - 13, logoStart + 3); wrt("     Grade Info System    ");
                cursor(consoleWidth / 2 - 13, logoStart + 4); wrt("                          ");
                cursor(consoleWidth / 2 - 13, logoStart + 5); wrt("                          ");
                //--in-frame rendering1 ends
            }

            Console.BackgroundColor = background; Console.ForegroundColor = ConsoleColor.White;

            //top thin long rope starts
            cursor(0, 0);
            for (int i = 1; i <= consoleWidth / 2; i++)
            {
                if (logoEffect) Thread.Sleep(effectSpeed);
                wrt("─");
            }
            //top thin long rope ends

            cursor(consoleWidth / 2, 0); wrt("┬");
            //the rope hanging down starts
            for (int i = 1; i <= logoStart; i++)
            {
                if (logoEffect) Thread.Sleep(effectSpeed * 2);
                cursor(consoleWidth / 2, i); wrt("│");
            }
            //the rope hanging down ends

            Console.BackgroundColor = background; Console.ForegroundColor = ConsoleColor.White;

            cursor(consoleWidth / 2 + 1, 0);
            for (int i = 1; i < consoleWidth / 2; i++)
            {
                if (logoEffect) Thread.Sleep(effectSpeed);
                wrt("─");
            }

            if (logoEffect) Thread.Sleep(afterLogoWait);

            cursor(consoleWidth / 2 - 13, logoStart + 5);
            wrt("                          ");

            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                int _ = 0; string M = "by MuMMy";
                cursor(consoleWidth - _ - M.Length, 1); wrt(M);
            }
            //ads

            //--in-frame rendering starts
            Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.White;

            cursor(consoleWidth / 2 - 13, logoStart); wrt("                          ");
            cursor(consoleWidth / 2 - 13, logoStart + 1); wrt("                          ");
            cursor(consoleWidth / 2 - 13, logoStart + 2); wrt("     Grade Info System    ");
            cursor(consoleWidth / 2 - 13, logoStart + 3); wrt("                          ");
            cursor(consoleWidth / 2 - 13, logoStart + 4); wrt("                          ");
            //--in-frame rendering ends

            //--interior screen title and text layout starts
            if (background == ConsoleColor.Black)
            {
                cursor(consoleWidth / 2 - 13, logoStart + 8);
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(options[choice - 1] + " process");
                cursor(0, mainStartLine); Console.ForegroundColor = ConsoleColor.White;
            }
            //--interior screen title and text layout ends
        }

        static void Main(string[] args)
        {
            ConsoleKey key = ConsoleKey.A;//the letter "A" is set as the default first key pressed
            Console.WindowWidth = consoleWidth; Console.WindowHeight = consoleHeight;//console dimensions applied

            do
            {
                if (key == ConsoleKey.DownArrow)
                    choice++;
                else if (key == ConsoleKey.UpArrow)
                    choice--;
                //arrow keys set

                if (choice < 1) choice = options.Length;
                else if (choice > options.Length) choice = 1;
                //if the selection number has come to the end, return to the beginning or if it has come to the beginning, it has been return to the end

                graphicsInterface(ConsoleColor.DarkBlue, openingLogoEffect);
                //main screen created

                openingLogoEffect = false;

                createMenu();
                //menu created

                key = Console.ReadKey().Key;
                //pressed key detected

                if (key == ConsoleKey.Enter)//option selected and loginned to intenior screen
                {
                    try
                    {
                        graphicsInterface(ConsoleColor.Black, interiorLogoEffect);
                        //interior screen design created

                        Console.CursorVisible = true;//cursor is shown

                        interiorDisplayCore();
                        //interior screen commands are executed here

                        Console.CursorVisible = false;//cursor is hidden
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n-Something went wrong!\n[" + ex.GetType().FullName + "] " + ex.Message);
                        //error checks and necessary done
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nPress any key to return to the home screen.");
                    //back to home screen no matter what

                    Console.ReadKey();
                    key = ConsoleKey.A;
                    //key value reset
                }
            }
            while (true);
            //by repeating the loop continuously, key detection from the keyboard has been made infinite
        }

        static void interiorDisplayCore()
        {
            int startLine = mainStartLine;

            if (students.totalStudent == 0 && choice != 1 && choice != 8)
            {
                wrt("No registered student found in the system!\nPlease add new record.\n"); return;
            }
            //if no student has been added, access to the screens that require student addition is denied

            cursor(0, 1); Console.ForegroundColor = ConsoleColor.DarkGreen;
            wrt("Press the (ESC) key to stop the \"" + options[choice - 1] + "\" process.");
            cursor(0, startLine); Console.ForegroundColor = ConsoleColor.Yellow;
            //information message (key) displayed at the top

            int[] k1 = { 0, 16, 48, 88 };//Students
            int[] k2 = { 61, 77, 87 };//Grades
            int[] k3 = { 120, 134 };//Average and Status [also used as initial value, <line break message>] 
            //the starting points of the columns were determined

            if (choice == 1)
            {
                #region choice1
                tableTitle("No", k1[1]);
                tableTitle("Name", k1[2] - k1[1]);
                tableTitle("Address", k1[3] - k1[2]);
                tableTitle("Department", 0);
                wrt("\n");
                //table headers added

                Console.ForegroundColor = ConsoleColor.White;

                int controlNumber = 0;

                startLine++;

                for (int i = 0; i < students.totalStudent; i++)
                {
                    cursor(k1[0], startLine + i); wrt(students.stuNo[i]);
                    cursor(k1[1], startLine + i); wrt(students.stuName[i]);
                    cursor(k1[2], startLine + i); wrt(students.stuAddress[i]);
                    cursor(k1[3], startLine + i); wrt(students.stuDepartment[i]);
                }
                //student records kept in the program are listed

                startLine--;

                while (true)
                {
                    ConsoleKeyInfo keyKontrol;

                    controlNumber++;

                    int gLine = startLine + students.totalStudent;

                    if (controlNumber == 1) cursor(k1[0], gLine + 1);
                    if (controlNumber == 2) cursor(k1[1], gLine);
                    if (controlNumber == 3) cursor(k1[2], gLine);
                    if (controlNumber == 4) cursor(k1[3], gLine);
                    //cursor points set

                    string entry = "";
                    bool output = false;

                    //--the text box starts
                    do
                    {
                        keyKontrol = Console.ReadKey(true);

                        if (keyKontrol.Key == ConsoleKey.Escape)
                        {
                            output = true; break;
                        }
                        //Pressing the ESC key exited the text box

                        if (keyKontrol.Key == ConsoleKey.Backspace)
                        {
                            if (entry != "")
                            {
                                entry = entry.Substring(0, entry.Length - 1);
                                wrt("\b \b");
                            }
                        }
                        //1 character deleted when pressing the backspace key

                        if (controlNumber == 1)
                        {
                            try
                            {
                                if (Convert.ToInt32(keyKontrol.KeyChar.ToString()) >= 0 && entry.Length < 15)
                                {
                                    wrt(keyKontrol.KeyChar);
                                    entry += keyKontrol.KeyChar;
                                }
                            }
                            catch { }
                            //first colon checks done
                        }
                        else
                        {
                            if (((controlNumber == 2 || controlNumber == 4) && entry.Length < 31) || (controlNumber == 3 && entry.Length < 39))
                            {
                                wrt(reverseSlashRemove(keyKontrol.KeyChar.ToString()));
                                entry += reverseSlashRemove(keyKontrol.KeyChar.ToString());
                            }
                            //other columns checks done
                        }
                    }
                    while (keyKontrol.Key != ConsoleKey.Enter);
                    //--text box ends

                    lineClear(0, 2, 60);
                    //message line cleared

                    if (output)
                    {
                        if (students.stuName.Count < students.stuNo.Count
                             || students.stuName.Count < students.stuAddress.Count
                             || students.stuName.Count < students.stuDepartment.Count) students.stuName.Add("");
                        if (students.stuAddress.Count < students.stuName.Count
                             || students.stuAddress.Count < students.stuNo.Count
                             || students.stuAddress.Count < students.stuDepartment.Count) students.stuAddress.Add("");
                        if (students.stuDepartment.Count < students.stuName.Count
                             || students.stuDepartment.Count < students.stuNo.Count
                             || students.stuDepartment.Count < students.stuAddress.Count) students.stuDepartment.Add("");
                        //if there are uninserted values, we ensured the equality of the arrays, preventing them from being corrupted

                        cursor(0, gLine + 1); break;
                        //we finished the process by moving the cursor to the end
                    }

                    if (controlNumber == 1)
                    {
                        if (entry == "")
                        {
                            msgShow("'No' field is required, please enter it.");

                            controlNumber = 0; continue;
                        }

                        if (Array.IndexOf(students.stuNo.ToArray(), entry) >= 0)
                        {
                            lineClear(0, gLine + 1, 15);
                            msgShow("Student number \"" + entry + "\" is already in the system.");

                            controlNumber = 0; continue;
                        }
                        else
                            students.stuNo.Add(entry);
                    }
                    if (controlNumber == 2) students.stuName.Add(entry);
                    if (controlNumber == 3) students.stuAddress.Add(entry);
                    if (controlNumber == 4) { students.stuDepartment.Add(entry); controlNumber = 0; }
                    //added to data layer if values are valid
                }
                #endregion
            }
            if (choice == 2)
            {
                #region choice2
                tableTitle("No", k1[1]);
                tableTitle("Name", k1[2] - k1[1]);
                tableTitle("Midterm", 5);
                tableTitle("Absences", 5);
                tableTitle("Final", 5);
                tableTitle("Make-up Exam", 0);

                wrt("\n");
                Console.ForegroundColor = ConsoleColor.White;

                int controlNumber = 0;

                startLine++;

                for (int i = 0; i < students.totalStudent; i++)
                {
                    cursor(k1[0], startLine + i); wrt(students.stuNo[i]);
                    cursor(k1[1], startLine + i); wrt(students.stuName[i]);
                }
                //student records kept in the program are listed

                for (int i = 0; i < students.totalGrade; i++)
                {
                    cursor(k1[2], startLine + i); wrt(students.stuMidterm[i]);
                    cursor(k2[0], startLine + i); wrt(students.stuAbsences[i]);
                    cursor(k2[1], startLine + i); if (students.stuFinal[i].ToString() != "") wrt(students.stuFinal[i]); else wrt("-");
                    cursor(k2[2], startLine + i); if (students.stuMakeup[i].ToString() != "") wrt(students.stuMakeup[i]); else wrt("-");
                }
                //grade records kept in the program are listed

                int index = students.totalGrade;
                while (students.totalStudent != index)
                {
                    ConsoleKeyInfo keyKontrol;

                    controlNumber++;

                    int gLine = startLine + students.totalGrade;

                    if (controlNumber == 1) cursor(k1[2], gLine);
                    if (controlNumber == 2) cursor(k2[0], gLine);
                    if (controlNumber == 3) cursor(k2[1], gLine);
                    if (controlNumber == 4) cursor(k2[2], gLine);

                    string entry = "";
                    bool output = false;
                    do
                    {
                        keyKontrol = Console.ReadKey(true);

                        if (keyKontrol.Key == ConsoleKey.Escape)
                        {
                            output = true; break;
                        }

                        if (keyKontrol.Key == ConsoleKey.Backspace)
                        {
                            if (entry != "")
                            {
                                entry = entry.Substring(0, entry.Length - 1);
                                wrt("\b \b");
                            }
                        }

                        try
                        {
                            if (Convert.ToInt32(keyKontrol.KeyChar.ToString()) >= 0 && entry.Length < 3)
                            {
                                wrt(keyKontrol.KeyChar);
                                entry += keyKontrol.KeyChar;
                            }

                        }
                        catch { }
                    }
                    while (keyKontrol.Key != ConsoleKey.Enter);

                    if (entry != "" && Convert.ToInt32(entry) > 100) lineClear(Console.CursorLeft - 3, gLine, 3);

                    lineClear(0, 2, 60);

                    if (output)
                    {
                        if (students.stuMidterm.Count > students.stuMakeup.Count)
                            students.stuMidterm.RemoveAt(students.stuMidterm.Count - 1);
                        if (students.stuAbsences.Count > students.stuMakeup.Count)
                            students.stuAbsences.RemoveAt(students.stuAbsences.Count - 1);
                        if (students.stuFinal.Count > students.stuMakeup.Count)
                            students.stuFinal.RemoveAt(students.stuFinal.Count - 1);
                        //when you want to quit, the last values of the midterm, absences and final are deleted.

                        cursor(0, startLine + students.totalStudent);
                        break;
                    }

                    if (entry == "")
                    {
                        msgShow("All fields are required, please enter.");
                        controlNumber--; continue;
                    }

                    if (Convert.ToInt32(entry) > 100)
                    {
                        msgShow("Number must be between 0-100.");

                        entry = "";
                        controlNumber--; continue;
                    }

                    if (controlNumber == 1)
                    {
                        students.stuMidterm.Add(entry);
                    }
                    if (controlNumber == 2)
                    {
                        students.stuAbsences.Add(entry);
                        if (Convert.ToInt32(entry) > 5)
                        {
                            students.stuFinal.Add("");
                            students.stuMakeup.Add("");

                            cursor(k2[1], gLine); wrt("-");
                            cursor(k2[2], gLine); wrt("-");

                            students.totalGrade += 1;
                            controlNumber = 0; index++;
                        }
                    }
                    if (controlNumber == 3)
                    {
                        students.stuFinal.Add(entry);
                        double avg = (Convert.ToInt32(students.stuMidterm[index]) * 0.3) + (Convert.ToInt32(students.stuFinal[index]) * 0.7);
                        if (Convert.ToInt32(entry) >= 50 && avg >= 60)
                        {
                            students.stuMakeup.Add("");
                            cursor(k2[2], gLine); wrt("-");

                            students.totalGrade += 1;
                            controlNumber = 0; index++;
                        }
                    }
                    if (controlNumber == 4)
                    {
                        students.stuMakeup.Add(entry);

                        students.totalGrade += 1;
                        controlNumber = 0; index++;
                    }

                    cursor(0, startLine + students.totalStudent);
                }
                #endregion
            }
            if (choice == 3)
            {
                #region choice3
                tableTitle("No", k1[1]);
                tableTitle("Name", k1[2] - k1[1]);
                tableTitle("Address", k1[3] - k1[2]);
                tableTitle("Department", k1[2] - k1[1]);
                tableTitle("Average", 6);
                tableTitle("Status", 0);

                wrt("\n");
                Console.ForegroundColor = ConsoleColor.White;

                startLine++;

                for (int i = 0; i < students.totalStudent; i++)
                {
                    cursor(k1[0], startLine + i); wrt(students.stuNo[i]);
                    cursor(k1[1], startLine + i); wrt(students.stuName[i]);
                    cursor(k1[2], startLine + i); wrt(students.stuAddress[i]);
                    cursor(k1[3], startLine + i); wrt(students.stuDepartment[i]);
                }
                //student records kept in the program are listed

                for (int i = 0; i < students.totalGrade; i++)
                {
                    int bf = -1;

                    if (students.stuMakeup[i].ToString() == "" && students.stuFinal[i].ToString() != "")
                        bf = Convert.ToInt32(students.stuFinal[i]);
                    else if (students.stuMakeup[i].ToString() != "")
                        bf = Convert.ToInt32(students.stuMakeup[i]);

                    double avg = 0;

                    if (bf != -1)
                        avg = (Convert.ToInt32(students.stuMidterm[i]) * 0.3) + (Convert.ToInt32(bf) * 0.7);

                    cursor(k3[0], startLine + i);
                    if (bf != -1)
                    {
                        wrt(avg);
                    }
                    else wrt("-");

                    cursor(k3[1], startLine + i);
                    if (avg >= 60 && bf >= 50) wrt("Successful");
                    else wrt("Unsuccessful");
                }
                //grade records kept in the program are listed

                cursor(0, startLine + students.totalStudent);

                #endregion
            }
            if (choice == 4)
            {
                #region choice4
                tableTitle("No", k1[1]);
                tableTitle("Name", k1[2] - k1[1]);
                tableTitle("Address", k1[3] - k1[2]);
                tableTitle("Department", k1[2] - k1[1]);
                tableTitle("Average", 6);
                tableTitle("Status", 0);

                wrt("\n");
                Console.ForegroundColor = ConsoleColor.White;

                startLine++;

                ConsoleKeyInfo keyKontrol;
                int index = 0;
                ArrayList foundIndx = new ArrayList();

                while (true)
                {
                    int gLine = startLine + index;

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    lineClear(k1[0], gLine, 15);
                    //search box created

                    string entry = "";
                    bool output = false;
                    do
                    {
                        keyKontrol = Console.ReadKey(true);

                        if (keyKontrol.Key == ConsoleKey.Escape)
                        {
                            output = true;
                            break;
                        }

                        if (keyKontrol.Key == ConsoleKey.Backspace)
                        {
                            if (entry != "")
                            {
                                entry = entry.Substring(0, entry.Length - 1);
                                wrt("\b \b");
                            }
                        }

                        try
                        {
                            if (Convert.ToInt32(keyKontrol.KeyChar.ToString()) >= 0 && entry.Length < 15)
                            {
                                wrt(keyKontrol.KeyChar);
                                entry += keyKontrol.KeyChar;
                            }
                        }
                        catch { }
                    }
                    while (keyKontrol.Key != ConsoleKey.Enter);

                    Console.BackgroundColor = ConsoleColor.Black;
                    lineClear(k1[0], gLine, 15);

                    lineClear(0, 2, 60);

                    if (output)
                    {
                        cursor(0, gLine); break;
                    }

                    if (entry == "")
                    {
                        msgShow("Enter a number to make a search."); continue;
                    }

                    int g = Array.IndexOf(students.stuNo.ToArray(), entry);

                    if (g < 0)
                    {
                        msgShow("Searched record not found!"); continue;
                    }

                    if (Array.IndexOf(foundIndx.ToArray(), g) >= 0)
                    {
                        msgShow("The searched entry is already in the found list!"); continue;
                    }

                    cursor(k1[0], gLine); wrt(students.stuNo[g]);
                    cursor(k1[1], gLine); wrt(students.stuName[g]);
                    cursor(k1[2], gLine); wrt(students.stuAddress[g]);
                    cursor(k1[3], gLine); wrt(students.stuDepartment[g]);

                    if (g < students.totalGrade)
                    {
                        int bf = -1;

                        if (students.stuMakeup[g].ToString() == "" && students.stuFinal[g].ToString() != "")
                            bf = Convert.ToInt32(students.stuFinal[g]);
                        else if (students.stuMakeup[g].ToString() != "")
                            bf = Convert.ToInt32(students.stuMakeup[g]);

                        double avg = 0;

                        if (bf != -1)
                            avg = (Convert.ToInt32(students.stuMidterm[g]) * 0.3) + (Convert.ToInt32(bf) * 0.7);

                        cursor(k3[0], gLine);
                        if (bf != -1)
                        {
                            wrt(avg);
                        }
                        else wrt("-");

                        cursor(k3[1], gLine);
                        if (avg >= 60 && bf >= 50) wrt("Successful");
                        else wrt("Unsuccessful");
                    }
                    //student and grade records kept in the program are listed

                    foundIndx.Add(g);
                    index++;
                }
                #endregion
            }
            if (choice == 5)
            {
                #region choice5
                tableTitle("No", k1[1]);
                tableTitle("Name", k1[2] - k1[1]);
                tableTitle("Address", k1[3] - k1[2]);
                tableTitle("Department", 0);

                wrt("\n");
                Console.ForegroundColor = ConsoleColor.White;

                startLine++;

                ConsoleKeyInfo keyKontrol;
                int index = 0;

                while (true)
                {
                    int gLine = startLine + index;

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    lineClear(k1[0], gLine, 15);
                    //search box created

                    string entry = "";
                    bool output = false;
                    do
                    {
                        keyKontrol = Console.ReadKey(true);

                        if (keyKontrol.Key == ConsoleKey.Escape)
                        {
                            output = true; break;
                        }

                        if (keyKontrol.Key == ConsoleKey.Backspace)
                        {
                            if (entry != "")
                            {
                                entry = entry.Substring(0, entry.Length - 1);
                                wrt("\b \b");
                            }
                        }

                        try
                        {
                            if (Convert.ToInt32(keyKontrol.KeyChar.ToString()) >= 0 && entry.Length < 15)
                            {
                                wrt(keyKontrol.KeyChar);
                                entry += keyKontrol.KeyChar;
                            }
                        }
                        catch { }
                    }
                    while (keyKontrol.Key != ConsoleKey.Enter);

                    Console.BackgroundColor = ConsoleColor.Black;
                    lineClear(k1[0], gLine, 15);

                    lineClear(0, 2, 60);

                    if (output)
                    {
                        cursor(0, gLine); break;
                    }

                    if (entry == "")
                    {
                        msgShow("Please enter a number."); continue;
                    }

                    int g = Array.IndexOf(students.stuNo.ToArray(), entry);

                    if (g < 0)
                    {
                        msgShow("Searched record not found!"); continue;
                    }

                    cursor(k1[0], gLine); wrt(students.stuNo[g]);
                    cursor(k1[1], gLine); wrt(students.stuName[g]);
                    cursor(k1[2], gLine); wrt(students.stuAddress[g]);
                    cursor(k1[3], gLine); wrt(students.stuDepartment[g]);
                    //student records kept in the program are listed

                    wrt("\n\nAre you sure you want to change? (Y): ");

                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        lineClear(0, gLine, consoleWidth);
                        lineClear(0, gLine + 1, consoleWidth);
                        lineClear(0, gLine + 2, consoleWidth);

                        cursor(k1[0], gLine); wrt(students.stuNo[g]);
                        cursor(k1[1], gLine); wrt(students.stuName[g]);
                        cursor(k1[2], gLine); wrt(students.stuAddress[g]);
                        cursor(k1[3], gLine); wrt(students.stuDepartment[g]);

                        int controlNumber = 0;

                        string entry_ = "m";

                        bool edited = false;
                        string ilkNo = students.stuNo[g].ToString();

                        while (true)
                        {
                            ConsoleKeyInfo keyKontrol_;

                            controlNumber++;

                            if (entry_ == "m")
                            {
                                cursor(k1[0] + students.stuNo[g].ToString().Length, gLine); entry_ = students.stuNo[g].ToString();
                            }
                            else if (controlNumber == 1) cursor(k1[0], gLine);
                            if (controlNumber == 2)
                            {
                                cursor(k1[1] + students.stuName[g].ToString().Length, gLine); entry_ = students.stuName[g].ToString();
                            }
                            if (controlNumber == 3)
                            {
                                cursor(k1[2] + students.stuAddress[g].ToString().Length, gLine); entry_ = students.stuAddress[g].ToString();
                            }
                            if (controlNumber == 4)
                            {
                                cursor(k1[3] + students.stuDepartment[g].ToString().Length, gLine); entry_ = students.stuDepartment[g].ToString();
                            }

                            bool output_ = false;
                            do
                            {
                                keyKontrol_ = Console.ReadKey(true);

                                if (keyKontrol_.Key == ConsoleKey.Escape)
                                {
                                    output_ = true; break;
                                }

                                if (keyKontrol_.Key == ConsoleKey.Backspace)
                                {
                                    if (entry_ != "")
                                    {
                                        entry_ = entry_.Substring(0, entry_.Length - 1);
                                        wrt("\b \b");
                                    }
                                }

                                if (controlNumber == 1)
                                {
                                    try
                                    {
                                        if (Convert.ToInt32(keyKontrol_.KeyChar.ToString()) >= 0 && entry_.Length < 15)
                                        {
                                            wrt(keyKontrol_.KeyChar);
                                            entry_ += keyKontrol_.KeyChar;
                                        }
                                    }
                                    catch { }
                                }
                                else
                                {
                                    if (((controlNumber == 2 || controlNumber == 4) && entry_.Length < 31) || (controlNumber == 3 && entry_.Length < 39))
                                    {
                                        wrt(reverseSlashRemove(keyKontrol_.KeyChar.ToString()));
                                        entry_ += reverseSlashRemove(keyKontrol_.KeyChar.ToString());
                                    }
                                }
                            }
                            while (keyKontrol_.Key != ConsoleKey.Enter);

                            lineClear(0, 2, 60);

                            if (output_)
                            {
                                cursor(0, gLine); break;
                            }

                            if (controlNumber == 1)
                            {
                                if (entry_ == "")
                                {
                                    msgShow("'No' field is required, please enter.");

                                    controlNumber = 0; continue;
                                }

                                if (students.stuNo[g].ToString() != entry_ && Array.IndexOf(students.stuNo.ToArray(), entry_) >= 0)
                                {
                                    lineClear(k1[0], gLine, 15);
                                    msgShow("Student number \"" + entry_ + "\" is already in the system.");

                                    entry_ = ""; controlNumber = 0; continue;
                                }
                                else
                                {
                                    students.stuNo[g] = entry_; edited = true;
                                }
                            }
                            if (controlNumber == 2)
                            {
                                students.stuName[g] = entry_; edited = true;
                            }
                            if (controlNumber == 3)
                            {
                                students.stuAddress[g] = entry_; edited = true;
                            }
                            if (controlNumber == 4)
                            {
                                students.stuDepartment[g] = entry_; edited = true;
                                break;
                            }
                        }

                        if (edited)
                        {
                            cursor(k3[0], gLine);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            wrt("<- Successfully changed.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    else
                    {
                        wrt("No"); Thread.Sleep(1000);

                        lineClear(0, gLine, consoleWidth);
                        lineClear(0, gLine + 1, consoleWidth);
                        lineClear(0, gLine + 2, consoleWidth);

                        output = true; continue;
                    }

                    index++;
                }
                #endregion
            }
            if (choice == 6)
            {
                #region choice6
                tableTitle("No", k1[1]);
                tableTitle("Name", k1[2] - k1[1]);
                tableTitle("Midterm", 5);
                tableTitle("Absences", 5);
                tableTitle("Final", 5);
                tableTitle("Make-up Exam", 0);

                wrt("\n");
                Console.ForegroundColor = ConsoleColor.White;

                startLine++;

                ConsoleKeyInfo keyKontrol;
                int index = 0;

                while (true)
                {
                    int gLine = startLine + index;

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    lineClear(k1[0], gLine, 15);
                    //search box created

                    string entry = "";
                    bool output = false;
                    do
                    {
                        keyKontrol = Console.ReadKey(true);

                        if (keyKontrol.Key == ConsoleKey.Escape)
                        {
                            output = true; break;
                        }

                        if (keyKontrol.Key == ConsoleKey.Backspace)
                        {
                            if (entry != "")
                            {
                                entry = entry.Substring(0, entry.Length - 1);
                                wrt("\b \b");
                            }
                        }

                        try
                        {
                            if (Convert.ToInt32(keyKontrol.KeyChar.ToString()) >= 0 && entry.Length < 15)
                            {
                                wrt(keyKontrol.KeyChar);
                                entry += keyKontrol.KeyChar;
                            }
                        }
                        catch { }
                    }
                    while (keyKontrol.Key != ConsoleKey.Enter);

                    Console.BackgroundColor = ConsoleColor.Black;
                    lineClear(k1[0], gLine, 15);

                    lineClear(0, 2, 60);

                    if (output)
                    {
                        cursor(0, gLine); break;
                    }

                    if (entry == "")
                    {
                        msgShow("Please enter a number."); continue;
                    }

                    int g = Array.IndexOf(students.stuNo.ToArray(), entry);

                    if (g < 0)
                    {
                        msgShow("Searched record not found!"); continue;
                    }

                    if (g >= students.stuMidterm.Count)
                    {
                        msgShow("Grade information not found for this student."); continue;
                    }

                    cursor(k1[0], gLine); wrt(students.stuNo[g]);
                    cursor(k1[1], gLine); wrt(students.stuName[g]);
                    //student records kept in the program are listed

                    cursor(k1[2], gLine); wrt(students.stuMidterm[g]);
                    cursor(k2[0], gLine); wrt(students.stuAbsences[g]);
                    cursor(k2[1], gLine); if (students.stuFinal[g].ToString() != "") wrt(students.stuFinal[g]); else wrt("-");
                    cursor(k2[2], gLine); if (students.stuMakeup[g].ToString() != "") wrt(students.stuMakeup[g]); else wrt("-");
                    //grade records kept in the program are listed

                    wrt("\n\nAre you sure you want to change? (Y): ");

                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        lineClear(0, gLine, consoleWidth);
                        lineClear(0, gLine + 1, consoleWidth);
                        lineClear(0, gLine + 2, consoleWidth);

                        cursor(k1[0], gLine); wrt(students.stuNo[g]);
                        cursor(k1[1], gLine); wrt(students.stuName[g]);
                        //student records kept in the program are listed

                        cursor(k1[2], gLine); wrt(students.stuMidterm[g]);
                        cursor(k2[0], gLine); wrt(students.stuAbsences[g]);
                        cursor(k2[1], gLine); if (students.stuFinal[g].ToString() != "") wrt(students.stuFinal[g]); else wrt("-");
                        cursor(k2[2], gLine); if (students.stuMakeup[g].ToString() != "") wrt(students.stuMakeup[g]); else wrt("-");
                        //grade records kept in the program are listed

                        int controlNumber = 0;

                        string entry_ = "m";

                        bool edited = false;

                        while (true)
                        {
                            ConsoleKeyInfo keyKontrol_;

                            controlNumber++;

                            if (entry_ == "m")
                            {
                                cursor(k1[2] + students.stuMidterm[g].ToString().Length, gLine); entry_ = students.stuMidterm[g].ToString();
                            }
                            else if (controlNumber == 1) cursor(k1[2], gLine);
                            if (controlNumber == 2)
                            {
                                if (entry_ == "") cursor(k2[0], gLine);
                                else
                                {
                                    cursor(k2[0] + students.stuAbsences[g].ToString().Length, gLine); entry_ = students.stuAbsences[g].ToString();
                                }
                            }
                            if (controlNumber == 3)
                            {
                                if (entry_ == "") cursor(k2[1], gLine);
                                else
                                {
                                    cursor(k2[1] + students.stuFinal[g].ToString().Length, gLine); entry_ = students.stuFinal[g].ToString();
                                }
                            }
                            if (controlNumber == 4)
                            {
                                if (entry_ == "") cursor(k2[2], gLine);
                                else
                                {
                                    cursor(k2[2] + students.stuMakeup[g].ToString().Length, gLine); entry_ = students.stuMakeup[g].ToString();
                                }
                            }

                            bool output_ = false;
                            do
                            {
                                keyKontrol_ = Console.ReadKey(true);

                                if (keyKontrol_.Key == ConsoleKey.Escape)
                                {
                                    output_ = true; break;
                                }

                                if (keyKontrol_.Key == ConsoleKey.Backspace)
                                {
                                    if (entry_ != "")
                                    {
                                        entry_ = entry_.Substring(0, entry_.Length - 1);
                                        wrt("\b \b");
                                    }
                                }
                                try
                                {
                                    if (Convert.ToInt32(keyKontrol_.KeyChar.ToString()) >= 0 && entry_.Length < 3)
                                    {
                                        wrt(keyKontrol_.KeyChar);
                                        entry_ += keyKontrol_.KeyChar;
                                    }

                                }
                                catch { }
                            }
                            while (keyKontrol_.Key != ConsoleKey.Enter);

                            if (entry_ != "" && Convert.ToInt32(entry_) > 100) lineClear(Console.CursorLeft - 3, gLine, 3);

                            lineClear(0, 2, 60);

                            if (output_)
                            {
                                cursor(0, startLine + students.totalStudent); break;
                            }

                            if (entry_ == "")
                            {
                                msgShow("All fields are required, please enter.");
                                controlNumber--; continue;
                            }

                            if (Convert.ToInt32(entry_) > 100)
                            {
                                msgShow("Number must be between 0-100.");

                                entry_ = "";
                                controlNumber--; continue;
                            }

                            if (controlNumber == 1)
                            {
                                students.stuMidterm[g] = entry_; edited = true;
                            }
                            if (controlNumber == 2)
                            {
                                students.stuAbsences[g] = entry_;

                                if (Convert.ToInt32(entry_) > 5)
                                {
                                    students.stuFinal[g] = "";
                                    students.stuMakeup[g] = "";

                                    lineClear(k2[1], gLine, 15);
                                    cursor(k2[1], gLine); wrt("-");
                                    cursor(k2[2], gLine); wrt("-");

                                    controlNumber = 0; edited = true; break;
                                }
                            }
                            if (controlNumber == 3)
                            {
                                students.stuFinal[g] = entry_;

                                double avg = (Convert.ToInt32(students.stuMidterm[g]) * 0.3) + (Convert.ToInt32(students.stuFinal[g]) * 0.7);
                                if (avg >= 60)
                                {
                                    students.stuMakeup[g] = "";

                                    lineClear(k2[2], gLine, 15);
                                    cursor(k2[2], gLine); wrt("-");

                                    controlNumber = 0; edited = true; break;
                                }
                            }
                            if (controlNumber == 4)
                            {
                                students.stuMakeup[g] = entry_;

                                controlNumber = 0; edited = true; break;
                            }
                        }

                        if (edited)
                        {
                            cursor(k3[0], gLine);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            wrt("<- Successfully changed.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    else
                    {
                        wrt("No"); Thread.Sleep(1000);

                        lineClear(0, gLine, consoleWidth);
                        lineClear(0, gLine + 1, consoleWidth);
                        lineClear(0, gLine + 2, consoleWidth);

                        output = true; continue;
                    }

                    index++;
                }

                #endregion
            }
            if (choice == 7)
            {
                #region choice7
                tableTitle("No", k1[1]);
                tableTitle("Name", k1[2] - k1[1]);
                tableTitle("Address", k1[3] - k1[2]);
                tableTitle("Department", 0);

                wrt("\n");
                Console.ForegroundColor = ConsoleColor.White;

                startLine++;

                ConsoleKeyInfo keyKontrol;

                while (true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    lineClear(k1[0], startLine, 15);
                    //search box created

                    string entry = "";
                    bool output = false;
                    do
                    {
                        keyKontrol = Console.ReadKey(true);

                        if (keyKontrol.Key == ConsoleKey.Escape)
                        {
                            output = true; break;
                        }

                        if (keyKontrol.Key == ConsoleKey.Backspace)
                        {
                            if (entry != "")
                            {
                                entry = entry.Substring(0, entry.Length - 1);
                                wrt("\b \b");
                            }
                        }

                        try
                        {
                            if (Convert.ToInt32(keyKontrol.KeyChar.ToString()) >= 0 && entry.Length < 15)
                            {
                                wrt(keyKontrol.KeyChar);
                                entry += keyKontrol.KeyChar;
                            }
                        }
                        catch { }
                    }
                    while (keyKontrol.Key != ConsoleKey.Enter);

                    Console.BackgroundColor = ConsoleColor.Black;
                    lineClear(k1[0], startLine, 15);

                    lineClear(0, 2, 60);

                    if (output)
                    {
                        cursor(0, startLine); break;
                    }

                    if (entry == "")
                    {
                        msgShow("Please enter a number."); continue;
                    }

                    int g = Array.IndexOf(students.stuNo.ToArray(), entry);

                    if (g < 0)
                    {
                        msgShow("Searched record not found!"); continue;
                    }

                    cursor(k1[0], startLine); wrt(students.stuNo[g]);
                    cursor(k1[1], startLine); wrt(students.stuName[g]);
                    cursor(k1[2], startLine); wrt(students.stuAddress[g]);
                    cursor(k1[3], startLine); wrt(students.stuDepartment[g]);
                    //student records kept in the program are listed

                    wrt("\n\nAre you sure you want to delete? (Y): ");

                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        lineClear(0, startLine, consoleWidth);
                        lineClear(0, startLine + 1, consoleWidth);
                        lineClear(0, startLine + 2, consoleWidth);

                        string ogrNo = students.stuNo[g].ToString();

                        students.stuNo.RemoveAt(g);
                        students.stuName.RemoveAt(g);
                        students.stuAddress.RemoveAt(g);
                        students.stuDepartment.RemoveAt(g);

                        if (g < students.totalGrade)
                        {
                            students.stuMidterm.RemoveAt(g);
                            students.stuAbsences.RemoveAt(g);
                            students.stuFinal.RemoveAt(g);
                            students.stuMakeup.RemoveAt(g);
                            students.totalGrade -= 1;
                        }

                        msgShow("Record \"" + ogrNo + "\" has been deleted successfully.");

                        if (students.totalStudent == 0)
                        {
                            cursor(0, startLine); break;
                        }
                    }
                    else
                    {
                        wrt("No"); Thread.Sleep(1000);

                        lineClear(0, startLine, consoleWidth);
                        lineClear(0, startLine + 1, consoleWidth);
                        lineClear(0, startLine + 2, consoleWidth);

                        output = true; continue;
                    }

                }
                #endregion
            }
            if (choice == 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                wrt("Are you sure you want to exit? The program will close! (Y): ");
                if (Console.ReadKey(true).Key == ConsoleKey.Y) Environment.Exit(0);
                else wrt("No");
            }

        }

        #region interiorScreenKernel_Methods

        static void msgShow(string m)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            cursor(0, 2); wrt(m);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void tableTitle(string title, int length)
        {
            wrt(title + (length > 0 ? new string(' ', (length <= title.Length ? length : length - title.Length)) : ""));
        }

        static void lineClear(int L, int T, int characterLength)
        {
            cursor(L, T); wrt(new string(' ', characterLength)); cursor(L, T);
        }

        static string reverseSlashRemove(string n)
        {
            return n.Replace("\\", "").Replace("\a", "").Replace("\b", "").Replace("\f", "")
                .Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace("\v", "");
        }

        #endregion

        #region graphicsInterface_Methods

        static void createMenu()
        {
            for (int i = 0, satirNo = mainStartLine + 1; i < options.Length; i++, satirNo += 3)
            {
                menuChoiceEffect(choice == i + 1);

                int nameLength = options[i].Length - ((i + 1).ToString().Length - 6);

                cursor(consoleWidth / 2 - 14, satirNo);
                if (nameLength < 28) wrt(new string(' ', 28));
                else wrt(new string(' ', nameLength + 2));

                cursor(consoleWidth / 2 - 14, satirNo + 1);
                wrt("  " + (i + 1) + "- " + options[i]);
                if (nameLength < 28) wrt(new string(' ', 28 - nameLength - ((i + 1).ToString().Length > 1 ? (i + 1).ToString().Length : 0)));
                else wrt("  ");

                cursor(consoleWidth / 2 - 14, satirNo + 2);
                if (nameLength < 28) wrt(new string(' ', 28));
                else wrt(new string(' ', nameLength + 2));
            }
            //menu names were created in the middle of the screen and the text background was filled according to the selection number
        }

        static void menuChoiceEffect(bool choice)
        {
            if (choice)
            {
                Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue; Console.ForegroundColor = ConsoleColor.White;
            }
            //when one of the menu options is selected, it is determined which color the back will be filled
        }

        #endregion

        #region common_Methods

        static void wrt(object m)
        {
            Console.Write(m);
        }

        static void cursor(int L, int T)
        {
            Console.SetCursorPosition(L, T);
        }

        #endregion
    }
}
//design and programming --> by MuMMy