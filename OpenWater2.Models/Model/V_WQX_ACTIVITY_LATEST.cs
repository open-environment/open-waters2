using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OpenWater2.Models.Model
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class V_WQX_ACTIVITY_LATEST 
    {
        #region Factory Method

        /// <summary>
        /// Create a new V_WQX_ACTIVITY_LATEST object.
        /// </summary>
        /// <param name="aCTIVITY_IDX">Initial value of the ACTIVITY_IDX property.</param>
        /// <param name="oRG_ID">Initial value of the ORG_ID property.</param>
        /// <param name="pROJECT_IDX">Initial value of the PROJECT_IDX property.</param>
        /// <param name="mONLOC_NAME">Initial value of the MONLOC_NAME property.</param>
        /// <param name="aCTIVITY_ID">Initial value of the ACTIVITY_ID property.</param>
        /// <param name="aCT_TYPE">Initial value of the ACT_TYPE property.</param>
        /// <param name="aCT_START_DT">Initial value of the ACT_START_DT property.</param>
        public static V_WQX_ACTIVITY_LATEST CreateV_WQX_ACTIVITY_LATEST(global::System.Int32 aCTIVITY_IDX, global::System.String oRG_ID, global::System.Int32 pROJECT_IDX, global::System.String mONLOC_NAME, global::System.String aCTIVITY_ID, global::System.String aCT_TYPE, global::System.DateTime aCT_START_DT)
        {
            V_WQX_ACTIVITY_LATEST v_WQX_ACTIVITY_LATEST = new V_WQX_ACTIVITY_LATEST();
            v_WQX_ACTIVITY_LATEST.ACTIVITY_IDX = aCTIVITY_IDX;
            v_WQX_ACTIVITY_LATEST.ORG_ID = oRG_ID;
            v_WQX_ACTIVITY_LATEST.PROJECT_IDX = pROJECT_IDX;
            v_WQX_ACTIVITY_LATEST.MONLOC_NAME = mONLOC_NAME;
            v_WQX_ACTIVITY_LATEST.ACTIVITY_ID = aCTIVITY_ID;
            v_WQX_ACTIVITY_LATEST.ACT_TYPE = aCT_TYPE;
            v_WQX_ACTIVITY_LATEST.ACT_START_DT = aCT_START_DT;
            return v_WQX_ACTIVITY_LATEST;
        }

        #endregion

        #region Simple Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.Int32 ACTIVITY_IDX
        {
            get
            {
                return _ACTIVITY_IDX;
            }
            set
            {
                if (_ACTIVITY_IDX != value)
                {
                    _ACTIVITY_IDX = value;
                }
            }
        }
        private global::System.Int32 _ACTIVITY_IDX;
        partial void OnACTIVITY_IDXChanging(global::System.Int32 value);
        partial void OnACTIVITY_IDXChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String ORG_ID
        {
            get
            {
                return _ORG_ID;
            }
            set
            {
                if (_ORG_ID != value)
                {
                    _ORG_ID = value;
                }
            }
        }
        private global::System.String _ORG_ID;
        partial void OnORG_IDChanging(global::System.String value);
        partial void OnORG_IDChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.Int32 PROJECT_IDX
        {
            get
            {
                return _PROJECT_IDX;
            }
            set
            {
                if (_PROJECT_IDX != value)
                {
                    _PROJECT_IDX = value;
                }
            }
        }
        private global::System.Int32 _PROJECT_IDX;
        partial void OnPROJECT_IDXChanging(global::System.Int32 value);
        partial void OnPROJECT_IDXChanged();

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
        public global::System.String MONLOC_NAME
        {
            get
            {
                return _MONLOC_NAME;
            }
            set
            {
                if (_MONLOC_NAME != value)
                {
                    _MONLOC_NAME = value;
                }
            }
        }
        private global::System.String _MONLOC_NAME;
        partial void OnMONLOC_NAMEChanging(global::System.String value);
        partial void OnMONLOC_NAMEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String ACTIVITY_ID
        {
            get
            {
                return _ACTIVITY_ID;
            }
            set
            {
                if (_ACTIVITY_ID != value)
                {
                    _ACTIVITY_ID = value;
                }
            }
        }
        private global::System.String _ACTIVITY_ID;
        partial void OnACTIVITY_IDChanging(global::System.String value);
        partial void OnACTIVITY_IDChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String ACT_TYPE
        {
            get
            {
                return _ACT_TYPE;
            }
            set
            {
                if (_ACT_TYPE != value)
                {
                    _ACT_TYPE = value;
                }
            }
        }
        private global::System.String _ACT_TYPE;
        partial void OnACT_TYPEChanging(global::System.String value);
        partial void OnACT_TYPEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.DateTime ACT_START_DT
        {
            get
            {
                return _ACT_START_DT;
            }
            set
            {
                if (_ACT_START_DT != value)
                {
                    _ACT_START_DT = value;
                }
            }
        }
        private global::System.DateTime _ACT_START_DT;
        partial void OnACT_START_DTChanging(global::System.DateTime value);
        partial void OnACT_START_DTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> WQX_IND
        {
            get
            {
                return _WQX_IND;
            }
            set
            {
                _WQX_IND = value;
            }
        }
        private Nullable<global::System.Boolean> _WQX_IND;
        partial void OnWQX_INDChanging(Nullable<global::System.Boolean> value);
        partial void OnWQX_INDChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> CREATE_DT
        {
            get
            {
                return _CREATE_DT;
            }
            set
            {
                _CREATE_DT = value;
            }
        }
        private Nullable<global::System.DateTime> _CREATE_DT;
        partial void OnCREATE_DTChanging(Nullable<global::System.DateTime> value);
        partial void OnCREATE_DTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String CREATE_USERID
        {
            get
            {
                return _CREATE_USERID;
            }
            set
            {
                _CREATE_USERID = value;
            }
        }
        private global::System.String _CREATE_USERID;
        partial void OnCREATE_USERIDChanging(global::System.String value);
        partial void OnCREATE_USERIDChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String ACT_COMMENT
        {
            get
            {
                return _ACT_COMMENT;
            }
            set
            {
                _ACT_COMMENT = value;
            }
        }
        private global::System.String _ACT_COMMENT;
        partial void OnACT_COMMENTChanging(global::System.String value);
        partial void OnACT_COMMENTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Alkalinity__total
        {
            get
            {
                return _Alkalinity__total;
            }
            set
            {
                _Alkalinity__total = value;
            }
        }
        private global::System.String _Alkalinity__total;
        partial void OnAlkalinity__totalChanging(global::System.String value);
        partial void OnAlkalinity__totalChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Ammonia
        {
            get
            {
                return _Ammonia;
            }
            set
            {
                _Ammonia = value;
            }
        }
        private global::System.String _Ammonia;
        partial void OnAmmoniaChanging(global::System.String value);
        partial void OnAmmoniaChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Dissolved_oxygen__DO_
        {
            get
            {
                return _Dissolved_oxygen__DO_;
            }
            set
            {
                _Dissolved_oxygen__DO_ = value;
            }
        }
        private global::System.String _Dissolved_oxygen__DO_;
        partial void OnDissolved_oxygen__DO_Changing(global::System.String value);
        partial void OnDissolved_oxygen__DO_Changed();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Escherichia_coli
        {
            get
            {
                return _Escherichia_coli;
            }
            set
            {
                _Escherichia_coli = value;
            }
        }
        private global::System.String _Escherichia_coli;
        partial void OnEscherichia_coliChanging(global::System.String value);
        partial void OnEscherichia_coliChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Nitrate
        {
            get
            {
                return _Nitrate;
            }
            set
            {
                _Nitrate = value;
            }
        }
        private global::System.String _Nitrate;
        partial void OnNitrateChanging(global::System.String value);
        partial void OnNitrateChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Nitrite
        {
            get
            {
                return _Nitrite;
            }
            set
            {
                _Nitrite = value;
            }
        }
        private global::System.String _Nitrite;
        partial void OnNitriteChanging(global::System.String value);
        partial void OnNitriteChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String pH
        {
            get
            {
                return _pH;
            }
            set
            {
                _pH = value;
            }
        }
        private global::System.String _pH;
        partial void OnpHChanging(global::System.String value);
        partial void OnpHChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Phosphorus
        {
            get
            {
                return _Phosphorus;
            }
            set
            {
                _Phosphorus = value;
            }
        }
        private global::System.String _Phosphorus;
        partial void OnPhosphorusChanging(global::System.String value);
        partial void OnPhosphorusChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Salinity
        {
            get
            {
                return _Salinity;
            }
            set
            {
                _Salinity = value;
            }
        }
        private global::System.String _Salinity;
        partial void OnSalinityChanging(global::System.String value);
        partial void OnSalinityChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Specific_Conductance
        {
            get
            {
                return _Specific_Conductance;
            }
            set
            {
                _Specific_Conductance = value;
            }
        }
        private global::System.String _Specific_Conductance;
        partial void OnSpecific_ConductanceChanging(global::System.String value);
        partial void OnSpecific_ConductanceChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Temperature__air
        {
            get
            {
                return _Temperature__air;
            }
            set
            {
                _Temperature__air = value;
            }
        }
        private global::System.String _Temperature__air;
        partial void OnTemperature__airChanging(global::System.String value);
        partial void OnTemperature__airChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Temperature__water
        {
            get
            {
                return _Temperature__water;
            }
            set
            {
                _Temperature__water = value;
            }
        }
        private global::System.String _Temperature__water;
        partial void OnTemperature__waterChanging(global::System.String value);
        partial void OnTemperature__waterChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Total_Dissolved_Solids
        {
            get
            {
                return _Total_Dissolved_Solids;
            }
            set
            {
                _Total_Dissolved_Solids = value;
            }
        }
        private global::System.String _Total_Dissolved_Solids;
        partial void OnTotal_Dissolved_SolidsChanging(global::System.String value);
        partial void OnTotal_Dissolved_SolidsChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [DataMemberAttribute()]
        public global::System.String Turbidity
        {
            get
            {
                return _Turbidity;
            }
            set
            {
                _Turbidity = value;
            }
        }
        private global::System.String _Turbidity;
        partial void OnTurbidityChanging(global::System.String value);
        partial void OnTurbidityChanged();

        #endregion

    }
}
