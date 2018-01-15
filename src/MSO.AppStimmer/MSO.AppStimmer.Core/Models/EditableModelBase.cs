using System;
using System.ComponentModel;
using System.Reflection;
using GalaSoft.MvvmLight.Command;

namespace MSO.StimmApp.Core.Models
{
    public abstract class EditableModelBase<T> : ModelBase, IEditableObject
    {
        private T Cache { get; set; }

        private object CurrentModel => this;

        public RelayCommand CancelEditCommand => new RelayCommand(this.CancelEdit);

        protected EditableModelBase(bool isNew)
            : base(isNew)
        { }

        public void BeginEdit()
        {
            this.Cache = Activator.CreateInstance<T>();

            //Set Properties of Cache
            foreach (var info in this.CurrentModel.GetType().GetRuntimeProperties())
            {
                if (!info.CanRead || !info.CanWrite)
                    continue;

                var oldValue = info.GetValue(this.CurrentModel, null);
                var editableObject = oldValue as IEditableObject;
                editableObject?.BeginEdit();

                this.Cache.GetType().GetRuntimeProperty(info.Name).SetValue(this.Cache, oldValue, null);
            }
        }

        public void EndEdit()
        {
            this.Cache = default(T);
        }

        public void CancelEdit()
        {
            foreach (var info in this.CurrentModel.GetType().GetRuntimeProperties())
            {
                if (!info.CanRead || !info.CanWrite)
                    continue;

                var oldValue = info.GetValue(this.Cache, null);
                var editableObject = oldValue as IEditableObject;
                editableObject?.CancelEdit();

                this.CurrentModel.GetType().GetRuntimeProperty(info.Name).SetValue(this.CurrentModel, oldValue, null);
            }
        }
    }
}
