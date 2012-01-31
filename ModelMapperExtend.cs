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
         return AddFromConfig(modelMapper, "loquaciousNHibernateMapping");
      }
      /// <summary>
      /// Add the mapping from the "fluentNHibernateMapping" config section. For now can be added only the assemblies
      /// </summary>
      /// <param name="modelMapper"></param>
      /// <param name="assemblies">return the array of the assemblyes loaded with the maps</param>
      /// <returns></returns>
      public static ModelMapper AddFromConfig(this ModelMapper modelMapper, out Assembly[] assemblies)
      {
         return AddFromConfig(modelMapper, "loquaciousNHibernateMapping", out assemblies);
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
         Assembly[] assemblies;

         return AddFromConfig(modelMapper, configSection, out assemblies);
      }

      /// <summary>
      /// Add the mapping from a config section. For now can be added only the assemblies
      /// </summary>
      /// <param name="modelMapper"></param>
      /// <param name="configSection"></param>
      /// <param name="assemblies">return the array of the assemblyes loaded with the maps</param>
      /// <returns></returns>
      /// <exception cref="ApplicationException"></exception>
      public static ModelMapper AddFromConfig(this ModelMapper modelMapper, string configSection, out Assembly[] assemblies)
      {
         var ris = (LoquaciousNHibernateMappingSection)ConfigurationManager.GetSection(configSection);

         if (ris == null)
         {
            string msg = string.Format("Failed to load the config section \"{0}\" for the loquaciousNHibernateMapping.",
                                       configSection);
            throw new ApplicationException(msg);
         }

         assemblies = new Assembly[ris.Assemblies.Count];
         for (int i = 0; i < ris.Assemblies.Count; ++i)
         {
            var module = ris.Assemblies[i];
            var asm = Assembly.Load(module.Assembly);
            assemblies[i] = asm;
            modelMapper.AddMappings(asm.GetTypes());
         }

         return modelMapper;
      }
   }
}
