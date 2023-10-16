using Models;
using Repository;
using System.Net.Mail;

namespace aspApp1.controller
{
    public class productManager :Manager<Product>
    {
        public productManager(MyDBContext myDBContext) : base(myDBContext) { }

    }
}