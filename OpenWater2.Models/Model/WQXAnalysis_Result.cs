using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OpenWater2.Models.Model
{
    [Serializable()]
    public partial class WQXAnalysis_Result
    {
        #region Simple Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> MONLOC_IDX
        {
            get
            {
                return _MONLOC_IDX;
            }
            set
            {
                _MONLOC_IDX = value;
            }
        }
        private Nullable<global::System.Int32> _MONLOC_IDX;
        partial void OnMONLOC_IDXChanging(Nullable<global::System.Int32> value);
        partial void OnMONLOC_IDXChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String MONLOC_ID
        {
            get
            {
                return _MONLOC_ID;
            }
            set
            {
                _MONLOC_ID = value;
            }
        }
        private global::System.String _MONLOC_ID;
        partial void OnMONLOC_IDChanging(global::System.String value);
        partial void OnMONLOC_IDChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String CHAR_NAME
        {
            get
            {
                return _CHAR_NAME;
            }
            set
            {
                _CHAR_NAME = value;
            }
        }
        private global::System.String _CHAR_NAME;
        partial void OnCHAR_NAMEChanging(global::System.String value);
        partial void OnCHAR_NAMEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ACT_START_DT
        {
            get
            {
                return _ACT_START_DT;
            }
            set
            {
                _ACT_START_DT =value;
            }
        }
        private Nullable<global::System.DateTime> _ACT_START_DT;
        partial void OnACT_START_DTChanging(Nullable<global::System.DateTime> value);
        partial void OnACT_START_DTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> RESULT_MSR
        {
            get
            {
                return _RESULT_MSR;
            }
            set
            {
                _RESULT_MSR =value;
            }
        }
        private Nullable<global::System.Decimal> _RESULT_MSR;
        partial void OnRESULT_MSRChanging(Nullable<global::System.Decimal> value);
        partial void OnRESULT_MSRChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String RESULT_MSR_UNIT
        {
            get
            {
                return _RESULT_MSR_UNIT;
            }
            set
            {
                _RESULT_MSR_UNIT =value;
            }
        }
        private global::System.String _RESULT_MSR_UNIT;
        partial void OnRESULT_MSR_UNITChanging(global::System.String value);
        partial void OnRESULT_MSR_UNITChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String DETECTION_LIMIT
        {
            get
            {
                return _DETECTION_LIMIT;
            }
            set
            {
                _DETECTION_LIMIT =value;
            }
        }
        private global::System.String _DETECTION_LIMIT;
        partial void OnDETECTION_LIMITChanging(global::System.String value);
        partial void OnDETECTION_LIMITChanged();

        #endregion

    }
}
