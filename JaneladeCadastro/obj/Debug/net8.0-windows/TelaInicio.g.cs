﻿#pragma checksum "..\..\..\TelaInicio.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5B04C69A8D6040D4995AC33C02FF4D8CEF3C33A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using JaneladeCadastro;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace JaneladeCadastro {
    
    
    /// <summary>
    /// TelaInicio
    /// </summary>
    public partial class TelaInicio : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\..\TelaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\TelaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\TelaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGerenciarRegistro;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\TelaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtGerenciar;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\TelaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdicionarRegistro;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\TelaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAdicionar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JaneladeCadastro;component/telainicio.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TelaInicio.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 23 "..\..\..\TelaInicio.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\TelaInicio.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\TelaInicio.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnGerenciarRegistro = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\TelaInicio.xaml"
            this.btnGerenciarRegistro.Click += new System.Windows.RoutedEventHandler(this.btnGerenciarRegistro_Click);
            
            #line default
            #line hidden
            
            #line 123 "..\..\..\TelaInicio.xaml"
            this.btnGerenciarRegistro.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 124 "..\..\..\TelaInicio.xaml"
            this.btnGerenciarRegistro.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtGerenciar = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btnAdicionarRegistro = ((System.Windows.Controls.Button)(target));
            
            #line 169 "..\..\..\TelaInicio.xaml"
            this.btnAdicionarRegistro.Click += new System.Windows.RoutedEventHandler(this.btnAdicionarRegistro_Click);
            
            #line default
            #line hidden
            
            #line 171 "..\..\..\TelaInicio.xaml"
            this.btnAdicionarRegistro.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter_1);
            
            #line default
            #line hidden
            
            #line 172 "..\..\..\TelaInicio.xaml"
            this.btnAdicionarRegistro.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtAdicionar = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

