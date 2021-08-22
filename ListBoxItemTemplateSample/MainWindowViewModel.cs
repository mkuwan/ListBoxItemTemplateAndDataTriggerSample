using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ListBoxItemTemplateSample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<SampleData> _sampleDatas;
        public ObservableCollection<SampleData> SampleDatas 
        { 
            get => _sampleDatas;
            set
            {
                _sampleDatas = value;
                OnPropertyChanged();
            }
        }

        private ICommand _loaded { get; set; }
        public ICommand LoadedCommand => _loaded ?? (_loaded = new RelayCommand(OnLoaded));


        public MainWindowViewModel()
        {

        }


        private void OnLoaded()
        {
            SetDatas();
        }

        private void SetDatas()
        {
            SampleDatas = new ObservableCollection<SampleData>();
            for (int i = 0; i < 10; i++)
            {
                SampleDatas.Add(new SampleData()
                {
                    ID = i,
                    SampleText = $"さんぷるてきすと{i}",
                    SampleText2 = $"サンプルテキスト{i}"
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _action != null;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }

    }

    public class SampleData
    {
        public int ID { get; set; }

        public string SampleText { get; set; }

        public string SampleText2 { get; set; }

    }
}
