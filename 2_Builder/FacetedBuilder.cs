using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Builder
{
    public class FacetedBuilder
    {
        public static void Test()
        {
            var student = new StudentBuilder()
                .PersonalInfo.Called("Ahmed")
                    .LivesAt("Cairo", "Saladin")
                    .HasPostalCodeOf("1234566")
                .EducationInfo
                    .AtSchool("Benha")
                    .AtGrade(4)
                .Build();
            Console.WriteLine(student);
        }
    }
    public class Student
    {
        // Personal Info (facet)
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        // Education Info (facet)
        public int Grade { get; set; }
        public string SchoolName { get; set; }
        public override string ToString()
        {
            return $"{Name}, Address: { nameof(StreetAddress)}: {StreetAddress}, { nameof(PostCode)}: {PostCode}, { nameof(City)}: {City}," +
                $" Education: { nameof(Grade)}: {Grade} At {SchoolName} { nameof(SchoolName)}";
        }
    }

    public class StudentBuilder // facade
    {
        // refernce type
        protected Student student = new Student();
        public Student Build()
        {
            return student;
        }
        public StudentEducationInfoBuilder EducationInfo => new StudentEducationInfoBuilder(student);
        public StudentPersonalInfoBuilder PersonalInfo => new StudentPersonalInfoBuilder(student);
    }

    // implementing the personal info facet.
    public class StudentPersonalInfoBuilder : StudentBuilder
    {
        public StudentPersonalInfoBuilder(Student student)
        {
            this.student = student;
        }
        public StudentPersonalInfoBuilder Called (string name)
        {
            student.Name = name;
            return this;
        }
        public StudentPersonalInfoBuilder LivesAt(string city, string streetAddress)
        {
            student.City = city;
            student.StreetAddress = streetAddress;
            return this;
        }
        public StudentPersonalInfoBuilder HasPostalCodeOf(string postalCode)
        {
            student.PostCode = postalCode;
            return this;
        }
    }
    // implementing the education info facet.
    public class StudentEducationInfoBuilder : StudentBuilder
    {
        public StudentEducationInfoBuilder(Student student)
        {
            this.student = student;
        }
        public StudentEducationInfoBuilder AtSchool (string schoolName)
        {
            student.SchoolName = schoolName;
            return this;
        }
        public StudentEducationInfoBuilder AtGrade (int grade)
        {
            student.Grade = grade;
            return this;
        }

    }
}
