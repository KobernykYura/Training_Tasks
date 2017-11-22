using System;

namespace Injector.Common
{
    public interface IRegister
    {
        /// <summary>
        /// Bining interfce on type.
        /// If the registration already exists, then when we re-generate an exception.
        /// </summary>
        void Bind<T, U>();
        /// <summary>
        /// Binding type on key value.
        /// If the registration already exists, then when we re-generate an exception.
        /// </summary>
        void Bind<Interface, Class>(string key);
        /// <summary>
        /// Binding type on himself.
        /// If the registration already exists, then when we re-generate an exception.
        /// </summary>
        void Bind<T>();
    }
}