using DnaMesModel.Shared;

namespace DnaMesUiBll.Config
{
    public static class UiStyleHelper
    {
        #region Private Members

        private const string IslFileName = "IG.isl";

        #endregion Private Members

        #region styleLibraryPath

        /// <summary>
        /// Path to the Style Library folder installed by the install.
        /// </summary>
        private static string StyleLibraryPath => SysInfo.BinPath + nameof(Config) + "\\StyleLibraries";

        #endregion //styleLibraryPath

        #region Private Methods

        #region GetIsl

        public static string GetIsl(string fileName=IslFileName) => System.IO.Path.Combine(StyleLibraryPath, fileName);

        #endregion GetIsl

        #endregion Private Methods
    }
}