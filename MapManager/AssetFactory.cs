using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapManager
{
    public static class AssetFactory
    {
        /// <summary>
        /// Given a directory of Asset files, construct an Enumerable that represents the assets.
        /// </summary>
        /// <param name="assetDirectory">The root directory to search for assets.</param>
        /// <returns>An IEnumerable of <see cref="Asset"/>.</returns>
        public static IEnumerable<Asset> Construct(string assetDirectory)
        {
            IList<Asset> assets = new List<Asset>();
            var allAssetPaths = Directory.EnumerateFiles(assetDirectory, "*.png", SearchOption.AllDirectories);

            foreach (var assetPath in allAssetPaths)
            {
                string name = assetPath.Replace(assetDirectory, string.Empty).Replace(".png", string.Empty);
                assets.Add(new Asset(assetPath) { Name = name });
            }

            return assets;
        }
    }
}
