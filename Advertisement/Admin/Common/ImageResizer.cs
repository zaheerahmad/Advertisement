//////////////////////////////////////////////////////////////////////////////
// This source code and all associated files and resources are copyrighted by
// the author(s). This source code and all associated files and resources may
// be used as long as they are used according to the terms and conditions set
// forth in The Code Project Open License (CPOL), which may be viewed at
// http://www.blackbeltcoder.com/Legal/Licenses/CPOL.
//
// Copyright (c) 2011 Jonathan Wood
//

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlackBeltCoder
{
	/// <summary>
	/// Class to resize an image.
	/// </summary>
	public class ImageResizer
	{
		/// <summary>
		/// Maximum width of resized image.
		/// </summary>
		public int MaxX { get; set; }

		/// <summary>
		/// Maximum height of resized image.
		/// </summary>
		public int MaxY { get; set; }

		/// <summary>
		/// If true, resized image is trimmed to exactly fit
		/// maximum width and height dimensions.
		/// </summary>
		public bool TrimImage { get; set; }

		/// <summary>
		/// Format used to save resized image.
		/// </summary>
		public ImageFormat SaveFormat { get; set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public ImageResizer()
		{
			MaxX = MaxY = 150;
			TrimImage = false;
			SaveFormat = ImageFormat.Jpeg;
		}

		/// <summary>
		/// Resizes the image from the source file according to the
		/// current settings and saves the result to the targe file.
		/// </summary>
		/// <param name="source">Path containing image to resize</param>
		/// <param name="target">Path to save resized image</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool Resize(string source, string target)
		{
			using (Image src = Image.FromFile(source, true))
			{
				// Check that we have an image
				if (src != null)
				{
					int origX, origY, newX, newY;
					int trimX = 0, trimY = 0;

					// Default to size of source image
					newX = origX = src.Width;
					newY = origY = src.Height;

					// Does image exceed maximum dimensions?
					if (origX > MaxX || origY > MaxY)
					{
						// Need to resize image
						if (TrimImage)
						{
							// Trim to exactly fit maximum dimensions
							double factor = Math.Max((double)MaxX / (double)origX,
								(double)MaxY / (double)origY);
							newX = (int)Math.Ceiling((double)origX * factor);
							newY = (int)Math.Ceiling((double)origY * factor);
							trimX = newX - MaxX;
							trimY = newY - MaxY;
						}
						else
						{
							// Resize (no trim) to keep within maximum dimensions
							double factor = Math.Min((double)MaxX / (double)origX,
								(double)MaxY / (double)origY);
							newX = (int)Math.Ceiling((double)origX * factor);
							newY = (int)Math.Ceiling((double)origY * factor);
						}
					}

					// Create destination image
					using (Image dest = new Bitmap(newX - trimX, newY - trimY))
					{
						Graphics graph = Graphics.FromImage(dest);
						graph.InterpolationMode =
							System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
						graph.DrawImage(src, -(trimX / 2), -(trimY / 2), newX, newY);
						dest.Save(target, SaveFormat);
						// Indicate success
						return true;
					}
				}
			}
			// Indicate failure
			return false;
		}
	}
}
