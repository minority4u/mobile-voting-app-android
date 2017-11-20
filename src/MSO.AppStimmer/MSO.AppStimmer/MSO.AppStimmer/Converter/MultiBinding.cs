
/*
    WARNING: This MultiBinding implementation only works when it is directly applied to its target property.
    It will fail if used inside of a setter (such is the case when used within a trigger or style).
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Converter
{
    /// <inheritdoc />
    /// <summary>
    ///     A class for binding on multiple Properties at once.
    /// </summary>
    [ContentProperty(nameof(Bindings))]
    public class MultiBinding : IMarkupExtension<Binding>
    {
        private BindableObject target;
        private readonly InternalValue internalValue = new InternalValue();
        private readonly IList<BindableProperty> properties = new List<BindableProperty>();

        public IList<Binding> Bindings { get; } = new List<Binding>();

        public string StringFormat { get; set; }

        public IMultiValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }

        public Binding ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(StringFormat) && Converter == null)
                throw new InvalidOperationException($"{nameof(MultiBinding)} requires a {nameof(Converter)} or {nameof(StringFormat)}");

            // Get the object that the markup extension is being applied to
            var provideValueTarget = (IProvideValueTarget)serviceProvider?.GetService(typeof(IProvideValueTarget));
            target = provideValueTarget?.TargetObject as BindableObject;

            if (target == null)
                return null;

            foreach (var b in Bindings)
            {
                var property = BindableProperty.Create($"Property-{Guid.NewGuid().ToString("N")}", typeof(object),
                    typeof(MultiBinding), default(object), propertyChanged: (_, o, n) => SetValue());

                properties.Add(property);
                target.SetBinding(property, b);
            }

            this.SetValue();

            var binding = new Binding
            {
                Path = nameof(InternalValue.Value),
                Converter = new MultiValueConverterWrapper(Converter, StringFormat),
                ConverterParameter = ConverterParameter,
                Source = this.internalValue
            };

            return binding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            var result = ProvideValue(serviceProvider);
            return result;
        }

        private void SetValue()
        {
            if (target == null)
                return;

            this.internalValue.Value = properties.Select(target.GetValue).ToArray();
        }

        private sealed class InternalValue : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private object value;
            public object Value
            {
                get => value;

                set
                {
                    if (Equals(this.value, value))
                        return;

                    this.value = value;
                    this.OnPropertyChanged();
                }
            }

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private sealed class MultiValueConverterWrapper : IValueConverter
        {
            private readonly IMultiValueConverter multiValueConverter;
            private readonly string stringFormat;

            public MultiValueConverterWrapper(IMultiValueConverter multiValueConverter, string stringFormat)
            {
                this.multiValueConverter = multiValueConverter;
                this.stringFormat = stringFormat;
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (multiValueConverter != null)
                {
                    value = multiValueConverter.Convert(value as object[], targetType, parameter, culture);
                }
                if (string.IsNullOrWhiteSpace(stringFormat))
                    return value;

                // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
                if (value is object[] array)
                {
                    value = string.Format(stringFormat, array);
                }
                else
                {
                    value = string.Format(stringFormat, value);
                }

                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}