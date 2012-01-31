namespace NHibernate.LoquaciousMappingConfig
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using System.Configuration;
   using System.Reflection;
   using NHibernate.LoquaciousMappingConfig.Config;
   using NHibernate.Mapping.ByCode;

   public static class ModelMapperExtend
   {
      /// <summary>
      /// Add the mapping from the "fluentNHibernateMapping" config section. For now can be added only the assemblies
      /// </summary>
      /// <param name="modelMapper"></param>
      /// <returns></returns>
      public static ModelMapper AddFromConfig(this ModelMapper modelMapper)
      {
         return AddFromConfig(modelMapper, LoquaciousNHibernateMappingHelper.DEFAULT_CONFIG_SECTION);
      }


      /// <summary>
      /// Add the mapping from a config section. For now can be added only the assemblies
      /// </summary>
      /// <param name="modelMapper"></param>
      /// <param name="configSection"></param>
      /// <returns></returns>
      /// <exception cref="ApplicationException"></exception>
      public static ModelMapper AddFromConfig(this ModelMapper modelMapper, string configSection)
      {
         var assemblies = LoquaciousNHibernateMappingHelper.GetAssembliesFromConfig(configSection);

         AddFromConfig(modelMapper, assemblies);

         return modelMapper;
      }

      private static void AddFromConfig(ModelMapper modelMapper, IList<Assembly> assemblies)
      {
         for (int i = 0; i < assemblies.Count; ++i)
         {
            modelMapper.AddMappings(assemblies[i].GetTypes());
         }
      }
   }
}
