using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Container
{
    #region Delegates
    public delegate void ContainerItemsEventDelegate(object sender, ContainerItemEventArgs e);
    public delegate bool ContainerExternalFilterDelegate(object sender,SharedLib.Applications.IApplicationProfile profile);
    #endregion

    #region IContainer
    /// <summary>
    /// Container interface.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Gets or sets the container id.
        /// </summary>
        int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Restructs the container.
        /// </summary>
        void Restruct();

        /// <summary>
        /// Occours when items are changed witthin the container.
        /// </summary>
        event ContainerItemsEventDelegate ItemsEvent;
    }
    #endregion

    #region ContainerItemEventArgs
    [Serializable()]
    public class ContainerItemEventArgs : EventArgs
    {
        #region Constructor
        public ContainerItemEventArgs(ContainerItemEventType action)
        {
            this.action = action;
        }
        public ContainerItemEventArgs(List<object> itemsList, ContainerItemEventType action)
        {
            this.newItems = itemsList;
            this.action = action;
        }
        /// <summary>
        /// Creates a new instance of ContainerItemEventArgs.
        /// </summary>
        /// <param name="containerId">ID of the container that raised the event.</param>
        /// <param name="itemsList">List of items affected by this event.</param>
        /// <param name="action">Type of the event.</param>
        public ContainerItemEventArgs(int containerId, List<object> itemsList, ContainerItemEventType action)
        {
            this.newItems = itemsList;
            this.action = action;
            this.containerId = containerId;

        }
        public ContainerItemEventArgs(int containerId, List<object> newItems, List<object> oldItems, ContainerItemEventType action)
        {
            this.NewItems = newItems;
            this.OldItems = oldItems;
            this.ContainerID = containerId;
            this.Action = action;
        }
        #endregion

        #region Fileds
        private ContainerItemEventType action;
        private List<object> newItems;
        private List<object> oldItems;
        private int containerId;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the container id that raised the event.
        /// </summary>
        public int ContainerID
        {
            get { return this.containerId; }
            protected set { this.containerId = value; }
        }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        public ContainerItemEventType Action
        {
            get { return this.action; }
            protected set { this.action = value; }
        }

        /// <summary>
        /// Gets the list of new items affected by this event.
        /// </summary>
        public List<object> NewItems
        {
            get
            {
                if (this.newItems == null)
                {
                    this.newItems = new List<object>();
                }
                return this.newItems;
            }
            set { this.newItems = value; }
        }

        /// <summary>
        /// Gets the list of olde items affected by this event.
        /// </summary>
        public List<object> OldItems
        {
            get
            {
                if (this.oldItems == null)
                {
                    this.oldItems = new List<object>();
                }
                return this.oldItems;
            }
            protected set { this.oldItems = value; }
        }

        #endregion

        #region Ovverides

        public override string ToString()
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(String.Format("Event Type:{0}", this.Action));
                builder.AppendLine(String.Format("New Items Count:{0}", this.NewItems.Count));
                foreach (var item in this.NewItems)
                {
                    builder.AppendLine(item.ToString());
                }
                builder.AppendLine(String.Format("Old Items Count:{0}", this.OldItems.Count));
                foreach (var item in this.OldItems)
                {
                    builder.AppendLine(item.ToString());
                }
                return builder.ToString();
            }
            catch
            {
                return base.ToString();
            }
        }

        #endregion
    }
    #endregion

    #region ContainerItemEventType
    [Serializable()]
    public enum ContainerItemEventType : int
    {
        /// <summary>
        /// Occours when item is added to container.
        /// <remarks>NewItems propery contains added items.</remarks>
        /// </summary>
        Added = 0,
        /// <summary>
        /// Occours when shared item is unasigned.
        /// <remarks>NewItems propery contains unasigned items.</remarks>
        /// </summary>
        UnAssigned = 4,
        /// <summary>
        /// Occours when item is removed from container.
        /// <remarks>NewItems propery contains removed items.</remarks>
        /// </summary>
        Removed = 8,
        /// <summary>
        /// Occours when item is added to container.
        /// </summary>
        Replaced = 16,
    }
    #endregion

}
