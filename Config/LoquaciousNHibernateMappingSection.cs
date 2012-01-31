namespace NHibernate.LoquaciousMappingConfig.Config
{
   using System;
   using System.Configuration;
   using System.Reflection;

   public class LoquaciousNHibernateMappingSection : ConfigurationSection
   {
      [ConfigurationProperty("assemblies")]
      public AssemblyCollection Assemblies
      {
         get
         {
            return (AssemblyCollection)this["assemblies"];
         }
      }
   }
}
