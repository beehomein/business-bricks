﻿#pragma checksum "..\..\PriceOverride.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF4A2923D22A41A2A7906806F74FCA76BE4E8409"
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
    /// PriceOverride
    /// </summary>
    public partial class PriceOverride : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\PriceOverride.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox barcode;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\PriceOverride.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OldPrice;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\PriceOverride.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewPrice;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\PriceOverride.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\PriceOverride.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/Billing Presentation;component/priceoverride.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PriceOverride.xaml"
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
            this.barcode = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\PriceOverride.xaml"
            this.barcode.KeyUp += new System.Windows.Input.KeyEventHandler(this.barcodeKeyup);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OldPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.NewPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\PriceOverride.xaml"
            this.NewPrice.KeyUp += new System.Windows.Input.KeyEventHandler(this.newPriceKeyup);
            
            #line default
            #line hidden
            
            #line 72 "..\..\PriceOverride.xaml"
            this.NewPrice.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidation);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\PriceOverride.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.Update);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\PriceOverride.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
