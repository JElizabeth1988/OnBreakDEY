﻿#pragma checksum "..\..\WPFListarContrato.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D2EB36EAFD3C5CE5479A71303A8F887B9265163"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
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
using System.Windows.Interactivity;
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
using Vista;


namespace Vista {
    
    
    /// <summary>
    /// ListarContrato
    /// </summary>
    public partial class ListarContrato : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvLista;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPasar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gbFiltrar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNumero;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboTipoContrato;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFiltrar;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WPFListarContrato.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRut;
        
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
            System.Uri resourceLocater = new System.Uri("/Vista;component/wpflistarcontrato.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WPFListarContrato.xaml"
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
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\WPFListarContrato.xaml"
            this.btnSalir.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgvLista = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\WPFListarContrato.xaml"
            this.dgvLista.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgvLista_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPasar = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.gbFiltrar = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 5:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.txtNumero = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cboTipoContrato = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.btnFiltrar = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\WPFListarContrato.xaml"
            this.btnFiltrar.Click += new System.Windows.RoutedEventHandler(this.btnFiltrar_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.txtRut = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

