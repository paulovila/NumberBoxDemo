using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace NumberBoxDemo
{
    public sealed partial class MainPage
    {
        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(Editor), typeof(MainPage), new PropertyMetadata(null));

        public Editor ViewModel
        {
            get => (Editor)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new Editor();

            var f1 = new FieldType { Label = "Category" };
            var f2 = new FieldType { Label = "Contributor" };
            var f3 = new FieldType { Label = "Modified" };
            var f4 = new FieldType { Label = "Name" };
            var op1 = new OperatorType { Label = "contains" };
            var op2 = new OperatorType { Label = "does not contain" };
            var op3 = new OperatorType { Label = "Before" };
            var op4 = new OperatorType { Label = "isEmpty" };
            ViewModel.FieldOperatorTypes = new ObservableCollection<FieldOperators> {
                new FieldOperators { Field=f1,                Operators= new ObservableCollection<OperatorType> { op1,op2} },
                new FieldOperators { Field=f2,                Operators= new ObservableCollection<OperatorType> { op1,op2} },
                new FieldOperators { Field=f3,                Operators= new ObservableCollection<OperatorType> { op1,op2,op3, op4} },
                new FieldOperators { Field=f4,                Operators= new ObservableCollection<OperatorType> { op3,op4} },
            };
            ViewModel.Fields = new ObservableCollection<FieldType> { f1, f2, f3, f4 };
            ViewModel.ConditionEditors = new ObservableCollection<ConditionEditor>();
        }

        private void OnAdd(object sender, RoutedEventArgs e) => ViewModel.Add();
    }

    public class OperatorType { public string Label { get; set; } }
    public class FieldType { public string Label { get; set; } }
    public class Condition : INPC
    {
        public Condition(ConditionEditor parent) => Parent = parent;
        public ConditionEditor Parent { get; set; }
        public OperatorType SelectedOperator { get; set; }
        FieldType _prevField;
        public FieldType Field { get => _field; 
            set { 
                if (_field != value) 
                { 
                    _field = value;
                    N();
                    if (_prevField == null)
                        Parent.AddEmptyCondition();
                    _prevField = _field;
                }
                
            }
        }
        FieldType _field;
    }
    public class FieldOperators
    {
        public FieldType Field { get; set; }
        public ObservableCollection<OperatorType> Operators { get; set; }
    }
    public class ConditionEditor : INPC
    {
        public ConditionEditor() => AddEmptyCondition();
        public void AddEmptyCondition() => Conditions.Add(new Condition(this));
        public string Name { get => _name; set { if (_name != value) { _name = value; N(); } } }
        string _name;
        public bool IsReadOnly { get; set; }
        public ObservableCollection<Condition> Conditions { get; set; } = new ObservableCollection<Condition>();
        public ObservableCollection<FieldType> Fields { get; internal set; }
    }
    public class Editor : INPC
    {
        public ObservableCollection<FieldOperators> FieldOperatorTypes { get; set; }
        public ObservableCollection<ConditionEditor> ConditionEditors { get; set; }
        public ConditionEditor SelectedConditionEditor { get => _selectedConditionEditor; set { if (_selectedConditionEditor != value) { _selectedConditionEditor = value; N(); } } }
        ConditionEditor _selectedConditionEditor;
        public ObservableCollection<FieldType> Fields { get; internal set; }
        int _i;
        internal void Add() => ConditionEditors.Add(new ConditionEditor() { Name = $"(new){++_i}" , Fields = this.Fields});
    }
    public class INPC : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void N([CallerMemberName] string s = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
    }
}
