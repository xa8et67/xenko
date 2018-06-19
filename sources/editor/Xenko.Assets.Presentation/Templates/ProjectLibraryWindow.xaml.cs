// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Xenko.Core.Assets.Editor.ViewModel;
using Xenko.Core;
using Xenko.Core.Presentation.Dialogs;
using Xenko.Core.Presentation.Services;
using Xenko.Core.Presentation.View;
using Xenko.Core.Presentation.ViewModel;
using Xenko.Core.Translation;
using MessageBoxButton = Xenko.Core.Presentation.Services.MessageBoxButton;
using MessageBoxImage = Xenko.Core.Presentation.Services.MessageBoxImage;

namespace Xenko.Assets.Presentation.Templates
{
    /// <summary>
    /// Interaction logic for GameTemplateWindow.xaml
    /// </summary>
    public partial class ProjectLibraryWindow : INotifyPropertyChanged
    {
        private readonly IViewModelServiceProvider services;
        private bool hasError;

        public ProjectLibraryWindow(string defaultLibraryName)
        {
            if (defaultLibraryName == null) throw new ArgumentNullException(nameof(defaultLibraryName));

            var dispatcher = new DispatcherService(Dispatcher);
            var dialog = new DialogService(dispatcher, EditorViewModel.Instance.EditorName);
            services = new ViewModelServiceProvider(new object[] { dispatcher, dialog });

            LibraryName = defaultLibraryName;
            Namespace = defaultLibraryName;
            InitializeComponent();
            DataContext = this;

            LibBox.TextChanged += LibBoxTextChanged;
        }

        private void LibBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            HasError = LibNameInputValidator(LibBox.Text);   // true=name collision
        }

        public bool HasError
        {
            get { return hasError; }
            set
            {
                hasError = value;
                OnPropertyChanged(nameof(HasError));
            }
        }

        public Func<string, bool> LibNameInputValidator { get; set; }

        public string LibraryName { get; set; }

        public string Namespace { get; set; }

        private async void ButtonOk(object sender, RoutedEventArgs e)
        {
            string error;
            if (!NamingHelper.IsValidNamespace(LibraryName, out error))
            {
                await services.Get<IDialogService>().MessageBox(string.Format(Tr._p("Message", "Type a valid library name. Error with {0}"), error), MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!NamingHelper.IsValidNamespace(Namespace, out error))
            {
                await services.Get<IDialogService>().MessageBox(string.Format(Tr._p("Message", "Type a valid namespace name. Error with {0}"), error), MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Result = Xenko.Core.Presentation.Services.DialogResult.Ok;
            Close();
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            Result = Xenko.Core.Presentation.Services.DialogResult.Cancel;
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
