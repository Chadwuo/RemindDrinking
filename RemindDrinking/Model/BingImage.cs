using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RemindDrinking.Model
{
    /// <summary>
    /// BingImage class
    /// </summary>
    [DataContract]
    public class BingImage
    {
        /// <summary>
        /// Images
        /// </summary>
        [DataMember(Name = "images")]
        public List<Images> Images { get; set; }
    }

    /// <summary>
    /// Images class
    /// </summary>
    [DataContract]
    public class Images
    {
        
        /// <summary>
        /// Startdate
        /// </summary>
        [DataMember(Name = "startdate")]
        public string Startdate { get; set; }

        /// <summary>
        /// Fullstartdate
        /// </summary>
        [DataMember(Name = "fullstartdate")]
        public string Fullstartdate { get; set; }

        /// <summary>
        /// Enddate
        /// </summary>
        [DataMember(Name = "enddate")]
        public string Enddate { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Urlbase
        /// </summary>
        [DataMember(Name = "urlbase")]
        public string Urlbase { get; set; }

        /// <summary>
        /// Copyright
        /// </summary>
        [DataMember(Name = "copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// Copyrightlink
        /// </summary>
        [DataMember(Name = "copyrightlink")]
        public string Copyrightlink { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Quiz
        /// </summary>
        [DataMember(Name = "quiz")]
        public string Quiz { get; set; }

        /// <summary>
        /// Wp
        /// </summary>
        [DataMember(Name = "wp")]
        public bool Wp { get; set; }

        /// <summary>
        /// Hsh
        /// </summary>
        [DataMember(Name = "hsh")]
        public string Hsh { get; set; }

        /// <summary>
        /// Drk
        /// </summary>
        [DataMember(Name = "drk")]
        public int Drk { get; set; }

        /// <summary>
        /// Top
        /// </summary>
        [DataMember(Name = "top")]
        public int Top { get; set; }

        /// <summary>
        /// Bot
        /// </summary>
        [DataMember(Name = "bot")]
        public int Bot { get; set; }

        /// <summary>
        /// Hs
        /// </summary>
        [DataMember(Name = "hs")]
        public List<string> Hs { get; set; }
    }
}

