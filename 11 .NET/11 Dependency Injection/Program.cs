using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace _11_Dependency_Injection
{
    //class ClassA {
    //    public void ActionA() => Console.WriteLine("Action in ClassA");
    //}
    //class ClassB {
    //    public void ActionB() {
    //        Console.WriteLine("Action in ClassB");
    //        var a =new ClassA();
    //        a.ActionA();
    //    }
    //}
    public class MyServiceOptions {
        public string data1 { get; set; }
        public int data2 { get; set; }
    }
    public class MyService { 
        public string data1 { get; set; }
        public int data2 { get; set; }
        public MyService(IOptions<MyServiceOptions> options) {
            MyServiceOptions _options = options.Value;
            data1=_options.data1;
            data2=_options.data2;
        }
        public void PrintData() {
            Console.WriteLine($"{data1} / {data2}");
        }
    }
    interface IClassB {
        public void ActionB();
    }
    interface IClassC {
        public void ActionC();
    }
    class ClassC : IClassC
    {
        public void ActionC()
        {
            Console.WriteLine("Action in ClassC");
        }
    }

    class ClassB:IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }
    class ClassC2 : IClassC
    {
        public ClassC2(IOptions<ClassC2StringOption> _stringOptions)
        { 
            Console.WriteLine("ClassC2 is created: message: "+_stringOptions.Value.stringValue);
        }
        public void ActionC()
        {
            Console.WriteLine("Action in C2");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }
    class Horn {
        public void Beep() {
            Console.WriteLine("Beep - Beep");
        }
    }
    class Car {
        Horn horn { get; set; }
        public Car(Horn _horn) { horn = _horn; }
        public void Beep() {
            
            horn.Beep();
        }
    }
    public class ClassC2StringOption {
        public string stringValue { get;set; }
    }
    public class ClassB2StringOption
    {
        public string stringValue { get; set; }
    }
    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, IOptions<ClassB2StringOption> option)
        {

            c_dependency = classc;
            message = option.Value.stringValue;
            Console.WriteLine("ClassB2 is created");
        }
        public ClassB2(IClassC classc, string mgs)
        {
            
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }

        public void ActionB()
        {
            Console.WriteLine("messageB2: " + message);
            c_dependency.ActionC();
        }
        public static IClassB CreateB2(IServiceProvider provider) {
            var objectB2 = new ClassB2(provider.GetService<IClassC>(), "Created in normal delegate");
            return objectB2;
        }
        public static Func<IServiceProvider, IClassB> CreateB2(string _message)
        {
            return new Func<IServiceProvider, IClassB>((provider) => {
                var objectB2 = new ClassB2(provider.GetService<IClassC>(), _message);
                return objectB2;
            });
        }
    }
    internal class Program
    {
        public static IClassB CreateB2(IServiceProvider provider)
        {
            var objectB2 = new ClassB2(provider.GetService<IClassC>(), "Thuc hien trong B2");
            return objectB2;
        }
        static void Main(string[] args)
        {
            //var b = new ClassB();
            //b.ActionB();
            //IClassC objectC = new ClassC();
            //IClassB objectB = new ClassB1(objectC);
            //ClassA objectA = new ClassA(objectB); 

            //objectA.ActionA();


            //Horn horn=new Horn();
            //Car car = new Car(horn);
            //car.Beep(); 





            //ServiceCollection services = new ServiceCollection();

            ////Dang ky cac dich vu...
            //services.AddTransient<IClassC, ClassC1>();

            //ServiceProvider provider = services.BuildServiceProvider();

            //Console.WriteLine("provider hash: "+provider.GetHashCode());
            //var provider1 = provider.CreateScope().ServiceProvider;

            //Console.WriteLine("provider hash: "+ provider1.GetHashCode());
            //provider.GetService<IClassC>();
            //provider.GetService<IClassC>();
            //provider1.GetService<IClassC>();

            //for (int i = 0; i < 5; i++) {
            //    IClassC c = provider.CreateScope().ServiceProvider.GetService<IClassC>();
            //    Console.WriteLine("Hash: "+  c.GetHashCode());
            //}






            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider;

            //services.AddSingleton<IClassB>(ClassB2.CreateB2("Created in Custom Delegate"));
            //services.AddSingleton<IClassB>(ClassB2.CreateB2);
            services.AddSingleton<IClassB, ClassB2>();

            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<IClassC, ClassC2>();
            services.Configure<ClassC2StringOption>(x=>x.stringValue="Configured Message");
            services.Configure<ClassB2StringOption>(x=>x.stringValue="Created in Normal way");
            provider = services.BuildServiceProvider();

            ClassA objectA = provider.GetService<ClassA>();
            objectA.ActionA();





            //ServiceCollection services=new ServiceCollection();
            //services.AddSingleton<MyService>();
            //services.Configure<MyServiceOptions>((options) => {
            //    options.data1 = "Xin chao"; options.data2 = 2021;
            //});

            //ServiceProvider provider = services.BuildServiceProvider();
            //MyService myService = provider.GetService<MyService>();
            //myService.PrintData();
        }
    }
}