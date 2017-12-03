using System;
using GalaSoft.MvvmLight;
using MSO.StimmApp.Core.Helpers;

namespace MSO.StimmApp.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    ///     The base class for all model objects.
    ///     Can be extended by additonal properties, if neccessary.
    /// </summary>
    public class ModelBase : ObservableObject
    {
        public ModelBase(bool isNew = true)
        {
            this.Id = Guid.NewGuid();
            this.IsNew = isNew;
        }

        /// <summary>
        ///     Returns true, if the model object was newly created. False otherwise.
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        ///     A unique identifier for this model object.
        /// </summary>
        public Guid Id { get; set; }
    }
}
