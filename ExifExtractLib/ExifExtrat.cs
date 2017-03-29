using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;


namespace ExifExtractLib
{
    public class ExifExtrat
    {
        public ExifExtrat()
        {
        }

        #region Static Methods
        public static string GetExifDTOrig(string filePath)
        {
            Image image = null;
            try
            {
                image = new Bitmap(filePath);
                PropertyItem[] propItems = image.PropertyItems;
                foreach (PropertyItem propitem in propItems)
                {
                    if (propitem.Id.ToString("x") == "9003")
                    {
                        string strTakenDate = System.Text.Encoding.ASCII.GetString(propitem.Value);
                        if (image != null)
                            image.Dispose();
                        return strTakenDate;
                    }
                }
                if (image != null)
                    image.Dispose();
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                if (image != null)
                    image.Dispose();
                return null;
            }
        }
        #endregion Static Methods
    }
}
