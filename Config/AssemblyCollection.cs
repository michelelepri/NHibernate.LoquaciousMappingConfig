namespace NHibernate.LoquaciousMappingConfig.Config
{
   using System.Configuration;

   public class AssemblyCollection : ConfigurationElementCollection
   {
      public AssemblyElement this[int index]
      {
         get
         {
            return base.BaseGet(index) as AssemblyElement;
         }
         set
         {
            if (base.BaseGet(index) != null)
            {
               base.BaseRemoveAt(index);
            }
            this.BaseAdd(index, value);
         }
      }

      #region Overrides of ConfigurationElementCollection

      protected override ConfigurationElement CreateNewElement()
      {
         return new AssemblyElement();
      }

      protected override object GetElementKey(ConfigurationElement element)
      {
         var o = ((AssemblyElement)element);

         return o.Assembly;
      }

      #endregion
   }
}
