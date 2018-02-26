using System;
using System.Dynamic;
using ImpromptuInterface;

namespace TestingFundamentals.IntegrationTesting.Classes
{
    //FAKE
    public class Null<T> : DynamicObject where T : class
    {

        public static T Instance => new Null<T>().ActLike<T>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(
                typeof(T).GetMethod(binder.Name).ReturnType
                );

            return true;
        }
    }
}