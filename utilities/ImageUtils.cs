using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SwagLab.utilities
{

    static class ImageUtils
    {

        public static bool IsImageLoaded(dynamic imgTagOrUrl)
        {
            string imageUrl;
            try
            {
                // Step 1: Get the src attribute value of the <img> tag
                if (imgTagOrUrl.GetType() == typeof(OpenQA.Selenium.WebElement)) {
                    imageUrl = imgTagOrUrl.GetAttribute("src");
                }
                else
                {
                    imageUrl = imgTagOrUrl;

                }
                // Step 2: Create a WebRequest for the image URL
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageUrl);
                request.Method = "HEAD";

                // Step 3: Get the WebResponse
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Step 4: Check if the response status code is OK (200)
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Option 1: Check Content-Type to verify it's an image
                        string contentType = response.ContentType;
                        if (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }

                        // Option 2: Check file extension using regular expression
                        string fileExtensionPattern = @"\.(jpg|jpeg|png|gif|bmp|svg)$";
                        if (Regex.IsMatch(imageUrl, fileExtensionPattern, RegexOptions.IgnoreCase))
                        {
                            return true;
                        }

                        // Option 3: Check file extension using string ends with
                        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".svg" };
                        foreach (string extension in imageExtensions)
                        {
                            if (imageUrl.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                            {
                                return true;
                            }
                        }
                    }
                }

                // Step 5: If none of the checks pass, return false
                return false;
            }
            catch (Exception)
            {
                // Step 6: Handle exceptions and return false if any error occurs
                return false;
            }
        }
    }





}
