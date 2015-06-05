//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Timesheet
{
    
    
    /// <summary>
    /// The AuthenticationSection Configuration Section.
    /// </summary>
    public partial class AuthenticationSection : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the AuthenticationSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string AuthenticationSectionSectionName = "authenticationSection";
        
        /// <summary>
        /// Gets the AuthenticationSection instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public static global::Timesheet.AuthenticationSection Instance
        {
            get
            {
                return ((global::Timesheet.AuthenticationSection)(global::System.Configuration.ConfigurationManager.GetSection(global::Timesheet.AuthenticationSection.AuthenticationSectionSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Timesheet.AuthenticationSection.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Timesheet.AuthenticationSection.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Password Property
        /// <summary>
        /// The XML name of the <see cref="Password"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string PasswordPropertyName = "password";
        
        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Password.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Timesheet.AuthenticationSection.PasswordPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Timesheet.Password Password
        {
            get
            {
                return ((global::Timesheet.Password)(base[global::Timesheet.AuthenticationSection.PasswordPropertyName]));
            }
            set
            {
                base[global::Timesheet.AuthenticationSection.PasswordPropertyName] = value;
            }
        }
        #endregion
        
        #region Username Property
        /// <summary>
        /// The XML name of the <see cref="Username"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string UsernamePropertyName = "username";
        
        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Username.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Timesheet.AuthenticationSection.UsernamePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Timesheet.Username Username
        {
            get
            {
                return ((global::Timesheet.Username)(base[global::Timesheet.AuthenticationSection.UsernamePropertyName]));
            }
            set
            {
                base[global::Timesheet.AuthenticationSection.UsernamePropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Timesheet
{
    
    
    /// <summary>
    /// The Username Configuration Element.
    /// </summary>
    public partial class Username : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region value Property
        /// <summary>
        /// The XML name of the <see cref="value"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string valuePropertyName = "value";
        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The value.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Timesheet.Username.valuePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string value
        {
            get
            {
                return ((string)(base[global::Timesheet.Username.valuePropertyName]));
            }
            set
            {
                base[global::Timesheet.Username.valuePropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Timesheet
{
    
    
    /// <summary>
    /// The Password Configuration Element.
    /// </summary>
    public partial class Password : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region value Property
        /// <summary>
        /// The XML name of the <see cref="value"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string valuePropertyName = "value";
        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The value.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Timesheet.Password.valuePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string value
        {
            get
            {
                return ((string)(base[global::Timesheet.Password.valuePropertyName]));
            }
            set
            {
                base[global::Timesheet.Password.valuePropertyName] = value;
            }
        }
        #endregion
    }
}