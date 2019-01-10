namespace CyClone.Core
{
    public interface IcyMapping
    {
        #region PROPERTIES

        bool IsMounted { get; }

        #endregion

        #region FUNCTIONS

        void Mount();
        void Unmount();
        void Unmount(bool force);

        #endregion
    }
}
