using System;

namespace Learning.CQRS.Repository.Write.Implement.Exceptions
{
    public class DataProviderAssembliesNotFoundException : Exception
    {
        public override string Message
        {
            get { return "ابتدا اسمبلی مدل های خود را به دیتا پروایدر اضافه کنید"; }
        }
    }
}
