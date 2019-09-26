namespace CyClone.Core
{
    public interface IcyMapping
    {
        #region PROPERTIES

        /// <summary>
        /// Gets if mapping is currently mounted.
        /// </summary>
        bool IsMounted { get; }

        #endregion

        #region FUNCTIONS

        void Mount();
        void Unmount();
        void Unmount(bool force);

        #endregion
    }
}
