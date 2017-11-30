using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventReflection
{
    public class CreateReflector
    {
        /// <summary>
        /// Create instance of class type object and get his event.
        /// </summary>
        /// <typeparam name="EType">Type of class to create.</typeparam>
        /// <returns></returns>
        /// <exception cref="MemberAccessException">"MemberAccessException for type <typeparamref name="EType"/>.</exception>
        /// <exception cref="NotSupportedException">Not supported for this type to call constructor.</exception>
        /// <exception cref="MissingMethodException">No standart constructor for type <typeparamref name="EType"/>.</exception>
        public EType Create<EType>() where EType : class
        {
            object obj;

            try
            {
                obj = Activator.CreateInstance(typeof(EType));
            }
            catch (MissingMethodException e)
            {
                throw new MissingMethodException($"No standart constructor for type {typeof(EType)}", e);
            }
            catch (NotSupportedException e)
            {
                throw new NotSupportedException("Not supported for this type to call constructor.", e);
            }
            catch (MemberAccessException e)
            {
                throw new MemberAccessException($"MemberAccessException for type {typeof(EType)}", e);
            }

            return (EType)obj; 
        }
        
    }

}

