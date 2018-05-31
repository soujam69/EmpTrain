using DevExpress.Mvvm;
using DevExpress.Xpf.Grid;
using System;
using System.Windows.Input;

namespace Employee_Training.Helpers
{
    class DevExpressGrid : ViewModelBase
    {
        public bool CanEdit
        {
            get { return GetProperty(() => CanEdit); }
            set { SetProperty(() => CanEdit, value); }
        }

        #region grid handle

        public const string OnNewItemCommandEvent = @"InitNewRow";
        private ICommand _onNewItemCommand;
        public ICommand OnNewItemCommand => _onNewItemCommand ?? (_onNewItemCommand = new DelegateCommand<InitNewRowEventArgs>(NewItemAction));

        public const string OnNewItemValidationCommandEvent = @"ValidateRow";
        private ICommand _onNewItemValidationCommand;
        public ICommand OnNewItemValidationCommand => _onNewItemValidationCommand ?? (_onNewItemValidationCommand = new DelegateCommand<GridRowValidationEventArgs>(NewItemValidationAction));

        public const string OnNewItemExceptionCommandEvent = @"InvalidRowException";
        private ICommand _onNewItemExceptionCommand;
        public ICommand OnNewItemExceptionCommand => _onNewItemExceptionCommand ?? (_onNewItemExceptionCommand = new DelegateCommand<InvalidRowExceptionEventArgs>(NewItemExceptionAction));

        public const string OnRowUpdatedCommandEvent = @"RowUpdated";
        private ICommand _onRowUpdatedCommand;
        public ICommand OnRowUpdatedCommand => _onRowUpdatedCommand ?? (_onRowUpdatedCommand = new DelegateCommand<RowEventArgs>(RowUpdatedAction));
        public const string OnPreviewMouseLeftButtonDownCommandEvent = @"PreviewMouseLeftButtonDown";
        private ICommand _onPreviewMouseLeftButtonDownCommand;
        public ICommand OnPreviewMouseLeftButtonDownCommand => _onPreviewMouseLeftButtonDownCommand ?? (_onPreviewMouseLeftButtonDownCommand = new DelegateCommand<MouseButtonEventArgs>(PreviewMouseLeftButtonDownAction));

        public const string SelectedItemCHangedCommandEvent = @"SelectedItemChanged";
        private ICommand _selectedItemCHangedCommand;
        public ICommand SelectedItemCHangedCommand => _selectedItemCHangedCommand ?? (_selectedItemCHangedCommand = new DelegateCommand<SelectedItemChangedEventArgs>(SelectedItemChangedAction));

        public const string OnShowGridMenuCommandEvent = @"ShowGridMenu";
        private ICommand _onShowGridMenuCommand;
        public ICommand OnShowGridMenuCommand => _onShowGridMenuCommand ?? (_onShowGridMenuCommand = new DelegateCommand<GridMenuEventArgs>(ShowGridMenuAction));
        //PreviewKeyDown
        public const string OnPreviewKeyDownCommandEvent = @"PreviewKeyDown";

        private ICommand _OnPreviewKeyDownCommand;
        public ICommand OnPreviewKeyDownCommand => _OnPreviewKeyDownCommand ?? (_OnPreviewKeyDownCommand = new DelegateCommand<KeyEventArgs>(PreviewKeyDownAction));

        #region actions
        public virtual void NewItemAction(InitNewRowEventArgs e)
        {
            throw new NotImplementedException();
        }
        public virtual void NewItemValidationAction(GridRowValidationEventArgs e)
        {
            throw new NotImplementedException();
        }
        public virtual void NewItemExceptionAction(InvalidRowExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
        public virtual void RowUpdatedAction(RowEventArgs e)
        {
            throw new NotImplementedException();
        }
        public virtual void PreviewMouseLeftButtonDownAction(MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
        public virtual void SelectedItemChangedAction(SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        public virtual void ShowGridMenuAction(GridMenuEventArgs e)
        {
            throw new NotImplementedException();
        }
        public virtual void PreviewKeyDownAction(KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
        #region helpers
        protected GridControl GetGridControlFromInitNewRowEvent(InitNewRowEventArgs e)
        {
            var table = e.OriginalSource as TableView;
            var grid = table.Parent as GridControl;
            return grid;
        }

        #endregion
    }
}
