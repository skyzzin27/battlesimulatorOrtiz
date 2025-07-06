using System;
using System.Drawing;
using System.Windows.Forms;

public class ColoredProgressBar : ProgressBar
{
    public ColoredProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rec = e.ClipRectangle;

        // Background
        e.Graphics.FillRectangle(Brushes.LightGray, rec);

        rec.Width = (int)(rec.Width * ((double)Value / Maximum));

        Brush brush = Brushes.Green;

        double percent = (double)Value / Maximum;

        if (percent <= 0.3)
            brush = Brushes.Red;
        else if (percent <= 0.6)
            brush = Brushes.Orange;

        e.Graphics.FillRectangle(brush, 0, 0, rec.Width, rec.Height);

        // Optional: draw text like "76/100"
        string percentText = $"{Value} HP";
        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
        using (var font = new Font(FontFamily.GenericSansSerif, 8))
        {
            e.Graphics.DrawString(percentText, font, Brushes.Black, rec, sf);
        }
    }
}
