using System.ComponentModel;
using System.Reflection;

namespace DemExTest.Common
{
    public static class ViewUtil
    {
        public static void DisplayAllProperties(object? obj, Panel panel)
        {
            foreach (var ctrl in panel.Controls.OfType<Control>().ToList())
            {
                if (ctrl?.Name.StartsWith("auto_") == true)
                {
                    panel.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            if (obj == null) return;

            int y = 45;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var browsableAttr = prop.GetCustomAttribute(typeof(BrowsableAttribute), true) as BrowsableAttribute;
                if (browsableAttr == null)
                {
                    var displayNameAttr = prop.GetCustomAttribute(typeof(DisplayNameAttribute), true) as DisplayNameAttribute;

                    string label = displayNameAttr?.DisplayName ?? prop.Name;

                    var nameLabel = new Label
                    {
                        Name = "auto_" + prop.Name,
                        Text = label + ":",
                        Location = new Point(15, y),
                        AutoSize = true
                    };

                    panel.Controls.Add(nameLabel);
                    nameLabel.ResumeLayout();

                    int xValueLabelLocation = nameLabel.Location.X + nameLabel.Width;
                    string text = prop.GetValue(obj)?.ToString() ?? "null";

                    var valueLabel = new Label
                    {
                        Name = "auto_value_" + prop.Name,
                        Text = text,
                        Location = new Point(xValueLabelLocation, y),
                        AutoSize = true
                    };

                    panel.Controls.Add(valueLabel);
                    y += 25;
                }
            }
        }
    }
}
