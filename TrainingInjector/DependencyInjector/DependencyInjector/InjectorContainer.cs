using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Injector.Common;

namespace DependencyInjector
{
    /*
    -иметь возможность регистрации типа самого на себя ++
    -иметь возможность регистрации интерфейса и реализующего его типа ++
    -то же действие, но с возможностью указания строкового ключа  ++
    -если регистрация уже существует, то при повторной генерируем исключение ++
    -при регистрации интерфейсов проверяем регистрируемый тип на реализацию данного интерфейса ++
    -при получении зависимости использовать конструктор с максимальным числом аргументов ++
    -при невозможности передать данные в конструктор (отсутствуют сведения) генерируем исключение ++
    -контейнер может осуществлять инъекцию через свойство (*)
    */

    public class InjectorContainer : IRegister, IGet
    {
        // dictionary interface-implementation
        private readonly IDictionary<Type, Type> dictionary = new Dictionary<Type, Type>();
        // dictionary interface ready object
        private readonly IDictionary<Type, object> dictImplement = new Dictionary<Type, object>();
        // dictionary string key-interface
        private readonly IDictionary<string, KeyValuePair<Type, Type>> dictionaryKey = new Dictionary<string, KeyValuePair<Type, Type>>();

        /// <summary>
        /// Registration type on itself.
        /// </summary>
        /// <typeparam name="T">Type to register on itself.</typeparam>
        public void Bind<T>()
        {
            if (!typeof(T).IsClass)
                throw new ArgumentException($"Type {typeof(T).Name} must be class!");

            IsTypeAlreadyBinded<T,T>();

            dictionary.Add(typeof(T), typeof(T));
        }

        /// <summary>
        /// Binding interface with implementation and <see cref="string"/> type key.
        /// </summary>
        /// <typeparam name="Interface">Interface as key.</typeparam>
        /// <typeparam name="Class">Class as implementation</typeparam>
        /// <param name="key">String type key</param>
        public void Bind<Interface,Class>(string key)
        {
            BindTypeValidation<Interface, Class>();

            KeyInitValidation(key);

            IsKeyAlreadyBinded(key);

            dictionaryKey.Add(key, new KeyValuePair<Type, Type>(typeof(Interface), typeof(Class)));
        }

        /// <summary>
        /// Registration interface and its implementing type with the ability to specify a string key.
        /// </summary>
        /// <typeparam name="TInterface">Interface as key.</typeparam>
        /// <typeparam name="UClass">Class as implementation</typeparam>
        public void Bind<TInterface,UClass>()
        {
            BindTypeValidation<TInterface, UClass>();

            IsTypeAlreadyBinded<TInterface, UClass>();

            dictionary.Add(typeof(TInterface), typeof(UClass));
        }

        /// <summary>
        /// Get object by registered <see cref="interface"/>.
        /// </summary>
        /// <typeparam name="Interface">Interface as key and output format.</typeparam>
        /// <returns>Object of implementation.</returns>
        public Interface Get<Interface>()
        {
            // interface registratio validation
            NoRegisteredTypeValidation<Interface>();

            return (Interface)Get(typeof(Interface));
        }

        /// <summary>
        /// Get object by registered key.
        /// /// </summary>
        /// <typeparam name="Interface">Interface as key and output format.</typeparam>
        /// <param name="key">Key of binding.</param>
        /// <returns>Object of implementation.</returns>
        public Interface GetByKey<Interface>(string key)
        {
            // string validation
            KeyInitValidation(key);

            // interface registratio validation
            NoRegisteredKeyValidation<Interface>(key);

            var pair = dictionaryKey[key];

            return (Interface)GetKey(pair.Value);
        }



        #region ------------------private methods------------------


        /// <summary>
        /// Private get by key implementation method.
        /// </summary>
        /// <param name="value">Type of implementation.</param>
        /// <returns>Object of implementation.</returns>
        private object GetKey(Type value)
        {
            // all good constructors
            var constructors = value.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            List<int> argAmountList = new List<int>();
            List<object> argTypeList = new List<object>();

            // number of parameters in every constructor
            foreach (var item in constructors)
                argAmountList.Add(item.GetParameters().Count());

            ParameterInfo[] param = GetParameters(constructors, argAmountList);

            // add types of parameters to types array
            foreach (var p in param)
            {
                argTypeList.Add(GetDefault(p.GetType()));
            }

            // activation of constructor
            var resultObject = Activator.CreateInstance(value, argTypeList.ToArray());

            return resultObject;
        }

        /// <summary>
        /// Private get implementation method.
        /// </summary>
        /// <param name="contract">Contract for implementation call.</param>
        /// <returns>Object of implementation.</returns>
        private object Get(Type contract)
        {
            // check if we have implemented this type earlier
            if (dictImplement.ContainsKey(contract))
            {
                return dictImplement[contract];
            }
            else
            {
                // all good constructors
                var constructors = dictionary[contract].GetConstructors(BindingFlags.Public | BindingFlags.Instance);

                List<int> argAmountList = new List<int>();
                List<object> argTypeList = new List<object>();

                // number of parameters in every constructor
                foreach (var item in constructors)
                    argAmountList.Add(item.GetParameters().Count());

                ParameterInfo[] param = GetParameters(constructors, argAmountList);

                // add types of parameters to types array
                foreach (var p in param)
                {
                    argTypeList.Add(GetDefault(p.GetType()));
                }

                // activation of constructor
                var resultObject = Activator.CreateInstance(dictionary[contract], argTypeList.ToArray());
                dictImplement.Add(contract, resultObject);

                return resultObject;
            }
        }

        /// <summary>
        /// Privet method for get parameters for constructor.
        /// </summary>
        /// <param name="constructors">Array of type's constructors.</param>
        /// <param name="argAmountList">List of amound of arguments in constructors.</param>
        /// <returns>Array of parameters.</returns>
        private static ParameterInfo[] GetParameters(ConstructorInfo[] constructors, List<int> argAmountList)
        {
            // all constructors with maximum number of parameters
            var suitableCrots = constructors.Where(crot =>
                crot.GetParameters().Count() == argAmountList.Max());

            // threw Exception if we have more than 1 constructors with maximum number of parameters
            if (suitableCrots.Count() > 1)
                throw new TypeInitializationException("There are more than 1 constructors with maximum number of parameters", new Exception());

            var param = suitableCrots.First().GetParameters();
            return param;
        }

        /// <summary>
        /// Implement default value of system type.
        /// </summary>
        /// <param name="type">Type to create.</param>
        /// <returns>Object of type.</returns>
        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);

            return null;
        }

        /// <summary>
        /// Validatin if <typeparamref name="Interface"/> is interface, <typeparamref name="Class"/> is class.
        /// And is <typeparamref name="Interface"/> implemented in class <typeparamref name="Class"/>.
        /// </summary>
        /// <typeparam name="Interface">Interface of type.</typeparam>
        /// <typeparam name="Class">Type for checking.</typeparam>
        private static void BindTypeValidation<Interface, Class>()
        {
            if (!typeof(Interface).IsInterface)
                throw new ArgumentException($"Type {typeof(Interface).Name} must be interface!");

            if (!typeof(Class).IsClass)
                throw new ArgumentException($"Type {typeof(Class).Name} must be class!");

            if (!IsContain<Interface, Class>())
                throw new NotImplementedException($"Interface {typeof(Interface).Name} not implemeted by class {typeof(Class).Name}");
        }

        /// <summary>
        /// Is interface <typeparam name="Interface"/> implemented in type <typeparam name="Class"/>.
        /// </summary>
        /// <typeparam name="Interface">Interface of type.</typeparam>
        /// <typeparam name="Class">Type for checking.</typeparam>
        /// <returns>Returns true if interface <typeparam name="Interface"/> implemented in type <typeparam name="Class"/>.</returns>
        private static bool IsContain<Interface, Class>()
        {
            var inface = typeof(Class).GetInterface(typeof(Interface).Name);
            return inface != null;
        }
        
        /// <summary>
        /// Return true if this key is already binded to type <paramref name="type"/>.
        /// </summary>
        /// <param name="key">Key for binding.</param>
        /// <param name="type">Type for binding to key.</param>
        /// <returns>Return true if this key is already binded to type <paramref name="type"/>.</returns>
        private bool IsExistKey(string key, Type type)
        {
            if (dictionaryKey.ContainsKey(key))
                return true;

            return false;
        }
        
        /// <summary>
        /// Return true if this key is already binded to type <paramref name="value"/>.
        /// </summary>
        /// <param name="key">Key for binding.</param>
        /// <param name="value">Type for binding to key.</param>
        /// <returns>Return true if this key is already binded to type <paramref name="value"/>.</returns>
        private bool IsExist(Type key, Type value)
        {
            if (dictionary.Contains(new KeyValuePair<Type, Type>(key, value)))
                return true;

            return false;
        }

        /// <summary>
        /// Validation if interface-class pair is already binded.
        /// </summary>
        /// <typeparam name="T">Key type.</typeparam>
        /// <typeparam name="U">Implementation type.</typeparam>
        private void IsTypeAlreadyBinded<T, U>()
        {
            if (IsExist(typeof(T), typeof(U)))
                throw new NotSupportedException($"Type {typeof(T).Name} is already binded!", new InvalidOperationException());
        }

        /// <summary>
        /// Validation if key is already binded.
        /// </summary>
        /// <typeparam name="Class">Implementstion type.</typeparam>
        /// <param name="key">Key pararmeter.</param>
        private void IsKeyAlreadyBinded(string key)
        {
            if (dictionaryKey.ContainsKey(key))
                throw new NotSupportedException($"An element with the same key has already been added.");
        }

        /// <summary>
        /// Validation if key type is contains in dictionary.
        /// </summary>
        /// <typeparam name="T">Type for validation.</typeparam>
        private void NoRegisteredTypeValidation<T>()
        {
            if (!dictionary.ContainsKey(typeof(T)))
                throw new KeyNotFoundException($"No registered key {typeof(T).Name}");
        }

        /// <summary>
        /// Validation if key is contains in dictionary.
        /// </summary>
        /// <param name="T">Key for validation.</typeparam>
        private void NoRegisteredKeyValidation<Interface>(string key)
        {
            if (!dictionaryKey.ContainsKey(key))
                throw new KeyNotFoundException($"No registered key {key}");

            if (dictionaryKey[key].Key != typeof(Interface))
                throw new KeyNotFoundException($"No registered interface {typeof(Interface)}");
        }

        /// <summary>
            /// Validation if key is not null orempty.
            /// </summary>
            /// <param name="key"></param>
        private static void KeyInitValidation(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException($"Key {key} must be initialised!");
        }
       
        #endregion

    }
}
