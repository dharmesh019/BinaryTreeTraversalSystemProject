using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTreeCreationAndTraversal.Interfaces;
using Microsoft.Practices.Unity;
using GateNodeTreeCreationAndTraversal;

namespace FactoryOfBusinessObjects
{
    public static class FactoryOfObjects<AnyType> // Design pattern :- Simple factory pattern
    {
        private static IUnityContainer _objectsofOurProjects = null;


        public static AnyType Create()
        {
            // Design pattern :- Lazy loading. Eager loading
            if (_objectsofOurProjects == null)
            {
                _objectsofOurProjects = new UnityContainer();

                _objectsofOurProjects.RegisterType<IGateNodeTree,
                    GateNodeTree>();
               
            }
           return _objectsofOurProjects.Resolve<AnyType>();
        }
    }
}
