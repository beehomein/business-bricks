﻿#pragma checksum "..\..\..\Promotions\CreatePromotion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53242F9E67891246DFF6F8813E91A360266C0660"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Billing_Presentation.Promotions;
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


namespace Billing_Presentation.Promotions {
    
    
    /// <summary>
    /// CreatePromotion
    /// </summary>
    public partial class CreatePromotion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Promotions\CreatePromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Promotion;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Promotions\CreatePromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submitbtn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Promotions\CreatePromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Closebtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Billing Presentation;component/promotions/createpromotion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Promotions\CreatePromotion.xaml"
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
            this.Promotion = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.Submitbtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Promotions\CreatePromotion.xaml"
            this.Submitbtn.Click += new System.Windows.RoutedEventHandler(this.submit);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Closebtn = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Promotions\CreatePromotion.xaml"
            this.Closebtn.Click += new System.Windows.RoutedEventHandler(this.close);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

