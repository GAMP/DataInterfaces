using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GizmoDALV2.DTO
{
    #region AppEntityContainer
    /// <summary>
    /// App entity container dto.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class AppEntityContainer
    {
        #region FIELDS
        private IEnumerable<Entities.AppEnterprise> enterprises;
        private IEnumerable<Entities.AppCategory> categories;
        private IEnumerable<Entities.App> apps;
        private IEnumerable<Entities.AppExe> executables;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Get or sets enterprises.
        /// </summary>
        [ProtoMember(1, AsReference = true)]
        [DataMember()]
        public IEnumerable<Entities.AppEnterprise> Enterprises
        {
            get
            {
                if (enterprises == null)
                    enterprises = new List<Entities.AppEnterprise>();
                return enterprises;
            }
            set
            {
                enterprises = value;
            }
        }

        /// <summary>
        /// Gets or sets categories.
        /// </summary>
        [ProtoMember(2, AsReference = true)]
        [DataMember()]
        public IEnumerable<Entities.AppCategory> Categories
        {
            get
            {
                if (categories == null)
                    categories = new List<Entities.AppCategory>();
                return categories;
            }
            set
            {
                categories = value;
            }
        }

        /// <summary>
        /// Gets or sets apps.
        /// </summary>
        [ProtoMember(3, AsReference = true)]
        [DataMember()]
        public IEnumerable<Entities.App> Apps
        {
            get
            {
                if (apps == null)
                    apps = new List<Entities.App>();
                return apps;
            }
            set
            {
                apps = value;
            }
        }

        /// <summary>
        /// Gets or sets executables.
        /// </summary>
        [ProtoMember(4, AsReference = true)]
        [DataMember()]
        public IEnumerable<Entities.AppExe> Executables
        {
            get
            {
                if (executables == null)
                    executables = new List<Entities.AppExe>();
                return executables;
            }
            set
            {
                executables = value;
            }
        }

        #endregion
    }
    #endregion

    #region AppInfoContainer
    /// <summary>
    /// Application info container.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class AppInfoContainer
    {
        #region FIELDS
        private IEnumerable<AppRatingDTO> appRatings;
        private IEnumerable<AppStatDTO> appStats;
        private IEnumerable<AppExeStatDTO> appExe;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets app ratings.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public IEnumerable<AppRatingDTO> AppRating
        {
            get
            {
                if (appRatings == null)
                    appRatings = new List<AppRatingDTO>();
                return appRatings;
            }
            set
            {
                appRatings = value;
            }
        }

        /// <summary>
        /// Gets or sets app stats.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public IEnumerable<AppStatDTO> AppStat
        {
            get
            {
                if (appStats == null)
                    appStats = new List<AppStatDTO>();
                return appStats;
            }
            set
            {
                appStats = value;
            }
        }

        /// <summary>
        /// Gets or sets app exe stat.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public IEnumerable<AppExeStatDTO> AppExeStat
        {
            get
            {
                if (appExe == null)
                    appExe = new List<AppExeStatDTO>();
                return appExe;
            }
            set
            {
                appExe = value;
            }
        }

        #endregion
    }
    #endregion

    #region NewsEntityContainer
    /// <summary>
    /// News and adds entity container.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class NewsEntityContainer
    {
        #region FILEDS
        IEnumerable<Entities.News> news;
        IEnumerable<Entities.Feed> feeds;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets news.
        /// </summary>
        [ProtoMember(1)]
        public IEnumerable<Entities.News> News
        {
            get
            {
                if (news == null)
                    news = new List<Entities.News>();
                return news;
            }
            set { news = value; }
        }

        /// <summary>
        /// Gets or sets feeds.
        /// </summary>
        [ProtoMember(2)]
        public IEnumerable<Entities.Feed> Feeds
        {
            get
            {
                if (feeds == null)
                    feeds = new List<Entities.Feed>();
                return feeds;
            }
            set { feeds = value; }
        }

        #endregion
    } 
    #endregion
}
