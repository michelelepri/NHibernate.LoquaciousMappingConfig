namespace NHibernate.LoquaciousMappingConfig.Config
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using System.Configuration;
   using System.Reflection;

   public static class LoquaciousNHibernateMappingHelper
   {
      public const string DEFAULT_CONFIG_SECTION = "loquaciousNHibernateMapping";

      /// <summary>
      /// Return the list of assemblies loaded from the default 'loquaciousNHibernateMapping' configSection
      /// </summary>
      /// <returns></returns>
      public static Assembly[] GetAssembliesFromConfig()
      {
         return GetAssembliesFromConfig(DEFAULT_CONFIG_SECTION);
      }

      /// <summary>
      /// Return the list of assemblies loaded from the configSection
      /// </summary>
      /// <param name="configSection"></param>
      /// <returns></returns>
      public static Assembly[] GetAssembliesFromConfig(string configSection)
      {
         var ris = (LoquaciousNHibernateMappingSection)ConfigurationManager.GetSection(configSection);

         if (ris == null)
         {
            string msg = String.Format("Failed to load the config section \"{0}\" for the loquaciousNHibernateMapping.",
                                       configSection);
            throw new ApplicationException(msg);
         }

         var assemblies = new Assembly[ris.Assemblies.Count];
         for (int i = 0; i < ris.Assemblies.Count; ++i)
         {
            var module = ris.Assemblies[i];
            var asm = Assembly.Load(module.Assembly);
            assemblies[i] = asm;
         }

         return assemblies;
      }
   }
}
