namespace NHibernate.LoquaciousMappingConfig.Config
{
   using System.Configuration;

   public class FluentNHibernateMappingSection : ConfigurationSection
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
