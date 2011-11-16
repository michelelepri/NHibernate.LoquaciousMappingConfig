namespace NHibernate.LoquaciousMappingConfig.Config
{
   using System.Configuration;

   public class AssemblyElement : ConfigurationElement
   {
      [ConfigurationProperty("assembly", IsRequired = true)]
      public string Assembly
      {
         get
         {
            return (string)this["assembly"];
         }
      }

   }
}
