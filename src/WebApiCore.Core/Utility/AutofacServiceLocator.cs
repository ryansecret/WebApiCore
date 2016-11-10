using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NDaisy.Core.ServiceLocator;

namespace WebApiCore.Core.Utility
{
    public class AutofacServiceLocator : ServiceLocatorImplBase
    {
        /// <summary>
        /// The <see cref="T:Autofac.IComponentContext"/> from which services
        ///             should be located.
        /// 
        /// </summary>
        private readonly IComponentContext _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Autofac.Extras.CommonServiceLocator.AutofacServiceLocator"/> class.
        /// 
        /// </summary>
        /// <param name="container">The <see cref="T:Autofac.IComponentContext"/> from which services
        ///             should be located.
        ///             </param><exception cref="T:System.ArgumentNullException">Thrown if <paramref name="container"/> is <see langword="null"/>.
        ///             </exception>
        public AutofacServiceLocator(IComponentContext container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this._container = container;
        }

        /// <summary>
        /// Resolves the requested service instance.
        /// 
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param><param name="key">Name of registered service you want. May be <see langword="null"/>.</param>
        /// <returns>
        /// The requested service instance.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="serviceType"/> is <see langword="null"/>.
        ///             </exception>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");
            if (key == null)
                return ResolutionExtensions.Resolve(this._container, serviceType);
            return ResolutionExtensions.ResolveNamed(this._container, key, serviceType);
        }

        /// <summary>
        /// Resolves all requested service instances.
        /// 
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <returns>
        /// Sequence of service instance objects.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="serviceType"/> is <see langword="null"/>.
        ///             </exception>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");
            return Enumerable.Cast<object>((IEnumerable)ResolutionExtensions.Resolve(this._container, typeof(IEnumerable<>).MakeGenericType(serviceType)));
        }
    }
}