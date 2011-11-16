using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernate.LoquaciousMappingConfig
{
   using System.Reflection;
   using NHibernate.Mapping.ByCode;

   public static class ModelMapperExtend
   {
      /// <summary>
      /// Add the mapping from the "fluentNHibernateMapping" config section. For now can be added only the assemblies
      /// </summary>
      /// <param name="fluentMappingsContainer"></param>
      /// <returns></returns>
      public static ModelMapper AddFromConfig(this ModelMapper modelMapper)
      {
         return AddFromConfig(modelMapper, "loquaciousNHibernateMapping");
      }

      /// <summary>
      /// Add the mapping from a config section. For now can be added only the assemblies
      /// </summary>
      /// <param name="fluentMappingsContainer"></param>
      /// <param name="configSection"></param>
      /// <returns></returns>
      /// <exception cref="ApplicationException"></exception>
      public static ModelMapper AddFromConfig(this ModelMapper fluentMappingsContainer, string configSection)
      {
         var ris = (FluentNHibernateMappingSection)ConfigurationManager.GetSection(configSection);

         if (ris == null)
         {
            string msg = string.Format("Failed to load the config section \"{0}\" for the FluentNHibernateMappingConfig.",
                                       configSection);
            throw new ApplicationException(msg);
         }

         for (int i = 0; i < ris.Assemblies.Count; ++i)
         {
            var module = ris.Assemblies[i];
            fluentMappingsContainer.AddFromAssembly(Assembly.Load(module.Assembly));
         }

         return fluentMappingsContainer;
      }
   }
}
