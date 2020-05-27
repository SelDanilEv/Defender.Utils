using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DefenderUniversalLibrary
{
    #region Singleton
    public class Singleton<Class> where Class : class, new()
    {
        private static Class instance;

        private static object syncRoot = new Object();

        protected Singleton() { }

        public static Class GetInstance()
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new Class();
            }
            return instance;
        }

        public static void SetInstance(Class @class)
        {
            instance = @class;
        }
    }
    #endregion

    #region Repository
    public interface IRepository<T> where T : class                //use pattern repository for each entity
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
    #endregion

    #region Command
    public class RelayCommand<T> : ICommand        //command with parameter
    {
        private Action<T> _execute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {
            _execute?.Invoke((T)parameter);
        }

        public RelayCommand(Action<T> execute)
        {
            _execute = execute;
        }
    }

    public class Command : ICommand              // command without parameter
    {
        public Command() { }

        private Action _execute;

        public event EventHandler CanExecuteChanged;

        public Command(Action execute)
        {
            _execute = execute;
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
    }
    #endregion
}
