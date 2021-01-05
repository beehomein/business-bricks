﻿#pragma checksum "..\..\ConnectionStatus.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D5427A6DD593E07ED93A814413C41460A79152B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Billing_Presentation;
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


namespace Billing_Presentation {
    
    
    /// <summary>
    /// ConnectionStatus
    /// </summary>
    public partial class ConnectionStatus : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button checkPrinterStatus;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Container;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border InternetStatus;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Internetcheck;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label connection;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image connectionImage;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border UpdateStatus;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Timecheck;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label time;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image dbConnection;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\ConnectionStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close;
        
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
            System.Uri resourceLocater = new System.Uri("/Billing Presentation;component/connectionstatus.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConnectionStatus.xaml"
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
            this.checkPrinterStatus = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\ConnectionStatus.xaml"
            this.checkPrinterStatus.Click += new System.Windows.RoutedEventHandler(this.CheckPrinterStatus_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Container = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.InternetStatus = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.Internetcheck = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\ConnectionStatus.xaml"
            this.Internetcheck.Click += new System.Windows.RoutedEventHandler(this.Internetcheck_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.connection = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.connectionImage = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.UpdateStatus = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.Timecheck = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\ConnectionStatus.xaml"
            this.Timecheck.Click += new System.Windows.RoutedEventHandler(this.Timecheck_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.time = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.dbConnection = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.close = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\ConnectionStatus.xaml"
            this.close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

