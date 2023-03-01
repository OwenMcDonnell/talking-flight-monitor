using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class Notam
    {

        #region "private fields"
        private string _sourceID = string.Empty;
        private string _accountID = string.Empty;
        private string _ID = string.Empty;
        private string _locationID = string.Empty;
        private string _locationICAO = string.Empty;
        private string _locationName = string.Empty;
        private string _locationType = string.Empty;
        private DateTime? _dateCreated;
        private DateTime? _dateEffective;
        private DateTime? _dateExpire;
        private bool? _isExpireDateEstimated = false;
        private DateTime? _dateModified;
        private string _schedule = string.Empty;
        private string _HTML = string.Empty;
        private string _text = string.Empty;
        private string _raw = string.Empty;
        private string _nrc = string.Empty;
        private string _code = string.Empty;
        private string _category = string.Empty;
        private string _subject = string.Empty;
        private string _status = string.Empty;
        private bool? _isObstacle = false;
        #endregion

        #region "public properties"

        public string SourceID { get => _sourceID; set => _sourceID = value; }
        public string AccountID { get => _accountID; set => _accountID = value; }
        public string ID { get => _ID; set => _ID = value; }
        public string LocationID { get => _locationID; set => _locationID = value; }
        public string LocationICAO { get => _locationICAO; set => _locationICAO = value; }
        public string LocationName { get => _locationName; set => _locationName = value; }
        public string LocationType { get => _locationType; set => _locationType = value; }
                                public bool? IsExpireDateEstimated { get => _isExpireDateEstimated; set => _isExpireDateEstimated = value; }
                public string Schedule { get => _schedule; set => _schedule = value; }
        public string HTML { get => _HTML; set => _HTML = value; }
        public string Text { get => _text; set => _text = value; }
        public string Raw { get => _raw; set => _raw = value; }
        public string Nrc { get => _nrc; set => _nrc = value; }
        public string Code { get => _code; set => _code = value; }
        public string Category { get => _category; set => _category = value; }
        public string Subject { get => _subject; set => _subject = value; }
        public string Status { get => _status; set => _status = value; }
        public bool? IsObstacle { get => _isObstacle; set => _isObstacle = value; }
        public DateTime? DateCreated { get => _dateCreated; set => _dateCreated = value; }
        public DateTime? DateEffective { get => _dateEffective; set => _dateEffective = value; }
        public DateTime? DateExpire { get => _dateExpire; set => _dateExpire = value; }
        public DateTime? DateModified { get => _dateModified; set => _dateModified = value; }
        #endregion
    }
}
