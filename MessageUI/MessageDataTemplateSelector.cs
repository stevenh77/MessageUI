using System;
using System.Windows;
using System.Windows.Controls;
using MessageUI.Models;
using MessageUI.ViewModels;

namespace MessageUI
{
    public class MessageDataTemplateSelector : ContentControl
    {
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            var item = newContent as MessageViewModel;
            if (item == null) throw new Exception("Expected datatype is MessageViewModel");

            // you could load dynamically from a DLL or loose xaml file, here we use an application resource
            var key = string.Format("{0}DataTemplate", item.MessageType);
            var dataTemplate = Application.Current.Resources[key] as DataTemplate;

            ContentTemplate = dataTemplate;
        }
    }
}