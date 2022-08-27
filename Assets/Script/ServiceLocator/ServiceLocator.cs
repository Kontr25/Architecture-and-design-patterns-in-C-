using System;
using System.Collections.Generic;

namespace Script.ServiceLocator
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        protected Dictionary<Type, T> _itemsMap { get; }

        public ServiceLocator()
        {
            _itemsMap = new Dictionary<Type, T>();
        }

        public TP Register<TP>(TP newservice) where TP : T
        {
            var type = newservice.GetType();

            if (_itemsMap.ContainsKey(type))
            {
                throw new Exception($"Cannot add item of typr {type}. This type contains");
            }

            _itemsMap[type] = newservice;

            return newservice;
        }

        public void Unregister<TP>(TP service) where TP : T
        {
            var type = service.GetType();
            if (_itemsMap.ContainsKey(type))
            {
                _itemsMap.Remove(type);
            }
        }

        public TP GetTP<TP>() where TP : T
        {
            var type = typeof(TP);

            if (!_itemsMap.ContainsKey(type))
            {
                throw new Exception($"There is no object of type {type} in the service locator");
            }

            return (TP) _itemsMap[type];
        }
    }
}