﻿#pragma checksum "..\..\..\userControls\ToDoItem.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FE36DE1C3870C4D9C94C15939E2F6450ACC065804A3A1DC9776E99693F50BF9C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using MizuFlow;
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


namespace MizuFlow {
    
    
    /// <summary>
    /// ToDoItem
    /// </summary>
    public partial class ToDoItem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btn_TaskSolved;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Task;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_EditTask;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon md_EditTask;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_Importance;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.RatingBar BasicRatingBar;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Inf;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup taskInfoPopup;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTaskInfo;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_MoreFunk;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup moreFunctionsPopup;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_CreatingData;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker _dp_CreationDate;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Deadline;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_Deadline;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_DateCheck;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_DateCheck;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\..\userControls\ToDoItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_Groups;
        
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
            System.Uri resourceLocater = new System.Uri("/MizuFlows;component/usercontrols/todoitem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\userControls\ToDoItem.xaml"
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
            this.btn_TaskSolved = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 45 "..\..\..\userControls\ToDoItem.xaml"
            this.btn_TaskSolved.Click += new System.Windows.RoutedEventHandler(this.Btn_TaskSolved_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_Task = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btn_EditTask = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\userControls\ToDoItem.xaml"
            this.btn_EditTask.Click += new System.Windows.RoutedEventHandler(this.Btn_EditTask_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.md_EditTask = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 5:
            this.cb_Importance = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.BasicRatingBar = ((MaterialDesignThemes.Wpf.RatingBar)(target));
            
            #line 88 "..\..\..\userControls\ToDoItem.xaml"
            this.BasicRatingBar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<int>(this.BasicRatingBar_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 93 "..\..\..\userControls\ToDoItem.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_AddSubtask_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 104 "..\..\..\userControls\ToDoItem.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Delete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Btn_Inf = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\userControls\ToDoItem.xaml"
            this.Btn_Inf.Click += new System.Windows.RoutedEventHandler(this.Btn_Inf_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.taskInfoPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 11:
            this.txtTaskInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.Btn_MoreFunk = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\..\userControls\ToDoItem.xaml"
            this.Btn_MoreFunk.Click += new System.Windows.RoutedEventHandler(this.Btn_MoreFunk_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.moreFunctionsPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 14:
            this.btn_CreatingData = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this._dp_CreationDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 168 "..\..\..\userControls\ToDoItem.xaml"
            this._dp_CreationDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Dp_CreatingDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btn_Deadline = ((System.Windows.Controls.Button)(target));
            return;
            case 17:
            this.dp_Deadline = ((System.Windows.Controls.DatePicker)(target));
            
            #line 194 "..\..\..\userControls\ToDoItem.xaml"
            this.dp_Deadline.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Dp_Deadline_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 18:
            this.btn_DateCheck = ((System.Windows.Controls.Button)(target));
            return;
            case 19:
            this.dp_DateCheck = ((System.Windows.Controls.DatePicker)(target));
            
            #line 215 "..\..\..\userControls\ToDoItem.xaml"
            this.dp_DateCheck.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Dp_DateCheck_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 20:
            this.cb_Groups = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 21:
            
            #line 240 "..\..\..\userControls\ToDoItem.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_ClosePopup_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

