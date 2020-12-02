using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagingReading
{
    class FilterFile
    {
        public List<string> member = new List<string>();//Done
        public List<string> memberName = new List<string>();//Done
        public List<string> memberEmail = new List<string>();//Done
        public List<string> memberPhone = new List<string>();//Done


        public List<string> book = new List<string>();//Done
        private List<string> bookName = new List<string>();//Done
        public List<string> categories = new List<string>();//Done
        public List<string> bookPage = new List<string>();

        //-------------------------------------------

        public List<string> MemberNameDuplicates = new List<string>();//Done

        public List<string> MemberNameNoDuplicates = new List<string>();//Done

        public List<string> MemberPageReadString = new List<string>();//Done

        private List<int> MemberPageRead = new List<int>();//Done

        //public List<int> MemberPageReadTotal = new List<int>();

        public int totalpage;
        public int totalbooks;
        public int totalmembers;
        public int totalBookRead;

        private List<string> BookDuplicates = new List<string>();//Done

        public List<int> TotalPageReadForEachMember = new List<int>();//Done

        public List<string> BookNoDuplicates = new List<string>();//Done

        public List<int> RankOfBookReadINT = new List<int>();//Done

        public List<string> BookInfoForName = new List<string>();//Done
        public List<string> BookInfoForCategories = new List<string>();//Done
        public List<string> BookInfoForPage = new List<string>();//Done

        public List<int> Categoriescount = new List<int>();//Done
        private List<int> RankOfBookReadINTNeededForCalcat = new List<int>();//Done

        private List<string> templisStrint = new List<string>();
        private List<int> templisInt = new List<int>();

        public List<string> MemberNameRankForBookRead = new List<string>();//Done

        public List<int> NumberOfbookreadFoeEachMember = new List<int>();

        public string[] Most8MemberRead = new string[8];

        public int[] Most8MemberReadPage = new int[8];

        public string[] Most5BookRead = new string[5];

        public int[] Most5BookReadTimes = new int[5];

  
        ~FilterFile() { }


        public void initiallyStart()
        {

            member.Clear();
            memberName.Clear();
            memberEmail.Clear();
            memberPhone.Clear();
     
            book.Clear();
            bookName.Clear();
            categories.Clear();
            bookPage.Clear();

            MemberNameDuplicates.Clear();
            MemberNameNoDuplicates.Clear();
            MemberPageReadString.Clear();

            MemberPageRead.Clear();


            totalBookRead = 0;
            totalbooks = 0;
            totalmembers = 0;
            totalpage = 0;

            BookDuplicates.Clear();

            TotalPageReadForEachMember.Clear();
            BookNoDuplicates.Clear();

            RankOfBookReadINT.Clear();


            BookInfoForCategories.Clear();
            BookInfoForName.Clear();
            BookInfoForPage.Clear();

            MemberNameRankForBookRead.Clear();
            NumberOfbookreadFoeEachMember.Clear();
        }
        public void filterFile(char Bet1And2, string beginning, string ending, string allLineFromFile, char splitsymbol)
        {
            string[] str = allLineFromFile.Split(splitsymbol);
            bool first = true;
            bool second = true;
            bool three = true;
            bool fourth = true;
            //    var f = modf;

            // var mm = checkRole;
            switch (Bet1And2)
            {
                case '1':
                    for (int i = 0; i <= str.Count() - 1; i++)
                    {
                        if (str[i].Contains(beginning))
                        {

                            for (int j = i + 1; j <= str.Count() + 1; j++)
                            {
                                if (str[j].Contains(ending))
                                {
                                    break;
                                }


                                if (first == true)
                                {
                                    MemberNameDuplicates.Add(str[j]);
                                    first = false;
                                    continue;
                                }


                                if (second == true)
                                {
                                    BookDuplicates.Add(str[j]);
                                    second = false;
                                    continue;
                                }
                                if (three == true)
                                {
                                    MemberPageReadString.Add(str[j]);
                                    first = true;
                                    second = true;
                                    continue;
                                }

                            }
                        }
                    }
                    break;


                case '2':
                    for (int i = 0; i <= str.Count() - 1; i++)
                    {
                        if (str[i].Contains(beginning))
                        {

                            for (int j = i + 1; j <= str.Count() + 1; j++)
                            {
                                if (str[j].Contains(ending))
                                {
                                    break;
                                }

                                if (first == true)
                                {
                                    book.Add(str[j]);
                                    first = false;
                                    continue;
                                }


                                if (second == true)
                                {
                                    bookName.Add(str[j]);
                                    second = false;
                                    continue;
                                }
                                if (three == true)
                                {
                                    bookPage.Add(str[j]);

                                    three = false;
                                    continue;
                                }

                                if (fourth == true)
                                {
                                    categories.Add(str[j]);
                                    first = true;
                                    second = true;
                                    three = true;


                                    continue;
                                }



                            }
                        }
                    }

                    break;

                case '3':
                    for (int i = 0; i <= str.Count() - 1; i++)
                    {
                        if (str[i].Contains(beginning))
                        {

                            for (int j = i + 1; j <= str.Count() + 1; j++)
                            {
                                if (str[j].Contains(ending))
                                {
                                    break;
                                }

                                if (first == true)
                                {
                                    member.Add(str[j]);
                                    first = false;
                                    continue;
                                }


                                if (second == true)
                                {
                                    memberName.Add(str[j]);
                                    second = false;
                                    continue;
                                }
                                if (three == true)
                                {
                                    memberEmail.Add(str[j]);

                                    three = false;
                                    continue;
                                }

                                if (fourth == true)
                                {
                                    memberPhone.Add(str[j]);
                                    first = true;
                                    second = true;
                                    three = true;


                                    continue;
                                }



                            }
                        }
                    }

                    break;
            }
        }






        private void TopfoGraph()
        {

            if (MemberNameNoDuplicates.Count >= 8)
            {

                for (int i = 0; i < 8; i++)
                {
                    Most8MemberRead[i] = MemberNameNoDuplicates[i].Trim(); ;
                    Most8MemberReadPage[i] = TotalPageReadForEachMember[i];
                }
            }


            if (BookInfoForName.Count >= 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    Most5BookRead[i] = BookInfoForName[i].Trim(); ;
                    Most5BookReadTimes[i] = RankOfBookReadINT[i];
                }
            }




        }


        public void setup()
        {

            replceIDByName();
            memberTotalReadConut();
        
            GiveListsOfBookInfo();
            RankingMemberByPageRead();
            RankingByBooks();
            MostCategories();
            RankingCategoriecount();



            CountTotalBMPBR();


            HowMuchMemberReadBOOK();
            TopfoGraph();
            RankingMemberByBook();


        }


        public void RankingMemberByPageRead()
        {
            templisInt.Clear();
            templisStrint.Clear();

            int m = MemberNameNoDuplicates.Count;
            for (int i = 0; i < m; i++)
            {

                int x = TotalPageReadForEachMember.Max();
                int index = TotalPageReadForEachMember.IndexOf(x);
                templisInt.Add(x);
                templisStrint.Add(MemberNameNoDuplicates[index]);
                TotalPageReadForEachMember.RemoveAt(index);
                MemberNameNoDuplicates.RemoveAt(index);


            }


            TotalPageReadForEachMember.AddRange(templisInt);

            MemberNameNoDuplicates.AddRange(templisStrint);


        }



        public void MostCategories()
        {

            templisInt.Clear();
            templisStrint.Clear();


        


            {
                int x = 0;
                for (int i = 0; i < BookInfoForCategories.Count; i++)
                {
                    if (templisStrint.Contains(BookInfoForCategories[i]))
                    {
                        continue;
                    }
                    for (int j = 0; j < BookInfoForCategories.Count; j++)
                    {
                        if (BookInfoForCategories[i].Trim() == BookInfoForCategories[j].Trim())
                        {

                            x += RankOfBookReadINTNeededForCalcat[j];
                        }
                    }

                    Categoriescount.Add(x);
                    x = 0;
                    templisStrint.Add(BookInfoForCategories[i]);

                }

                BookInfoForCategories.Clear();

                BookInfoForCategories.AddRange(templisStrint);
            }

        }






        public void RankingByBooks()
        {


            List<string> templisStrint3 = new List<string>();

            List<string> templisStrint4 = new List<string>();
            templisInt.Clear();
            templisStrint.Clear();

            int y = BookInfoForName.Count;

            categories.Clear();
            categories.AddRange(BookInfoForCategories);
            bookPage.Clear();

            for (int i = 0; i < y; i++)
            {
                int x = RankOfBookReadINT.Max();

                int index = RankOfBookReadINT.IndexOf(x);

                templisInt.Add(x);

                templisStrint.Add(BookInfoForName[index]);

                templisStrint3.Add(categories[index]);

                templisStrint4.Add(BookInfoForPage[index]);

                categories.RemoveAt(index);

                BookInfoForPage.RemoveAt(index);
                RankOfBookReadINT.RemoveAt(index);

                BookInfoForName.RemoveAt(index);



            }


            RankOfBookReadINT.AddRange(templisInt);
            BookInfoForName.AddRange(templisStrint);

            bookPage.AddRange( templisStrint4);
            categories.AddRange(templisStrint3);

        }

        public void RankingCategoriecount()
        {
            templisInt.Clear();
            templisStrint.Clear();


            int m = BookInfoForCategories.Count;
            for (int i = 0; i < m; i++)
            {
               
                int x = Categoriescount.Max();
                int index = Categoriescount.IndexOf(x);
                templisInt.Add(x);
                templisStrint.Add(BookInfoForCategories[index]);
                Categoriescount.RemoveAt(index);
                BookInfoForCategories.RemoveAt(index);
          

            }

            Categoriescount.AddRange(templisInt);

            BookInfoForCategories.AddRange(templisStrint);

        }




        public void RankingMemberByBook()
        {
            templisInt.Clear();
            templisStrint.Clear();


            MemberNameRankForBookRead.AddRange(MemberNameNoDuplicates);

            int m = MemberNameRankForBookRead.Count;
            for (int i = 0; i < m; i++)
            {

                int x = NumberOfbookreadFoeEachMember.Max();
                int index = NumberOfbookreadFoeEachMember.IndexOf(x);
                templisInt.Add(x);
                templisStrint.Add(MemberNameRankForBookRead[index]);
                NumberOfbookreadFoeEachMember.RemoveAt(index);
                MemberNameRankForBookRead.RemoveAt(index);

            }




            NumberOfbookreadFoeEachMember.AddRange(templisInt);

            MemberNameRankForBookRead.AddRange(templisStrint);


            templisInt.Clear();
            templisStrint.Clear();
            //5 or more than 5 
            int m1 = MemberNameRankForBookRead.Count;
            for (int i = 0; i < m; i++)
            {
                int x = NumberOfbookreadFoeEachMember.Max();
                int index = NumberOfbookreadFoeEachMember.IndexOf(x);
                if (x >= 5)
                {

                    templisInt.Add(x);
                    templisStrint.Add(MemberNameRankForBookRead[index]);
                    NumberOfbookreadFoeEachMember.RemoveAt(index);
                    MemberNameRankForBookRead.RemoveAt(index);
                }
                else
                {
                    NumberOfbookreadFoeEachMember.RemoveAt(index);
                    MemberNameRankForBookRead.RemoveAt(index);
                }


            }




            NumberOfbookreadFoeEachMember.AddRange(templisInt);

            MemberNameRankForBookRead.AddRange(templisStrint);


        }





        public void CountBookReadAndRemoveBookDup()
        {
            int i = 0;
            int co = 0;

            while (i < BookDuplicates.Count)
            {
                if (BookNoDuplicates.Contains(BookDuplicates[i]))
                {
                    i++;

                    continue;


                }

                foreach (string s in BookDuplicates)
                {
                    if (BookDuplicates[i].Trim() == s.Trim())
                    {
                        co += 1;
                    }

                }


                BookNoDuplicates.Add(BookDuplicates[i]);
                RankOfBookReadINT.Add(co);
                i++;
                co = 0;

            }
        }



        private void GiveListsOfBookInfo()
        {


            CountBookReadAndRemoveBookDup();
            for (int i = 0; i < BookNoDuplicates.Count; i++)
            {

                for (int j = 0; j < book.Count; j++)
                {
                    //     string temp = BookNoDuplicates[i].Trim();

                    if (BookNoDuplicates[i].Trim() == book[j].Trim())
                    {

                        BookInfoForName.Add(bookName[j]);
                        BookInfoForCategories.Add(categories[j]);
                        BookInfoForPage.Add(bookPage[j]);



                        RankOfBookReadINTNeededForCalcat.Add(RankOfBookReadINT[i]);




                    }



                }

            }


        }
        public void CountTotalBMPBR()
        {
            int i = 0;

            foreach (int x in MemberPageRead)
            {
                i += x;
            }

            totalpage = i;


            totalbooks = book.Count; ;



            totalmembers = member.Count;




            totalBookRead = BookNoDuplicates.Count;


        }


        private void convertpage()
        {
            foreach (string s in MemberPageReadString)
            {

                MemberPageRead.Add(Convert.ToInt32(s.Trim()));
            }
        }

        private void removeMemberNameDuplicates()
        {


            foreach (string s in MemberNameDuplicates)
            {
                string temp = s.Trim();
                if (!MemberNameNoDuplicates.Contains(temp))
                {
                    MemberNameNoDuplicates.Add(temp);
                }
            }
        }



        public void HowMuchMemberReadBOOK()
        {
            List<string> temp = new List<string>();

            int numberOfbookread = 0;


            int i = 0;
            while (i < MemberNameNoDuplicates.Count)
            {

                for (int k = 0; k < MemberNameDuplicates.Count; k++)
                {

                    string temp1 = MemberNameDuplicates[k].Trim();


                    if (MemberNameNoDuplicates[i] == temp1)
                    {
                        if (!temp.Contains(BookDuplicates[k]))
                        {
                            numberOfbookread += 1;

                            temp.Add(BookDuplicates[k]);
                        }

                    }

                }

                temp.Clear();
                NumberOfbookreadFoeEachMember.Add(numberOfbookread);
                numberOfbookread = 0;
                i++;
            }


        }
        public void memberTotalReadConut()
        {

            removeMemberNameDuplicates();
            convertpage();

            int i = 0;
            int cont = 0;


            while (i < MemberNameNoDuplicates.Count)
            {

                for (int k = 0; k < MemberNameDuplicates.Count; k++)
                {

                    string temp1 = MemberNameDuplicates[k].Trim();

                    if (MemberNameNoDuplicates[i] == (temp1))
                    {
                        cont += MemberPageRead[k];

                    }
                }

                TotalPageReadForEachMember.Add(cont);
                cont = 0;

                i++;
            }
        }







        private void replceIDByName()
        {
            List<string> temp1 = new List<string>();

            foreach (string s in member)
            {

                temp1.Add(s.Trim());
            }

            member.Clear();
            member.AddRange(temp1);
            temp1.Clear();


            foreach (string s in book)
            {

                temp1.Add(s.Trim());
            }
            book.Clear();
            book.AddRange(temp1);
            temp1.Clear();

            foreach (string s in MemberNameDuplicates)
            {

                temp1.Add(s.Trim());
            }
            MemberNameDuplicates.Clear();
            MemberNameDuplicates.AddRange(temp1);
            temp1.Clear();




            temp1.AddRange(MemberNameDuplicates);
            foreach (string s in temp1)
            {

                if (!member.Contains(s.Trim()))
                {

                    int index = MemberNameDuplicates.IndexOf(s);

                    MemberNameDuplicates.RemoveAt(index);
                    BookDuplicates.RemoveAt(index);
                    MemberPageReadString.RemoveAt(index);
                }
            }

            temp1.Clear();

            temp1.AddRange(BookDuplicates);
            foreach (string s in temp1)
            {
                if (!book.Contains(s))
                {
                    int index = BookDuplicates.IndexOf(s);

                    MemberNameDuplicates.RemoveAt(index);
                    BookDuplicates.RemoveAt(index);
                    MemberPageReadString.RemoveAt(index);

                }
            }



            temp1.Clear();


            for (int i = 0; i < MemberNameDuplicates.Count; i++)
            {




                for (int j = 0; j < member.Count; j++)
                {

                    if (MemberNameDuplicates[i] == member[j])
                    {
                        temp1.Add(memberName[j]);
                    }



                }



            }

            MemberNameDuplicates.Clear();
            MemberNameDuplicates.AddRange(temp1);

            temp1.Clear();


        }

    }
}





