﻿#pragma checksum "..\..\GameOptions.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4B6C82E6FC99CE3E1DBF4CDE72D5573F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BattleShip;
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


namespace BattleShip {
    
    
    /// <summary>
    /// UsrCtrlGameOptions
    /// </summary>
    public partial class UsrCtrlGameOptions : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\GameOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton EasyBtn;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\GameOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton MediumBtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\GameOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton HardBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/BattleShip;component/gameoptions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GameOptions.xaml"
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
            this.EasyBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 10 "..\..\GameOptions.xaml"
            this.EasyBtn.Checked += new System.Windows.RoutedEventHandler(this.EasyBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MediumBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 11 "..\..\GameOptions.xaml"
            this.MediumBtn.Checked += new System.Windows.RoutedEventHandler(this.MediumBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.HardBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\GameOptions.xaml"
            this.HardBtn.Checked += new System.Windows.RoutedEventHandler(this.HardBtn_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

