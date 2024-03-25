﻿#pragma checksum "..\..\LoginWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FB581EFFAB62486D05228E3A881A9760088FDE3E08DB11E9E60116D0AF28D395"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCIPrviProjekat;
using Notification.Wpf.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HCIPrviProjekat {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path UIPath;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Notification.Wpf.Controls.NotificationArea WindowNotificationArea;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBUserName;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbErrorUsername;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TBPassword;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockPassword;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbErrorPassword;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLogin;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HCIPrviProjekat;component/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoginWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 15 "..\..\LoginWindow.xaml"
            ((HCIPrviProjekat.LoginWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UIPath = ((System.Windows.Shapes.Path)(target));
            return;
            case 3:
            this.WindowNotificationArea = ((Notification.Wpf.Controls.NotificationArea)(target));
            return;
            case 4:
            this.TBUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 181 "..\..\LoginWindow.xaml"
            this.TBUserName.GotFocus += new System.Windows.RoutedEventHandler(this.TBUserName_GotFocus);
            
            #line default
            #line hidden
            
            #line 181 "..\..\LoginWindow.xaml"
            this.TBUserName.LostFocus += new System.Windows.RoutedEventHandler(this.TBUserName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lbErrorUsername = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.TBPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 187 "..\..\LoginWindow.xaml"
            this.TBPassword.GotFocus += new System.Windows.RoutedEventHandler(this.TBPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 187 "..\..\LoginWindow.xaml"
            this.TBPassword.LostFocus += new System.Windows.RoutedEventHandler(this.TBPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBlockPassword = ((System.Windows.Controls.TextBlock)(target));
            
            #line 188 "..\..\LoginWindow.xaml"
            this.TextBlockPassword.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlockPassword_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbErrorPassword = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.BtnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 202 "..\..\LoginWindow.xaml"
            this.BtnLogin.Click += new System.Windows.RoutedEventHandler(this.BtnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnClose = ((System.Windows.Controls.Button)(target));
            
            #line 248 "..\..\LoginWindow.xaml"
            this.BtnClose.Click += new System.Windows.RoutedEventHandler(this.BtnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

