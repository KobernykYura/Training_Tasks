using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventReflection
{
    /// <summary>
    /// Static class for comfortable method call.
    /// </summary>
    public static class StaticReflector
    {
        /// <summary>
        /// Extention method for getting event form object by name.
        /// </summary>
        /// <typeparam name="EType">Type of parameter <paramref name="obj"/>. Must be a class type.</typeparam>
        /// <param name="obj">The parameter of the object that the method uses.</param>
        /// <param name="name">The name of the event from object.</param>
        /// <returns><see cref="EventInfo"/> type of event to get from object <paramref name="obj"/>.</returns>
       /// <exception cref="ArgumentNullException">Check your arguments..</exception>
        public static EventInfo GetEvent<EType>(this object obj, string name) where EType : class
        {
            EventInfo even;

            if (obj == null || !(obj is EType))
                throw new NullReferenceException($"No Instance of object {typeof(EType)}");

            try
            {
                even = obj.GetType().GetEvent(name); // "PriceChanged"
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Your argument {name} is null.", e);
            }

            return even;
        }

        /// <summary>
        /// Extntion method for getting property from object by name.
        /// </summary>
        /// <typeparam name="EType">Type of parameter <paramref name="obj"/>. Must be a class type.</typeparam>
        /// <param name="obj">The parameter of the object that the method uses.</param>
        /// <param name="name">The name of the property to get from object.</param>
        /// <returns><see cref="ParameterInfo"/> type of property from object <paramref name="obj"/>.</returns>
        /// <exception cref="NullReferenceException">No Instance of object typeof(<typeparamref name="EType"/>).</exception>
        /// <exception cref="AmbiguousMatchException">The linkage criterion corresponds to several members.</exception>
        /// <exception cref="ArgumentNullException">Check your arguments.</exception>
        public static PropertyInfo GetProperty<EType>(this object obj, string name) where EType : class
        {
            PropertyInfo prop;

            if (obj == null || !(obj is EType))
                throw new NullReferenceException($"No Instance of object {typeof(EType)}");

            try
            {
                prop = obj.GetType().GetProperty(name); // "Price"
            }
            catch (AmbiguousMatchException e)
            {
                throw new AmbiguousMatchException("The linkage criterion corresponds to several members.", e);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Check your argument {name}.", e);
            }

            return prop;
        }

        /// <summary>
        /// Adds methods as delegate to event of object with reflection.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <param name="even">Event of target object.</param>
        /// <param name="func">Encapsulates method or mrthods to invoke by event. </param> 
        /// <exception cref="NullReferenceException">The argument of object can't be null.</exception>
        /// <exception cref="NotImplementedException">Event <paramref name="even"/> is not implemented in <paramref name="obj"/>.</exception>
        /// <exception cref="ArgumentException">The passed handler can not be used. Check your arguments.</exception>
        /// <exception cref="MethodAccessException">The calling object does not have permission to access this element.</exception>
        /// <exception cref="InvalidOperationException">This event does not support the public access method add.</exception>
        public static void AddToEventHandler(this EventInfo even, object obj, Delegate func)
        {
            if (obj == null)
                throw new NullReferenceException("The argument of object can't be null.");

            if (even == null)
                throw new NullReferenceException($"The argument of event can't be null");

            try
            {
                even.AddEventHandler(obj, func);
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("This event does not support the public access method add.", e);
            }
            catch (MethodAccessException e)
            {
                throw new MethodAccessException($"The calling object does not have permission to access this element. Check your delegate methods {func}.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("The passed handler can not be used. Check your arguments.", e);
            }
        }

        /// <summary>
        /// Method for setting value at property with reflection.
        /// </summary>
        /// <param name="obj">Target object.</param>
        /// <param name="prop"></param>
        /// <param name="num">Value of <see cref="decimal"/> type.</param>
        /// <exception cref="TargetInvocationException">Problem with setting value to property. More info into innerException.</exception>
        /// <exception cref="TargetException">Check setted delegate methods. More info into innerException.</exception>
        /// <exception cref="ArgumentException">Check your arguments. More info into innerException.</exception>
        /// <exception cref="NullReferenceException">No reference to propery. Property is null.</exception>
        public static void SetNewValue(this PropertyInfo prop, object obj, decimal num)
        {
            try
            {
                prop.SetValue(obj, num);
            }
            catch (TargetInvocationException e)
            {
                throw new TargetInvocationException("Problem with setting value to property.", e);
            }
            catch (TargetException e)
            {
                throw new TargetException($"Bad object as target.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Check your arguments.", e);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("No reference to propery. Property is null.", e);
            }
        }
    }
}
