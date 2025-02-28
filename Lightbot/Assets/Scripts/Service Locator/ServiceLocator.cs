using System;
using System.Collections.Generic;

namespace Service_Locator
{
    public class ServiceLocator:IServiceLocator
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
        public void RegisterService<T>(T service)
        {
            services[typeof(T)] = service;
        }

        public T GetService<T>()
        {
            if (services.ContainsKey(typeof(T)))
            {
                return (T)services[typeof(T)];
            }
            throw new ArgumentException($"Service of type {typeof(T)} not found.");
        }
    }
}