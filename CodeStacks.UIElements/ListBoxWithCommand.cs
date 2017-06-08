using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace xiaowen.codestacks.uielements
{
#if NETFX_CORE
using Windows.UI.Xaml;
#endif
    public class ListBoxWithCommand : ListBox, ICommandSource
    {
        /// <summary>
        /// 
        /// </summary>
        public ListBoxWithCommand() : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private static EventHandler _canExecuteChangedHandler;

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(ListBoxWithCommand),
                new PropertyMetadata((ICommand)null, new PropertyChangedCallback(CommandChanged)));

        public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register(
            "CommandTarget",
            typeof(IInputElement),
            typeof(ListBoxWithCommand),
            new PropertyMetadata((IInputElement)null)
            );

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter",
            typeof(object),
            typeof(ListBoxWithCommand),
            new PropertyMetadata((object)null)
            );

        /// <summary>
        /// from ICommandSource
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// from ICommandSource
        /// </summary>
        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// from ICommandSource
        /// </summary>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dObject"></param>
        /// <param name="e"></param>
        private static void CommandChanged(DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            ListBoxWithCommand listbox = (ListBoxWithCommand)dObject;
            listbox.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldCommand"></param>
        /// <param name="newCommand"></param>
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            if (oldCommand != null)
            {
                EventHandler handler = CanExecuteChanged;
                oldCommand.CanExecuteChanged -= handler;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;
                if (command != null)
                {
                    if (command.CanExecute(this.CommandParameter, this.CommandTarget))
                        this.IsEnabled = true;
                    else
                        this.IsEnabled = false;
                }
                else
                {
                    if (this.Command.CanExecute(CommandParameter))
                        this.IsEnabled = true;
                    else
                        this.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// register command
        /// </summary>
        /// <param name="oldCommand"></param>
        /// <param name="newCommand"></param>
        private void AddCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            _canExecuteChangedHandler = handler;
            if (newCommand != null)
                newCommand.CanExecuteChanged += _canExecuteChangedHandler;
        }

        /// <summary>
        /// Cancellation command
        /// </summary>
        /// <param name="oldCommand"></param>
        /// <param name="newCommand"></param>
        private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= handler;
        }


        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;
                if (command != null)
                    command.Execute(this.CommandParameter, this.CommandTarget);
                else
                    ((ICommand)Command).Execute(CommandParameter);
            }
        }
    }
}
