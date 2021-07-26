using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PratyushaJoinLinqPractice
{
    class Program
    {
        private static readonly teacher bi;

        static void Main(string[] args)
        {
            static double ConvertHoursToMilliseconds(double hours)
            {
                return TimeSpan.FromHours(hours).TotalMilliseconds;
            }


            Console.WriteLine(ConvertHoursToMilliseconds(1));

            Console.WriteLine(TimeSpan.FromMinutes(1).TotalSeconds);

            DateTime dt = DateTime.Now;

            DateTime newObj = new DateTime();
            

                //var p = long.Parse(TimeSpan.FromMilliseconds(360000));


            DateTime localDate = DateTime.Now;
            Console.WriteLine(localDate);

            ConcurrentDictionary<int, student> studentDict = new ConcurrentDictionary<int, student>();

            ConcurrentDictionary<int, teacher> teacherDict = new ConcurrentDictionary<int, teacher>();

            ConcurrentDictionary<int, books> booksDict = new ConcurrentDictionary<int, books>()
            ;

            student s1 = new student()
            {
                studid=101,
                age=15,
                stuaName="Sumukh",
                std=10

            };
            student s2 = new student() { studid = 102, age = 16, std = 11, stuaName = "SPS" };
            student s3 = new student() { studid = 103, age = 10, std = 5, stuaName = "opppS" };
            student s4 = new student() { studid = 104, age = 18, std = 13, stuaName = "Ajay" };
            student s5 = new student() { studid = 105, age = 17, std = 12, stuaName = "BHUMIKA" };

            studentDict.TryAdd(s1.studid,s1); studentDict.TryAdd(s2.studid, s2); studentDict.TryAdd(s3.studid, s3); studentDict.TryAdd(s4.studid, s4); studentDict.TryAdd(s5.studid, s5);

            teacher t1 = new teacher() {teacherID=1001,std=16 };
            teacher t2 = new teacher() { teacherID = 1002, std = 18 };
            teacher t3 = new teacher() { teacherID = 1003, std = 17 };
            teacher t4 = new teacher() { teacherID = 1004, std = 19 };
            teacher t5= new teacher() { teacherID = 1005, std = 5 };
            teacher t6= new teacher() { teacherID = 1006, std = 13 };
            teacher t7 = new teacher() { teacherID = 1071, std = 12};
            teacher t8 = new teacher() { teacherID = 1008, std = 12 };
            teacher t9 = new teacher() { teacherID = 1009, std = 11 };

            teacherDict.TryAdd(t1.teacherID, t1);teacherDict.TryAdd(t2.teacherID, t2); teacherDict.TryAdd(t3.teacherID, t3); teacherDict.TryAdd(t4.teacherID, t4); teacherDict.TryAdd(t5.teacherID, t5);
            teacherDict.TryAdd(t6.teacherID, t6); teacherDict.TryAdd(t7.teacherID, t7); teacherDict.TryAdd(t8.teacherID, t8); teacherDict.TryAdd(t9.teacherID, t9);

            books b1 = new books() { bookId = 10, std = 12, teacherId = 1008 };
            books b2 = new books() { bookId = 11, std = 13, teacherId = 1006 };
            books b3 = new books() { bookId = 12, std = 5, teacherId = 1005 };
            books b4 = new books() { bookId = 13, std = 13, teacherId = 1006 };
            books b5 = new books() { bookId = 14, std = 11, teacherId = 1009 };

            booksDict.TryAdd(b1.bookId, b1); booksDict.TryAdd(b2.bookId, b2); booksDict.TryAdd(b3.bookId, b3); booksDict.TryAdd(b4.bookId, b4); booksDict.TryAdd(b5.bookId, b5);




            var Query2 = (from sd in studentDict.Values
                         join td in teacherDict.Values
                         on sd.std equals td.std
              
                         orderby sd.age
                         
                         select new {
                             StudentName=sd.stuaName,
                             sd.age,
                             sd.std,
                             td.teacherID
                         }
                         ).ToList();


            foreach (var Query1 in Query2)
            {
                Console.WriteLine($"Student Age : {Query1.age}" + "   "+ $"Student Name : {Query1.StudentName}"+ "   "+ $"Student Std : {Query1.std}" + "   "+ $"Teacher ID : {Query1.teacherID}");

            }

            

        }
    }
}
