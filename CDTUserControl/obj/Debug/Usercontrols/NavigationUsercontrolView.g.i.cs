﻿#pragma checksum "..\..\..\Usercontrols\NavigationUsercontrolView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96D1124EC538581BC789C70922593F622A08D03D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CDTUserControl.Usercontrols;
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


namespace CDTUserControl.Usercontrols {
    
    
    /// <summary>
    /// NavigationUsercontrolView
    /// </summary>
    public partial class NavigationUsercontrolView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image filterimage;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image lockimage;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image filtercolourimage;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem MyTabItem1;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ColorButton;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem MyTabItem2;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AnalysisDataGrid;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem MyTabItem3;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SessionLogDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/CDTUserControl;component/usercontrols/navigationusercontrolview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
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
            this.filterimage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.lockimage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.filtercolourimage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            
            #line 51 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
            ((System.Windows.Controls.TabControl)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MyTabItem1 = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.ColorButton = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\Usercontrols\NavigationUsercontrolView.xaml"
            this.ColorButton.Click += new System.Windows.RoutedEventHandler(this.Btn_ColorBoxClickEvent);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MyTabItem2 = ((System.Windows.Controls.TabItem)(target));
            return;
            case 8:
            this.AnalysisDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.MyTabItem3 = ((System.Windows.Controls.TabItem)(target));
            return;
            case 10:
            this.SessionLogDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

