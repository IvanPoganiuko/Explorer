using FileTreeGrids.Extensions;
using FileTreeGrids.Models.FileSystemItems;
using FileTreeGrids.Models.FileSystemTrees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileTreeGrids
{
    public partial class FileTreeGrid : UserControl
    {
        //RoutedEvents
        public static readonly RoutedEvent RootChangedEvent;
        public static readonly RoutedEvent ItemTypeChangedEvent;

        //DependencyProperties
        public static readonly DependencyProperty RootProperty;
        public static readonly DependencyProperty ItemTypeProperty;

        //Events
        public event RoutedPropertyChangedEventHandler<string> RootChanged
        {
            add { AddHandler(RootChangedEvent, value); }
            remove { RemoveHandler(RootChangedEvent, value); }
        }
        public event RoutedPropertyChangedEventHandler<Type> ItemTypeChanged
        {
            add { AddHandler(ItemTypeChangedEvent, value); }
            remove { RemoveHandler(ItemTypeChangedEvent, value); }
        }

        //Properties
        public string Root
        {
            get { return (string)GetValue(RootProperty); }
            set { SetValue(RootProperty, value); }
        }
        public Type ItemType
        {
            get { return (Type)GetValue(ItemTypeProperty); }
            set { SetValue(ItemTypeProperty, value); }
        }

        internal FileSystemTree ItemsSource
        {
            get;
        }


        //Constructors
        static FileTreeGrid()
        {
            RootProperty = DependencyProperty.Register(
                nameof(Root), typeof(string), typeof(FileTreeGrid),
                new FrameworkPropertyMetadata(string.Empty, 
                    new PropertyChangedCallback(OnRootChanged)),
                new ValidateValueCallback(ValidateRootValue));
            ItemTypeProperty = DependencyProperty.Register(
                nameof(ItemType), typeof(Type), typeof(FileTreeGrid),
                new FrameworkPropertyMetadata(typeof(FileSystemItem),
                    new PropertyChangedCallback(OnItemTypeChanged)),
                new ValidateValueCallback(ValidateItemTypeValue));

            RootChangedEvent = EventManager.RegisterRoutedEvent(
                nameof(RootProperty), RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<string>),
                typeof(FileTreeGrid));
            ItemTypeChangedEvent = EventManager.RegisterRoutedEvent(
                nameof(ItemTypeProperty), RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Type>),
                typeof(FileTreeGrid));
        }
        public FileTreeGrid()
        {
            ItemsSource = new FileSystemTree();

            InitializeComponent();
        }

        //Static methods
        private static bool ValidateRootValue(object value)
        {
            string src = value as string;
            if (string.IsNullOrWhiteSpace(src))
                return false;

            if (!Directory.Exists(src))
                return false;

            return true;
        }
        private static void OnRootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (FileTreeGrid)d;

            var args = new RoutedPropertyChangedEventArgs<string>(
                (string)e.OldValue, (string)e.NewValue, RootChangedEvent);
            control.OnRootChanged(args);
        }
        private static bool ValidateItemTypeValue(object value)
        {
            var type = value as Type;

            if (value == null)
                return false;

            if (!type.IsCompatible<FileSystemItem>())
                return false;

            Type[] types = { typeof(FileSystemInfo) };
            if (type.GetConstructor(types) == null)
                return false;

            return true;
        }
        private static void OnItemTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (FileTreeGrid)d;

            var args = new RoutedPropertyChangedEventArgs<Type>(
                (Type)e.OldValue, (Type)e.NewValue, ItemTypeChangedEvent);
            control.OnItemTypeChanged(args);
        }

        //Methods
        protected virtual void OnRootChanged(RoutedPropertyChangedEventArgs<string> args)
        {
            ItemsSource.RootFullPath = Root;
            RaiseEvent(args);
        }
        protected virtual void OnItemTypeChanged(RoutedPropertyChangedEventArgs<Type> args)
        {
            ItemsSource.ItemType = ItemType;
            RaiseEvent(args);
        }
    }
}