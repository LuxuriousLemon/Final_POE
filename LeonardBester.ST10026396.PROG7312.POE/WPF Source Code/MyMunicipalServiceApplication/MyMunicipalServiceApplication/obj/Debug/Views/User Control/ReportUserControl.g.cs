﻿#pragma checksum "..\..\..\..\Views\User Control\ReportUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C61B2FA8605D84C31C87B1B7AB4573FEC2CDF2627A0100B8A9A93D1A2F894FD8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyMunicipalServiceApplication.Views.User_Control;
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


namespace MyMunicipalServiceApplication.Views.User_Control {
    
    
    /// <summary>
    /// ReportUserControl
    /// </summary>
    public partial class ReportUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLocation;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCategory;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtbDescription;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMediaAttachment;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtbFileDescription;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPrieview;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar prgEngagement;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
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
            System.Uri resourceLocater = new System.Uri("/MyMunicipalServiceApplication;component/views/user%20control/reportusercontrol.x" +
                    "aml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
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
            this.txtLocation = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.txtLocation.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputFieldChanged);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.txtLocation.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtLocation_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 51 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.cmbCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InputFieldChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rtbDescription = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 57 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.rtbDescription.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputFieldChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnMediaAttachment = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.btnMediaAttachment.Click += new System.Windows.RoutedEventHandler(this.btnMediaAttachment_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rtbFileDescription = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 61 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.rtbFileDescription.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputFieldChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.imgPrieview = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.prgEngagement = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\Views\User Control\ReportUserControl.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

