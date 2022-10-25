using System;

namespace Learning.CQRS.Repository.Write.Implement.Exceptions
{
    public class StoredProcedureAssembliesNotFoundException : Exception
    {
        public override string Message
        {
            get { return "ابتدا اسمبلی رویه های خود را به پروایدر اضافه کنید"; }
        }
    }
}
