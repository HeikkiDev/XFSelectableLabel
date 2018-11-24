using System.ComponentModel;
using Android.Content;
using Android.Widget;
using SelectableLabelApp.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SelectableLabel), typeof(SelectableLabelApp.Droid.Renderers.SelectableLabelRenderer))]
namespace SelectableLabelApp.Droid.Renderers
{
    public class SelectableLabelRenderer : ViewRenderer<SelectableLabel, TextView>
    {
        TextView textView;

        public SelectableLabelRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SelectableLabel> e)
        {
            base.OnElementChanged(e);

            var label = (SelectableLabel)Element;
            if (label == null)
                return;

            if (Control == null)
            {
                textView = new TextView(this.Context);
            }

            textView.Enabled = true;
            textView.Focusable = true;
            textView.LongClickable = true;
            textView.SetTextIsSelectable(true);

            // Initial properties Set
            textView.Text = label.Text;
            textView.SetTextColor(label.TextColor.ToAndroid());
            switch (label.FontAttributes)
            {
                case FontAttributes.None:
                    textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                    break;
                case FontAttributes.Bold:
                    textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
                    break;
                case FontAttributes.Italic:
                    textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Italic);
                    break;
                default:
                    textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                    break;
            }

            textView.TextSize = (float)label.FontSize;

            SetNativeControl(textView);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SelectableLabel.TextProperty.PropertyName)
            {
                if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
                {
                    textView.Text = Element.Text;
                }
            }
            else if (e.PropertyName == SelectableLabel.TextColorProperty.PropertyName)
            {
                if (Control != null && Element != null)
                {
                    textView.SetTextColor(Element.TextColor.ToAndroid());
                }
            }
            else if (e.PropertyName == SelectableLabel.FontAttributesProperty.PropertyName
                        || e.PropertyName == SelectableLabel.FontSizeProperty.PropertyName)
            {
                if (Control != null && Element != null)
                {
                    switch (Element.FontAttributes)
                    {
                        case FontAttributes.None:
                            textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                            break;
                        case FontAttributes.Bold:
                            textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
                            break;
                        case FontAttributes.Italic:
                            textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Italic);
                            break;
                        default:
                            textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                            break;
                    }

                    textView.TextSize = (float)Element.FontSize;
                }
            }
        }
    }
}