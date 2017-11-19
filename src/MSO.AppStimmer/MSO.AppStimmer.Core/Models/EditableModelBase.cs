namespace MSO.StimmApp.Core.Models
{
    // ToDo Update, to make it work with Xamarin
    //public abstract class EditableModelBase<T> : ModelBase, IEditableObject
    //{
    //    private T Cache { get; set; }

    //    private object CurrentModel => this;

    //    public RelayCommand CancelEditCommand => new RelayCommand(this.CancelEdit);

    //    public EditableModelBase(bool isNew)
    //        : base(isNew)
    //    { }

    //    public void BeginEdit()
    //    {
    //        this.Cache = Activator.CreateInstance<T>();

    //        //Set Properties of Cache
    //        foreach (var info in this.CurrentModel.GetType().GetProperties())
    //        {
    //            if (!info.CanRead || !info.CanWrite)
    //            {
    //                continue;
    //            }

    //            var oldValue = info.GetValue(this.CurrentModel, null);
    //            var editableObject = oldValue as IEditableObject;
    //            editableObject?.BeginEdit();

    //            this.Cache.GetType().GetProperty(info.Name).SetValue(this.Cache, oldValue, null);
    //        }
    //    }

    //    public void EndEdit()
    //    {
    //        this.Cache = default(T);
    //    }

    //    public void CancelEdit()
    //    {
    //        foreach (var info in this.CurrentModel.GetType().GetProperties())
    //        {
    //            if (!info.CanRead || !info.CanWrite)
    //            {
    //                continue;
    //            }

    //            var oldValue = info.GetValue(this.Cache, null);
    //            var editableObject = oldValue as IEditableObject;
    //            editableObject?.CancelEdit();

    //            this.CurrentModel.GetType().GetProperty(info.Name).SetValue(this.CurrentModel, oldValue, null);
    //        }
    //    }
    //}
}
