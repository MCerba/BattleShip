﻿#pragma checksum "..\..\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "395A351795C6FC0D8746B9C16C45812A"
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
    /// UsrCtrlMainMenu
    /// </summary>
    public partial class UsrCtrlMainMenu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainMenu;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewGameBtn;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OptBtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuitBtn;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContinueBtn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameTxt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Display;
        
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
            System.Uri resourceLocater = new System.Uri("/BattleShip;component/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainMenu.xaml"
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
            this.MainMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.NewGameBtn = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\MainMenu.xaml"
            this.NewGameBtn.Click += new System.Windows.RoutedEventHandler(this.NewGameBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OptBtn = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\MainMenu.xaml"
            this.OptBtn.Click += new System.Windows.RoutedEventHandler(this.OptBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.QuitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\MainMenu.xaml"
            this.QuitBtn.Click += new System.Windows.RoutedEventHandler(this.QuitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ContinueBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\MainMenu.xaml"
            this.ContinueBtn.Click += new System.Windows.RoutedEventHandler(this.ContinueBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UserNameTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\MainMenu.xaml"
            this.UserNameTxt.KeyDown += new System.Windows.Input.KeyEventHandler(this.UserNameTxt_KeyDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainMenu.xaml"
            this.UserNameTxt.GotFocus += new System.Windows.RoutedEventHandler(this.UserNameTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Display = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
