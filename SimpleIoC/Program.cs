using SimpleIoC.Implement;
using SimpleIoC.Interface;
using SimpleIoC.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoC
{
    class Program
    {
        static void Main(string[] args)
        {

            

            List<string> list = new List<string> { "1", "2", "3", "4" };
            string result = "";
            //foreach


            //Console.WriteLine("head: {0}", head1);
            Console.ReadLine();
            return;
            //Với mỗi Interface, ta define một Module tương ứng
            DIContainer.SetModule<IDatabase, Database>();
            DIContainer.SetModule<ILogger, Logger>();
            DIContainer.SetModule<IEmailSender, EmailSender>();

            DIContainer.SetModule<Cart, Cart>();

            //DI Container sẽ tự inject Database, Logger vào Cart
            var myCart = DIContainer.GetModule<Cart>();
            myCart.Checkout(1, 220391);
            Console.ReadLine();
            //Khi cần thay đổi, ta chỉ cần sửa code define
            //DIContainer.SetModule<IDatabase, XMLDatabase>();

            //var myCart = new Cart(new Database(), new Logger(), new EmailSender());
            ////Khi cần thay đổi database, logger
            //myCart = new Cart(new XMLDatabase(), new FakeLogger(), new FakeEmailSender());
        }
    }

    public class DIContainer
    {
        //Dictionary để chứa các interface và module tương ứng
        private static readonly Dictionary<Type, object>
                   ResgisteredModules = new Dictionary<Type, object>();

        //Hai hàm cơ bản, ở đây mình chuyển <T> thành 
        //dạng Type trong C# để dễ viết code
        public static void SetModule<TInterface, TModule>()
        {
            SetModule(typeof(TInterface), typeof(TModule));
        }

        public static T GetModule<T>()
        {
            return (T)GetModule(typeof(T));
        }


        private static void SetModule(Type interfaceType, Type moduleType)
        {
            //Kiểm tra module đã implement interface chưa
            if (!interfaceType.IsAssignableFrom(moduleType))
            {
                throw new Exception("Wrong Module type");
            }

            //Tìm constructor đầu tiên
            var firstConstructor = moduleType.GetConstructors()[0];
            object module = null;
            //Nếu như không có tham số
            if (!firstConstructor.GetParameters().Any())
            {
                //Khởi tạo module
                module = firstConstructor.Invoke(null); // new Database(), new Logger()
            }
            else
            {
                //Lấy các tham số của constructor
                var constructorParameters = firstConstructor.GetParameters(); //IDatebase, ILogger

                var moduleDependecies = new List<object>();
                foreach (var parameter in constructorParameters)
                {
                    var dependency = GetModule(parameter.ParameterType); //Lấy module tương ứng từ DIContainer
                    moduleDependecies.Add(dependency);
                }

                //Inject các dependency vào constructor của module
                module = firstConstructor.Invoke(moduleDependecies.ToArray());
            }
            //Lưu trữ interface và module tương ứng
            ResgisteredModules.Add(interfaceType, module);
        }

        private static object GetModule(Type interfaceType)
        {
            if (ResgisteredModules.ContainsKey(interfaceType))
            {
                return ResgisteredModules[interfaceType];
            }
            throw new Exception("Module not register");
        }
    }
}
