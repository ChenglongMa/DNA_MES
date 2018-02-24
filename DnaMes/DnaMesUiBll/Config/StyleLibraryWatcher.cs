using System.ComponentModel;
using System.IO;
using Infragistics.Win.AppStyling;

namespace DnaMesUiBll.Config
{
    /// <summary>
    /// Class that watches a specific StyleLibrary file and updates the currently loaded StyleLibrary
    /// when the file changes.
    /// </summary>
    /// <remarks>
    /// Call UpdateStatus with the StyleLibrary file you want to watch, or null to stop watching.
    /// </remarks>
    public class StyleLibraryWatcher
    {
        #region Member Variables

        private FileSystemWatcher _fileSystemWatcher;
        private ISynchronizeInvoke _synchronizingObject;

        #endregion //Member Variables

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="synchronizingObject">An object that can be used to marshal FileSystemWatcher event handler calls.</param>
        public StyleLibraryWatcher(ISynchronizeInvoke synchronizingObject)
        {
            _synchronizingObject = synchronizingObject;
        }

        #endregion //Constructor

        #region Properties

        #region FileSystemWatcher

        private FileSystemWatcher FileSystemWatcher
        {
            get
            {
                if (_fileSystemWatcher == null)
                {
                    _fileSystemWatcher = new FileSystemWatcher();
                    _fileSystemWatcher.Changed += FileSystemWatcher_Changed;
                }

                return _fileSystemWatcher;
            }
        }

        #endregion //FileSystemWatcher

        #endregion //Properties

        #region Methods

        #region UpdateStatus

        /// <summary>
        /// Updates the status of the StyleLibraryWatcher
        /// </summary>
        /// <param name="fileToWatch">A FileInfo object that references the StyleLibrary file to watch, or null to stop watching.</param>
        internal void UpdateStatus(FileInfo fileToWatch)
        {
            // If there is currently no StyleLibrary selected to watch, turn off file watching.
            if (fileToWatch == null)
            {
                FileSystemWatcher.EnableRaisingEvents = false;
                return;
            }


            // Setup the FileSystemWatcher object.
            FileSystemWatcher.SynchronizingObject = _synchronizingObject;
            FileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
            FileSystemWatcher.Path = @fileToWatch.DirectoryName;
            FileSystemWatcher.Filter = @fileToWatch.Name;
            FileSystemWatcher.EnableRaisingEvents = true;
        }

        #endregion //UpdateStatus

        #endregion //Methods

        #region Event Handlers

        #region FileSystemWatcher_Changed

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            // Load the StyleLibrary that just changed.
            //
            // Wrap the load in a try/catch for an IO exception.  This exception can occur randomly based
            // on timing due to the fact that the application that modified the StyleLibrary might not have
            // closed the file when we try to load it.
            try
            {
                StyleManager.Load(@e.FullPath);
            }
            catch (IOException ex)
            {
            }
        }

        #endregion //FileSystemWatcher_Changed

        #endregion //Event Handlers
    }
}