using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Elements;
using Xamarin.Forms;

namespace MSO.StimmApp.Behaviors
{
    public class EditorLengthValidatorBehavior : Behavior<ExpandableEditor>
    {
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(EditorLengthValidatorBehavior), 0, BindingMode.TwoWay);

        public int MaxLength
        {
            get
            {
                var result = (int)GetValue(MaxLengthProperty);
                return result;
            }
            set => SetValue(MaxLengthProperty, value);
        }


        //public int MaxLength { get; set; }

        protected override void OnAttachedTo(ExpandableEditor bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
            bindable.BindingContextChanged += (sender, _) => this.BindingContext = ((BindableObject)sender).BindingContext;
        }

        protected override void OnDetachingFrom(ExpandableEditor bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var editor = (ExpandableEditor)sender;

            if (editor.Text != null && this.MaxLength >= 1 && editor.Text.Length > this.MaxLength)
            {
                editor.TextChanged -= OnEntryTextChanged;
                editor.Text = e.OldTextValue;
                editor.TextChanged += OnEntryTextChanged;
            }
        }
    }
}
