﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectXML.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProjectXML.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tài khoản không hợp lệ. Vui lòng liên hệ quản lý !.
        /// </summary>
        internal static string AccountNotValid {
            get {
                return ResourceManager.GetString("AccountNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string ChangePasswordFail {
            get {
                return ResourceManager.GetString("ChangePasswordFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đổi mật khẩu thành công.
        /// </summary>
        internal static string ChangePasswordSuccess {
            get {
                return ResourceManager.GetString("ChangePasswordSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không thể kết nối đến cơ sở dữ liệu.
        /// </summary>
        internal static string DatabaseConnectionError {
            get {
                return ResourceManager.GetString("DatabaseConnectionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đăng nhập thất bại. Vui lòng liên hệ quản lý !.
        /// </summary>
        internal static string LoginFail {
            get {
                return ResourceManager.GetString("LoginFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mật khẩu mới không khớp.
        /// </summary>
        internal static string NewPasswordNotCorrect {
            get {
                return ResourceManager.GetString("NewPasswordNotCorrect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mật khẩu cũ không đúng.
        /// </summary>
        internal static string OldPasswordNotCorrect {
            get {
                return ResourceManager.GetString("OldPasswordNotCorrect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vui lòng nhập đầy đủ thông tin.
        /// </summary>
        internal static string PleaseEnterCompleteInfo {
            get {
                return ResourceManager.GetString("PleaseEnterCompleteInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap SplashScreen {
            get {
                object obj = ResourceManager.GetObject("SplashScreen", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tài khoản hoặc mật khẩu không chính xác.
        /// </summary>
        internal static string WrongUsernameOrPassword {
            get {
                return ResourceManager.GetString("WrongUsernameOrPassword", resourceCulture);
            }
        }
    }
}
