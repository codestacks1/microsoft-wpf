using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Xiaowen.CodeStacks.UIElements
{
    internal class StackPanelCommand : StackPanel, ICommandSource
    {
        public StackPanelCommand() : base() { }

        private static EventHandler _canExecuteChangedHandler;

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(StackPanelCommand),
            new PropertyMetadata((ICommand)null, new PropertyChangedCallback(CommandChanged))
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dObject"></param>
        /// <param name="e"></param>
        private static void CommandChanged(DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            StackPanelCommand stackPanel = (StackPanelCommand)dObject;
            stackPanel.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private void HookUpCommand(ICommand oldValue, ICommand newValue)
        {
            if (oldValue != null)
            {
                EventHandler handler = CanExecuteChanged;
                oldValue.CanExecuteChanged -= handler;
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

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter { get; set; }

        public IInputElement CommandTarget { get; set; }
    }
}
