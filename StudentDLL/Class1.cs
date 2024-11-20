using System;
using System.Collections.Generic;
using PersonLibrary;

namespace StudentLibrary
{
    public class Student : Person, IComparable<Student>
    {
        public double Average { get; set; }
        public int GroupNumber { get; set; }

        public Student() : base() { }

        public Student(string name, string surname, int age, string phone, double average, int groupNumber)
            : base(name, surname, phone, age)
        {
            Average = average;
            GroupNumber = groupNumber;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Средний балл: {Average}\nНомер группы: {GroupNumber}");
        }

        public int CompareTo(Student other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public class AgeComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == null || y == null)
                    throw new ArgumentNullException("Один из объектов для сравнения равен null");

                return x.Age.CompareTo(y.Age);
            }
        }

        public class SurnameComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == null || y == null)
                    throw new ArgumentNullException("Один из объектов для сравнения равен null");

                return string.Compare(x.Surname, y.Surname, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
