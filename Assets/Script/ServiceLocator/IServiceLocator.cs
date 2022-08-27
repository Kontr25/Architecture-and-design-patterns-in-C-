using System.Collections.Generic;
using UnityEngine;

namespace Script.ServiceLocator
{
    public interface IServiceLocator<T>
    {
        TP Register<TP>(TP newservice) where TP : T;
        void Unregister<TP>(TP service) where TP : T;
        TP GetTP<TP>() where TP : T;
    }
}