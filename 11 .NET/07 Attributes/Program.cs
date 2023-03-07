using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _07_Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Class)]
    public class StupidAttribute : Attribute
    {
        public string DetailInfo;
        public StupidAttribute(string DetailInfo)
        {
            this.DetailInfo = DetailInfo;
        }

    }

    public class User
    {
        [Required(ErrorMessage ="Name Phai Thiet Lap")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Ten phai dai tu 3 den 100 ky tu")]
        public string Name { get; set; }
        [Range(18,100,ErrorMessage ="Tuoi phai tu 18 den 80")]
        public int Age { get; set; }
        [Phone]
        public string phoneNumber { get; set; }
        [EmailAddress(ErrorMessage ="Dia chi email sai cau truc")]
        public string Email { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine(Name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User()
            {
                Name = null,
                Age = 0,
                phoneNumber = "0123456789",
                Email = "xuanthulab@gmail.com"
            };
            //PropertyInfo[] userClassProperties = user1.GetType().GetProperties();
            //foreach (PropertyInfo property in userClassProperties)
            //{
            //    string attributeInfo = ((StupidAttribute)property.GetCustomAttributes<Attribute>(false).ToList().Find(x => { return x.GetType().Name.Equals("StupidAttribute"); })).DetailInfo;
            //    Console.WriteLine($"{property.Name}({attributeInfo}): {property.GetValue(user1)}");
            //}

            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(user1, new ValidationContext(user1), results, false);
            if (!isValid) {
                Console.WriteLine("Validate Failed: ");
                results.ForEach(result => {
                    Console.WriteLine(result.MemberNames.ToList()[0]);
                    Console.WriteLine(result.ErrorMessage);
                });
            }else Console.WriteLine("Validated Successed.");


            Console.WriteLine(  user1.Age);
            Console.WriteLine(  "DONE");
        }
    }
}
