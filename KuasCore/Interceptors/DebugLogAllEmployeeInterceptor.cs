using AopAlliance.Intercept;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCore.Interceptors 
{
    class DebugLogAllEmployeeInterceptor : IMethodInterceptor
    {

        public object Invoke(IMethodInvocation invocation)
        {
            Console.WriteLine("DebogLogInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);
            Debug.Print("DebogLogInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);

            IList<Employee> result = (IList<Employee>)invocation.Proceed();

            foreach(Employee x in result){
                x.Name = "secret";
            }

            Console.WriteLine("回傳的資料已取得 [{0}]", result);
            Debug.Print("This Is the Result [{0}]", result);

            return result;
        }
    }
}
