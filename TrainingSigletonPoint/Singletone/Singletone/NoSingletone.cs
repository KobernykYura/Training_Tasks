using System;

namespace Singletone
{
    /// <summary>
    /// My sealed Singleton implementation.
    /// </summary>
    public sealed class NoSingletone
    {
        /// <summary>
        /// Count of Singleton realisation.
        /// </summary>
        private static byte _coun;
        private static Lazy<NoSingletone> _instance;
        private byte _result;


        /// <summary>
        /// Private constructor.
        /// </summary>
        private NoSingletone() { }

        /// <summary>
        /// Static property of singeltone getter.
        /// </summary>
        public static NoSingletone Instance
        {
            get
            {
                if (_coun == 0 || _instance.Value == null) // if we don't have sindleton, we create it.
                {
                    _coun++;
                    _instance = new Lazy<NoSingletone>(() => new NoSingletone()); // creation singleton.
                    return _instance.Value;
                }
                return _instance.Value; // return singleton if exist.
            }
        }

        //----Singleton propertys

        /// <summary>
        /// Property of domain result.
        /// </summary>
        public AppDomain AppDomainCurrent { get => AppDomain.CurrentDomain; }
        /// <summary>
        /// Property of frirndly domin name.
        /// </summary>
        public string AppDomainFriendly { get => AppDomain.CurrentDomain.FriendlyName; }
        /// <summary>
        /// Property of application domain id.
        /// </summary>
        public int AppDomainId { get => AppDomain.CurrentDomain.Id; }
        /// <summary>
        /// Property of method call result.
        /// </summary>
        public byte Result { get => _result; set => _result = value; }

        //----Singleton methods

        public byte ChangeField(byte b)
        {
            _result += b;
            return _result;
        }
    }
}
