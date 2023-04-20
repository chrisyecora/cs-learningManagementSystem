using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Library.LMSystem.Models;

namespace MAUI.LMSystem.ViewModels
{
    public class ModuleDetailsViewModel : INotifyPropertyChanged
    {
        public ModuleDetailsViewModel(Module module)
        {
            Name = module.Name;
            Description = module.Description;
            ModuleContent = new ObservableCollection<ContentItem>(module.Content);
            NotifyPropertyChanged(nameof(ModuleContent));
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public ObservableCollection<ContentItem> ModuleContent {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

