﻿#pragma checksum "C:\Users\HP\Documents\Visual Studio 2015\Projects\App2\App2\TagSong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DB417D364459D9331EF0882FD141D867"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App2
{
    partial class TagSong : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.myMap = (global::Windows.UI.Xaml.Controls.Maps.MapControl)(target);
                    #line 14 "..\..\..\TagSong.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.myMap).Loaded += this.myMap_Loaded;
                    #line 14 "..\..\..\TagSong.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.myMap).MapTapped += this.myMap_MapTapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.add_song = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 15 "..\..\..\TagSong.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.add_song).Click += this.add_song_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.song_name = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 21 "..\..\..\TagSong.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.button).Click += this.button_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

